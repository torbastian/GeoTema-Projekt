using System;
using System.Linq;
using System.Windows.Forms;

namespace GeoTema_Statistik
{
    public partial class frmChangePassword : Form
    {
        private string user;

        public string returnValue { get; set; }

        public frmChangePassword(string u)
        {
            InitializeComponent();
            user = u;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            txtUsername.Text = user;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            CheckPassword();
        }

        private void CheckPassword()
        {   //Få fat i bruger input
            string password = txtPassword.Text;
            string password2 = txtPassword.Text;

            //Kør simpel validereing
            if (password.Length <= 3 || !password.Any(char.IsUpper) || !password.Any(char.IsNumber))
            {
                MessageBox.Show("Password skal være længere end 3 karaktere." +
                                "/nPassword skal indholde mindst et stort bogstav." +
                                "/nPassword skal indholde mindst et tal.", "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Check om begge passwords er ens
            if (password != password2)
            {
                MessageBox.Show("Begge Passwords skal matche", "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                returnValue = password;
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
