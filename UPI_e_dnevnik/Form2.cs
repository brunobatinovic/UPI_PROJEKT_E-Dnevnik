using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace UPI_e_dnevnik
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Ucenik u;
            using (StreamReader sr = File.OpenText("login.txt"))
            {
                string linija = sr.ReadLine();

                string[] n = linija.Split(';');
                int q = int.Parse(n[0]);
                int q1 = int.Parse(n[7]);
                int q2 = int.Parse(n[8]);
                int q3 = int.Parse(n[9]);

                u = new Ucenik(q, n[1], n[2], n[3], n[4], n[5], n[6], q1, q2, q3, n[10], n[11], n[12], n[13]);

            }
            label1.Text = u.Imeprezime + " " + u.Razred + "\n" + u.OcjeneHR + "\n" + u.BiljeskeHR + "\n" + u.OcjeneENG + "\n" + u.BiljeskeENG +
                "\n" + u.OcjeneMAT + "\n" + u.BiljeskeMAT + "\n" + "Broj opravdanih:" + u.Br_opravdanih + " Broj neopravdanih:" + u.Br_neopravdanih +
                " Broj novih izostanaka:" + u.Br_noviizostanci + "\n" + u.Novi_izostanci;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
