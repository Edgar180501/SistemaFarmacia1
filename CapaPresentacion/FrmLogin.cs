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
            string cadenaConexion = "Data Source = HPEDGAR; Initial Catalog =  dbfarmacia ;Integrated Security = True";

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
                        // 1. Guardar datos en la clase Sesion (ESTO SE QUEDA IGUAL)
                        Sesion.IdUsuario = Convert.ToInt32(lector["id_usuario"]);
                        Sesion.NombreUsuario = lector["nombre_usuario"].ToString();
                        Sesion.NombreReal = lector["nombre_real"].ToString();

                        // ------------------- LO NUEVO EMPIEZA AQUÍ -------------------

                        // IMPORTANTE: Debemos cerrar el lector antes de hacer otra consulta en la misma conexión
                        lector.Close();

                        // Insertamos el registro de inicio de sesión y obtenemos el ID generado
                        string queryAudit = "INSERT INTO auditoria_sesiones (id_usuario, nombre_usuario, fecha_inicio) VALUES (@id, @nom, GETDATE()); SELECT SCOPE_IDENTITY();";

                        SqlCommand cmdAudit = new SqlCommand(queryAudit, con);
                        cmdAudit.Parameters.AddWithValue("@id", Sesion.IdUsuario);
                        cmdAudit.Parameters.AddWithValue("@nom", Sesion.NombreUsuario);

                        // ExecuteScalar ejecuta la consulta y devuelve la primera columna de la primera fila (el ID)
                        object resultado = cmdAudit.ExecuteScalar();

                        if (resultado != null)
                        {
                            Sesion.IdSesionActual = Convert.ToInt32(resultado);
                        }

                        // ------------------- LO NUEVO TERMINA AQUÍ -------------------


                        // 2. Abrir el formulario principal (ESTO SE QUEDA IGUAL)
                        FrmListadoProveedor menu = new FrmListadoProveedor();
                        this.Hide();
                        menu.Show();

                        // Cierra la aplicación totalmente al cerrar el menú
                        menu.FormClosed += (s, args) =>
                        {
                            // --- NUEVO: Agregamos la llamada para registrar la salida ---
                            RegistrarSalida();
                            this.Close();
                        };
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

        // Pega esto debajo de tu método btnIngresar_Click (antes de la última llave de cierre de la clase)
        private void RegistrarSalida()
        {
            if (Sesion.IdSesionActual == 0) return; // Si no hay sesión iniciada, no hacemos nada

            string cadenaConexion = "Data Source = HPEDGAR; Initial Catalog =  dbfarmacia ;Integrated Security = True";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                try
                {
                    con.Open();
                    // Actualizamos la fecha de fin usando el ID que guardamos al entrar
                    string query = "UPDATE auditoria_sesiones SET fecha_fin = GETDATE() WHERE id_sesion = @idSesion";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@idSesion", Sesion.IdSesionActual);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Opcional: Manejo de errores silencioso al cerrar
                    Console.WriteLine("Error al cerrar sesión: " + ex.Message);
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
    

