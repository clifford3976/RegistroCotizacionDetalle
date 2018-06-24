using RegistroCotizacionDetalle.DAL;
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
    public partial class rCotizaciones : Form
    {
        public rCotizaciones()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Cotizaciones Cotizacion = BLL.CotizacionesBLL.Buscar(id);

            if (Cotizacion != null)
            {
                LlenarCampos(Cotizacion);
            }
            else
                MessageBox.Show("No se encontro!", "Buscar de nuevo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IdnumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            ObservacionesrichTextBox.Clear();
            CantidadtextBox.Clear();
            PreciotextBox.Clear();
            ImportetextBox.Clear();
            TotalnumericUpDown.Value = 0;

            DetalledataGridView.DataSource = null;
            errorProvider1.Clear();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Cotizaciones Cotizacion;
            bool Paso = false;

            if (Errores())
            {
                MessageBox.Show("revisar los campos", "Validar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cotizacion = LlenaClase();

            
            if (IdnumericUpDown.Value == 0)
                Paso = BLL.CotizacionesBLL.Guardar(Cotizacion);
            else
             
                Paso = BLL.CotizacionesBLL.Modificar(Cotizacion);

         
            if (Paso)
            {
                Nuevobutton.PerformClick();
                MessageBox.Show("Guardado!!", "Exitosamente",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se guardo!!", "trata de nuevo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);

           
            if (BLL.CotizacionesBLL.Eliminar(id))
                MessageBox.Show("fue eliminado!!", "Exitosamente",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se elimino!!", "trata de nuevo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            List<CotizacionesDetalle> Detalle = new List<CotizacionesDetalle>();

            if (DetalledataGridView.DataSource != null)
            {
                Detalle = (List<CotizacionesDetalle>)DetalledataGridView.DataSource;
            }

            
            Detalle.Add(
                new CotizacionesDetalle(
                    id: 0,
                    cotizacionId: (int)IdnumericUpDown.Value,
                    personaId: (int)PersonacomboBox.SelectedValue,
                    articuloId: (int)ArticulocomboBox.SelectedValue,
                    cantidad: (int)Convert.ToInt32(CantidadtextBox.Text),
                    precio: (int)Convert.ToInt32(PreciotextBox.Text),
                    importe: (int)Convert.ToInt32(ImportetextBox.Text)

                ));

            DetalledataGridView.DataSource = null;
            DetalledataGridView.DataSource = Detalle;
        }

        private void LlenarComboBox()
        {
            Repositorio<Personas> repositorio = new Repositorio<Personas>(new Contexto());
            Repositorio<Articulos> repositori = new Repositorio<Articulos>(new Contexto());
            PersonacomboBox.DataSource = repositorio.GetList(c => true);
            PersonacomboBox.ValueMember = "PersonaId";
            PersonacomboBox.DisplayMember = "Nombres";

            ArticulocomboBox.DataSource = repositori.GetList(c => true);
            ArticulocomboBox.ValueMember = "ArticuloId";
            ArticulocomboBox.DisplayMember = "Descripcion";
        }

        private Cotizaciones LlenaClase()
        {
            Cotizaciones Cotizacion = new Cotizaciones();

            Cotizacion.CotizacionId = Convert.ToInt32(IdnumericUpDown.Value);
            Cotizacion.Fecha = FechadateTimePicker.Value;
            Cotizacion.Comentario = ObservacionesrichTextBox.Text;

            
            foreach (DataGridViewRow item in DetalledataGridView.Rows)
            {
                Cotizacion.AgregarDetalle(
                    ToInt(item.Cells["id"].Value),
                    ToInt(item.Cells["CotizacionId"].Value),
                    ToInt(item.Cells["PersonaId"].Value),
                    ToInt(item.Cells["ArticuloId"].Value),
                    ToInt(item.Cells["Cantidad"].Value),
                    ToInt(item.Cells["Precio"].Value),
                    ToInt(item.Cells["Importe"].Value)
                  );
            }
            return Cotizacion;
        }

        private bool Errores()
        {
            bool Errores = false;

            if (String.IsNullOrWhiteSpace(ObservacionesrichTextBox.Text))
            {
                errorProvider1.SetError(ObservacionesrichTextBox,
                    "llenar el comentario");
                Errores = true;
            }

            if (String.IsNullOrWhiteSpace(CantidadtextBox.Text))
            {
                errorProvider1.SetError(CantidadtextBox,
                    "Digite una cantidad");
                Errores = true;
            }

            if (String.IsNullOrWhiteSpace(PreciotextBox.Text))
            {
                errorProvider1.SetError(PreciotextBox,
                    "Digite el precio");
                Errores = true;
            }

            if (String.IsNullOrWhiteSpace(ImportetextBox.Text))
            {
                errorProvider1.SetError(ImportetextBox,
                    "Digite un importe");
                Errores = true;
            }

            if (DetalledataGridView.RowCount == 0)
            {
                errorProvider1.SetError(DetalledataGridView,
                    "Es obligatorio llenar este campo");
                Errores = true;
            }

            return Errores;
        }

        private int ToInt(object valor)
        {
            int retornar = 0;

            int.TryParse(valor.ToString(), out retornar);

            return retornar;
        }

        private void LlenarCampos(Cotizaciones Cotizacion)
        {
            IdnumericUpDown.Value = Cotizacion.CotizacionId;
            FechadateTimePicker.Value = Cotizacion.Fecha;
            ObservacionesrichTextBox.Text = Cotizacion.Comentario;

           
            DetalledataGridView.DataSource = Cotizacion.Detalle;

         
            DetalledataGridView.Columns["Id"].Visible = false;
            DetalledataGridView.Columns["CotizacionId"].Visible = false;
        }

        private void PreciotextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToInt32(PreciotextBox.Text) != 0)
                {

                    TotalnumericUpDown.Value += Convert.ToInt32(PreciotextBox.Text);

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

       
    }
}
