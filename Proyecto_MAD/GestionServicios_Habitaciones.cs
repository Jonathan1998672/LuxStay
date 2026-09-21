using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_MAD
{
    public partial class GestionServicios_Habitaciones : Form
    {
        public GestionServicios_Habitaciones()
        {
            InitializeComponent();
            this.FormClosing += Exit_FormClosing;
        }
        private void Exit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GestionHoteles gestionHoteles = new GestionHoteles();
            gestionHoteles.Show(this);
            Hide();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void GestionServicios_Habitaciones_Load(object sender, EventArgs e)
        {

        }
    }
}
