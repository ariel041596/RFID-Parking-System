using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RFIDParking
{
    public partial class PaymentForm : Form
    {
        MySqlConnection conn;
        string conn_string;
        public MySqlConnection connect;
        
       

        public PaymentForm()
        {
            InitializeComponent();
            


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            User us = new User();
            us.Show();
            us.Enabled = true;
        }

        void deletedata()
        {
            string deleteQuery = "DELETE FROM report WHERE RFIDNumber='" + User.recby + "'";
            MySqlCommand cmds = new MySqlCommand(deleteQuery, conn);
            conn.Open();
            cmds.ExecuteNonQuery();
            conn.Close();
        }
        void insertTimeout()
        {
            string insertQuery = "UPDATE reportwithpayment SET time_out='" + User.recby2 + "' WHERE RFIDNumber='" + User.recby + "'";
            MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
            conn.Open();
            cmd.Parameters.Add(new MySqlParameter("@time_out", User.recby2));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        
        void InsertData()
        {
            DateTime timein = Convert.ToDateTime(User.recby2);
            DateTime timeout = Convert.ToDateTime(User.recby3);
            TimeSpan ts = timein.Subtract(timeout);

            string insertQuery = "UPDATE reportwithpayment SET payment='"+txtPayment.Text+"',vehicle_type='"+comboType.Text+"',duration='"+ts+"' WHERE RFIDnumber='"+User.recby+"'";
            MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
            try
            {
                conn.Open();
                cmd.Parameters.Add(new MySqlParameter("@payment", txtPayment.Text));
                cmd.Parameters.Add(new MySqlParameter("@vehicle_type", comboType.Text));

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ej)
            {
                MessageBox.Show(ej.Message);
            }
        }
        void setupDB()
        {
            string pass = "";
            conn_string = "SERVER=localhost; PORT=3306; DATABASE=dbparking;UID=root;PASSWORD=" + pass + "";
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = conn_string;
                conn.Open();
                conn.Close();

            }
            catch (Exception ed)
            {
                MessageBox.Show(ed.Message + "Please contact your system administrator.");
                this.Close();
            }
        }
        
        private void btnPaid_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtAmount.Text) < Convert.ToInt32(txtPayment.Text))
                {
                    if (MaterialMessageBox.Show("Insufficient Payment!", "Insufficient", MessageBoxButtons.OK) == DialogResult.OK)
                    {

                    }
                }
                else if (txtAmount.Text == "")
                {
                    if (MaterialMessageBox.Show("Please enter amount.", "Enter amount", MessageBoxButtons.OK) == DialogResult.OK)
                    {

                    }
                }
                else
                {
                    if (MaterialMessageBox.Show("Payment Successfull.", "Success", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        
                        setupDB();
                        InsertData();

                        deletedata();
                        insertTimeout();

                        this.Dispose();
                        User us = new User();
                        us.Show();
                        us.Enabled = true;

                       

                    }
                }
            }
            catch(Exception eb)
            {
                MessageBox.Show(eb.Message);
            }
           
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            
            
        }

        private void comboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboType.Text == "Motorcycle")
            {
                txtPayment.Text = "30";
            }
            else if(comboType.Text=="Private Vehicle")
            {
                txtPayment.Text = "50";
            }
            else
            {
                txtPayment.Text = "Please select type";
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPayment.Text) && !string.IsNullOrEmpty(txtAmount.Text))
            {
                txtChange.Text = (Convert.ToInt32(txtAmount.Text) - Convert.ToInt32(txtPayment.Text)).ToString();
            }
            else
            {
                txtChange.Text = "";
            }
        }
    }
}
