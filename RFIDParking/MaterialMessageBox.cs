using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFIDParking
{
    public static class MaterialMessageBox
    {
        public static DialogResult Show(string message, string caption, MessageBoxButtons button)
        {
            DialogResult result = DialogResult.None;
            switch (button)
            {
                case MessageBoxButtons.YesNo:
                    using (YesNoMessageBox YesNo = new YesNoMessageBox())
                    {
                        YesNo.Text = caption;
                        YesNo.Message = message;
                        result = YesNo.ShowDialog();

                    }
                    break;
                case MessageBoxButtons.OK:
                    using (OKMessageBox Ok = new OKMessageBox())
                    {
                        Ok.Text = caption;
                        Ok.Message = message;
                        result = Ok.ShowDialog();

                    }
                    break;
            }
            return result;

        }
    }
}
