using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace GeoTema_Statistik
{
    public class SQL
    {
        private static string user;
        private static string pass;
        private static string datasource;

        public string BuildConnectionString()
        {   //Lav en connection string ved hjælp af SqlConnectionStringBuilder
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = datasource;
            builder.InitialCatalog = "fødselsrate_2017";
            builder.UserID = user;
            builder.Password = pass;
            builder.ConnectTimeout = 20;

            return builder.ConnectionString;
        }

        public static void SetData(string u, string p, string d)
        {
            user = u;
            pass = p;
            datasource = d;
        }

        public static void SetDataNone()
        {
            user = string.Empty;
            pass = string.Empty;
            datasource = string.Empty;
        }

        public int TestConnection()
        {
            //Test forbindelsen, og få fat i brugerens rank
            int code = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(BuildConnectionString()))
                {
                    connection.Open();
                    code++;

                    //find ud af hvilken rolle brugeren høre til
                    SqlCommand command = new SqlCommand("SELECT IS_ROLEMEMBER('db_datareader')," +
                                                        "IS_ROLEMEMBER('db_datawriter')," +
                                                        "IS_SRVROLEMEMBER('sysadmin');", connection);

                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();

                    int[] Rolelist = { reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2) };

                    //Brugeren er en Datareader, en Standardbruger
                    if (Rolelist[0] == 1)
                        code = 1;

                    //Brugeren er en eksklusiv datawriter, og bliver nægtet adgang
                    if (Rolelist[1] == 1 && Rolelist[0] == 0)
                        code = 2;

                    //Brugeren er en Datareader og Datawriter, en Superbruger
                    if (Rolelist[1] == 1 && Rolelist[0] == 1)
                        code = 3;

                    //Brugeren er en sysadmin, en Administrator
                    if (Rolelist[2] == 1)
                        code = 10;

                    return code;
                }
            }
            catch (SqlException e)
            {
                return e.Number;
            }
        }

        public byte MustChangePassword(string nPassword)
        {   //Forbind til serveren for at skifte password
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = datasource;
            builder.UserID = user;
            builder.Password = pass;
            builder.ConnectTimeout = 20;

            try
            {
                SqlConnection.ChangePassword(builder.ConnectionString, nPassword);
            }
            catch (Exception)
            {
                return 0;
            }

            return 1;
        }

        public DataTable GetDataSet(string SQLQuery)
        {  
            BuildConnectionString();
            //Forbind til SQL Server og få DataSet ud fra SQLQuery
            using (SqlConnection connection = new SqlConnection(BuildConnectionString()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(SQLQuery, connection);

                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }
        }

        public int ExecuteBatch(List<string> script)
        {
            //Kør en liste af kommandoer i en enkel forbindelse
            try
            {
                using (SqlConnection connection = new SqlConnection(BuildConnectionString()))
                {
                    connection.Open();
                    int count = 0;
                    foreach (var query in script)
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        count += command.ExecuteNonQuery();
                    }
                    return count;
                }
            }
            catch
            {
                return 0;
            }

        }

        public int ExecuteCommand(string SQLQuery)
        {
            BuildConnectionString();
            //Forbind til SQL Server og send Query igennem
            using (SqlConnection connection = new SqlConnection(BuildConnectionString()))
            {
                SqlCommand command = new SqlCommand(SQLQuery, connection);
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }
}
