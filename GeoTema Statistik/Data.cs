using System;
using System.Collections.Generic;
using System.Data;

namespace GeoTema_Statistik
{
    class Data
    {
        public static int rank;

        private static string DefaultInner = "SELECT Land.ID, Land.Land, Land.Verdensdel, Rang.Rang, Rang.Fødselsrate FROM Land INNER JOIN Rang ON Land.ID = Rang.ID";
        
        private static string DefaultUser = "SELECT name, principal_id, create_date, modify_date FROM master.sys.server_principals";

        public static DataTable FillTable()
        {   //Få fat i dataset
            SQL Conn = new SQL();
            return Conn.GetDataSet(DefaultInner + ";");
        }

        public static DataTable FillTable(string Country)
        {   //Få fat i datasettet, hvor Land.Land = indtastet land
            SQL Conn = new SQL();
            return Conn.GetDataSet(DefaultInner + string.Format(" WHERE Land.Land = '{0}';", Country));
        }

        public static DataTable FillUserTable()
        {   //Få fat i datasettet til brugere
            SQL Conn = new SQL();
            return Conn.GetDataSet(DefaultUser + ";");
        }

        public static DataTable FillUserTable(string user)
        {   //Få fat i datasettet for den specefike bruger
            SQL Conn = new SQL();
            return Conn.GetDataSet(DefaultUser + string.Format(" WHERE name = '{0}'", user));
        }

        public static bool ResetPassword(string user)
        {   //Reset password
            bool success = false;

            List<string> script = new List<string>();

            script.Add(string.Format("ALTER LOGIN [{0}] WITH DEFAULT_DATABASE=[MASTER]", user));
            script.Add("USE [MASTER]");
            script.Add(string.Format("ALTER LOGIN [{0}] WITH PASSWORD=N'Passw0rd' MUST_CHANGE", user));

            SQL Conn = new SQL();

            success = (Conn.ExecuteBatch(script) == -script.Count);

            return success;
        }

        public static bool AddCountry(Country C)
        {
            bool success = false;

            try
            {
                //Opret ny list og kør dem som batch
                List<string> script = new List<string>();
                script.Add(string.Format("INSERT INTO Land (Land, Verdensdel) VALUES ('{0}', '{1}')", C.Land, C.Verdensdel));
                script.Add(string.Format("INSERT INTO Rang (rang, Fødselsrate) VALUES ({0}, {1});", C.Rang, C.Foedselsrate));

                SQL Conn = new SQL();
                success = (Conn.ExecuteBatch(script) == script.Count);
            }
            catch
            {
                success = false;
            }

            return success;
        }

        public static bool AddUser(User U)
        {
            bool success = false;

            try
            {   //Lav et nyt script
                List<string> script = new List<string>();
                
                //Check om brugeren skal skifte password næste gang de logger ind eller ej
                if (U.MustChange)
                    script.Add(string.Format("CREATE LOGIN [{0}] WITH PASSWORD = N'{1}' MUST_CHANGE, CHECK_EXPIRATION = ON;", U.Username, U.Password));
                else
                    script.Add(string.Format("CREATE LOGIN [{0}] WITH PASSWORD = N'{1}', CHECK_EXPIRATION = ON;", U.Username, U.Password));

                //Lav en bruger på Databasen fra Login
                script.Add(string.Format("CREATE USER [{0}] FOR LOGIN [{0}];", U.Username));

                //Kig igennem alle roller, og tilføj kommandoen til script
                foreach (var role in U.Roles)
                    script.Add(string.Format("ALTER ROLE [{0}] ADD MEMBER [{1}];", role, U.Username));

                SQL Conn = new SQL();
                success = (Conn.ExecuteBatch(script) == -script.Count);

            }
            catch (Exception e)
            {
                return false;
            }

            return success;
        }
    }
}
