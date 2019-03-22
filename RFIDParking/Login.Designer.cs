namespace RFIDParking
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtUsername = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtPassword = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblfirstusername = new System.Windows.Forms.Label();
            this.lblFirstPassword = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSignIn = new LollipopButton();
            this.lblSecondUsername = new System.Windows.Forms.Label();
            this.lblSecondPassword = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(163)))), ((int)(((byte)(150)))));
            this.panel4.Location = new System.Drawing.Point(14, 32);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(15, 5);
            this.panel4.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel3.Location = new System.Drawing.Point(8, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(5, 40);
            this.panel3.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Maroon;
            this.panel2.Location = new System.Drawing.Point(30, 14);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 20);
            this.panel2.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(149)))), ((int)(((byte)(11)))));
            this.panel5.Location = new System.Drawing.Point(14, 12);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(15, 5);
            this.panel5.TabIndex = 5;
            // 
            // txtUsername
            // 
            this.txtUsername.Depth = 0;
            this.txtUsername.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.Red;
            this.txtUsername.Hint = "";
            this.txtUsername.Location = new System.Drawing.Point(14, 291);
            this.txtUsername.MaxLength = 32767;
            this.txtUsername.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.SelectedText = "";
            this.txtUsername.SelectionLength = 0;
            this.txtUsername.SelectionStart = 0;
            this.txtUsername.Size = new System.Drawing.Size(329, 23);
            this.txtUsername.TabIndex = 6;
            this.txtUsername.TabStop = false;
            this.txtUsername.UseSystemPasswordChar = false;
            this.txtUsername.Click += new System.EventHandler(this.txtUsername_Click);
            this.txtUsername.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUsername_KeyUp);
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave);
            this.txtUsername.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtUsername_MouseClick);
            // 
            // txtPassword
            // 
            this.txtPassword.Depth = 0;
            this.txtPassword.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Hint = "";
            this.txtPassword.Location = new System.Drawing.Point(14, 361);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.Size = new System.Drawing.Size(329, 23);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.TabStop = false;
            this.txtPassword.UseSystemPasswordChar = false;
            this.txtPassword.Click += new System.EventHandler(this.txtPassword_Click);
            this.txtPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyUp);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(43, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 29);
            this.label1.TabIndex = 11;
            this.label1.Text = "RFID Parking";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Teal;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(129, 419);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "Sign-In";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(43, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Login to Your Account";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblfirstusername
            // 
            this.lblfirstusername.AutoSize = true;
            this.lblfirstusername.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfirstusername.ForeColor = System.Drawing.Color.Gray;
            this.lblfirstusername.Location = new System.Drawing.Point(11, 271);
            this.lblfirstusername.Name = "lblfirstusername";
            this.lblfirstusername.Size = new System.Drawing.Size(66, 16);
            this.lblfirstusername.TabIndex = 13;
            this.lblfirstusername.Text = "Username";
            // 
            // lblFirstPassword
            // 
            this.lblFirstPassword.AutoSize = true;
            this.lblFirstPassword.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstPassword.ForeColor = System.Drawing.Color.Gray;
            this.lblFirstPassword.Location = new System.Drawing.Point(11, 338);
            this.lblFirstPassword.Name = "lblFirstPassword";
            this.lblFirstPassword.Size = new System.Drawing.Size(63, 16);
            this.lblFirstPassword.TabIndex = 13;
            this.lblFirstPassword.Text = "Password";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(116, 94);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // btnSignIn
            // 
            this.btnSignIn.BackColor = System.Drawing.Color.Teal;
            this.btnSignIn.BGColor = "teal";
            this.btnSignIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSignIn.FontColor = "#ffffff";
            this.btnSignIn.Location = new System.Drawing.Point(13, 413);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(330, 43);
            this.btnSignIn.TabIndex = 3;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click_1);
            // 
            // lblSecondUsername
            // 
            this.lblSecondUsername.AutoSize = true;
            this.lblSecondUsername.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecondUsername.ForeColor = System.Drawing.Color.Gray;
            this.lblSecondUsername.Location = new System.Drawing.Point(8, 254);
            this.lblSecondUsername.Name = "lblSecondUsername";
            this.lblSecondUsername.Size = new System.Drawing.Size(80, 19);
            this.lblSecondUsername.TabIndex = 13;
            this.lblSecondUsername.Text = "Username";
            // 
            // lblSecondPassword
            // 
            this.lblSecondPassword.AutoSize = true;
            this.lblSecondPassword.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecondPassword.ForeColor = System.Drawing.Color.Gray;
            this.lblSecondPassword.Location = new System.Drawing.Point(8, 320);
            this.lblSecondPassword.Name = "lblSecondPassword";
            this.lblSecondPassword.Size = new System.Drawing.Size(76, 19);
            this.lblSecondPassword.TabIndex = 13;
            this.lblSecondPassword.Text = "Password";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(355, 644);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblSecondPassword);
            this.Controls.Add(this.lblFirstPassword);
            this.Controls.Add(this.lblSecondUsername);
            this.Controls.Add(this.lblfirstusername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtUsername;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPassword;
        private LollipopButton btnSignIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblfirstusername;
        private System.Windows.Forms.Label lblFirstPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblSecondUsername;
        private System.Windows.Forms.Label lblSecondPassword;

    }
}

