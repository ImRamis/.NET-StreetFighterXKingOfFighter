namespace StreetFighterXKingOfFighter
{
    partial class GameForm
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
            this.dB_Panel1 = new DB_Panel();
            key1 = new System.Windows.Forms.Label();
            key2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dB_Panel1
            // 
            this.dB_Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dB_Panel1.Location = new System.Drawing.Point(0, 0);
            this.dB_Panel1.Name = "dB_Panel1";
            this.dB_Panel1.Size = new System.Drawing.Size(1262, 721);
            this.dB_Panel1.TabIndex = 0;
            // 
            // key1
            // 
            key1.Location = new System.Drawing.Point(0, 0);
            key1.Font = new System.Drawing.Font("Arial", 6f);
            key1.Name = "key1";
            key1.Size = new System.Drawing.Size(150, 23);
            key1.Visible = false;
            key1.TabIndex = 0;
            // 
            // key2
            // 
            key2.Font = new System.Drawing.Font("Arial", 6f);
            key2.Name = "key2";
            key2.Visible = false;
            key2.Size = new System.Drawing.Size(150, 23);
            key2.Location = new System.Drawing.Point(dB_Panel1.Width - key2.Width, 0);
            key2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1262, 721);
            this.Controls.Add(key1);
            this.Controls.Add(key2);
            this.Controls.Add(this.dB_Panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Street of Fighter 97ex";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        public DB_Panel dB_Panel1;
        public static System.Windows.Forms.Label key2;
        public static System.Windows.Forms.Label key1;
    }
}

