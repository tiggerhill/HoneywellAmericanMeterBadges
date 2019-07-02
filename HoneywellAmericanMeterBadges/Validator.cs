using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoneywellAmericanMeterBadges
{
    public static class Validator  // Provides static methods for validating data
    {
        // The title that will appear in dialog boxes
        private static string title = "Entry Error";

        public static string Title
        {
            get { return title; }
            set { title = value; }
        }

        public static bool IsPresent(Control control)
        {
            if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                TextBox textBox = (TextBox)control;
                if (textBox.Text == "")
                {
                    MessageBox.Show(textBox.Tag + " is a required field.", Title);
                    textBox.Focus();
                    return false;
                }
            }
            else if (control.GetType().ToString() == "System.Windows.Forms.ListBox")
            {
                ListBox listBox = (ListBox)control;
                if (listBox.SelectedIndex == -1)
                {
                    MessageBox.Show(listBox.Tag + " is a required field.", Title);
                    listBox.Focus();
                    return false;
                }
            }
            else if (control.GetType().ToString() == "System.Windows.Forms.ComboBox")
            {
                ComboBox comboBox = (ComboBox)control;
                if (comboBox.SelectedIndex < 0 )
                {
                    MessageBox.Show(comboBox.Tag + " is a required field.", Title);
                    comboBox.Focus();
                    return false;
                }
            }
            return true;
        }

        public static bool IsInt32(TextBox textBox)
        {
            try
            {
                Convert.ToInt32(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag + " must be an integer.", Title);
                textBox.Focus();
                return false;
            }
        }

        public static bool HasYear(Control control)
        {
            TextBox textBox = (TextBox)control;
            if (textBox.Text == "")
            {
                MessageBox.Show(textBox.Tag + " is required on all manufacturing badges.");
                textBox.Focus();
                return false;
            }
            return true;
        }

        public static bool VerifyCount(TextBox beginningText, TextBox endingText, TextBox countText)
        {
            var beginning = Convert.ToInt32(beginningText.Text);
            var ending = Convert.ToInt32(endingText.Text);            
            var count = Convert.ToInt32(countText.Text);

            if ((ending - (beginning - 1) != count))
            {
                MessageBox.Show((ending - (beginning - 1)) + " - Please verify the count.");
                return false;
            }
            return true;
        }

        //TODO public static bool ComboBox??
    }
}
