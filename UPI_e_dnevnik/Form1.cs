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
    public partial class Form1 : Form
    {
        Dictionary<int, Ucenik> d_ucenici = new Dictionary<int, Ucenik>();
        Dictionary<int, Profesor> d_profesori = new Dictionary<int, Profesor>();
        Dictionary<int, Razrednik> d_razrednici = new Dictionary<int, Razrednik>();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

            d_profesori.Clear();

            using (StreamReader sr = File.OpenText("profesori.txt"))
            {
                string linija;
                while ((linija = sr.ReadLine()) != null)
                {
                    string[] n = linija.Split(';');
                    int q = int.Parse(n[0]);
                    int q1 = int.Parse(n[3]);
                    int q2 = int.Parse(n[4]);
                    int q3 = int.Parse(n[5]);

                    Profesor novi = new Profesor(q, n[1], n[2], q1, q2, q3);
                    d_profesori.Add(q, novi);
                }
            }

            d_razrednici.Clear();

            using (StreamReader sr = File.OpenText("razrednici.txt"))
            {
                //020;Vinka_Vinkić;razvinka;1A
                string linija;
                while ((linija = sr.ReadLine()) != null)
                {
                    string[] n = linija.Split(';');
                    int q = int.Parse(n[0]);

                    Razrednik novi = new Razrednik(q, n[1], n[2], n[3]);
                    d_razrednici.Add(q, novi);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int u_id;
            string u_loz;
            try
            {
                u_id = int.Parse(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Krivi unos ID-a!");
                textBox1.Text = "";               
                return;
            }
            if(textBox2.Text=="")
            {
                MessageBox.Show("Unesite lozinku!");
                return;
            }
            else
            {
               u_loz = textBox2.Text;
            }

            int zastavica = 0;
            
            foreach (int u in d_ucenici.Keys)
            {
                Ucenik t = (Ucenik)d_ucenici[u];
                if (t.Id == u_id && t.Lozinka == u_loz)
                {
                    zastavica = 1;
                    using (StreamWriter sw = File.CreateText("login.txt"))
                    {                      
                            string linija = t.Id + ";" + t.Imeprezime + ";" + t.Lozinka + ";" + t.Razred + ";" + t.OcjeneHR + ";" + t.OcjeneENG + ";" + t.OcjeneMAT +
                                ";" + t.Br_opravdanih + ";" + t.Br_neopravdanih + ";" + t.Br_noviizostanci + ";" + t.Novi_izostanci + ";" + t.BiljeskeHR + ";" + t.BiljeskeENG + ";" + t.BiljeskeMAT;
                            sw.WriteLine(linija);                     
                    }

                }
            }
            if(zastavica==0)
            {
                MessageBox.Show("Ponovite unos!");
                textBox1.Text = "";
                textBox2.Text = "";
                return;
            }
            else
            {
                
                Form2 fm2 = new Form2();
                fm2.ShowDialog();
            }
               

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int u_id;
            string u_loz;
            try
            {
                u_id = int.Parse(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Krivi unos ID-a!");
                textBox1.Text = "";
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Unesite lozinku!");
                return;
            }
            else
            {
                u_loz = textBox2.Text;
            }

            int zastavica = 0;

            foreach (int u in d_profesori.Keys)
            {
                Profesor t = (Profesor)d_profesori[u];
                if (t.Id == u_id && t.Lozinka == u_loz)
                {
                    zastavica = 1;
                    using (StreamWriter sw = File.CreateText("login.txt"))
                    {
                        //010;Katarina_Katić;profkata;0;1;0
                        string linija = t.Id + ";" + t.ImePrezime + ";" + t.Lozinka + ";" + t.PredHR + ";" + t.PredENG + ";" + t.PredMAT;
                        sw.WriteLine(linija);
                    }

                }
            }
            if (zastavica == 0)
            {
                MessageBox.Show("Ponovite unos!");
                textBox1.Text = "";
                textBox2.Text = "";
                return;
            }
            else
            {
                
                Form3 fm3 = new Form3();
                fm3.ShowDialog();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int u_id;
            string u_loz;
            try
            {
                u_id = int.Parse(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Krivi unos ID-a!");
                textBox1.Text = "";
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Unesite lozinku!");
                return;
            }
            else
            {
                u_loz = textBox2.Text;
            }

            int zastavica = 0;

            foreach (int u in d_razrednici.Keys)
            {
                Razrednik t = (Razrednik)d_razrednici[u];
                if (t.Id == u_id && t.Lozinka == u_loz)
                {
                    zastavica = 1;
                    using (StreamWriter sw = File.CreateText("login.txt"))
                    {
                        //2020;Vinka_Vinkić;razvinka;1A
                        string linija = t.Id + ";" + t.ImePrezime + ";" + t.Lozinka + ";" + t.Razred;
                        sw.WriteLine(linija);
                    }

                }
            }
            if (zastavica == 0)
            {
                MessageBox.Show("Ponovite unos!");
                textBox1.Text = "";
                textBox2.Text = "";
                return;
            }
            else
            {
                
                Form4 fm4 = new Form4();
                fm4.ShowDialog();
                
            }
        }
    }
}
