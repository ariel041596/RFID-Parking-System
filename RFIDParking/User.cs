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
using System.IO.Ports;
using System.IO.MemoryMappedFiles;
using System.Drawing.Imaging;
using System.IO;


namespace RFIDParking
{
    public partial class User : Form
    {
        MySqlConnection connection = new MySqlConnection(@"Data Source=localhost; port=3306; Initial Catalog=dbparking; User Id=root; password=''");
        public static string server;
        MySqlConnection conn;
        public MySqlConnection connect;
        string conn_string;
        int counter = 0;
        bool checker;
        private string entry;
        int i;

        


        public User()
        {
            InitializeComponent();
            comboPortName.SelectedIndex = -1;
            setupDB();
            
        }

        void scannerON()
        {
            try
            {
                if (!serialPort1.IsOpen)
                {
                    serialPort1.Open();
                    serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceived);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        void scannerOFF()
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();

                }
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        void setupDB()
        {
            if (string.IsNullOrEmpty(txtServer.Text))
            {
                server = "127.0.0.1";

            }
            else
            {
                server = txtServer.Text;
            }
            string pass = "";
            conn_string = "SERVER=" + server + "; PORT=3306; DATABASE=dbparking;UID=root;PASSWORD=" + pass + "";
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = conn_string;
                conn.Open();
               // MessageBox.Show("Connection Successfull!");
                conn.Close();

            }
            catch(Exception ed)
            {
                MessageBox.Show(ed.Message + "Please contact your system administrator.");
                this.Close();
            }
        }

        void setupRFID()
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            serialPort1.PortName = comboPortName.Text; 
            try
            {
                if (!serialPort1.IsOpen)
                {
                    serialPort1.Open();
                }
            }
            catch(Exception es)
            {
                MessageBox.Show(es.Message);
            }
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
        }

