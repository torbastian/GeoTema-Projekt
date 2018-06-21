using System;
using System.Windows.Forms;

namespace GeoTema_Statistik
{
    public partial class frmCountryCreator : Form
    {
        public frmCountryCreator()
        {   //Gør at komma seperatoren bliver lavet til et punktom per default, siden SQL ikke kan lide komma i sine værdier
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            CreateCountry();
        }

        private void CreateCountry()
        {   //Lav et nyt land udfra værdier indtastet i formen
            string land = txtLand.Text;
            string verdensdel = cbbVerdensdel.Text;

            int rang = Convert.ToInt16(nudRang.Value);

            float foedselsrate = (float)nudFoedsel.Value;

            Country C = new Country(land, verdensdel, rang, foedselsrate);

            //Check om Landet bestod validering
            if (!C.validated)
            {
                MessageBox.Show("Fejl!: En værdi fejlede verifikation!\nPrøv igen", "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {   //Sæt dialogResult til OK Hvis AddCountry var en success
                if (Data.AddCountry(C))
                    DialogResult = DialogResult.OK;
            }
        }

        private void frmCountryCreator_Load(object sender, EventArgs e)
        {
            cbbVerdensdel.SelectedIndex = 0;
        }
    }
}
