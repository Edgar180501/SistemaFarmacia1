using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmListadoProveedor : Form
    {
        public FrmListadoProveedor()
        {
            InitializeComponent();
        }

        private void FrmListadoProveedor_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;           
            
            Mostrar();
        }

        //Método para mostrar los registros en el DataGridView
        public void Mostrar()
        {
            this.dlistado.DataSource = CNProveedor.Listar();
        }
        //Método para buscar clientes por nombre
        public void BuscarNombre()
        {
            this.dlistado.DataSource = CNProveedor.BuscarNombre(txtbuscar.Text);
        }
        //Método para buscar clientes por RFC
        public void Buscarrfc()
        {
            this.dlistado.DataSource = CNProveedor.Buscarrfc(txtbuscar.Text);
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (rbtnnombre.Checked)
            {
                BuscarNombre();
            }
            else if (rbtnrfc.Checked)
            {
                Buscarrfc();
            }
            else
            {
                MessageBox.Show("Seleccione un criterio de búsqueda.",
                        "Sistema de Ventas",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            FrmRegistrarProveedor form = new FrmRegistrarProveedor();

            form.Insert = true;

            form.Show();
            this.Hide();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            FrmRegistrarProveedor form = new FrmRegistrarProveedor();

            form.Edit = true;

            form.txtid_proveedor.Text = this.dlistado.CurrentRow.Cells["id_proveedor"].Value.ToString();
            form.txtnombre.Text = this.dlistado.CurrentRow.Cells["nombre"].Value.ToString();
            form.txttelefono.Text = this.dlistado.CurrentRow.Cells["telefono"].Value.ToString();
            form.txtcorreo.Text = this.dlistado.CurrentRow.Cells["correo"].Value.ToString();
            form.txtdireccion.Text = this.dlistado.CurrentRow.Cells["direccion"].Value.ToString();
            form.txtrfc.Text = this.dlistado.CurrentRow.Cells["rfc"].Value.ToString();

            string estado = this.dlistado.CurrentRow.Cells["estado"].Value.ToString();

            if (estado == "Activo")
            {
                form.rbtnactivo.Checked = true;
            }
            else
            {
                form.rbtninactivo.Checked = true;
            }

            form.Show();
            this.Hide();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("¿Realmente desea eliminar el(los) registro(s)?",
                    "Sistema de Farmacia",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);
                if (dlistado.SelectedRows.Count > 0)
                {
                    if (opcion == DialogResult.OK)
                    {
                        string id_proveedor = dlistado.CurrentRow.Cells["id_proveedor"].Value.ToString();
                        CNProveedor.Eliminar(Convert.ToInt32(id_proveedor));

                        MessageBox.Show("Registro eliminado",
                            "Sistema de Farmacia",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        Mostrar();
                    }
                }
                Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
