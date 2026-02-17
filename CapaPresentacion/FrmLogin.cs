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
using static System.Collections.Specialized.BitVector32;

namespace CapaPresentacion
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
     
                // REEMPLAZA CON TU CADENA DE CONEXIÓN REAL
                string cadenaConexion = "Data Source = USUARIO-TVQNB7K; Initial Catalog =  dbfarmacia ;Integrated Security = True";

                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    // Consulta segura con parámetros para evitar inyección SQL
                    string query = "SELECT id_usuario, nombre_usuario, nombre_real FROM usuarios WHERE nombre_usuario = @user AND password = @pass";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@user", txtUsuario.Text);
                    cmd.Parameters.AddWithValue("@pass", txtPassword.Text);

                    try
                    {
                        con.Open();
                        SqlDataReader lector = cmd.ExecuteReader();

                        if (lector.Read())
                        {
                            // 1. Guardar datos en la clase Sesion
                            Sesion.IdUsuario = Convert.ToInt32(lector["id_usuario"]);
                            Sesion.NombreUsuario = lector["nombre_usuario"].ToString();
                            Sesion.NombreReal = lector["nombre_real"].ToString();

                            // 2. Abrir el formulario principal (Ajusta el nombre si es distinto)
                            FrmListadoProveedor menu = new FrmListadoProveedor();
                            this.Hide();
                            menu.Show();

                            // Cierra la aplicación totalmente al cerrar el menú
                            menu.FormClosed += (s, args) => this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al conectar: " + ex.Message);
                    }
                }
            }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_Click(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
    
}
    

