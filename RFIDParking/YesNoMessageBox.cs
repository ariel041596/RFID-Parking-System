using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;

namespace RFIDParking
{
    public partial class YesNoMessageBox : MaterialSkin.Controls.MaterialForm
    {
        MaterialSkin.MaterialSkinManager skinManager;
        public YesNoMessageBox()
        {
            skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.Grey800, Primary.Grey800, Primary.Grey100, Accent.LightBlue400, TextShade.WHITE);
            InitializeComponent();
        }

        public string Message
        {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value; }
        }

        private void lollipopLabel1_Click(object sender, EventArgs e)
        {

        }

        private void YesNoMessageBox_Load(object sender, EventArgs e)
        {

        }

        private void btnYes_Click(object sender, EventArgs e)
        {

        }
    }
}
