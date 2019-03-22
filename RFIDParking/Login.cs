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
using System.Net;
using MaterialSkin;


namespace RFIDParking
{
    public partial class Login : MaterialSkin.Controls.MaterialForm
    {
       MaterialSkinManager skinManager;

        public static string CIP = "";//From Main.Cs
        private void getIP()//From Main.Cs
        {
            skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.Grey900, Primary.Grey900, Primary.Blue800, Accent.LightBlue700, TextShade.WHITE);
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    CIP = ip.ToString();

                }
            }
        }


        private void Login_Load(object sender, EventArgs e)
        {
            getIP();
            lblSecondUsername.Visible = false;
            lblSecondPassword.Visible = false;

        }

        MySqlConnection con = new MySqlConnection(@"Data Source=localhost; port=3306; Initial Catalog=dbparking; User Id=root; password=''");
        int i;
        string utype;
        string date = DateTime.Now.ToString();
        

        
        public Login()
        {
            InitializeComponent();
        }

        public static string username;
        public static string recby
        {
            get { return username; }
            set { username = value; }
        }

        private void btnSignIn_Click_1(object sender, EventArgs e)
        {
             i = 0;
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tbl_user where username='" + txtUsername.Text + "' and password='" + txtPassword.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            con.Close();

            try
            {

                if (i == 0)
                {
                    MessageBox.Show("Invalid Credentials");
                    con.Close();
                }
                else
                {

                    utype = dt.Rows[0][4].ToString().Trim();

                    if (utype == "1")
                    {

                        recby = txtUsername.Text;
                        this.Hide();
                        Admin ad = new Admin();
                        ad.Show();


                    }
                    else
                    {
                        string action = "Login";
                        string insertQuery = "INSERT INTO log(username,Message,Date)VALUES('" + txtUsername.Text + "','" + action + "','" + date + "')";
                        con.Open();
                        MySqlCommand command = new MySqlCommand(insertQuery, con);
                        command.ExecuteNonQuery();

                        recby = txtUsername.Text;
                        this.Hide();
                        User us = new User();
                        us.Show();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            i = 0;
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tbl_user where username='" + txtUsername.Text + "' and password='" + txtPassword.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            con.Close();

            try
            {

                if (i == 0)
                {
                    MessageBox.Show("Invalid Credentials");
                    con.Close();
                }
                else
                {

                    utype = dt.Rows[0][4].ToString().Trim();

                    if (utype == "1")
                    {

                        recby = txtUsername.Text;
                        this.Hide();
                        Admin ad = new Admin();
                        ad.Show();


                    }
                    else
                    {
                        string action = "Login";
                        string insertQuery = "INSERT INTO log(username,Date,Message)VALUES('" + txtUsername.Text + "','" + date + "','" + action + "')";
                        con.Open();
                        MySqlCommand command = new MySqlCommand(insertQuery, con);
                        command.ExecuteNonQuery();

                        recby = txtUsername.Text;
                        this.Hide();
                        User us = new User();
                        us.Show();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            lblfirstusername.Visible = false;
            lblSecondUsername.Visible = true;
            lblSecondUsername.ForeColor = Color.FromArgb(74, 138, 244);

        }


        private void txtUsername_Leave(object sender, EventArgs e)
        {
            lblfirstusername.Visible = true;
            lblSecondUsername.Visible = false;
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            lblFirstPassword.Visible = false;
            lblSecondPassword.Visible = true;
            lblSecondPassword.ForeColor = Color.FromArgb(74, 138, 224);

        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            lblFirstPassword.Visible = true;
            lblSecondPassword.Visible = false;
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            lblFirstPassword.Visible = false;
            lblSecondPassword.Visible = true;
            lblSecondPassword.ForeColor = Color.FromArgb(74, 138, 224);
        }

        private void txtUsername_KeyUp(object sender, KeyEventArgs e)
        {
            lblfirstusername.Visible = false;
            lblSecondUsername.Visible = true;
            lblSecondUsername.ForeColor = Color.FromArgb(74, 138, 244);
        }

        

        

        

    }
}
