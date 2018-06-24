using RegistroCotizacionDetalle.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistroCotizacionDetalle.UI.Registro
{
    public partial class rArticulos : Form
    {
        public rArticulos()
        {
            InitializeComponent();
        }

        private bool Validar(int validar)
        {

            bool paso = false;
            if (validar == 1 && IdnumericUpDown.Value == 0)
            {
                errorProvider1.SetError(IdnumericUpDown, "digite el ID");
                paso = true;

            }
            if (validar == 2 && DescripciontextBox.Text == string.Empty)
            {
                errorProvider1.SetError(DescripciontextBox, "digite la descripcion");
                paso = true;
            }
            if (validar == 2 && PrecionumericUpDown.Value == 0)
            {

                errorProvider1.SetError(PrecionumericUpDown, "digite el precio");
                paso = true;
            }
            if (validar == 2 && CantidadCotizadonumericUpDown.Value == 0)
            {

                errorProvider1.SetError(CantidadCotizadonumericUpDown, "digite la cantidad cotizada");

            }
            return paso;

        }

        private Articulos LlenarClase()
        {

            Articulos Articulo = new Articulos();

            Articulo.ArticuloID = Convert.ToInt32(IdnumericUpDown.Value);
            Articulo.FechaVencimiento = FechadateTimePicker.Value;
            Articulo.Descripcion = DescripciontextBox.Text;
            Articulo.Precio = Convert.ToInt32(PrecionumericUpDown.Value);
            Articulo.CantidadCotizado = Convert.ToInt32(CantidadCotizadonumericUpDown.Value);

            return Articulo;
        }


        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IdnumericUpDown.Value = 0;
            DescripciontextBox.Clear();
            PrecionumericUpDown.Value = 0;
            CantidadCotizadonumericUpDown.Value = 0;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            if (Validar(2))
            {

                MessageBox.Show("Llenar los campos");
                return;
            }

            errorProvider1.Clear();

            if (IdnumericUpDown.Value == 0)
                paso = BLL.ArticulosBLL.Guardar(LlenarClase());
            else
                paso = BLL.ArticulosBLL.Modificar(LlenarClase());

            if (paso)

                MessageBox.Show("Guardado", "Exitosamente",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se guardo", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (Validar(1))
            {
                MessageBox.Show("digite un ID");
                return;
            }

            int id = Convert.ToInt32(IdnumericUpDown.Value);

            if (BLL.ArticulosBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exitosamente",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se elimino", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (Validar(1))
            {
                MessageBox.Show("digite un ID");
                return;
            }

            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Articulos Articulo = BLL.ArticulosBLL.Buscar(id);

            if (Articulo != null)
            {

                DescripciontextBox.Text = Articulo.Descripcion; ;
                PrecionumericUpDown.Value = Articulo.Precio;
                FechadateTimePicker.Value = Articulo.FechaVencimiento;
                CantidadCotizadonumericUpDown.Value = Articulo.CantidadCotizado;

            }
            else
                MessageBox.Show("No se encontro", "Buscar de nuevo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
