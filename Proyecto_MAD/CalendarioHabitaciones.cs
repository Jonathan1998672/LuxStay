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
using static Proyecto_MAD.Reservaciones;

namespace Proyecto_MAD
{
    public partial class CalendarioHabitaciones : Form
    {
        private Reservaciones ventanaReservaciones;

        private List<string> _numerosHabitacionDisponibles = new List<string>();

        private List<string> _IdHabitacionDisponibles = new List<string>();

        public CalendarioHabitaciones(Reservaciones reservaciones)
        {
            InitializeComponent();
            ConfigurarCombos();
            this.ventanaReservaciones = reservaciones;
        }

        private void CargarTiposHabitacion(int hotelId)
        {
            ComBoxTipoHabitacion.Items.Clear();
            ComBoxTipoHabitacion.DisplayMember = "Nivel";
            ComBoxTipoHabitacion.ValueMember = "TipoHabID";
            var obj = new EnlaceDB();
            List<EnlaceHoteles> tiposHabitacion = obj.BuscarTipoHabitacionHotel(hotelId);

            foreach (var tipo in tiposHabitacion)
            {
                ComBoxTipoHabitacion.Items.Add(tipo);
            }

        }

        public static class TipoHabitacionReservado
        {
            public static string IdHabitacion { get; set; }
            public static int IdTipoHabi { get; set; }
            public static decimal preciodecimal { get; set; }
            public static string precioformateado { get; set; }
            public static int capacidad {  get; set; }

        }
        private void comboBoxTipoHabitacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComBoxTipoHabitacion.SelectedItem != null)
            {
                EnlaceHoteles tipoSeleccionado = (EnlaceHoteles)ComBoxTipoHabitacion.SelectedItem;

                labelPrecio.Text = $"Precio por noche: {tipoSeleccionado.PrecioFormateado.ToString()}";
                labelPersonas.Text = $"Capacidad máxima: {tipoSeleccionado.CantPersonas} personas";
                TipoHabitacionReservado.IdTipoHabi = tipoSeleccionado.TipoHabID;
                TipoHabitacionReservado.preciodecimal = tipoSeleccionado.PrecioNoche;
                TipoHabitacionReservado.precioformateado = tipoSeleccionado.PrecioFormateado;
                TipoHabitacionReservado.capacidad = tipoSeleccionado.CantPersonas;
                listCaracteristicas.Items.Clear();
                string[] caracteristicas = tipoSeleccionado.CaractTipHab.Split(',');
                foreach (string caracteristica in caracteristicas)
                {
                    listCaracteristicas.Items.Add(caracteristica.Trim());
                }

                GridHabitaciones.DataSource = null;
                GridHabitaciones.Rows.Clear();

                var obj = new EnlaceDB();
                _numerosHabitacionDisponibles = obj.BuscarHabitacionesPorTipo(TipoHabitacionReservado.IdTipoHabi);
                _IdHabitacionDisponibles= obj.BuscarHabitacionesId(TipoHabitacionReservado.IdTipoHabi);
                button5.Enabled = true;
            }
        }
        private void ConfigurarCombos()
        {
            comboBox1.Items.AddRange(DateTimeFormatInfo.CurrentInfo.MonthNames.Take(12).ToArray());
            comboBox1.SelectedIndex = 0; 

            int añoActual = DateTime.Now.Year;
            for (int i = 0; i <= 5; i++)
            {
                comboBox2.Items.Add((añoActual + i).ToString());
            }
            comboBox2.SelectedIndex = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                int mesSeleccionado = comboBox1.SelectedIndex + 1; 
                int añoSeleccionado = int.Parse(comboBox2.SelectedItem.ToString());

                DateTime fechaSeleccionada = new DateTime(añoSeleccionado, mesSeleccionado, 1);
                DateTime fechaActual = DateTime.Now;

                if (fechaSeleccionada < new DateTime(fechaActual.Year, fechaActual.Month, 1))
                {
                    MessageBox.Show("No puedes seleccionar fechas pasadas.", "Fecha no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ConfigurarDataGridView(mesSeleccionado, añoSeleccionado);

                

            }
        }

        private void ConfigurarDataGridView(int mes, int año)
        {
            GridHabitaciones.Columns.Clear();
            GridHabitaciones.Rows.Clear();
            GridHabitaciones.AllowUserToAddRows = false;
            GridHabitaciones.RowHeadersVisible = false;

            var obj = new EnlaceDB();
            List<EnlaceReservaciones> reservaciones = obj.ObtenerReservaciones(TipoHabitacionReservado.IdTipoHabi);

            GridHabitaciones.Columns.Add("Habitacion", "Habitación");
            GridHabitaciones.Columns[0].Width = 80;

            GridHabitaciones.Columns.Add("HabitacionID", "ID");
            GridHabitaciones.Columns[1].Width = 50;
            GridHabitaciones.Columns[1].Visible = false;

            int mesSiguiente = mes == 12 ? 1 : mes + 1;
            int añoSiguiente = mes == 12 ? año + 1 : año;

            int diasMesActual = DateTime.DaysInMonth(año, mes);
            int diasMesSiguiente = DateTime.DaysInMonth(añoSiguiente, mesSiguiente);

            for (int i = 1; i <= diasMesActual; i++)
            {
                string nombreMes = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mes);
                GridHabitaciones.Columns.Add($"Día{i}_{mes}", $"{i} {nombreMes} {año}");
                GridHabitaciones.Columns[GridHabitaciones.Columns.Count - 1].Width = 80;
            }

            for (int i = 1; i <= diasMesSiguiente; i++)
            {
                string nombreMes = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mesSiguiente);
                GridHabitaciones.Columns.Add($"Día{i}_{mesSiguiente}", $"{i} {nombreMes} {añoSiguiente}");
                GridHabitaciones.Columns[GridHabitaciones.Columns.Count - 1].Width = 80;
            }

            for (int i = 0; i < _numerosHabitacionDisponibles.Count; i++)
            {
                object[] fila = new object[diasMesActual + diasMesSiguiente + 2]; 
                fila[0] = _numerosHabitacionDisponibles[i]; 
                fila[1] = _IdHabitacionDisponibles[i];   
                GridHabitaciones.Rows.Add(fila);
            }

            foreach (DataGridViewRow row in GridHabitaciones.Rows)
            {
                int habitacionId = Convert.ToInt32(row.Cells[1].Value);

                for (int col = 2; col < GridHabitaciones.Columns.Count; col++)
                {
                    string fechaTexto = GridHabitaciones.Columns[col].HeaderText;
                    DateTime fechaCelda;
                    if (DateTime.TryParseExact(fechaTexto, "d MMMM yyyy", CultureInfo.CreateSpecificCulture("es-ES"), DateTimeStyles.None, out fechaCelda))
                    {
                        var reservacion = reservaciones.FirstOrDefault(r =>
                            r.HabitacionID == habitacionId &&
                            fechaCelda >= r.FechCheckIn && fechaCelda <= r.FechCheckOut &&
                            r.Estatus != "Cancelado");

                        if (reservacion != null)
                        {
                            if (fechaCelda == reservacion.FechCheckIn || fechaCelda == reservacion.FechCheckOut)
                            {
                                row.Cells[col].Style.BackColor = Color.Orange;
                            }
                            else
                            {
                                row.Cells[col].Style.BackColor = Color.Red;
                            }
                        }
                        else
                        {
                            row.Cells[col].Style.BackColor = Color.LightGreen;
                        }
                    }
                }
            }

        }

        private void CalendarioHabitaciones_Load(object sender, EventArgs e)
        {
            lbNombreHotel.Text = Hotelseleccionado.NombreHotel;
            CargarTiposHabitacion(Hotelseleccionado.IdHotel);
            ComBoxTipoHabitacion.SelectedIndexChanged += comboBoxTipoHabitacion_SelectedIndexChanged;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ventanaReservaciones == null)
            {
                MessageBox.Show("Error: La ventana de reservaciones no está inicializada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (GridHabitaciones.SelectedCells.Count == 0)
            {
                MessageBox.Show("No has seleccionado ninguna fecha.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewCell cell in GridHabitaciones.SelectedCells)
            {
                if (cell.ColumnIndex == 0)
                {
                    MessageBox.Show("No puedes seleccionar la columna de habitación. Solo selecciona fechas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            int filaSeleccionada = GridHabitaciones.SelectedCells[0].RowIndex;

            foreach (DataGridViewCell cell in GridHabitaciones.SelectedCells)
            {
                if (cell.RowIndex != filaSeleccionada)
                {
                    MessageBox.Show("Debes seleccionar solo fechas de una misma habitación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            foreach (DataGridViewCell cell in GridHabitaciones.SelectedCells)
            {
                if (cell.Style.BackColor == Color.Red)
                {
                    MessageBox.Show("Una de las fechas seleccionadas ya está reservada. Por favor elige otras fechas.", "Fecha reservada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            foreach (DataGridViewCell cell in GridHabitaciones.SelectedCells)
            {
                string fechaTexto = GridHabitaciones.Columns[cell.ColumnIndex].HeaderText;
                if (DateTime.TryParseExact(fechaTexto, "d MMMM yyyy", CultureInfo.CreateSpecificCulture("es-ES"), DateTimeStyles.None, out DateTime fechaCelda))
                {
                    if (fechaCelda.Date < DateTime.Now.Date)
                    {
                        MessageBox.Show("No puedes reservar fechas anteriores al día de hoy.", "Fecha no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            List<int> columnasSeleccionadas = GridHabitaciones.SelectedCells.Cast<DataGridViewCell>()
                .Select(cell => cell.ColumnIndex)
                .OrderBy(index => index)
                .ToList();

            
            int columnaInicio = columnasSeleccionadas.First();
            int columnaFin = columnasSeleccionadas.Last();

            string fechaInicio = GridHabitaciones.Columns[columnaInicio].HeaderText;
            string fechaFin = GridHabitaciones.Columns[columnaFin].HeaderText;

            string habitacion = GridHabitaciones.Rows[filaSeleccionada].Cells[0].Value?.ToString() ?? "Desconocido";

            TipoHabitacionReservado.IdHabitacion= GridHabitaciones.Rows[filaSeleccionada].Cells[1].Value?.ToString() ?? "Desconocido";

            string seleccionComboBox = ComBoxTipoHabitacion.Text;

            string precio= TipoHabitacionReservado.precioformateado.ToString();

            string capacidad= TipoHabitacionReservado.capacidad.ToString();

            ventanaReservaciones.EstablecerDatosReserva(fechaInicio, fechaFin, habitacion, seleccionComboBox, precio, capacidad);

            Close();
        }

        private void button4_Click(object sender, EventArgs e) // Siguiente mes
        {
            if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                int mesSeleccionado = comboBox1.SelectedIndex + 1;
                
                if (mesSeleccionado == 12)
                {
                    mesSeleccionado = 1;
                    int indiceAño = comboBox2.SelectedIndex + 1;
                    if (indiceAño < comboBox2.Items.Count)
                    {
                        comboBox2.SelectedIndex = indiceAño;
                        comboBox1.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("No puedes seleccionar fechas más de 5 años en el futuro.", "Fecha no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    comboBox1.SelectedIndex++;
                }
                int añoSeleccionado = int.Parse(comboBox2.SelectedItem.ToString());
                ConfigurarDataGridView(comboBox1.SelectedIndex + 1, añoSeleccionado);
            }
        }

        private void button3_Click(object sender, EventArgs e) // Mes anterior
        {
            if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                int mesSeleccionado = comboBox1.SelectedIndex + 1;
                int añoSeleccionado = int.Parse(comboBox2.SelectedItem.ToString());

                DateTime fechaActual = DateTime.Now;
                DateTime fechaSeleccionada = new DateTime(añoSeleccionado, mesSeleccionado, 1);

                if (fechaSeleccionada <= new DateTime(fechaActual.Year, fechaActual.Month, 1))
                {
                    MessageBox.Show("No puedes seleccionar fechas pasadas.", "Fecha no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (mesSeleccionado == 1)
                {
                    int indiceAño = comboBox2.SelectedIndex - 1;
                    if (indiceAño >= 0)
                    {
                        comboBox2.SelectedIndex = indiceAño;
                        comboBox1.SelectedIndex = 11;

                    }
                    else
                    {
                        return; 
                    }
                }
                else
                {
                    comboBox1.SelectedIndex--; 
                }
                ConfigurarDataGridView(comboBox1.SelectedIndex + 1, int.Parse(comboBox2.SelectedItem.ToString()));
            }
        }

    }
}
