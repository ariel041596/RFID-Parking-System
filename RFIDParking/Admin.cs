using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using MySql.Data.MySqlClient;


namespace RFIDParking
{
    public partial class Admin : Form
    {
        MySqlConnection connection = new MySqlConnection(@"Data Source=localhost; port=3306; Initial Catalog=dbparking; User Id=root; password=''");

        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MaterialMessageBox.Show("Are you sure want to exit? ", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnAuditTrail_Click(object sender, EventArgs e)
        {
            listViewAudit.BringToFront();
            panelAudit.BringToFront();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            listViewReport.BringToFront();
            PanelReport.BringToFront();

            listViewReport.Items.Clear();
            MySqlCommand command = new MySqlCommand("SELECT * FROM reportwithpayment", connection);

            try
            {
                
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["idNum"].ToString());
                    item.SubItems.Add(dr["RFIDnumber"].ToString());
                    item.SubItems.Add(dr["driver_name"].ToString());
                    item.SubItems.Add(dr["plate_number"].ToString());
                    item.SubItems.Add(dr["time_in"].ToString());
                    item.SubItems.Add(dr["time_out"].ToString());
                    item.SubItems.Add(dr["payment"].ToString());
                    item.SubItems.Add(dr["duration"].ToString());
                    item.SubItems.Add(dr["vehicle_type"].ToString());
                    listViewReport.Items.Add(item);
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            btnSignout.Text = "       Login as " + Login.recby + "\n      RFID-Administrator";

            signOutExit1.Hide();

            


            listViewAudit.Items.Clear();
            MySqlCommand command = new MySqlCommand("SELECT * FROM log", connection);

            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["id"].ToString());
                    item.SubItems.Add(dr["username"].ToString());
                    item.SubItems.Add(dr["Message"].ToString());
                    item.SubItems.Add(dr["Date"].ToString());
                    listViewAudit.Items.Add(item);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void materialListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialListView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void btnSignout_Click(object sender, EventArgs e)
        {
            signOutExit1.BringToFront();
            signOutExit1.Visible = true;
        }
    }
}
