using RegistroCotizacionDetalle.UI.Consulta;
using RegistroCotizacionDetalle.UI.Registro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistroCotizacionDetalle
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void PersonastoolStripButton_Click(object sender, EventArgs e)
        {
            UI.Registro.rPersonas r = new rPersonas();
            r.Show();
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Registro.rPersonas r = new rPersonas();
            r.Show();
        }

        private void ArticulostoolStripButton_Click(object sender, EventArgs e)
        {
            UI.Registro.rArticulos r = new rArticulos();
            r.Show();
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Registro.rArticulos r = new rArticulos();
            r.Show();
        }

        private void CotizacionestoolStripButton_Click(object sender, EventArgs e)
        {
            UI.Registro.rCotizaciones r = new rCotizaciones();
            r.Show();
        }

        private void cotizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Registro.rCotizaciones r = new rCotizaciones();
            r.Show();
        }

        private void personasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UI.Consulta.cPersonas c = new cPersonas();
            c.Show();
        }

        private void articuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Consulta.cPersonas c = new cPersonas();
            c.Show();
        }
    }
}
