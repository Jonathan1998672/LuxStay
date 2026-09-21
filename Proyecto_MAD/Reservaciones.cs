using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;
using static Proyecto_MAD.CalendarioHabitaciones;
using static Proyecto_MAD.Form1;

namespace Proyecto_MAD
{
    public partial class Reservaciones : Form

    {
        private decimal Total {  get; set; }
        private int IDClienteSelec {  get; set; }
        public Reservaciones()
        {
            InitializeComponent();
            this.FormClosing += Exit_FormClosing;
        }
        private void Exit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ConfigurarNumericUpDown()
        {
            int valorMaximo = Convert.ToInt32(lbCapacidad.Text);

            NumHosped.Maximum = valorMaximo;
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            decimal cantidadNoches = NumHosped.Value;

            decimal total = cantidadNoches * TipoHabitacionReservado.preciodecimal;

            decimal totalConDosDecimales = Math.Round(total, 2);
            string totalConPunto = totalConDosDecimales.ToString("0.00", CultureInfo.InvariantCulture);
            Total = decimal.Parse(totalConPunto, CultureInfo.InvariantCulture);


            string totalFormateado = total.ToString("N2", new System.Globalization.CultureInfo("es-MX"));
            lbTotal.Text = $"${totalFormateado}";

            btnReservar.Enabled = true;
        }

