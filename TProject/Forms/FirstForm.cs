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
            form.Open();
            this.Hide();
            form.ShowDialog();
            this.Close();
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
                Main form = new Main();
                if (form.SaveAs() != null)
                {
                    form.Init(backPicture);
                    this.Hide();
                    form.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}
