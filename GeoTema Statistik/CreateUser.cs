using System;
using System.Windows.Forms;

namespace GeoTema_Statistik
{
    public partial class frmCreateUser : Form
    {

        public frmCreateUser()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            CreateUser();
        }

        private void CreateUser()
        {
            //Få fat i bruger input værdier
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            bool role = (rbnStandard.Checked == true);

            bool changePassword = (cbMustChange.Checked == true);

            //Lav en ny bruger og check om den er valideret
            User user = new User(username, password, role, changePassword);

            if (user.validated)
            {   //Prøv at opret brugeren i Databasen
                if (Data.AddUser(user))
                {
                    MessageBox.Show(string.Format("Bruger [{0}] oprettet!", user.Username), "Success!");
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    MessageBox.Show("Bruger blev ikke oprettet!\nPrøv Igen", "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Bruger bestod ikke validering!", "Fejl!");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
