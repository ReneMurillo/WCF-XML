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
    public partial class Form1 : Form
    {
        int CategoriaId = 0;
        public Form1()
        {
            InitializeComponent();
        }

        void LlenarGrid()
        {
            using (ProductService.ServiceProductClient cliente = new ServiceProductClient())
            {
                dtgCategorias.DataSource = cliente.ListarCategorias();
            }
        }

        void LimpiarCampos()
        {
            txtNombre.Text = txtDescripcion.Text = "";
            CategoriaId = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if(txtDescripcion.Text != "" && txtNombre.Text != "")
            {
                Categoria categoria = new Categoria();
                categoria.Nombre = txtNombre.Text.Trim();
                categoria.Descripcion = txtDescripcion.Text.Trim();

                using (ServiceProductClient cliente = new ServiceProductClient())
                {
                    if (btnCrear.Text == "Guardar")
                    {
                        var exito = cliente.CrearCategoria(categoria);
                        if (exito)
                        {
                            MessageBox.Show("Categoría creada con éxito", "Creada", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        categoria.CategoriaId = CategoriaId;
                        var exito = cliente.ActualizarCategoria(categoria);
                        if (exito)
                        {
                            MessageBox.Show("Categoría actualizada con éxito", "Actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dtgCategorias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dtgCategorias.CurrentRow.Cells[0].Value.ToString());
            using (ServiceProductClient cliente = new ServiceProductClient())
            {
                var categoria = cliente.VerCategoria(id);
                txtNombre.Text = categoria.Nombre;
                txtDescripcion.Text = categoria.Descripcion;
                CategoriaId = categoria.CategoriaId;
            }
            btnCrear.Text = "Actualizar";
            btnEliminar.Visible = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (ServiceProductClient cliente = new ServiceProductClient())
            {
                var exito = cliente.EliminarCategoria(CategoriaId);
                if (exito)
                {
                    MessageBox.Show("Categoría eliminada con éxito", "Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LlenarGrid();
                    LimpiarCampos();
                    btnEliminar.Visible = false;
                    btnCrear.Text = "Guardar";
                }
                else
                {
                    MessageBox.Show("Algo salió mal, inténtelo nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
