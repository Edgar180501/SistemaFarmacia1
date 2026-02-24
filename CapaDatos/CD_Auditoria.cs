using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Auditoria
    {
        private Conexion conexion = new Conexion();

        public DataTable ListarSesiones()
        {
            DataTable tabla = new DataTable();
            using (SqlConnection con = conexion.AbrirConexion())
            {
                string query = "SELECT * FROM auditoria_sesiones";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader leer = cmd.ExecuteReader();
                tabla.Load(leer);
            }
            return tabla;
        }
    }
}
