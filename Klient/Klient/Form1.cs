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

namespace Klient
{
    public partial class frmKlient : Form
    {
        private TcpClient klient = null;
        private bool czypolaczono = false;
        private bool czycenzura = true;
        private bool czyprzeklinal = false;
        private BinaryReader r = null;
        private BinaryWriter w = null;
        public string imieUzytkownika;
        public string nazwaPortu;
        public string ip;
        public string[] przeklenstwa = { "huj", "chuj", "kurwa", "paradysz", "pizda", "pierdole", "jebac", "skurwysyn", "suka", "kutas" };

        public void wyswietl(RichTextBox o, string tekst)
        {
            o.Focus();
            o.AppendText(tekst);
            o.ScrollToCaret();
            txtWysylane.Focus();

            if (czyprzeklinal == true)
            {
                czyprzeklinal = false;
                wyswietl(txtLog, "PROSZE NIE PRZEKLINAC\n");
            }

        }



        private string filtruj(string oo)
        {

            if (czycenzura == true)
            {
                string tekst = oo;


                string[] slowa = tekst.Split(' ');

                for (int q = 0; q < slowa.Length; q++)
                {

                    for (int w = 0; w < przeklenstwa.Length; w++)
                    {
                        if (slowa[q] == przeklenstwa[w])
                        {
                            czyprzeklinal = true;
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

        public frmKlient()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Start sc1 = new Start();
            sc1.ShowDialog();
            nazwaPortu = sc1.nazwaPortu;
            imieUzytkownika = sc1.nazwaUzytkownika;
            ip = sc1.ip;
            txtPort.Text = sc1.nazwaPortu;
            txtIP.Text = sc1.ip;
        }



        private void polaczenie_DoWork(object sender, DoWorkEventArgs e)
        {
            klient = new TcpClient();
            wyswietl(txtLog, "Próbuje się połączyć\n");
            klient.Connect(IPAddress.Parse(txtIP.Text), int.Parse(txtPort.Text));
            wyswietl(txtLog, "Połączenie nawiązane\nŻądam zezwolenia\n");
            NetworkStream stream = klient.GetStream();
            w = new BinaryWriter(stream);
            r = new BinaryReader(stream);
            w.Write(KomunikatyKlienta.Zadaj);

            if (r.ReadString() == KomunikatySerwera.OK) 
            {
                wyswietl(txtLog, "Połączono\n");
                czypolaczono = true;
                cmdWyslij.Enabled = true;
                odbieranie.RunWorkerAsync();
            }
            else
            {
                wyswietl(txtLog, "Brak odpowiedzi\nRozlaczono\n");
                czypolaczono = false;
                if (klient != null) klient.Close();
                cmdWyslij.Enabled = false;
                cmdPolacz.Text = "Połącz";
            }
        }


        private void odbieranie_DoWork(object sender, DoWorkEventArgs e)
        {
            string tekst;
            while ((tekst = r.ReadString()) != KomunikatySerwera.Rozlacz)
            {
                if ((tekst = r.ReadString()) == KomunikatySerwera.Cenzura) {  czycenzura = true; wyswietl(txtLog, "Kontrola tekstu włączona\n)"); }
                if ((tekst = r.ReadString()) == KomunikatySerwera.BezCenzury) { czycenzura = false; wyswietl(txtLog, "Kontrola tekstu wyłączona\n"); } 
                    
               wyswietl(txtOdbieranie, "===== Rozmówca =====\n" + tekst + '\n');
                    
            }
            
            cmdWyslij.Enabled = false;
            wyswietl(txtLog, "Rozlaczono\n");
            cmdPolacz.Text = "Połącz";
            czypolaczono = false;
            if (klient != null) klient.Close();
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

        private void cmdPolacz_Click(object sender, EventArgs e)
        {
            if (cmdPolacz.Text == "Połącz")
            {
                polaczenie.RunWorkerAsync();
                cmdPolacz.Text = "Rozłącz";
            }
            else
            {
                if (czypolaczono)
                {
                    w.Write(KomunikatyKlienta.Rozlacz);
                    klient.Close();
                    czypolaczono = false;
                }
                cmdPolacz.Text = "Połącz";
                cmdWyslij.Enabled = false;
                wyswietl(txtLog, "Rozlaczono\n");
            }
        }

        private void frmKlient_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (czypolaczono)
            {
                w.Write(KomunikatyKlienta.Rozlacz);
                klient.Close();
                czypolaczono = false;
            }
            polaczenie.CancelAsync();
            odbieranie.CancelAsync();
        }


    }
}
