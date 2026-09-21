using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Proyecto_MAD.Form1;

namespace Proyecto_MAD
{
    public partial class MenuAdministradores : Form
    {
        public MenuAdministradores()
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
            Application.Restart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GestionUsuarios gestionUsuarios = new GestionUsuarios();
            gestionUsuarios.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GestionHoteles gestionHoteles = new GestionHoteles();
            gestionHoteles.Show();
            Hide();
        }

        private void MenuAdministradores_Load(object sender, EventArgs e)
        {
            lbCorreo.Text = SesionUsuario.Correo;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Historial_Cliente historial_Cliente = new Historial_Cliente();
            historial_Cliente.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ReporteVentas reporteVentas = new ReporteVentas();
            reporteVentas.Show();
            Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ReporteOcupacionHotel reporOcHot = new ReporteOcupacionHotel();
            reporOcHot.Show();
            Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Cancelaciones cancelaciones = new Cancelaciones();
            cancelaciones.Show();
            Hide();
        }
    }
}
