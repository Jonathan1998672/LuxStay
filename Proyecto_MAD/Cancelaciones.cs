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

namespace Proyecto_MAD
{
    public partial class Cancelaciones : Form
    {
        private bool ReservaSelecc {  get; set; }
        private string Codigo {  get; set; }
        private string Hotel {  get; set; }
        private DateTime fechaCheckIn {  get; set; }
        private string Estatus {  get; set; }
        public Cancelaciones()
        {
            InitializeComponent();
            this.FormClosing += Exit_FormClosing;
        }
        private void Exit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void CargarReservas(string filtro, string valor)
        {
            var obj = new EnlaceDB();
            var table = new DataTable();
            table = obj.Buscar_ReservacionesCancelar(filtro, valor);
            GrdReservaciones.DataSource = table;
            GrdReservaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            GrdReservaciones.Columns["FechaCheckIn"].Visible = false;
            GrdReservaciones.Columns["FechaCheckOut"].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuAdministradores menuAdministradores = new MenuAdministradores();
            menuAdministradores.Show(this);
            Hide();
        }

        private void Cancelaciones_Load(object sender, EventArgs e)
        {
            CargarReservas("TODOS", "");
            GrdReservaciones.SelectionChanged += GrdReservaciones_SelectionChanged;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string valor = txtCodigo.Text;
            CargarReservas("CODIGO", valor);
        }

        private void GrdReservaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (GrdReservaciones.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = GrdReservaciones.SelectedRows[0];

                ReservaSelecc = true;
                Codigo = selectedRow.Cells["Codigo"].Value.ToString();
                Hotel = selectedRow.Cells["Hotel"].Value.ToString();
                fechaCheckIn = Convert.ToDateTime(selectedRow.Cells["FechaCheckIn"].Value);
                Estatus= selectedRow.Cells["Estatus"].Value.ToString();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (ReservaSelecc == true)
            {
                DateTime fechaLimiteCancelacion = fechaCheckIn.AddDays(-3);

                if (Estatus == "Pendiente")
                {
                    if (DateTime.Now > fechaLimiteCancelacion)
                    {
                        MessageBox.Show($"No se puede cancelar la reservación.\n\nSolo se permiten cancelaciones hasta 3 días antes de la fecha de Check In ({fechaLimiteCancelacion:dd/MM/yyyy}).",
                                      "Cancelación no permitida",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Stop);
                        return;
                    }

                    DialogResult result = MessageBox.Show(
                        $"¿Estás seguro que deseas cancelar la reservación {Codigo} del hotel {Hotel}?\n\nEsta acción no se podrá deshacer.",
                        "Confirmar cancelación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        var obj = new EnlaceDB();
                        obj.CancelarReservacion(Codigo);
                        CargarReservas("TODOS", "");
                        txtCodigo.Clear();
                        ReservaSelecc = false;
                    }
                }
                else
                {
                    MessageBox.Show("Cancelación ya Realizado");
                }
            }
            else
            {
                MessageBox.Show("Selecciona una reservación para cancelar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }







    }
}
