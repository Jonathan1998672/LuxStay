using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto_MAD
{
    public partial class ReporteOcupacionHotel : Form
    {
        public ReporteOcupacionHotel()
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
            MenuAdministradores menuAdministradores = new MenuAdministradores();
            menuAdministradores.Show(this);
            Hide();
        }

        private void CargarReporte1(string pais, string ciudad, string Hotel, int? year)
        {
            var obj = new EnlaceDB();
            var table = new DataTable();
            table = obj.ReporteOcupacion(pais, ciudad, Hotel, year);
            GrdReporte1.DataSource = table;
            GrdReporte1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            GrdReporte1.Columns["NumMes"].Visible = false;
        }

        private void CargarReporte2(string pais, string ciudad, string Hotel, int? year)
        {
            var obj = new EnlaceDB();
            var table = new DataTable();
            table = obj.ReporteOcupacion2(pais, ciudad, Hotel, year);
            GrdReporte2.DataSource = table;
            GrdReporte2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            GrdReporte2.Columns["NumMes"].Visible = false;
        }
        private void ReporteOcupacionHotel_Load(object sender, EventArgs e)
        {
            var db = new EnlaceDB();
            DataTable paises = db.Get_Paises();

            DataRow filaTodos = paises.NewRow();
            filaTodos["PaisID"] = 0;
            filaTodos["Nombre"] = "Todos";
            paises.Rows.InsertAt(filaTodos, 0);

            ComBoxPais.DisplayMember = "Nombre";
            ComBoxPais.ValueMember = "PaisID";
            ComBoxPais.DataSource = paises;

            DataTable hoteles = db.Get_Hoteles();

            DataRow Filas = hoteles.NewRow();
            Filas["HotelID"] = 0;
            Filas["Nombre"] = "Todos";
            hoteles.Rows.InsertAt(Filas, 0);

            BoxHoteles.DisplayMember = "Nombre";
            BoxHoteles.ValueMember = "HotelID";
            BoxHoteles.DataSource = hoteles;

            BoxYears.SelectedIndex = 0;
        }

        private void cbPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComBoxPais.SelectedValue is int paisID)
            {
                EnlaceDB db = new EnlaceDB();
                DataTable ciudades = db.Get_CiudadesPorPais(paisID);

                DataRow filaTodos = ciudades.NewRow();
                filaTodos["CiudadID"] = 0;
                filaTodos["Nombre"] = "Todos";
                ciudades.Rows.InsertAt(filaTodos, 0);

                ComBoxCiudad.DisplayMember = "Nombre";
                ComBoxCiudad.ValueMember = "CiudadID";
                ComBoxCiudad.DataSource = ciudades;
            }
        }
        private void btnFiltrarHot_Click(object sender, EventArgs e)
        {
            string Hotel= BoxHoteles.Text;
            string pais= ComBoxPais.Text;
            string ciudad= ComBoxCiudad.Text;
            int? Year = null;

            if (!string.IsNullOrWhiteSpace(BoxYears.Text) && BoxYears.Text != "Todos")
            {
                Year = int.Parse(BoxYears.Text);
            }

            CargarReporte1(pais,ciudad,Hotel, Year);
            CargarReporte2(pais, ciudad, Hotel, Year);

        }

    }
}
