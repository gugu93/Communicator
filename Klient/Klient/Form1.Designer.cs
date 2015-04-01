namespace Klient
{
    partial class frmKlient
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
            this.txtPort = new System.Windows.Forms.TextBox();
            this.cmdWyslij = new System.Windows.Forms.Button();
            this.cmdPolacz = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.txtWysylane = new System.Windows.Forms.RichTextBox();
            this.txtOdbieranie = new System.Windows.Forms.RichTextBox();
            this.polaczenie = new System.ComponentModel.BackgroundWorker();
            this.odbieranie = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(422, 76);
            this.txtPort.Name = "txtPort";
            this.txtPort.ReadOnly = true;
            this.txtPort.Size = new System.Drawing.Size(127, 20);
            this.txtPort.TabIndex = 17;
            this.txtPort.Text = "8000";
            // 
            // cmdWyslij
            // 
            this.cmdWyslij.Enabled = false;
            this.cmdWyslij.Location = new System.Drawing.Point(392, 369);
            this.cmdWyslij.Name = "cmdWyslij";
            this.cmdWyslij.Size = new System.Drawing.Size(89, 31);
            this.cmdWyslij.TabIndex = 16;
            this.cmdWyslij.Text = "Wyślij";
            this.cmdWyslij.UseVisualStyleBackColor = true;
            this.cmdWyslij.Click += new System.EventHandler(this.cmdWyslij_Click);
            // 
            // cmdPolacz
            // 
            this.cmdPolacz.Location = new System.Drawing.Point(392, 117);
            this.cmdPolacz.Name = "cmdPolacz";
            this.cmdPolacz.Size = new System.Drawing.Size(89, 46);
            this.cmdPolacz.TabIndex = 15;
            this.cmdPolacz.Text = "Połącz";
            this.cmdPolacz.UseVisualStyleBackColor = true;
            this.cmdPolacz.Click += new System.EventHandler(this.cmdPolacz_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 515);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Log";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(369, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nr Portu";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(15, 540);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(335, 54);
            this.txtLog.TabIndex = 12;
            this.txtLog.Text = "";
            // 
            // txtWysylane
            // 
            this.txtWysylane.Location = new System.Drawing.Point(15, 369);
            this.txtWysylane.Name = "txtWysylane";
            this.txtWysylane.Size = new System.Drawing.Size(335, 131);
            this.txtWysylane.TabIndex = 11;
            this.txtWysylane.Text = "";
            this.txtWysylane.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWysylane_KeyPress);
            // 
            // txtOdbieranie
            // 
            this.txtOdbieranie.Location = new System.Drawing.Point(15, 25);
            this.txtOdbieranie.Name = "txtOdbieranie";
            this.txtOdbieranie.ReadOnly = true;
            this.txtOdbieranie.Size = new System.Drawing.Size(335, 338);
            this.txtOdbieranie.TabIndex = 10;
            this.txtOdbieranie.Text = "";
            // 
            // polaczenie
            // 
            this.polaczenie.WorkerSupportsCancellation = true;
            this.polaczenie.DoWork += new System.ComponentModel.DoWorkEventHandler(this.polaczenie_DoWork);
            // 
            // odbieranie
            // 
            this.odbieranie.WorkerSupportsCancellation = true;
            this.odbieranie.DoWork += new System.ComponentModel.DoWorkEventHandler(this.odbieranie_DoWork);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Adres IP";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(422, 42);
            this.txtIP.Name = "txtIP";
            this.txtIP.ReadOnly = true;
            this.txtIP.Size = new System.Drawing.Size(127, 20);
            this.txtIP.TabIndex = 21;
            this.txtIP.Text = "192.168.0.15";
            // 
            // frmKlient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 619);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.cmdWyslij);
            this.Controls.Add(this.cmdPolacz);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtWysylane);
            this.Controls.Add(this.txtOdbieranie);
            this.Name = "frmKlient";
            this.Text = "Klient";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmKlient_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button cmdWyslij;
        private System.Windows.Forms.Button cmdPolacz;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.RichTextBox txtWysylane;
        private System.Windows.Forms.RichTextBox txtOdbieranie;
        private System.ComponentModel.BackgroundWorker polaczenie;
        private System.ComponentModel.BackgroundWorker odbieranie;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIP;
    }
}

