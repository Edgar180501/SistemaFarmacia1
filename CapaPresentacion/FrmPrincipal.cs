using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        // 1. MÉTODO PARA ABRIR FORMULARIOS DENTRO DEL PANEL
        // Este método recibe cualquier formulario y lo mete en el panel central
        private void AbrirFormularioEnPanel(object formHijo)
        {
            // Si el panel ya tiene un formulario, lo eliminamos para poner el nuevo
            if (this.panelCentral.Controls.Count > 0)
                this.panelCentral.Controls.RemoveAt(0);

            Form fh = formHijo as Form;
            fh.TopLevel = false; // Decimos que no es una ventana independiente
            fh.FormBorderStyle = FormBorderStyle.None; // Le quitamos los bordes
            fh.Dock = DockStyle.Fill; // Que se estire para llenar todo el panel

            this.panelCentral.Controls.Add(fh); // Lo agregamos al panel
            this.panelCentral.Tag = fh;
            fh.Show(); // ¡Listo! El formulario aparece dentro
        }

        // 2. EVENTOS DE TUS BOTONES DEL MENÚ
        // Supongamos que tienes un botón llamado btnProveedores
        private void btnProveedores_Click(object sender, EventArgs e)
        {
            // Llamamos al método y le pasamos el formulario que quieres ver
            AbrirFormularioEnPanel(new FrmListadoProveedor());
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FrmBitacora());
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            // Opcional: Puedes cargar una pantalla de bienvenida al iniciar
            // AbrirFormularioEnPanel(new FrmBienvenida());
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FrmRegistrarProveedor());
        }

        private void btnProveedores_Click_1(object sender, EventArgs e)
        {
            // Reemplaza 'panelCentral' por el nombre que le pusiste a tu panel del medio
            AbrirFormularioEnPanel(new FrmListadoProveedor());
        }

        private void btnBitácora_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FrmBitacora());
        }
    }
}
