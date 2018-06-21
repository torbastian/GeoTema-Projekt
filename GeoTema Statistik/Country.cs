namespace GeoTema_Statistik
{
    class Country
    {
        private string land;
        private string verdensdel;

        private int rang;

        private float foedselsrate;

        public bool validated = false;

        public string Land {
            get { return land; }
        }

        public string Verdensdel {
            get { return verdensdel; }
        }

        public int Rang {
            get { return rang; }
        }

        public float Foedselsrate {
            get { return foedselsrate; }
        }

        //Constructor
        public Country(string l, string v, int r, float f)
        {   //Hvis dataen er valid, skriv data til objekts variabler
            if(Validate(l, r, f))
            {
                land = l;
                verdensdel = v;
                rang = r;
                foedselsrate = f;
                validated = true;
            }
        }

        //Bruges til at validere data
        private bool Validate(string l, int r, float f)
        {
            bool success = false;

            success = (l.Length < 50 && l.Length >= 2 && r > 0 && f > 0);

            return success;
        }
    }
}
