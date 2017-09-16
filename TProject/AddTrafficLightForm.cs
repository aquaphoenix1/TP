using System;
using System.Windows.Forms;

namespace TProject
{
    public partial class AddTrafficLightForm : Form
    {
        public AddTrafficLightForm()
        {
            InitializeComponent();

            this.greenSeconds = 10;
            this.redSeconds = 30;

            textBoxGreenSeconds.Text = greenSeconds.ToString();
            textBoxRedSeconds.Text = redSeconds.ToString();
        }

        public AddTrafficLightForm(int greenSec, int redSec)
        {
            InitializeComponent();

            this.greenSeconds = greenSec;
            this.redSeconds = redSec;

            textBoxGreenSeconds.Text = greenSeconds.ToString();
            textBoxRedSeconds.Text = redSeconds.ToString();
        }

        private int redSeconds;
        private int greenSeconds;

        public int GetRedSeconds()
        {
            return redSeconds;
        }

        public int GetGreenSeconds()
        {
            return greenSeconds;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            try
            {
                redSeconds = Int16.Parse(textBoxRedSeconds.Text);
                greenSeconds = Int16.Parse(textBoxGreenSeconds.Text);

                if (redSeconds > 100) throw new TooManySecondsException("красного");
                if (greenSeconds > 30) throw new TooManySecondsException("зеленого");

                if (redSeconds < 30) throw new TooLowSecondsException("красного");
                if (greenSeconds < 10) throw new TooLowSecondsException("зеленого");

                this.AcceptButton.DialogResult = DialogResult.OK;
                buttonCancel_Click(sender, e);
            }
            catch (TooManySecondsException ex) { MessageBox.Show(ex.Message); }
            catch (TooLowSecondsException ex) { MessageBox.Show(ex.Message); }
            catch { MessageBox.Show("Неверные параметры"); }
        }
    }
}
