using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Auditoria
    {
        private CD_Auditoria objetoCD = new CD_Auditoria();

        public DataTable MostrarAuditoria(string rolUsuario)
        {
            // Validamos que el rol sea exactamente 'admin'
            if (rolUsuario.ToLower() == "admin")
            {
                return objetoCD.ListarSesiones();
            }
            else
            {
                return null; // O podrías lanzar una excepción
            }
        }
    }
}