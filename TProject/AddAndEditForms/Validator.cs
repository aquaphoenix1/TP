using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TProject.AddAndEditForms
{
    static class Validator
    {
        public static void NumericUpDown_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumericUpDown nUD = ((NumericUpDown)sender);
            string tmp = nUD.Value.ToString().Trim();
            string outS = string.Empty;
            bool zapyataya = true;

            foreach (char ch in tmp)
            {
                if (Char.IsDigit(ch) || (ch == ',' && zapyataya))
                {
                    outS += ch;
                    if (ch == ',')
                    {
                        zapyataya = false;
                    }
                }
            }

            decimal.TryParse(outS, out decimal value);
            nUD.Value = value;
        }
    }
}
