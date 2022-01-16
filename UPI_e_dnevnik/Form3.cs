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
    public partial class Form3 : Form
    {
        Dictionary<int, Ucenik> d_ucenici = new Dictionary<int, Ucenik>();
        Ucenik t;
        Profesor p;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
            
            using (StreamReader sr = File.OpenText("login.txt"))
            {
                string linija = sr.ReadLine();
                string[] n = linija.Split(';');

                int q1 = int.Parse(n[0]);
                int q2 = int.Parse(n[3]);
                int q3 = int.Parse(n[4]);
                int q4 = int.Parse(n[5]);
                p = new Profesor(q1, n[1], n[2], q2, q3, q4);
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("Označite razred!");
                return;
            }
            else if (radioButton1.Checked == true)
            {
                listBox1.Items.Clear();
                foreach (int u in d_ucenici.Keys)
                {
                    t = (Ucenik)d_ucenici[u];
                    if(t.Razred=="1A")
                        listBox1.Items.Add(t.Imeprezime);
                }
            }
            else
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
                    if(t.Imeprezime==listBox1.SelectedItem.ToString())
                    {
                        label1.Text = t.Imeprezime + " " + t.Razred + "\n" + t.OcjeneHR + "\n" + t.BiljeskeHR + "\n" + t.OcjeneENG + "\n" + t.BiljeskeENG +
                        "\n" + t.OcjeneMAT + "\n" + t.BiljeskeMAT + "\n" + "Broj opravdanih:" + t.Br_opravdanih + " Broj neopravdanih:" + t.Br_neopravdanih +
                        " Broj novih izostanaka:" + t.Br_noviizostanci + "\n" + t.Novi_izostanci;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex==-1)
            {
                MessageBox.Show("Niste označili učenika!");
                return;
            }
            else
            {
                
                foreach (int j in d_ucenici.Keys)
                {
                    Ucenik a = (Ucenik)d_ucenici[j];
                    if (listBox1.SelectedItem.ToString() == a.Imeprezime)
                        t = a;                          
                }
                int uocjena;
                
                if(textBox1.Text!="")
                {
                    try
                    {
                        uocjena = int.Parse(textBox1.Text);
                    }
                    catch
                    {

                        MessageBox.Show("Krivi unos ocjene!");
                        return;
                    }
                    if(uocjena<=0 || uocjena>=6)
                    {
                        MessageBox.Show("Krivi unos ocjene!");
                        return;
                    }
                    if (p.PredHR == 1)
                        t.OcjeneHR += uocjena+",";
                    else if (p.PredENG == 1)
                        t.OcjeneENG += uocjena+",";
                    else if (p.PredMAT == 1)
                        t.OcjeneMAT += uocjena+",";

                }

                if (textBox2.Text != "")
                {
                    if (p.PredHR == 1)
                        t.BiljeskeHR += textBox2.Text + ",";
                    else if (p.PredENG == 1)
                        t.BiljeskeENG += textBox2.Text + ",";
                    else if (p.PredMAT == 1)
                        t.BiljeskeMAT += textBox2.Text + ",";
                }  

                if(radioButton3.Checked)
                {
                    t.Br_noviizostanci += 1;

                    if (p.PredHR == 1)
                        t.Novi_izostanci += "HR "+ DateTime.Now;
                    else if (p.PredENG == 1)
                        t.Novi_izostanci += "ENG " + DateTime.Now;
                    else if (p.PredMAT == 1)
                        t.Novi_izostanci += "MAT " + DateTime.Now;
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

                MessageBox.Show("Unešeno!");
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
