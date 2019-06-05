using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Pipes
{
    public partial class Form1 : Form
    {
        private int intHeartBeat = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Timers.Timer timHeartBeat = new System.Timers.Timer()
            {
                Enabled = true
                ,
                Interval = 1000
            };
            timHeartBeat.Elapsed += new ElapsedEventHandler(processHeartBeat);

        }
        private void processHeartBeat(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                intHeartBeat++;
                Console.WriteLine("Processing beat # : " + intHeartBeat.ToString());

            }
            catch
            {
                Console.WriteLine("Error processing beat # : " + intHeartBeat.ToString());
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            intHeartBeat = intHeartBeat + 100;
        }
    }
}
