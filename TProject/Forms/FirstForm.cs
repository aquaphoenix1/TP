using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TProject.Forms
{
    public enum Act { Add, Load, Delete };

    public partial class FirstForm : Form
    {
        public FirstForm()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, System.EventArgs e)
        {
            Main form = new Main();
            if (form.Open(Act.Load) == DialogResult.OK)
            {
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
        }

        private void CreateNewButton_Click(object sender, System.EventArgs e)
        {
            Image backPicture;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    backPicture = Image.FromStream(fs);
                }

                ConductingForm saForm = new ConductingForm(backPicture, Act.Add);
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

        private void RemoveButton_Click(object sender, System.EventArgs e)
        {
            new ConductingForm(Act.Delete).ShowDialog();
        }
    }
}
