using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class CDProveedor
    {
        public int Idproveedor { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Rfc { get; set; }
        public string Estado { get; set; }

        public string Buscar { get; set; }
       

        public DataTable Listar()
        {
            DataTable resul = new DataTable("Proveedor");
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion.ConnectionString = Conexion.Conn;
                SqlCommand Cmd = new SqlCommand("splistar_Proveedor", conexion);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(Cmd);
                SqlDat.Fill(resul);
            }
            catch (Exception ex)
            {
                resul = null;
                throw ex;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return resul;
        }
        public string Guardar(CDProveedor prov)
        {
            string resul = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Conn;
                conexion.Open();
                SqlCommand Cmd = new SqlCommand("spguardar_Proveedor", conexion);
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.Parameters.AddWithValue("@id_proveedor", SqlDbType.Int).Direction = ParameterDirection.Output;

                Cmd.Parameters.AddWithValue("@nombre", prov.Nombre);
                Cmd.Parameters.AddWithValue("@telefono", prov.Telefono);
                Cmd.Parameters.AddWithValue("@correo", prov.Correo);
                Cmd.Parameters.AddWithValue("@direccion", prov.Direccion);
                Cmd.Parameters.AddWithValue("@rfc", prov.Rfc);

                resul = Cmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo insertar el registro";
            }
            catch (Exception ex)
            {
                resul = ex.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return resul;
        }
        public string Editar(CDProveedor cli)
        {
            string resul = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                // Abrir conexión a la base de datos
                conexion.ConnectionString = Conexion.Conn;
                conexion.Open();

                // Configurar el comando para ejecutar el stored procedure
                SqlCommand Cmd = new SqlCommand("speditar_Proveedor", conexion);
                Cmd.CommandType = CommandType.StoredProcedure;

                // Agregar parámetros del stored procedure
                Cmd.Parameters.AddWithValue("@id_proveedor", cli.Idproveedor);  // ID del cliente a actualizar
                Cmd.Parameters.AddWithValue("@nombre", cli.Nombre);
                Cmd.Parameters.AddWithValue("@direccion", cli.Direccion);
                Cmd.Parameters.AddWithValue("@rfc", cli.Rfc);
                Cmd.Parameters.AddWithValue("@telefono", cli.Telefono);
                Cmd.Parameters.AddWithValue("@correo", cli.Correo);
                Cmd.Parameters.AddWithValue("@estado", cli.Estado);

                // Ejecutar el stored procedure
                // ExecuteNonQuery() retorna el número de filas afectadas (debe ser 1)
                resul = Cmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo actualizar el registro";
            }
            catch (Exception ex)
            {
                resul = ex.Message;
            }
            finally
            {
                // Cerrar la conexión si está abierta
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return resul;
        }
        public string Eliminar(CDProveedor prov)
        {
            string resul = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Conn;
                conexion.Open();
                SqlCommand Cmd = new SqlCommand("speliminar_Proveedor", conexion);
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.Parameters.AddWithValue("@id_proveedor", prov.Idproveedor);

                resul = Cmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar el registro";
            }
            catch (Exception ex)
            {
                resul = ex.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return resul;
        }
        public DataTable BuscarNombre(CDProveedor prov)
        {
            DataTable resul = new DataTable("Proveedor");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Conn;
                SqlCommand Cmd = new SqlCommand("spbuscar_Proveedor_nombre", conexion);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@nombre", prov.Buscar);
                SqlDataAdapter SqlDat = new SqlDataAdapter(Cmd);
                SqlDat.Fill(resul);
            }
            catch (Exception ex)
            {
                resul = null;
                throw ex;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return resul;
        }
        public DataTable Buscarrfc(CDProveedor prov)
        {
            DataTable resul = new DataTable("Proveedor");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Conn;
                SqlCommand Cmd = new SqlCommand("spbuscar_Proveedor_rfc", conexion);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@rfc", prov.Buscar);
                SqlDataAdapter SqlDat = new SqlDataAdapter(Cmd);
                SqlDat.Fill(resul);
            }
            catch (Exception ex)
            {
                resul = null;
                throw ex;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return resul;
        }

   
    }

       
    
}