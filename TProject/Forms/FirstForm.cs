using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TProject.Forms
{
    public partial class FirstForm : Form
    {
        public FirstForm()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, System.EventArgs e)
        {
            Main form = new Main();
            if (form.Open() == DialogResult.OK)
            {
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
        }

        private void createNewButton_Click(object sender, System.EventArgs e)
        {
            Image backPicture;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open))
                {
                    backPicture = Image.FromStream(fs);
                }

                SaveAs saForm = new SaveAs(backPicture);
                saForm.ShowDialog();
                if (saForm.DialogResult == DialogResult.OK)
                {
                    Main form = new Main();
                    form.Init(backPicture);
                    this.Hide();
                    form.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}