        void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    entry = serialPort1.ReadLine();
                    this.Invoke(new EventHandler(displaydata_event));
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error Scanner is OFF");
                }
            } //end if

        }

        void displaydata_event(object sender, EventArgs e)
        {
            txtRFID.Text = entry.Substring(0,12);
          //  selectFromDB();
            //  selectFromDB();
            //if (checker == true)
            //{
            //    //insertData();
           // checkExistToFill();
            txtTimeIn.Text = DateTime.Now.ToString("MM/dd/yyyy h:mm tt") +" "+ DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            serialPort1.Write("x");
            //}
            //else if (checker == false)
            //{
            //    MessageBox.Show("NO RECORDS FOUND");
            //    //Will get ERROR MessageBox
            //}
        }
        void selectFromDB()
        {
           // setupDB();
            string selectQuery = "select * from accounts where rfid='" + txtRFID.Text + "'";
            MySqlCommand cmd = new MySqlCommand(selectQuery, conn);
            MySqlDataReader reader;

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //byte[] imgg = (byte[])(reader["Image"]);
                    //if (imgg == null)
                    //{
                    //    pictureBox1.Image = null;
                    //}
                    //else
                    //{
                    //    MemoryStream msstream = new MemoryStream(imgg);
                    //    pictureBox1.Image = System.Drawing.Image.FromStream(msstream);

                    //}
                    //txtName.Text = safeGetString(reader, "name");
                }
                conn.Close();
            }
            catch (Exception et)
            {
                MessageBox.Show(et.Message);
            }

        }
        void checkifExisting()
        {

            string checkquery = "SELECT rfid FROM accounts";
            MySqlCommand cmd = new MySqlCommand(checkquery, conn);
            MySqlDataReader reader;

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string rf = safeGetString(reader, "rfid");
                    if (rf == txtRFID.Text)
                    {
                        checker = true;

                    }
                    else
                    {
                        checker = false;
                    }
                }
                conn.Close();
            }
            catch (Exception eh)
            {
                MessageBox.Show(eh.Message);
            }
        }
        public static string safeGetString(MySqlDataReader reader, string colname)
        {
            int colIndex = reader.GetOrdinal(colname);
            if (reader.IsDBNull(colIndex))
            {
                return reader.GetString(colIndex);
            }
            else
            {
                return string.Empty;
            }
        }


        

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

        void populateListViewforReport()
        {
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
        void populateListView()
        {
            listViewGetSerial.Items.Clear();
            MySqlCommand command = new MySqlCommand("SELECT * FROM report", connection);
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["RFIDnumber"].ToString());
                    item.SubItems.Add(dr["plate_number"].ToString());
                    item.SubItems.Add(dr["time_in"].ToString());
                    item.SubItems.Add(dr["driver_name"].ToString());
                    listViewGetSerial.Items.Add(item);

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void checkExistToFill()
        {
            i = 0;
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM report WHERE RFIDNumber='" + txtRFID.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            conn.Close();
            MySqlDataReader reader;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtName.Text = (reader["driver_name"].ToString());
                    txtPlateNumber.Text = (reader["plate_number"].ToString());
                    txtTimeIn.Text = (reader["time_in"].ToString());
                    btnGetData.Visible = false;
                    btnOutForPayment.Visible = true;

                }
                else
                {
                    if (MaterialMessageBox.Show("Please register first!", "No Records Found.", MessageBoxButtons.OK) == DialogResult.OK)
                    {

                    }
                }
                conn.Close();
            }
            catch (Exception ei)
            {
                MessageBox.Show(ei.Message);
                
            }

        }
        void checkExist()
        {
            i = 0;
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM report WHERE RFIDNumber='" + txtRFID.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            conn.Close();
            try
            {
                if (i == 0)
                {
                    
                    if (MaterialMessageBox.Show("Data Inserted", "Inserted", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        InsertData();
                        populateListView();
                        populateListViewforReport();
                        txtRFID.Text = null;
                        txtName.Text = null;
                        txtPlateNumber.Text = null;
                        txtTimeIn.Text = null;
                        txtTimeOut.Text = null;
                        txtPayment.Text = null;
                    }
                }
                else
                {
                    if (MaterialMessageBox.Show("Already Exist.", "Records Found", MessageBoxButtons.OK) == DialogResult.OK)
                    {

                    }
                }
            }
            catch(Exception eo)
            {
                MessageBox.Show(eo.Message);
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
           
            populateListView();
            populateListViewforReport();
            lblDate.Text = DateTime.Now.ToString("dd MMMM yyyy");
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();

            btnSignout.Text = "       Login as " + Login.recby +"\n      RFID-Moderator";

            signOutExit1.Hide();
           
            

        }

        private void btnGetSerial_Click(object sender, EventArgs e)
        {
            
            panelPay.BringToFront();
            panelPay.Visible = true;
            
        }

        private void btnRfidSetup_Click(object sender, EventArgs e)
        {
            PanelRFID.BringToFront();
            PanelRFID.Visible = true;
            
            
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            PanelRFID.Visible = false;
            listViewReport.BringToFront();
            listViewReport.Visible = true;
            panel7.BringToFront();
            panel7.Visible = true;
           

        }

        void InsertData()
        {
            string timein = txtTimeIn.Text;
            txtTimeIn.Text = DateTime.Now.ToString("MM/dd/yyyy h:mm tt") + " " + DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            string insertQuery = "INSERT INTO report(RFIDnumber,driver_name,plate_number,time_in,time_out,payment)VALUES ('" + txtRFID.Text + "','" + txtName.Text + "','" + txtPlateNumber.Text + "','" +timein + "','" + txtTimeOut.Text + "','" + txtPayment.Text + "')";
            string insertQuery2 = "INSERT INTO reportwithpayment(RFIDnumber,driver_name,plate_number,time_in,time_out,payment)VALUES ('" + txtRFID.Text + "','" + txtName.Text + "','" + txtPlateNumber.Text + "','" + timein + "','" + txtTimeOut.Text + "','" + txtPayment.Text + "')";
            MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
            MySqlCommand cmds = new MySqlCommand(insertQuery2, conn);
            try
            {
                //First Insertion
                conn.Open();
                cmd.Parameters.Add(new MySqlParameter("@RFIDnumber", txtRFID.Text));
                cmd.Parameters.Add(new MySqlParameter("@driver_name", txtName.Text));
                cmd.Parameters.Add(new MySqlParameter("@plate_number", txtPlateNumber.Text));
                cmd.Parameters.Add(new MySqlParameter("@time_in", txtTimeIn.Text));
                cmd.Parameters.Add(new MySqlParameter("@time_out", txtTimeOut.Text));
                cmd.Parameters.Add(new MySqlParameter("@payment", txtPayment.Text));

                cmd.ExecuteNonQuery();
                //Second Insertion
                cmds.Parameters.Add(new MySqlParameter("@RFIDnumber", txtRFID.Text));
                cmds.Parameters.Add(new MySqlParameter("@driver_name", txtName.Text));
                cmds.Parameters.Add(new MySqlParameter("@plate_number", txtPlateNumber.Text));
                cmds.Parameters.Add(new MySqlParameter("@time_in", txtTimeIn.Text));
                cmds.Parameters.Add(new MySqlParameter("@time_out", txtTimeOut.Text));
                cmds.Parameters.Add(new MySqlParameter("@payment", txtPayment.Text));

                cmds.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ej)
            {
                MessageBox.Show(ej.Message);
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (txtRFID.Text == "")
            {
                label3.Visible = true;
                label3.Text = "Please scan your RFID Card!";
                label3.ForeColor = Color.Red;

            }
            else if (txtRFID.Text != "")
            {
                label3.Visible = false;
                checkExist();
            }
            

        }

        private void btnGetSerial_Click_1(object sender, EventArgs e)
        {
            
            panelPay.BringToFront();
            panelPay.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
            panelPay.BringToFront();
            panelPay.Visible = true;
        }

        private void materialListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void btnGetSerial_Click_2(object sender, EventArgs e)
        {
            
            panelPay.BringToFront();
            panelPay.Visible = true;
        }

        private void btnGetSerial_Click_3(object sender, EventArgs e)
        {
            
            panelPay.BringToFront();
            panelPay.Visible = true;
        }

        private void panelUsertoSignOut_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void panelUsertoSignOut_Click(object sender, EventArgs e)
        {
           

        }

        private void panelUsertoSignOut_Leave(object sender, EventArgs e)
        {
            
        }

        private void panelUsertoSignOut_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void panelUsertoSignOut_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void btnSignout_Click(object sender, EventArgs e)
        {
           signOutExit1.BringToFront();
           signOutExit1.Visible = true;
            
        }

        private void btnSignout_Leave(object sender, EventArgs e)
        {
           // listViewGetSerial.BringToFront();
            
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSignout_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void btnSignout_Click_1(object sender, EventArgs e)
        {
            listViewReport.Visible = false;
            PanelRFID.BringToFront();
            PanelRFID.Visible = true;
            signOutExit1.BringToFront();
            signOutExit1.Visible = true;
        }

        private void btnReport_Leave(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
        bool gp2toogle = false;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            gp2toogle = !gp2toogle;
            if (gp2toogle == true)
            {
                GBSettings.Visible = true;
            }
            else if (gp2toogle == false)
            {
                GBSettings.Visible = false;
            }
            getPorts();
        }
        void getPorts()
        {
            string[] arr = SerialPort.GetPortNames();
            for(int i =0; i<arr.Length; i++)
            {
                comboPortName.Items.Add(arr[i]);
            }
        }

        bool scanToogle = false;
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            scanToogle = !scanToogle;
            if (scanToogle == true)
            {
                scannerON();
                lblScanner.Text = "SCANNER: ON";
            }
            else if (scanToogle == false)
            {
                scannerOFF();
                lblScanner.Text = "SCANNER: OFF";
            }
        }

        bool toogleIP = false;
        private void CheckDefault_CheckedChanged(object sender, EventArgs e)
        {
            toogleIP = !toogleIP;
            if (toogleIP == true)
            {
                txtServer.Visible = true;
            }
            else if (toogleIP == false)
            {
                txtServer.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                setupRFID();
                MessageBox.Show("Port has been configured.");
                //setupDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void User_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void listViewGetSerial_MouseClick(object sender, MouseEventArgs e)
        {

            txtRFID.Text = listViewGetSerial.SelectedItems[0].SubItems[0].Text;
            txtPlateNumber.Text = listViewGetSerial.SelectedItems[0].SubItems[1].Text;
            txtTimeIn.Text = listViewGetSerial.SelectedItems[0].SubItems[2].Text;
            txtName.Text = listViewGetSerial.SelectedItems[0].SubItems[3].Text;
            
            btnOutForPayment.Visible = true;
            label3.Visible = false;
            btnGetData.Visible = false;
            
        }
        
        private void btnOutForPayment_Click(object sender, EventArgs e)
        {
            if (MaterialMessageBox.Show("Vehicle Exit? ", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { 
                string timeout = txtTimeOut.Text;
                txtTimeOut.Text = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
                PaymentForm pf = new PaymentForm();
                pf.Show();

                this.Enabled = false;

                recby = txtRFID.Text;
                recby2 = txtTimeOut.Text;
                recby3 = txtTimeIn.Text;
            }

        }
        public static string rfidnumber;
        public static string recby
        {
            get { return rfidnumber; }
            set { rfidnumber = value; }
        }
        public static string timeout;
        public static string recby2
        {
            get { return timeout; }
            set { timeout = value; }
        }
        public static string timeIn;
        public static string recby3
        {
            get { return timeIn; }
            set { timeIn = value; }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            txtRFID.Text = null;
            txtName.Text = null;
            txtPlateNumber.Text = null;
            txtTimeIn.Text = null;
            txtTimeOut.Text = null;
            txtPayment.Text = null;
            populateListView();
            populateListViewforReport();
            btnOutForPayment.Visible = false;
            label3.Visible = false;
            btnGetData.Visible = true;

        }

        

        private void button2_Click_1(object sender, EventArgs e)
        {
            checkExistToFill();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtTimeIn.Text = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
        }
    }
}
