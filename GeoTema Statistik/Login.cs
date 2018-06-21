using System;
using System.Windows.Forms;

namespace GeoTema_Statistik
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            //Få fat i brugerens Input
            string username = cbbUsername.Text;
            string password = txtPassword.Text;
            string datasource = cbbIp.Text;

            //Hvis alt er flydt ind, prøv at login
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(datasource))
            {   //Set Statiske SQL Variabler
                SQL.SetData(username, password, datasource);

                //Test forbindelsen, og få response koden
                SQL Conn = new SQL();
                int code = Conn.TestConnection();


                if (code > 0 && code <= 10 && code != 3)
                {   //Koden er accepteret og der er forbindelse, åben frmData
                    Data.rank = code;
                    frmData fData = new frmData();
                    fData.Show();
                    this.Hide();
                    SaveServerInputValues();
                }
                else if (code == 18488)
                {   //Hvis koden returnere 18488, skal brugeren skifte deres password, her åbnes ChangePassword formen
                    using (frmChangePassword form = new frmChangePassword(username))
                    {
                        var result = form.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            if (Conn.MustChangePassword(form.returnValue) == 0)
                                MessageBox.Show("Password blev ikke ændret");
                            else
                            {
                                MessageBox.Show("Password blev ændret");
                                txtPassword.Clear();
                            }
                        }
                    }
                }
                else if (code == 4060 || code == 3)
                {   //Hvis koden returnere 4060, eller 3 er adgang nægtet
                    MessageBox.Show("Adgang nægtet", "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {   //Ellers kunne der ikke oprettes forbindelse
                    MessageBox.Show(string.Format("Kunne ikke oprette forbindelse til server\nKode: {0}", code), "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    SQL.SetDataNone();
                }
            }
        }

        private void SaveServerInputValues()
        {   //Hvis den indtastede værdi ikke er i samlingen tilføj den, og hvis der 5+ værdier i samlingen, slet den sidste
            if (!cbbIp.Items.Contains(cbbIp.Text))
            {
                if (cbbIp.Items.Count >= 5)
                    cbbIp.Items.RemoveAt(cbbIp.Items.Count - 1);

                cbbIp.Items.Add(cbbIp.Text);
            }

            if (!cbbUsername.Items.Contains(cbbUsername.Text))
            {
                if (cbbUsername.Items.Count >= 5)
                    cbbUsername.Items.RemoveAt(cbbUsername.Items.Count - 1);

                cbbUsername.Items.Add(cbbUsername.Text);
            }

            //Lav ny array list for at gemme den i Settings
            System.Collections.ArrayList arrayList = new System.Collections.ArrayList(cbbIp.Items);
            Properties.Settings.Default.cbbStrings = arrayList;

            arrayList = new System.Collections.ArrayList(cbbUsername.Items);
            Properties.Settings.Default.cbbUsers = arrayList;

            //Gem
            Properties.Settings.Default.Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {   //Indlæs samlingerne fra settings til comboboksene 
            if (Properties.Settings.Default.cbbStrings != null)
                cbbIp.Items.AddRange(Properties.Settings.Default.cbbStrings.ToArray());

            if (Properties.Settings.Default.cbbUsers != null)
                cbbUsername.Items.AddRange(Properties.Settings.Default.cbbUsers.ToArray());
        }
    }
}
