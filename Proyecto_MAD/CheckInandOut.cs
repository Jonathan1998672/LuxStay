using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;
using static Proyecto_MAD.MenuOperativos;

namespace Proyecto_MAD
{
    public partial class CheckInandOut : Form
    {
        private string Codigo {  get; set; }
        public bool ReservaBuscada {  get; set; }
        private string EstadoCkeckIn {  get; set; }
        private string EstadoCkeckOut { get; set; }
        private DateTime fechaCheckIn {  get; set; }
        private string fechaCheckInStr {  get; set; }

        public CheckInandOut()
        {
            InitializeComponent();
            this.FormClosing += Exit_FormClosing;
        }
        private void Exit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuOperativos menuOperativos = new MenuOperativos();
            menuOperativos.Show(this);
            Hide();
        }
        private void CheckInandOut_Load(object sender, EventArgs e)
        {
            if (Check_Seleccionado.Check == true)
            {
                label1.Enabled = false;//In
                label2.Enabled = true;//Out

                label3.Enabled = false;//In
                txtCodigoIn.Enabled = false;//In
                btnBuscarIn.Enabled = false;//In
                GrdReservacionesIn.Enabled = false;//In

                label4.Enabled = true;//Out
                txtCodigoOut.Enabled = true;//Out
                btnBuscarOut.Enabled = true;//Out
                GrdReservacionesOut.Enabled = true;//Out
                CargarReservasOut("TODOS", "");
                GrdReservacionesOut.SelectionChanged += GrdReservacionesOut_SelectionChanged;

            }
            else
            {
                label1.Enabled = true;//In
                label2.Enabled = false;//Out

                label4.Enabled = false;//Out
                txtCodigoOut.Enabled = false;//Out
                btnBuscarOut.Enabled = false;//Out
                GrdReservacionesOut.Enabled = false;//Out

                label3.Enabled = true;//In
                txtCodigoIn.Enabled = true;//In
                btnBuscarIn.Enabled = true;//In
                GrdReservacionesIn.Enabled = true;//In
                CargarReservasIn("TODOS", "");
                GrdReservacionesIn.SelectionChanged += GrdReservacionesIn_SelectionChanged;

            }
        }

        private void GrdReservacionesIn_SelectionChanged(object sender, EventArgs e)
        {
            if (GrdReservacionesIn.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = GrdReservacionesIn.SelectedRows[0];

                lbCodigo.Text = selectedRow.Cells["Codigo"].Value.ToString();
                lbNombreHotel.Text = selectedRow.Cells["Hotel"].Value.ToString();
                lbTipoHabitacion.Text = selectedRow.Cells["Tipo Habitacion"].Value.ToString();
                lbHabitacion.Text = selectedRow.Cells["Habitacion"].Value.ToString();
                lbPais.Text = selectedRow.Cells["Pais"].Value.ToString();
                lbCliente.Text = selectedRow.Cells["Cliente"].Value.ToString();
                lbCodigo.Visible = true;
                lbNombreHotel.Visible = true;
                lbTipoHabitacion.Visible = true;
                lbHabitacion.Visible = true;
                lbPais.Visible = true;
                lbCliente.Visible = true;

                btnCheckIn.Enabled = true;
                Codigo = selectedRow.Cells["Codigo"].Value.ToString();
                

                EstadoCkeckIn= selectedRow.Cells["CheckIn"].Value.ToString();
                fechaCheckIn = Convert.ToDateTime(selectedRow.Cells["FechaCheckIn"].Value);
                fechaCheckInStr = selectedRow.Cells["Fecha de Check In"].Value.ToString();
            }
        }

