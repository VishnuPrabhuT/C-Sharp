﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Runtime.InteropServices;
using System.Collections;
using System.IO;
using System.Security.Permissions;

namespace FileWatcherLogger
{
    public partial class FileEventsLogger : ServiceBase
    {
        private int eventId = 1;
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public FileEventsLogger()
        {
            InitializeComponent();

            Timer timer = new Timer();
            timer.Interval = 1000 * 60 * 2;
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        private void ResetFileWatcher()
        {
            watcher = new FileSystemWatcher();
            do
            {
                try
                {
                    watcher.EnableRaisingEvents = false;
                    eventLogger.WriteEntry($"Before SetUpFileWatcher! InternalBufferSize - {watcher.InternalBufferSize} EnableRaisingEvents - {watcher.EnableRaisingEvents} Path - {watcher.Path}", EventLogEntryType.Warning, eventId++);
                    SetUpFileWatcher();
                    eventLogger.WriteEntry($"After SetUpFileWatcher Back Online!!! InternalBufferSize - {watcher.InternalBufferSize} EnableRaisingEvents - {watcher.EnableRaisingEvents} Path-{watcher.Path}", EventLogEntryType.Information, eventId++);
                }
                catch (Exception e)
                {
                    eventLogger.WriteEntry($"In ResetFileWatcher Catch | Message - {e.Message} StackTrace - {e.StackTrace} {watcher.EnableRaisingEvents} {watcher.Path}", EventLogEntryType.Error, eventId++);
                    // Sleep for a bit; otherwise, it takes a bit of processor time
                    System.Threading.Thread.Sleep(5000);
                    watcher.EnableRaisingEvents = false;
                }
            }
            while (!watcher.EnableRaisingEvents);
        }

        private void SetUpFileWatcher()
        {
            watcher.Path = File.ReadAllText(@"C:\Release\Path.txt");
            watcher.InternalBufferSize = 4 * 4096;
            watcher.NotifyFilter = NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.FileName
                                 | NotifyFilters.DirectoryName;
            watcher.Filter = "*";
            watcher.Changed += this.OnChanged;
            watcher.Created += this.OnCreated;
            watcher.Deleted += this.OnDeleted;
            watcher.Renamed += this.OnRenamed;
            watcher.Error += new ErrorEventHandler(this.OnWatcherError);
            watcher.EnableRaisingEvents = true;
        }

        // Define the event handlers.
        private void OnDeleted(object source, FileSystemEventArgs e) =>
             eventLogger.WriteEntry($"{e.FullPath} | {e.ChangeType}", EventLogEntryType.SuccessAudit, eventId++);
        private void OnCreated(object source, FileSystemEventArgs e) =>
             eventLogger.WriteEntry($"{e.FullPath} | {e.ChangeType}", EventLogEntryType.SuccessAudit, eventId++);
        private void OnChanged(object source, FileSystemEventArgs e) =>
             eventLogger.WriteEntry($"{e.FullPath} | {e.ChangeType}", EventLogEntryType.SuccessAudit, eventId++);
        private void OnRenamed(object source, RenamedEventArgs e) =>
            eventLogger.WriteEntry($"{e.OldFullPath} renamed to {e.FullPath}", EventLogEntryType.SuccessAudit, eventId++);

        protected override void OnStart(string[] args)
        {
            try
            {
                System.Diagnostics.EventLog.DeleteEventSource("FileWatcherLogger");
                if (!EventLog.SourceExists("FileWatcherLogger"))
                {
                    EventLog.CreateEventSource(
                        "FileWatcherLogger", "FileWatcherLog");
                }

                eventLogger.Source = "FileWatcherLogger";
                eventLogger.Log = "FileWatcherLog";
                eventLogger.WriteEntry("In OnStart " + String.Join("-", args));
                ResetFileWatcher();
            }
            catch(Exception e)
            {
                eventLogger.WriteEntry($"Error {e.Message} {e.StackTrace} {@File.ReadAllText(@"C:\Release\Path.txt")}");
            }
        }

        protected override void OnPause()
        {
            eventLogger.WriteEntry("In OnPause");
        }

        protected override void OnContinue()
        {
            eventLogger.WriteEntry("In OnContinue");
        }

        protected override void OnStop()
        {
            eventLogger.WriteEntry("In OnStop");
        }

        protected override void OnShutdown()
        {
            eventLogger.WriteEntry("In OnShutdown");
        }

        protected override bool OnPowerEvent(PowerBroadcastStatus powerStatus)
        {
            eventLogger.WriteEntry($"In OnPowerEvent {powerStatus.GetType()}");
            if (PowerBroadcastStatus.QuerySuspend == powerStatus)
            {
                return false;
            }
            return true;
        }

        protected override void OnCustomCommand(int command)
        {
            eventLogger.WriteEntry("In OnCustomCommand - Commad passed from Service Control Manager (SCM)" + command.ToString());
        }

        public void OnWatcherError(object sender, ErrorEventArgs e)
        {
            Exception watchException = e.GetException();
            eventLogger.WriteEntry($"Message - {watchException.Message} StackTrace - {watchException.StackTrace}", EventLogEntryType.Error, eventId++);

            ResetFileWatcher();
        }

        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            eventLogger.WriteEntry($"InternalBufferSize - {watcher.InternalBufferSize} EnableRaisingEvents - {watcher.EnableRaisingEvents} Path - {watcher.Path}", EventLogEntryType.Information, eventId++);
            if (!watcher.EnableRaisingEvents)
            {
                watcher.EnableRaisingEvents = true;
                eventLogger.WriteEntry($"Turning EnableRaisingEvents - {watcher.EnableRaisingEvents}", EventLogEntryType.Warning, eventId++);
            }
        }
    }
}
