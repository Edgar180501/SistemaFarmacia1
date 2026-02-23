using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmBitacora : Form
    {
        public FrmBitacora()
        {
            InitializeComponent();
        }

        private void dgvBitacora_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmBitacora_Load(object sender, EventArgs e)
        {
            string cadenaConexion = "Data source = HPEDGAR; Initial Catalog = dbfarmacia; Integrated Security = true";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                // Traemos todo de la tabla bitácora ordenado por lo más reciente
                string query = "SELECT * FROM Bitacora ORDER BY fecha_hora DESC";

                SqlDataAdapter adaptador = new SqlDataAdapter(query, con);
                System.Data.DataTable dt = new System.Data.DataTable();

                try
                {
                    adaptador.Fill(dt);
                    dgvBitacora.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar bitácora: " + ex.Message);
                }
            }
        }
    }
}
