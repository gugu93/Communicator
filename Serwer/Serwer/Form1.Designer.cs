namespace Serwer
{
    partial class frmSerwer
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
            this.txtOdbieranie = new System.Windows.Forms.RichTextBox();
            this.txtWysylane = new System.Windows.Forms.RichTextBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdSluchaj = new System.Windows.Forms.Button();
            this.cmdWyslij = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.polaczenie = new System.ComponentModel.BackgroundWorker();
            this.odbieranie = new System.ComponentModel.BackgroundWorker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtOdbieranie
            // 
            this.txtOdbieranie.Location = new System.Drawing.Point(12, 38);
            this.txtOdbieranie.Name = "txtOdbieranie";
            this.txtOdbieranie.ReadOnly = true;
            this.txtOdbieranie.Size = new System.Drawing.Size(335, 338);
            this.txtOdbieranie.TabIndex = 0;
            this.txtOdbieranie.Text = "";
            // 
            // txtWysylane
            // 
            this.txtWysylane.Location = new System.Drawing.Point(12, 382);
            this.txtWysylane.Name = "txtWysylane";
            this.txtWysylane.Size = new System.Drawing.Size(335, 131);
            this.txtWysylane.TabIndex = 1;
            this.txtWysylane.Text = "";
            this.txtWysylane.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWysylane_KeyPress);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 553);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(335, 54);
            this.txtLog.TabIndex = 2;
            this.txtLog.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(386, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nr Portu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 528);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Log";
            // 
            // cmdSluchaj
            // 
            this.cmdSluchaj.Location = new System.Drawing.Point(367, 71);
            this.cmdSluchaj.Name = "cmdSluchaj";
            this.cmdSluchaj.Size = new System.Drawing.Size(89, 46);
            this.cmdSluchaj.TabIndex = 5;
            this.cmdSluchaj.Text = "Czekaj na połączenie";
            this.cmdSluchaj.UseVisualStyleBackColor = true;
            this.cmdSluchaj.Click += new System.EventHandler(this.cmdSluchaj_Click);
            // 
            // cmdWyslij
            // 
            this.cmdWyslij.Enabled = false;
            this.cmdWyslij.Location = new System.Drawing.Point(389, 382);
            this.cmdWyslij.Name = "cmdWyslij";
            this.cmdWyslij.Size = new System.Drawing.Size(89, 31);
            this.cmdWyslij.TabIndex = 6;
            this.cmdWyslij.Text = "Wyślij";
            this.cmdWyslij.UseVisualStyleBackColor = true;
            this.cmdWyslij.Click += new System.EventHandler(this.cmdWyslij_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(460, 38);
            this.txtPort.Name = "txtPort";
            this.txtPort.ReadOnly = true;
            this.txtPort.Size = new System.Drawing.Size(74, 20);
            this.txtPort.TabIndex = 7;
            this.txtPort.Text = "8000";
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
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(389, 438);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(157, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Włącz filtr wulgarnych słów";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // frmSerwer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(565, 619);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.cmdWyslij);
            this.Controls.Add(this.cmdSluchaj);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtWysylane);
            this.Controls.Add(this.txtOdbieranie);
            this.Name = "frmSerwer";
            this.Text = "Serwer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSerwer_FormClosed);
            this.Load += new System.EventHandler(this.frmSerwer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtOdbieranie;
        private System.Windows.Forms.RichTextBox txtWysylane;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdSluchaj;
        private System.Windows.Forms.Button cmdWyslij;
        private System.Windows.Forms.TextBox txtPort;
        private System.ComponentModel.BackgroundWorker polaczenie;
        private System.ComponentModel.BackgroundWorker odbieranie;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

