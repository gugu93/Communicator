using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using komunikaty;

namespace Serwer
{
    public partial class frmSerwer : Form
    {
        private TcpListener listener = null;
        private TcpClient klient = null;
        private bool czypolaczono = false;
        private BinaryReader r = null;
        private BinaryWriter w = null;
        public string imieUzytkownika;
        public string nazwaPortu;
        public string[] przeklenstwa = { "huj", "chuj", "kurwa", "paradysz", "pizda", "pierdole", "jebac", "skurwysyn", "suka", "kutas" }; 
        
 
        public frmSerwer()
        {
            InitializeComponent();
        
        }

        private string filtruj(string oo)
        {

            if (checkBox1.Checked == true)
            {

                string tekst = oo;

                string[] slowa = tekst.Split(' ');

                for (int q = 0; q < slowa.Length; q++)
                {

                    for (int w = 0; w < przeklenstwa.Length; w++)
                    {
                        if (slowa[q] == przeklenstwa[w])
                        {
                            string cenzura = "";
                            int gwiazdki = slowa[q].Length - 2;
                            cenzura = cenzura + slowa[q][0];
                            for (int j = 0; j < gwiazdki; j++)
                            {
                                cenzura += "*";
                            }

                            cenzura += slowa[q][slowa[q].Length - 1];


                            slowa[q] = cenzura;
                        }
                    }

                }

                string pocenzurze = "";

                for (int e = 0; e < slowa.Length; e++)
                {
                    pocenzurze += slowa[e] + " ";
                }



                return pocenzurze;

            }
            return oo;

         }

        private void frmSerwer_Load(object sender, EventArgs e)
        {
            Start sc1 = new Start();
            sc1.ShowDialog();
            nazwaPortu = sc1.nazwaPortu;
            imieUzytkownika = sc1.nazwaUzytkownika;
            txtPort.Text = sc1.nazwaPortu;
            
        }

        public void wyswietl(RichTextBox o, string tekst)
        {
            o.Focus();
            o.AppendText(tekst);
            o.ScrollToCaret();
            txtWysylane.Focus();
            
        }

        private void polaczenie_DoWork(object sender, DoWorkEventArgs e)
        {
            wyswietl(txtLog, "Czekam na połaczenie\n");
            listener = new TcpListener(Int32.Parse(txtPort.Text));
            listener.Start();
            while (!listener.Pending())
            {
                if (this.polaczenie.CancellationPending)
                {
                    if (klient != null) klient.Close();
                    listener.Stop();
                    czypolaczono = false;
                    cmdSluchaj.Text = "Czekaj na połączenie";
                    return;
                }
            }
            klient = listener.AcceptTcpClient();
            wyswietl(txtLog, "Zażądano połączenia\n");
            NetworkStream stream = klient.GetStream();
            w = new BinaryWriter(stream);
            r = new BinaryReader(stream);
            if (r.ReadString() == KomunikatyKlienta.Zadaj)
            {
                w.Write(KomunikatySerwera.OK);
                wyswietl(txtLog, "Połączono\n");
                czypolaczono = true;
                cmdWyslij.Enabled = true;
                checkBox1.Enabled = true;
                odbieranie.RunWorkerAsync();
            }
            else
            {
                wyswietl(txtLog, "Klient odrzucony\nRozlaczono\n");
                if (klient != null) klient.Close();
                listener.Stop();
                czypolaczono = false;
            }
        }

        private void odbieranie_DoWork(object sender, DoWorkEventArgs e)
        {
            string tekst;
            while ((tekst = r.ReadString()) != KomunikatyKlienta.Rozlacz)
            {
                wyswietl(txtOdbieranie, "===== Rozmówca =====\n" + tekst + '\n');
            }
            wyswietl(txtLog, "Rozlaczono\n");
            czypolaczono = false;
            klient.Close();
            listener.Stop();
            cmdSluchaj.Text = "Czekaj na połączenie";
        }

        private void cmdWyslij_Click(object sender, EventArgs e)
        {
            string t;
            string tekst = txtWysylane.Text;
            t = filtruj(tekst);
            if (tekst == "") { txtWysylane.Focus(); return; }
            if (tekst[tekst.Length - 1] == '\n')
                tekst = tekst.TrimEnd('\n');
            w.Write(t);
            wyswietl(txtOdbieranie, "===== " + imieUzytkownika + " =====\n" + t + '\n');
            txtWysylane.Text = "";
        }

        private void txtWysylane_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmdWyslij.Enabled && e.KeyChar == (char)13) cmdWyslij_Click(sender, e);
        }

        private void cmdSluchaj_Click(object sender, EventArgs e)
        {
            if (cmdSluchaj.Text == "Czekaj na połączenie")
            {

                polaczenie.RunWorkerAsync();
                cmdSluchaj.Text = "Rozłącz";
            }
            else
            {
                if (czypolaczono)
                {
                    w.Write(KomunikatySerwera.Rozlacz);
                    listener.Stop();
                    if (klient != null) klient.Close();
                    czypolaczono = false;
                }
                wyswietl(txtLog, "Rozlaczono\n");
                cmdSluchaj.Text = "Czekaj na połączenie";
                cmdWyslij.Enabled = false;
                polaczenie.CancelAsync();
                odbieranie.CancelAsync();
            }
        }

        private void frmSerwer_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (czypolaczono)
            {
                w.Write(KomunikatySerwera.Rozlacz);
                listener.Stop();
                if (klient != null) klient.Close();
                czypolaczono = false;
            }
            polaczenie.CancelAsync();
            odbieranie.CancelAsync();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)
            {
                //wyswietl(txtLog, "Kontrola tekstu włączona\n");
                w.Write(KomunikatySerwera.Cenzura);
            }
            else
            {
               //wyswietl(txtLog, "Kontrola tekstu wyłączona\n");
               w.Write(KomunikatySerwera.BezCenzury);
            }
        }
    }
}
