using System;
using System.Threading;
using System.Windows.Forms;

namespace AADT
{
    public partial class AADTForm : Form
    {
        public AADTForm()
        {
            InitializeComponent();
            //name = this.nameLabel.Text;
            dataSelected = this.roadWayComboBox.Items.ToString();
        }
        public string name
        {
            get;
            set;
        }
        public static string path
        {
            get;
            set;
        }

        public string dataSelected
        {
            get;
            set;
        }

        private void predictButton_Click(object sender, EventArgs e)
        {
            progressBar1.Show();
            path = pathTextBox.Text;
            minionBackgroundWorker.WorkerReportsProgress = true;
            minionBackgroundWorker.RunWorkerAsync();
            //Application.Exit();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                pathTextBox.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void roadWayComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataSelected = roadWayComboBox.SelectedItem.ToString();
        }

        private void minionBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(100);  
                minionBackgroundWorker.ReportProgress(i);
            }
        }

        private void minionBackgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            this.Text = "Progress: " + e.ProgressPercentage.ToString() + "%";
        }

        private void minionBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Application.OpenForms["AADTForm"].Close();
        }

        private void AADTForm_Load(object sender, EventArgs e)
        {
            progressBar1.Hide();
        }
    }
}



