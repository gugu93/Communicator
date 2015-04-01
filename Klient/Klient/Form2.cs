using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klient
{
    public partial class Start : Form
    {
        public string nazwaPortu;
        public string nazwaUzytkownika;
        public string ip;
        public Start()
        {
            InitializeComponent();
            frmKlient s1 = new frmKlient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nazwaPortu = textBox2.Text;
            nazwaUzytkownika = textBox1.Text;
            ip = textBox3.Text;
            this.Close();
        }
    }
}
