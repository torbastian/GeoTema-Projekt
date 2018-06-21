using System;
using System.Windows.Forms;

namespace GeoTema_Statistik
{
    public partial class frmData : Form
    {
        public frmData()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            //Se om searchTerm textboxen er tom eller ej
            try
            {
                string land = txtSearchTerm.Text;
                if (!string.IsNullOrEmpty(land))
                {   //Hvis den ikke er tom, søg efter det indtastede land i databasen
                    dgvData.DataSource = Data.FillTable(land);
                    dgvData.Refresh();
                }
                else
                {   //Hvis den er tom, få fat i et opdateret DataSet
                    dgvData.DataSource = Data.FillTable();
                    dgvData.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmData_Load(object sender, EventArgs e)
        {   //Få fat i Dataset
            try
            {
                dgvData.DataSource = Data.FillTable();
                CheckRank();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CountryCreatorDialog();
        }

        private void CountryCreatorDialog()
        {   //Lav en ny CountryCreator og åben en dialog
            try
            {
                frmCountryCreator CC = new frmCountryCreator();

                DialogResult DiagResult = CC.ShowDialog();

                if (DiagResult == DialogResult.OK)
                {   //Opdater Dataset
                    dgvData.DataSource = Data.FillTable();
                    dgvData.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckRank()
        {   //Check brugerens rank, hvilket bestemmer hvilke funktioner der bliver låst op for
            int rank = Data.rank;
            btnAdd.Enabled = (rank >= 3);
            btnAdmin.Enabled = (rank == 10);
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {   //Åben ny admin form
            frmAdminWindow Admin = new frmAdminWindow();
            Admin.Show();
        }

        private void frmData_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {   //Genindlæs data og clear textbox
            txtSearchTerm.Clear();
            dgvData.DataSource = Data.FillTable();
        }
    }
}
