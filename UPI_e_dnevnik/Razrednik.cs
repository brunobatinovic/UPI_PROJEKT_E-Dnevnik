using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPI_e_dnevnik
{
    class Razrednik
    {
        private int id;
        private string lozinka;
        private string imePrezime;
        private string razred;

        public int Id { get => id; set => id = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
        public string ImePrezime { get => imePrezime; set => imePrezime = value; }
        public string Razred { get => razred; set => razred = value; }

        public Razrednik(int id, string ip, string pw, string raz)
        {
            this.Id = id;
            this.ImePrezime = ip;
            this.Lozinka = pw;
            this.Razred = raz;
        }
    }
}
