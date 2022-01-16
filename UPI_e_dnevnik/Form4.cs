using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace UPI_e_dnevnik
{
    public partial class Form4 : Form
    {
        Razrednik r;
        Dictionary<int, Ucenik> d_ucenici = new Dictionary<int, Ucenik>();
        Ucenik t;

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            using (StreamReader sr = File.OpenText("login.txt"))
            {
                string linija = sr.ReadLine();
                string[] n = linija.Split(';');

                int q1 = int.Parse(n[0]);

                r = new Razrednik(q1, n[1], n[2], n[3]);

            }
            d_ucenici.Clear();

            using (StreamReader sr = File.OpenText("ucenici.txt"))
            {
                string linija;
                while ((linija = sr.ReadLine()) != null)
                {
                    string[] n = linija.Split(';');
                    int q = int.Parse(n[0]);
                    int q1 = int.Parse(n[7]);
                    int q2 = int.Parse(n[8]);
                    int q3 = int.Parse(n[9]);

                    Ucenik novi = new Ucenik(q, n[1], n[2], n[3], n[4], n[5], n[6], q1, q2, q3, n[10], n[11], n[12], n[13]);
                    d_ucenici.Add(q, novi);
                }
            }
            if(r.Razred=="1A")
            {
                listBox1.Items.Clear();
                foreach (int u in d_ucenici.Keys)
                {
                    t = (Ucenik)d_ucenici[u];
                    if (t.Razred == "1A")
                        listBox1.Items.Add(t.Imeprezime);
                }
            }
            else if(r.Razred=="2A")
            {
                listBox1.Items.Clear();
                foreach (int u in d_ucenici.Keys)
                {
                    t = (Ucenik)d_ucenici[u];
                    if (t.Razred == "2A")
                        listBox1.Items.Add(t.Imeprezime);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Oznacite ucenika!");
                return;
            }
            else
            {
                foreach (int u in d_ucenici.Keys)
                {
                    t = (Ucenik)d_ucenici[u];
                    if (t.Imeprezime == listBox1.SelectedItem.ToString())
                    {
                        label1.Text = t.Imeprezime + " " + t.Razred + "\n" + t.OcjeneHR + "\n" + t.BiljeskeHR + "\n" + t.OcjeneENG + "\n" + t.BiljeskeENG +
                        "\n" + t.OcjeneMAT + "\n" + t.BiljeskeMAT + "\n" + "Broj opravdanih:" + t.Br_opravdanih + " Broj neopravdanih:" + t.Br_neopravdanih +
                        " Broj novih izostanaka:" + t.Br_noviizostanci + "\n" + t.Novi_izostanci;
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked==false && radioButton2.Checked==false)
            {
                MessageBox.Show("Oznacite opciju!");
                return;
            }
            foreach (int j in d_ucenici.Keys)
            {
                Ucenik a = (Ucenik)d_ucenici[j];
                if (listBox1.SelectedItem.ToString() == a.Imeprezime)
                    t = a;
            }
            if(radioButton1.Checked)
            {
                t.Br_opravdanih += t.Br_noviizostanci;
                t.Br_noviizostanci = 0;
                t.Novi_izostanci = "Novi izostanci:";
            }
            else if(radioButton2.Checked)
            {
                t.Br_neopravdanih += t.Br_noviizostanci;
                t.Br_noviizostanci = 0;
                t.Novi_izostanci = "Novi izostanci:";
            }
           

            using (StreamWriter sw = File.CreateText("ucenici.txt"))
            {
                string linija = "";
                foreach (int uu in d_ucenici.Keys)
                {
                    Ucenik uup = (Ucenik)d_ucenici[uu];
                    linija = uup.Id + ";" + uup.Imeprezime + ";" + uup.Lozinka + ";" + uup.Razred + ";" + uup.OcjeneHR + ";" + uup.OcjeneENG + ";" + uup.OcjeneMAT +
                        ";" + uup.Br_opravdanih + ";" + uup.Br_neopravdanih + ";" + uup.Br_noviizostanci + ";" + uup.Novi_izostanci + ";" + uup.BiljeskeHR + ";" + uup.BiljeskeENG + ";" + uup.BiljeskeMAT;
                    sw.WriteLine(linija);
                }
            }

        }
    }
}
