using System.Collections.Generic;
using System.Linq;

namespace GeoTema_Statistik
{
    class User
    {
        private string username;
        private string password;
        private List<string> roles = new List<string>();

        private bool mustChange;

        public bool validated = false;

        public string Username {
            get { return username; }
        }
        
        public string Password {
            get { return password; }
        }

        public List<string> Roles {
            get { return roles; }
        }

        public bool MustChange {
            get { return mustChange; }
        }

        public User(string u, string p, bool r, bool mc)
        {
            if (Validate(u, p))
            {
                if (r)
                {
                    //Standard Bruger
                    roles.Add("db_datareader");
                }
                else
                {
                    //Super Bruger
                    roles.Add("db_datareader");
                    roles.Add("db_datawriter");
                }

                username = u;
                password = p;
                mustChange = mc;
                validated = true;
            }
        }

        private bool Validate(string u, string p)
        {   //Simpel validering, SQL serveren håndtere også validereing for dens egne regler
            bool success = false;

            if (u.Length < 20)
                if (p.Length < 30 && p.Any(char.IsUpper) && p.Any(char.IsNumber))
                    success = true;

            return success;
        }
    }
}
