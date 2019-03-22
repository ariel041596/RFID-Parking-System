namespace RFIDParking
{
    partial class SignOutExit
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignOutExit));
            this.UserSignOutExit = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserSignOutExit
            // 
            this.UserSignOutExit.BackColor = System.Drawing.Color.Teal;
            this.UserSignOutExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UserSignOutExit.FlatAppearance.BorderSize = 0;
            this.UserSignOutExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserSignOutExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserSignOutExit.ForeColor = System.Drawing.Color.White;
            this.UserSignOutExit.Image = ((System.Drawing.Image)(resources.GetObject("UserSignOutExit.Image")));
            this.UserSignOutExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UserSignOutExit.Location = new System.Drawing.Point(0, 0);
            this.UserSignOutExit.Name = "UserSignOutExit";
            this.UserSignOutExit.Size = new System.Drawing.Size(146, 38);
            this.UserSignOutExit.TabIndex = 0;
            this.UserSignOutExit.Text = "      Sign-Out";
            this.UserSignOutExit.UseVisualStyleBackColor = false;
            this.UserSignOutExit.Click += new System.EventHandler(this.UserSignOutExit_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Teal;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(0, 40);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(146, 38);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "                 Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SignOutExit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.UserSignOutExit);
            this.Name = "SignOutExit";
            this.Size = new System.Drawing.Size(146, 103);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UserSignOutExit;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button button1;

    }
}
