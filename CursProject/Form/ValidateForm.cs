using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CursProject.Form
{
    public class ValidateForm : System.Windows.Forms.Form
    {
        public bool ValidateControl(Control control, bool isNumberic)
        {
            return isNumberic ? ValidateNumbericControl(control) : ValidateStringControl(control);
        }

        public bool ValidateStringControl(Control control)
        {
            string text = control.Text;
            control.BackColor = IsValidString(text) ? Color.White : Color.Salmon;
            return IsValidString(text);
        }

        public bool ValidateNumbericControl(Control control)
        {
            string strNumber = control.Text;
            control.BackColor = IsValidNumber(strNumber) ? Color.White : Color.Salmon;
            return IsValidNumber(strNumber);
        }

        public bool ValidateComboBox(ComboBox comboBox)
        {
            comboBox.BackColor = IsValidComboBox(comboBox) ? Color.White : Color.Salmon;
            return IsValidComboBox(comboBox);
        }

        private bool IsValidString(string text)
        {
            return text.Trim().Length != 0;
        }

        private bool IsValidNumber(string strNumber)
        {
            int number = 0;
            return IsValidString(strNumber) && Int32.TryParse(strNumber, out number);
        }

        private bool IsValidComboBox(ComboBox comboBox)
        {
            return comboBox.SelectedIndex != -1;
        }

        private void InitializeComponent()
        {
            var resources = new ComponentResourceManager(typeof (ValidateForm));
            SuspendLayout();
            // 
            // ValidateForm
            // 
            ClientSize = new Size(292, 273);
            Icon = ((Icon) (resources.GetObject("$this.Icon")));
            Name = "ValidateForm";
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
        }
    }
}