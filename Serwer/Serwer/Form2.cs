using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serwer
{
    public partial class Start : Form
    {
        public string nazwaPortu;
        public string nazwaUzytkownika;

        public Start()
        {
            InitializeComponent();
            frmSerwer s1 = new frmSerwer();
            //s1.imieUzytkownika = textBox1.Text;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nazwaPortu = textBox2.Text;
            nazwaUzytkownika = textBox1.Text;
            this.Close();
        }

        private void Start_Load(object sender, EventArgs e)
        {

        }
    }
}
