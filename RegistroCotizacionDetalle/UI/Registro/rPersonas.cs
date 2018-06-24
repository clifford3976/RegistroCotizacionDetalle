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
    public partial class rPersonas : Form
    {
        public rPersonas()
        {
            InitializeComponent();
        }

        private bool Validar()
        {
            bool Errores = false;

            if (String.IsNullOrWhiteSpace(TelefonomaskedTextBox.Text))
            {
                errorProvider1.SetError(TelefonomaskedTextBox,
                    "llenar el campo de telefono");
                Errores = true;
            }
            if (String.IsNullOrWhiteSpace(NombretextBox.Text))
            {
                errorProvider1.SetError(NombretextBox,
                     "llenar el campo de nombre");
                Errores = true;
            }
            if (String.IsNullOrWhiteSpace(DirecciontextBox.Text))
            {

                errorProvider1.SetError(DirecciontextBox,
                    "llenar el campo de direccion");
                Errores = true;
            }
            if (String.IsNullOrWhiteSpace(CedulamaskedTextBox.Text))
            {

                errorProvider1.SetError(CedulamaskedTextBox,
                    "llenar el campo de cedula");
                Errores = true;
            }

            return Errores;
        }

        private Personas LlenaClase()
        {
            Personas Persona = new Personas();

            Persona.PersonaId = Convert.ToInt32(IdnumericUpDown.Value);
            Persona.Fecha = FechadateTimePicker.Value;
            Persona.Nombres = NombretextBox.Text;
            Persona.Cedula = CedulamaskedTextBox.Text;
            Persona.Direccion = DirecciontextBox.Text;
            Persona.Telefono = TelefonomaskedTextBox.Text;

            return Persona;
        }


        private void Nuevobutton_Click(object sender, EventArgs e)
        {

            IdnumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            NombretextBox.Clear();
            CedulamaskedTextBox.Clear();
            DirecciontextBox.Clear();
            TelefonomaskedTextBox.Clear();
            errorProvider1.Clear();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Personas Persona;
            bool Paso = false;


            Persona = LlenaClase();

           
            if (IdnumericUpDown.Value == 0)
                Paso = BLL.PersonasBLL.Guardar(Persona);
            else
                
                Paso = BLL.PersonasBLL.Modificar(Persona);

            if (Paso)
                MessageBox.Show("Guardado!!", "Exitosamente",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se guardo!!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);

            if (BLL.PersonasBLL.Eliminar(id))
                MessageBox.Show("Eliminado!!", "Exitosamente",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se elimino!!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Personas Persona = BLL.PersonasBLL.Buscar(id);

            if (Persona != null)
            {
                FechadateTimePicker.Value = Persona.Fecha;
                NombretextBox.Text = Persona.Nombres;
                CedulamaskedTextBox.Text = Persona.Cedula;
                DirecciontextBox.Text = Persona.Direccion;
                TelefonomaskedTextBox.Text = Persona.Telefono;
            }
            else
                MessageBox.Show("No se encontro!", "Buscar de nuevo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
