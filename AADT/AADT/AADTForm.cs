using System;
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
            path = pathTextBox.Text;
            Application.OpenForms["AADTForm"].Close();
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

    }
}



