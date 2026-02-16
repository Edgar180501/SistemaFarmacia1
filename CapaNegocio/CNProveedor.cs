using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CNProveedor
    {
        //Método Listar que llama al método Listar de la clase CDProveedor de la CapaDatos
        public static DataTable Listar()
        {
            CDProveedor Datos = new CDProveedor();
            return Datos.Listar();
        }
        //Método Guardar que llama al método Guardar de la clase CDProveedor de la CapaDatos
        public static string Guardar(string nombre, string telefono, string correo, string direccion, string rfc, string estado)
        {
            CDProveedor Datos = new CDProveedor();
            Datos.Nombre = nombre;
            Datos.Telefono = telefono;
            Datos.Correo = correo;
            Datos.Direccion = direccion;
            Datos.Rfc = rfc;
            Datos.Estado = estado;
            return Datos.Guardar(Datos);
        }
        //Método Editar que llama al método Editar de la clase CDProveedor de la CapaDatos
        public static string Editar(int id_proveedor, string nombre, string telefono, string correo, string direccion, string rfc, string estado)
        {
            CDProveedor Datos = new CDProveedor();
            Datos.Idproveedor = id_proveedor;
            Datos.Nombre = nombre;
            Datos.Telefono = telefono;
            Datos.Correo = correo;
            Datos.Direccion = direccion;
            Datos.Rfc = rfc;
            Datos.Estado = estado;
            return Datos.Editar(Datos);
        }
        //Método Eliminar que llama al método Eliminar de la clase CDProveedor de la CapaDatos
        public static string Eliminar(int id_proveedor)
        {
            CDProveedor Datos = new CDProveedor();
            Datos.Idproveedor = id_proveedor;
            return Datos.Eliminar(Datos);
        }
        //Método BuscarNombre que llama al método Buscar de la clase CDProveedor de la CapaDatos
        public static DataTable BuscarNombre(string textobuscar)
        {
            CDProveedor Datos = new CDProveedor();
            Datos.Buscar = textobuscar;
            return Datos.BuscarNombre(Datos);
        }
        //Método BuscarRfc que llama al método BuscarRfc de la clase CDProveedor de la CapaDatos
        public static DataTable Buscarrfc(string textobuscar)
        {
            CDProveedor Datos = new CDProveedor();
            Datos.Buscar = textobuscar;
            return Datos.Buscarrfc(Datos);
        }
    }
}
