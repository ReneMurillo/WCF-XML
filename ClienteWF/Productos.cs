using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClienteWF.ProductService;

namespace ClienteWF
{
    public partial class Productos : Form
    {
        int ProductoId = 0;
        public Productos()
        {
            InitializeComponent();
        }

        void LlenarGrid()
        {
            using (ProductService.ServiceProductClient cliente = new ServiceProductClient())
            {
                dtgProductos.DataSource = cliente.ListarProductos();
            }
        }


        void LimpiarCampos()
        {
            txtNombre.Text = txtDescripcion.Text = txtStock.Text = "";
            ProductoId = 0;
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text != "" && txtNombre.Text != "" && txtStock.Text != "")
            {
                Producto producto = new Producto();
                producto.Nombre = txtNombre.Text.Trim();
                producto.Precio = Convert.ToDecimal(txtDescripcion.Text.Trim());
                producto.Stock = Convert.ToInt32(txtStock.Text.Trim());
                using (ServiceProductClient cliente = new ServiceProductClient())
                {
                    if (btnCrear.Text == "Guardar")
                    {
                        var exito = cliente.CrearProducto(producto);
                        if (exito)
                        {
                            MessageBox.Show("Producto creado con éxito", "Creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LlenarGrid();
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("Algo salió mal, inténtelo nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    else
                    {
                        producto.ProductoId = ProductoId;
                        var exito = cliente.ActualizarProducto(producto);
                        if (exito)
                        {
                            MessageBox.Show("Producto actualizado con éxito", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LlenarGrid();
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("Algo salió mal, inténtelo nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe rellenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dtgProductos.CurrentRow.Cells[0].Value.ToString());
            using (ServiceProductClient cliente = new ServiceProductClient())
            {
                var producto = cliente.VerProducto(id);
                txtNombre.Text = producto.Nombre;
                txtDescripcion.Text = Convert.ToString(producto.Precio);
                txtStock.Text = Convert.ToString(producto.Stock);
                ProductoId = producto.ProductoId;
            }
            btnCrear.Text = "Actualizar";
            btnEliminar.Visible = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (ServiceProductClient cliente = new ServiceProductClient())
            {
                var exito = cliente.EliminarProducto(ProductoId);
                if (exito)
                {
                    MessageBox.Show("Producto eliminado con éxito", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LlenarGrid();
                    LimpiarCampos();
                    btnEliminar.Visible = false;
                }
                else
                {
                    MessageBox.Show("Algo salió mal, inténtelo nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(txtBuscar.Text != "")
            {
                using (ServiceProductClient cliente = new ServiceProductClient())
                {
                    dtgProductos.DataSource = cliente.Filtrar(txtBuscar.Text);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Inicio inicio = new Inicio();
            inicio.Show();
        }
    }
}
