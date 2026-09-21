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
using static Proyecto_MAD.CalendarioHabitaciones;

namespace Proyecto_MAD
{
    public partial class Historial_Cliente : Form
    {
        public Historial_Cliente()
        {
            InitializeComponent();
            this.FormClosing += Exit_FormClosing;
        }
        private void Exit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CargarHistorial(string filtro, string valor)
        {
            var obj = new EnlaceDB();
            var table = new DataTable();
            table = obj.HistorialCliente(filtro, valor);
            GrdHistorial.DataSource = table;
            GrdHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void Historial_Cliente_Load(object sender, EventArgs e)
        {
            BoxFiltro.SelectedIndex = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MenuAdministradores menuAdministradores = new MenuAdministradores();
            menuAdministradores.Show(this);
            Hide();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string Filtro = BoxFiltro.Text;
            string valor = txtFiltro.Text;
            CargarHistorial(Filtro, valor);
            txtFiltro.Enabled = true;
            btnYear.Enabled = true;
            txtYear.Clear();
        }
        private void btnYear_Click(object sender, EventArgs e)
        {
            string texto = txtYear.Text.Trim();
            if (string.Equals(texto, "todos", StringComparison.OrdinalIgnoreCase))
            {
                if (GrdHistorial.DataSource is DataTable dt)
                {
                    dt.DefaultView.RowFilter = "";
                }
            }
            else if (int.TryParse(texto, out int year))
            {
                if (year >= 1900 && year <= 2100)
                {
                    if (GrdHistorial.DataSource is DataTable dt)
                    {
                        var columnType = dt.Columns["Fecha de Check In"].DataType;
                        if (columnType == typeof(DateTime))
                        {
                            dt.DefaultView.RowFilter = $"YEAR(CONVERT([Fecha de Check In], 'System.DateTime')) = {year}";
                        }
                        else
                        {
                            dt.DefaultView.RowFilter = $"[Fecha de Check In] LIKE '%{year}'";
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un año válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
