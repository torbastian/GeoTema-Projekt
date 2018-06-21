using System;
using System.Windows.Forms;

namespace GeoTema_Statistik
{
    public partial class frmAdminWindow : Form
    {
        public frmAdminWindow()
        {
            InitializeComponent();
        }

        private void frmAdminWindow_Load(object sender, EventArgs e)
        {
            dgvUsers.DataSource = Data.FillUserTable();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            string user = txtUserSearch.Text;
            if (!string.IsNullOrEmpty(user))
            {   //Hvis den ikke er tom, søg efter det indtastede bruger i databasen
                dgvUsers.DataSource = Data.FillUserTable(user);
                dgvUsers.Refresh();
            }
            else
            {   //Hvis den er tom, få fat i et opdateret DataSet
                dgvUsers.DataSource = Data.FillUserTable();
                dgvUsers.Refresh();
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            ResetSelectedPassword();
        }

        private void ResetSelectedPassword()
        {
            string user = dgvUsers.SelectedCells[0].Value.ToString();
            if (MessageBox.Show(string.Format("Er du sikker på at du vil Nulstille password for [{0}]?", user), "Advarsel!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (Data.ResetPassword(user))
                    MessageBox.Show(string.Format("Password for bruger [{0}] nulstillet til Default", user), "Success!");
            }
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            btnResetPassword.Enabled = (dgvUsers.SelectedRows.Count == 1 || dgvUsers.CurrentCell.ColumnIndex == 0);
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            frmCreateUser newUser = new frmCreateUser();
            newUser.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtUserSearch.Clear();
            dgvUsers.DataSource = Data.FillUserTable();
        }
    }
}
