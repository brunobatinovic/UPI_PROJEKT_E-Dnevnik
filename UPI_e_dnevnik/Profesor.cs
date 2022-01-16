using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPI_e_dnevnik
{
    class Profesor
    {
        private int id;
        private string imePrezime;
        private string lozinka;
        private int predHR;
        private int predENG;
        private int predMAT;

        public int Id { get => id; set => id = value; }
        public string ImePrezime { get => imePrezime; set => imePrezime = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
        public int PredHR { get => predHR; set => predHR = value; }
        public int PredENG { get => predENG; set => predENG = value; }
        public int PredMAT { get => predMAT; set => predMAT = value; }

        public Profesor(int id, string ip, string pw, int phr, int peng, int pmat)
        {
            this.Id = id;
            this.ImePrezime = ip;
            this.Lozinka = pw;
            this.PredHR = phr;
            this.PredENG = peng;
            this.PredMAT = pmat;
        }
    }
}
