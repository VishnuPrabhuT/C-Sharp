using System;
using System.Windows.Forms;

namespace AADT
{
    public partial class AADTForm : Form
    {
        public AADTForm()
        {
            InitializeComponent();
            name = this.nameLabel.Text;
            dataSelected = Convert.ToInt32(this.dataSelectUpDown.Value);
        }
        public string name
        {
            get;
            set;
        }
        public string path
        {
            get;
            set;
        }

        public int dataSelected
        {
            get;
            set;
        }

        private void predictButton_Click(object sender, EventArgs e)
        {
            path = pathTextBox.Text;
            Application.Exit();
        }

    }
}