        private void cbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CoBFiltro.SelectedItem.ToString().ToUpper() == "TODOS")
            {
                txtFiltro.Enabled = false;
                txtFiltro.Text = "";
            }
            else
            {
                txtFiltro.Enabled = true;
            }
        }

        private void CargarClientes(string filtro, string valor)
        {
            var obj = new EnlaceDB();
            var table = new DataTable();
            table = obj.Buscar_Clientes(filtro, valor);
            GrdClientes.DataSource = table;
            GrdClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void Reservaciones_Load(object sender, EventArgs e)
        {
            CoBFiltro.SelectedIndex = 0;
            CargarClientes("TODOS", "");
            GrdClientes.SelectionChanged += GrdClientes_SelectionChanged;
            GrdHoteles.SelectionChanged += GrdHoteles_SelectionChanged;
            NumHosped.ValueChanged += NumericUpDown_ValueChanged;

            var db = new EnlaceDB();
            DataTable paises = db.Get_Paises();

            DataRow filaTodos = paises.NewRow();
            filaTodos["PaisID"] = 0;
            filaTodos["Nombre"] = "Todos";
            paises.Rows.InsertAt(filaTodos, 0);

            ComBoxPais.DisplayMember = "Nombre";
            ComBoxPais.ValueMember = "PaisID";
            ComBoxPais.DataSource = paises;
        }

        private void ComBoxPais_SelectedIndexChanged(object sender, EventArgs e)
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

        public void EstablecerDatosReserva(string fechaInicio, string fechaFin, string habitacion, string seleccionComboBox, string precio, string capacidad)
        {
            lbFechaIN.Text = $"{fechaInicio}";
            lbFechaOUT.Text = $"{fechaFin}";
            lbHabitacion.Text = $"{habitacion}";
            lbTipHabi.Text = $"{seleccionComboBox}";
            lbPrecio.Text = $"{precio}";
            lbCapacidad.Text = $"{capacidad}";
            NumHosped.Enabled = true ;
            ConfigurarNumericUpDown();
            NumHosped.Value = 0;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            MenuOperativos menuOperativos = new MenuOperativos();
            menuOperativos.Show(this);
            Hide();
        }

        private void btnSelecHab_Click(object sender, EventArgs e)
        {
            CalendarioHabitaciones calendarioHabitaciones = new CalendarioHabitaciones(this);
            calendarioHabitaciones.ShowDialog();
        }

        private void GrdClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GrdClientes_SelectionChanged(object sender, EventArgs e)
        {
            if(GrdClientes.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = GrdClientes.SelectedRows[0];

                lbNombre.Text = selectedRow.Cells["Nombre"].Value.ToString() + " " + selectedRow.Cells["Apellidos"].Value.ToString();
                lbRFC.Text = selectedRow.Cells["RFC"].Value.ToString();
                IDClienteSelec= int.Parse(selectedRow.Cells["ClienteID"].Value.ToString());
                ComBoxPais.Enabled = true;
                btnBuscarHotel.Enabled = true;
                GrdClientes.Enabled = true;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string Filtro=CoBFiltro.Text;
            string valor= txtFiltro.Text;
            if (Filtro=="TODOS")
            {
                CargarClientes(Filtro, "");
            }
            else if (Filtro == "RFC")
            {
                CargarClientes(Filtro, valor);
            }
            else if(Filtro == "CORREO")
            {
                CargarClientes(Filtro, valor);
            }
            else if (Filtro == "APELLIDOS")
            {
                CargarClientes(Filtro, valor);
            }
        }

        public static class Hotelseleccionado
        {
            public static int IdHotel { get; set; }
            public static string NombreHotel { get; set; }

        }
        private void CargarCaracteristicasHotel(int ID)
        {
            var obj = new EnlaceDB();
            var hoteles = obj.CargarCaractHotel(ID);

            listBoxCaracHotel.Items.Clear();

            foreach (var hotel in hoteles)
            {
                var caracteristicas = hotel.Caracteristicas.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var c in caracteristicas)
                {
                    listBoxCaracHotel.Items.Add(c.Trim());
                }
            }
        }
        private void GrdHoteles_SelectionChanged(object sender, EventArgs e)
        {
            if (GrdHoteles.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = GrdHoteles.SelectedRows[0];

                Hotelseleccionado.NombreHotel = lbNombreHotel.Text = selectedRow.Cells["Nombre de Hotel"].Value.ToString();
                Hotelseleccionado.IdHotel = int.Parse(selectedRow.Cells["HotelID"].Value.ToString());

                btnSelecHab.Enabled = true;

                CargarCaracteristicasHotel(Hotelseleccionado.IdHotel);

                NumHosped.Enabled = false;
                NumHosped.Value = 0;
                lbHabitacion.Text = "";
                lbTipHabi.Text = "";
                lbPrecio.Text = "";
                lbCapacidad.Text = "";
                lbFechaIN.Text = "";
                lbFechaOUT.Text = "";
                lbTotal.Text = "";
                txtAnticipo.Clear();
                btnReservar.Enabled = false;
            }
        }
        private void CargarHoteles(string filtro, string valor)
        {
            var obj = new EnlaceDB();
            var table = new DataTable();
            table = obj.CargarHotel(filtro, valor);
            GrdHoteles.DataSource = table;
            GrdHoteles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            GrdHoteles.Columns["Usuario Registrador"].Visible = false;
            GrdHoteles.Columns["Fecha inicio de Operaciones"].Visible = false;
            GrdHoteles.Columns["Fecha y Hora de Registro"].Visible = false;
            GrdHoteles.Columns["HotelID"].Visible = false;
        }
        private void btnBuscarHotel_Click(object sender, EventArgs e)
        {

            if(ComBoxPais.Text== "Todos")
            {
                CargarHoteles("TODOS", "");
            }else if(ComBoxCiudad.Text== "Todos")
            {
                string valor = ComBoxPais.Text;
                CargarHoteles("PAIS", valor);
            }
            else
            {
                string valor = ComBoxCiudad.Text;
                CargarHoteles("CIUDAD", valor);
            }
            
            GrdHoteles.Enabled = true;
            

        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            
            var Reserva = new EnlaceReservaciones();

            Guid newGuid = Guid.NewGuid();
            Reserva.ReservacionID = newGuid;

            decimal anticipo;
            if (decimal.TryParse(txtAnticipo.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out anticipo))
            {
                Reserva.Anticipo = anticipo;
            }
            else
            {
                MessageBox.Show("Por favor ingresa un Anticipo válido (ej. 99.99).");
                return;
            }
            
            if(NumHosped.Value == 0)
            {
                MessageBox.Show("El numero de personas hospedadas debe ser mayor a 0");
                return;
            }
            Reserva.PrecioNoche = Total;
            
            string FechaIn = lbFechaIN.Text;
            DateTime fecha = DateTime.ParseExact(FechaIn, "d MMMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"));
            string fechaFormateada = fecha.ToString("dd/MM/yyyy");
            Reserva.FechaCheckIn = fechaFormateada;

            string FechaOut = lbFechaOUT.Text;
            DateTime fecha2 = DateTime.ParseExact(FechaOut, "d MMMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"));
            string fechaFormateada2 = fecha2.ToString("dd/MM/yyyy");
            Reserva.FechaCheckOut = fechaFormateada2;

            Reserva.UsuarioRegistro= SesionUsuario.IDUser;

            Reserva.TipoHabID = TipoHabitacionReservado.IdTipoHabi;

            Reserva.HabitacionID = int.Parse(TipoHabitacionReservado.IdHabitacion);

            Reserva.ClienteID = IDClienteSelec;

            Reserva.CantidadPersonas= (int)NumHosped.Value;

            var obj= new EnlaceDB();
            obj.CrearReservacion(Reserva);

            DialogResult result = MessageBox.Show(
    "¡Reservación creada!\n\nID de la Reserva:\n" + Reserva.ReservacionID.ToString() + "\n\n¿Deseas copiar el ID al portapapeles?",
    "Reserva Generada",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                Clipboard.SetText(Reserva.ReservacionID.ToString());
                MessageBox.Show("ID copiado al portapapeles.", "Copiado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            btnReservar.Visible = false;
            btnSelecHab.Enabled = false;
            btnBuscarHotel.Enabled = false;
            btnFiltrar.Enabled = false;
            GrdClientes.Enabled = false;
            GrdHoteles.Enabled = false;
            txtAnticipo.Enabled = false;
            NumHosped.Enabled = false;
            btnNewReservacion.Visible=true;
        }

        private void btnNewReservacion_Click(object sender, EventArgs e)
        {
            Reservaciones nuevoFormulario = new Reservaciones();
            nuevoFormulario.Show(); 
            this.Dispose();
        }

        

    }
}
