using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPI_e_dnevnik
{
    class Ucenik
    {
        private int id;
        private string imeprezime;
        private string lozinka;
        private string razred;
        private string ocjeneHR;
        private string ocjeneENG;
        private string ocjeneMAT;
        private int br_opravdanih;
        private int br_neopravdanih;
        private int br_noviizostanci;
        private string biljeskeHR;
        private string biljeskeENG;
        private string biljeskeMAT;
        private string novi_izostanci;


        public string Imeprezime { get => imeprezime; set => imeprezime = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
        public string Razred { get => razred; set => razred = value; }
        public string OcjeneHR { get => ocjeneHR; set => ocjeneHR = value; }
        public string OcjeneENG { get => ocjeneENG; set => ocjeneENG = value; }
        public string OcjeneMAT { get => ocjeneMAT; set => ocjeneMAT = value; }
        public string BiljeskeHR { get => biljeskeHR; set => biljeskeHR = value; }
        public string BiljeskeENG { get => biljeskeENG; set => biljeskeENG = value; }
        public string BiljeskeMAT { get => biljeskeMAT; set => biljeskeMAT = value; }
        public int Br_opravdanih { get => br_opravdanih; set => br_opravdanih = value; }
        public int Br_neopravdanih { get => br_neopravdanih; set => br_neopravdanih = value; }

        public int Id { get => id; set => id = value; }
        public string Novi_izostanci { get => novi_izostanci; set => novi_izostanci = value; }
        public int Br_noviizostanci { get => br_noviizostanci; set => br_noviizostanci = value; }

        public Ucenik(int id, string ip, string pw, string raz, string ohr, string oeng, string omat, int br_op, int br_neop,
                      int br_nizo, string ni, string biljhr, string biljeng, string biljmat)
        {
            this.Id = id;
            this.Imeprezime = ip;
            this.Lozinka = pw;
            this.Razred = raz;
            this.OcjeneHR = ohr;
            this.OcjeneENG = oeng;
            this.OcjeneMAT = omat;
            this.Br_opravdanih = br_op;
            this.Br_neopravdanih = br_neop;
            this.Br_noviizostanci = br_nizo;
            this.novi_izostanci = ni;
            this.BiljeskeHR = biljhr;
            this.BiljeskeENG = biljeng;
            this.BiljeskeMAT = biljmat;
        }
    }
}
