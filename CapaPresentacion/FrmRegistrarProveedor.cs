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
    public partial class FrmRegistrarProveedor : Form
    {
        public bool Insert = false;
        public bool Edit = false;
        public FrmRegistrarProveedor()
        {
            InitializeComponent();
        }

        private void FrmRegistrarProveedor_load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FrmRegistrarProveedor_Load(object sender, EventArgs e)
        {

        }

        private void txtid_proveedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtrfc_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbtnactivo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtninactivo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string estado = "";
            if (rbtnactivo.Checked == true)
            {
                estado = "ACTIVO";
            }
            else
            {
                estado = "INACTIVO";
            }

            try
            {
                if (this.txtnombre.Text == string.Empty || this.txttelefono.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese los datos del proveedor", "Sistema de Farmacia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (this.Insert == true)
                    {
                        CNProveedor.Guardar(this.txtnombre.Text,
                                            this.txttelefono.Text,
                                            this.txtcorreo.Text,
                                            this.txtdireccion.Text,
                                            this.txtrfc.Text,
                                            estado);
                        MessageBox.Show("Proveedor registrado correctamente", "Sistema de Farmacia",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (this.Edit == true)
                    {
                        CNProveedor.Editar(Convert.ToInt32(this.txtid_proveedor.Text),
                                           this.txtnombre.Text,
                                           this.txttelefono.Text,
                                           this.txtcorreo.Text,
                                           this.txtdireccion.Text,
                                           this.txtrfc.Text,
                                           estado);
                        MessageBox.Show("Proveedor editado correctamente", "Sistema de Farmacia",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Insert = false;
                    this.Edit = false;

                    FrmListadoProveedor form = new FrmListadoProveedor();
                    form.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            FrmListadoProveedor form = new FrmListadoProveedor();
            form.Show();
            this.Hide();
        }
    }
}