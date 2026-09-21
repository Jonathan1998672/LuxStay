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
    public partial class MenuOperativos : Form
    {
        public MenuOperativos()
        {
            InitializeComponent();
            this.FormClosing += Exit_FormClosing;
        }
        private void Exit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void MenuOperativos_Load(object sender, EventArgs e)
        {
            lbCorreo.Text = SesionUsuario.Correo;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GestionClientes gestionClientes = new GestionClientes();
            gestionClientes.Show(this);
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reservaciones re = new Reservaciones();
            re.Show(this);
            Hide();
        }

        public static class Check_Seleccionado
        {
            public static bool Check { get; set; }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            CheckInandOut checkInandOut = new CheckInandOut();
            Check_Seleccionado.Check = false;
            checkInandOut.Show(this);
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CheckInandOut checkInandOut = new CheckInandOut();
            Check_Seleccionado.Check = true;
            checkInandOut.Show(this);
            Hide();
        }
    }
}