        private void GrdReservacionesOut_SelectionChanged(object sender, EventArgs e)
        {
            if (GrdReservacionesOut.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = GrdReservacionesOut.SelectedRows[0];

                lbCodigo.Text = selectedRow.Cells["Codigo"].Value.ToString();
                lbNombreHotel.Text = selectedRow.Cells["Hotel"].Value.ToString();
                lbTipoHabitacion.Text = selectedRow.Cells["Tipo Habitacion"].Value.ToString();
                lbHabitacion.Text = selectedRow.Cells["Habitacion"].Value.ToString();
                lbPais.Text = selectedRow.Cells["Pais"].Value.ToString();
                lbCliente.Text = selectedRow.Cells["Cliente"].Value.ToString();
                lbCodigo.Visible = true;
                lbNombreHotel.Visible = true;
                lbTipoHabitacion.Visible = true;
                lbHabitacion.Visible = true;
                lbPais.Visible = true;
                lbCliente.Visible = true;
                Codigo = selectedRow.Cells["Codigo"].Value.ToString();

                btnFactura.Enabled = true;
                fechaCheckIn = Convert.ToDateTime(selectedRow.Cells["FechaCheckIn"].Value);
                EstadoCkeckIn = selectedRow.Cells["CheckIn"].Value.ToString();
                EstadoCkeckOut = selectedRow.Cells["CheckOut"].Value.ToString();
                fechaCheckInStr = selectedRow.Cells["Fecha de Check In"].Value.ToString();

                DatosparaFactura.HotelID = int.Parse(selectedRow.Cells["HotelID"].Value.ToString());
                DatosparaFactura.TipoHabID = int.Parse(selectedRow.Cells["TipoHabID"].Value.ToString());
                DatosparaFactura.HabitacionID = int.Parse(selectedRow.Cells["HabitacionID"].Value.ToString());
                DatosparaFactura.ClienteID = int.Parse(selectedRow.Cells["ClienteID"].Value.ToString());
                DatosparaFactura.Codigo = selectedRow.Cells["Codigo"].Value.ToString();
                DatosparaFactura.NombreHotel= selectedRow.Cells["Hotel"].Value.ToString();
                DatosparaFactura.TipoHabitacion = selectedRow.Cells["Tipo Habitacion"].Value.ToString();
                DatosparaFactura.Habitacion = selectedRow.Cells["Habitacion"].Value.ToString();
                DatosparaFactura.Direccion = selectedRow.Cells["Domicilio"].Value.ToString();
                DatosparaFactura.NombreCliente = selectedRow.Cells["Cliente"].Value.ToString();
                DatosparaFactura.Correo = selectedRow.Cells["Correo"].Value.ToString();
                DatosparaFactura.celular = selectedRow.Cells["Celular"].Value.ToString();
                string fechaStr = selectedRow.Cells["FechaCheckIn"].Value.ToString();
                DatosparaFactura.fechaCheckIn = DateTime.Parse(fechaStr);
                string fechaStr2 = selectedRow.Cells["FechaCheckOut"].Value.ToString();
                DatosparaFactura.fechaCheckOut = DateTime.Parse(fechaStr2);
                DatosparaFactura.Pais = selectedRow.Cells["Pais"].Value.ToString();
                DatosparaFactura.Anticipo = Convert.ToDecimal(selectedRow.Cells["AnticipoNum"].Value);
                DatosparaFactura.AnticipoForm = selectedRow.Cells["Anticipo"].Value.ToString();
                DatosparaFactura.PrecioNoche = Convert.ToDecimal(selectedRow.Cells["PrecioNoche"].Value); 
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var obj = new EnlaceDB();
            DateTime fechaActual = DateTime.Today;
            if (EstadoCkeckIn == "Deshabilitado")
            {
                MessageBox.Show("Debes de realizar Check-In ");
                return;
            }
            if (fechaActual > fechaCheckIn)
            {
                
                if (EstadoCkeckOut == "Habilitado")
                {
                    MessageBox.Show("Check-Out ya realizado ");
                    return;
                }
                FacturaHospedaje facturaHospedaje = new FacturaHospedaje();
                facturaHospedaje.ShowDialog();
                if (ReservaBuscada)
                {
                    CargarReservasOut("CODIGO", Codigo);
                }
                else
                {
                    CargarReservasOut("TODOS", "");
                }
            }
            else
            {
                MessageBox.Show($"Solo puedes realizar Check-Out un dia despues de la fecha de Check-In: {fechaCheckInStr}");
            }
        }

        public static class DatosparaFactura
        {
            public static int HotelID { get; set; }
            public static int TipoHabID { get; set; }
            public static int HabitacionID { get; set; }
            public static int ClienteID { get; set; }
            public static string Codigo {  get; set; }
            public static string NombreHotel {  get; set; }
            public static string TipoHabitacion { get; set; }
            public static string Habitacion { get; set; }
            public static string Direccion {  get; set; }
            public static string NombreCliente {  get; set; }
            public static string Correo { get; set; }
            public static string celular { get; set; }
            public static DateTime fechaCheckIn { get; set; }
            public static DateTime fechaCheckOut { get; set; }
            public static string Pais {  get; set; }
            public static decimal Anticipo {  get; set; }
            public static string AnticipoForm { get; set; }
            public static decimal PrecioNoche {  get; set; }
        }

        private void CargarReservasIn(string filtro, string valor)
        {
            var obj = new EnlaceDB();
            var table = new DataTable();
            table = obj.Buscar_ReservacionesCheck(filtro, valor);
            GrdReservacionesIn.DataSource = table;
            GrdReservacionesIn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            GrdReservacionesIn.Columns["FechaCheckIn"].Visible = false;
            GrdReservacionesIn.Columns["FechaCheckOut"].Visible = false;
            GrdReservacionesIn.Columns["HotelID"].Visible = false;
            GrdReservacionesIn.Columns["TipoHabID"].Visible = false;
            GrdReservacionesIn.Columns["HabitacionID"].Visible = false;
            GrdReservacionesIn.Columns["ClienteID"].Visible = false;
            GrdReservacionesIn.Columns["Correo"].Visible = false;
            GrdReservacionesIn.Columns["Celular"].Visible = false;
            GrdReservacionesIn.Columns["AnticipoNum"].Visible = false;
            GrdReservacionesIn.Columns["PrecioNoche"].Visible = false;
        }
        public void CargarReservasOut(string filtro, string valor)
        {
            var obj = new EnlaceDB();
            var table = new DataTable();
            table = obj.Buscar_ReservacionesCheck(filtro, valor);
            GrdReservacionesOut.DataSource = table;
            GrdReservacionesOut.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            GrdReservacionesOut.Columns["FechaCheckIn"].Visible = false;
            GrdReservacionesOut.Columns["FechaCheckOut"].Visible = false;
            GrdReservacionesOut.Columns["HotelID"].Visible = false;
            GrdReservacionesOut.Columns["TipoHabID"].Visible = false;
            GrdReservacionesOut.Columns["HabitacionID"].Visible = false;
            GrdReservacionesOut.Columns["ClienteID"].Visible = false;
            GrdReservacionesOut.Columns["Correo"].Visible = false;
            GrdReservacionesOut.Columns["Celular"].Visible = false;
            GrdReservacionesOut.Columns["AnticipoNum"].Visible = false;
            GrdReservacionesOut.Columns["PrecioNoche"].Visible = false;
        }
        private void btnBuscarIn_Click(object sender, EventArgs e)
        {
            string valor = txtCodigoIn.Text;
            CargarReservasIn("CODIGO", valor);
            ReservaBuscada = true;
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            var obj= new EnlaceDB();
            DateTime fechaActual = DateTime.Today;


            if (EstadoCkeckIn == "Deshabilitado")
            {
                if (fechaActual == fechaCheckIn)
                {
                    obj.CheckIn(Codigo);

                    if (ReservaBuscada)
                    {
                        CargarReservasIn("CODIGO", Codigo);
                    }
                    else
                    {
                        CargarReservasIn("TODOS", "");
                    }

                }
                else
                {
                    MessageBox.Show($"Solo puedes hacer Check-In el día registrado: {fechaCheckInStr}");
                }
            }
            else
            {
                MessageBox.Show("Check-In ya Realizado");
            }
        }

        private void btnBuscarOut_Click(object sender, EventArgs e)
        {
            string valor = txtCodigoOut.Text;
            CargarReservasOut("CODIGO", valor);
            ReservaBuscada = true;
        }
    }
}
