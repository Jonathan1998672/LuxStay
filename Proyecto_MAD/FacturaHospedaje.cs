using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Proyecto_MAD.CheckInandOut;

namespace Proyecto_MAD
{
    
    public partial class FacturaHospedaje : Form
    {
        private static decimal MontoHosp { get; set; }
        private static decimal MontoServ { get; set; }
        private static decimal MontoTot { get; set; }
        private static Guid IdFactura {  get; set; }

        CheckInandOut checkInOut = new CheckInandOut();
        public FacturaHospedaje()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Factura = new EnlaceFactura();
            Factura.FacturaID = IdFactura;
            Factura.ReservacionID = Guid.Parse(DatosparaFactura.Codigo);
            Factura.MontoHospedaje = MontoHosp;
            Factura.MontoServicios = MontoServ;
            Factura.MontoTotal = MontoTot;


            var obj= new EnlaceDB();
            obj.CrearFactura(Factura);
            GenerarFacturatxt();
            Close();
        }

        private void GenerarFacturatxt()
        {
            string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string fileName = $"Factura_{DatosFactura.IDFactura}.txt";
            string fullPath = Path.Combine(downloadsPath, fileName);

            string contenido = "";
            contenido += "                           Factura del Hotel\n\n";
            contenido += "Datos de la Factura\n";
            contenido += "-------------------------------------------------------------------------\n";
            contenido += $"Folio: {DatosFactura.IDFactura}\n";
            contenido += $"Fecha de emisión: {DatosFactura.FechaEmision}\n\n";

            contenido += "Datos del Hotel\n";
            contenido += "-------------------------------------------------------------------------\n";
            contenido += $"Hotel: {DatosFactura.Hotel}\n";
            contenido += $"Dirección: {DatosparaFactura.Direccion}\n\n";

            contenido += "Datos del Cliente\n";
            contenido += "-------------------------------------------------------------------------\n";
            contenido += $"Nombre: {DatosparaFactura.NombreCliente}\n";
            contenido += $"Correo: {DatosparaFactura.Correo}\n";
            contenido += $"Teléfono: {DatosparaFactura.celular}\n\n";

            contenido += "Detalles de la Reserva\n";
            contenido += "-------------------------------------------------------------------------\n";
            contenido += $"Código de reservación: {DatosparaFactura.Codigo}\n";
            contenido += $"Fecha de inicio: {DatosparaFactura.fechaCheckIn.ToString("dd/MM/yyyy")}\n";
            contenido += $"Fecha de salida: {DatosFactura.FechaFin}\n\n";

            contenido += "Servicios Utilizados\n";
            contenido += "-------------------------------------------------------------------------\n";
            contenido += "Servicios                           Precio       Cantidad   Total\n";
            contenido += "-------------------------------------------------------------------------\n";
            foreach (DataGridViewRow fila in GrdServicios.Rows)
            {
                if (fila.IsNewRow) continue;

                string servicio = fila.Cells[0].Value?.ToString() ?? "";
                string precio = fila.Cells[1].Value?.ToString() ?? "";
                string cantidad = fila.Cells[3].Value?.ToString() ?? "";
                string total = fila.Cells[5].Value?.ToString() ?? "";

                contenido += $"{servicio.PadRight(35)} {precio.PadRight(12)} {cantidad.PadRight(10)} {total}\n";
            }

            contenido += "Montos\n";
            contenido += "-------------------------------------------------------------------------\n";
            contenido += $"Servicios: {DatosFactura.MontoServicios}                 Método de Pago: {BoxMetPago.Text}\n";
            contenido += $"Hospedaje: {DatosFactura.MontoHospedaje}                 Total: {DatosFactura.MontoTotal}\n";
            contenido += $"Anticipo: -{DatosparaFactura.AnticipoForm}\n\n";


            File.WriteAllText(fullPath, contenido);

            MessageBox.Show("Factura generada exitosamente en Descargas.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static class DatosFactura
        {
            public static string IDFactura {  get; set; }
            public static string FechaEmision { get; set; }
            public static string Hotel {  get; set; }
            public static string FechaFin {  get; set; }
            public static DateTime FechaFinal { get; set; }
            public static string MontoServicios { get; set; }
            public static string MontoHospedaje { get; set; }
            public static string MontoTotal { get; set; }

        }
        private void CargarDatos()
        {
            Guid newGuid = Guid.NewGuid();
            IdFactura = newGuid;
            lbFacturaID.Text = DatosFactura.IDFactura = newGuid.ToString();
            DateTime fechaActual = DateTime.Today;
            lbFechaEmision.Text = DatosFactura.FechaEmision = fechaActual.ToString("dd/MM/yyyy");
            lbNombreHotel.Text = DatosFactura.Hotel = DatosparaFactura.NombreHotel + "  HABITACION: " + DatosparaFactura.TipoHabitacion +", "+DatosparaFactura.Habitacion;
            lbDireccion.Text = DatosparaFactura.Direccion;
            lbNombreCliente.Text= DatosparaFactura.NombreCliente;
            lbCorreo.Text = DatosparaFactura.Correo;
            lbcelular.Text = DatosparaFactura.celular;
            lbFechaIn.Text = DatosparaFactura.fechaCheckIn.ToString("dd/MM/yyyy");

            if (fechaActual< DatosparaFactura.fechaCheckOut)
            {
                lbFechaOut.Text = DatosFactura.FechaFin = fechaActual.ToString("dd/MM/yyyy");
                DatosFactura.FechaFinal=DateTime.Today;
            }
            else
            {
                lbFechaOut.Text= DatosFactura.FechaFin = DatosparaFactura.fechaCheckOut.ToString("dd/MM/yyyy");
                DatosFactura.FechaFinal = DatosparaFactura.fechaCheckOut;
            }

            lbCodigo.Text = DatosparaFactura.Codigo;
            lbAnticipo.Text= "-"+DatosparaFactura.AnticipoForm;

            int diasCalculados = Math.Max(0, (DatosFactura.FechaFinal - DatosparaFactura.fechaCheckIn).Days);

            decimal MontoHospedaje = DatosparaFactura.PrecioNoche * diasCalculados;
            MontoHosp = MontoHospedaje;

            string totalFormateado = MontoHospedaje.ToString("N2", new System.Globalization.CultureInfo("es-MX"));

            lbHospedaje.Text = DatosFactura.MontoHospedaje = $"${totalFormateado}";

        }

        private void Cargarservicios(int IDH, int IDTH)
        {
            var obj = new EnlaceDB();
            var table = new DataTable();
            table = obj.CargarServiciosCobrar(IDH, IDTH);

            if (!table.Columns.Contains("Cantidad"))
                table.Columns.Add("Cantidad", typeof(int));

            if (!table.Columns.Contains("MontoTotal"))
                table.Columns.Add("MontoTotal", typeof(decimal));

            if (!table.Columns.Contains("Total"))
                table.Columns.Add("Total", typeof(string));

            foreach (DataRow row in table.Rows)
            {
                row["Cantidad"] = 1;
                row["MontoTotal"] = Convert.ToDecimal(row["PrecioDecimal"]);
            }

            GrdServicios.DataSource = table;
            GrdServicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            int cantidadIndex = GrdServicios.Columns["Cantidad"].Index;
            GrdServicios.Columns.Remove("Cantidad");

            var nudColumn = new DataGridViewNumericUpDownColumn();
            nudColumn.Name = "Cantidad";
            nudColumn.HeaderText = "Cantidad";
            nudColumn.DataPropertyName = "Cantidad";
            nudColumn.Width = 70;

            GrdServicios.Columns.Insert(cantidadIndex, nudColumn);

            GrdServicios.Columns["MontoTotal"].ReadOnly = true;

            foreach (DataGridViewColumn col in GrdServicios.Columns)
            {
                col.ReadOnly = col.Name != "Cantidad";
            }

            foreach (DataGridViewRow row in GrdServicios.Rows)
            {
                if (row.Cells["Cantidad"].Value != null && row.Cells["PrecioDecimal"].Value != null)
                {
                    int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    decimal precio = Convert.ToDecimal(row.Cells["PrecioDecimal"].Value);

                    decimal total = cantidad * precio;
                    row.Cells["MontoTotal"].Value = total;

                    row.Cells["Total"].Value = "$" + total.ToString("N2", new System.Globalization.CultureInfo("es-MX"));
                    

                }
            }

            GrdServicios.Columns["MontoTotal"].Visible = false;
            GrdServicios.Columns["PrecioDecimal"].Visible = false;
            GrdServicios.CellValueChanged -= GrdServicios_CellValueChanged;
            GrdServicios.CellValueChanged += GrdServicios_CellValueChanged;
        }
        private void GrdServicios_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (GrdServicios.Columns[e.ColumnIndex].Name == "Cantidad")
            {
                var cantidadCell = GrdServicios.Rows[e.RowIndex].Cells["Cantidad"];
                var precioCell = GrdServicios.Rows[e.RowIndex].Cells["PrecioDecimal"];
                var totalCell = GrdServicios.Rows[e.RowIndex].Cells["MontoTotal"];
                var totalMontoCell = GrdServicios.Rows[e.RowIndex].Cells["Total"];

                if (cantidadCell.Value != null && precioCell.Value != null)
                {
                    int cantidad = 0;
                    decimal precio = 0;

                    int.TryParse(cantidadCell.Value.ToString(), out cantidad);
                    decimal.TryParse(precioCell.Value.ToString(), out precio);

                    decimal total = cantidad * precio;
                    totalCell.Value = total;

                    totalMontoCell.Value = "$" + total.ToString("N2", new System.Globalization.CultureInfo("es-MX"));
                }
            }
        }

        private void FacturaHospedaje_Load(object sender, EventArgs e)
        {
            BoxMetPago.SelectedIndex = 0;
            CargarDatos();
            Cargarservicios(DatosparaFactura.HotelID,DatosparaFactura.TipoHabID);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            decimal totalSum = 0;
            foreach (DataGridViewRow row in GrdServicios.Rows)
            {
                if (row.Cells["MontoTotal"].Value != null)
                {
                    decimal total = Convert.ToDecimal(row.Cells["MontoTotal"].Value);
                    totalSum += total; 
                }
            }
            decimal variableTotal = totalSum;
            MontoServ = variableTotal;


            lbServicios.Text = DatosFactura.MontoServicios = "$" + variableTotal.ToString("N2", new System.Globalization.CultureInfo("es-MX"));

            button1.Enabled = true;

            decimal MontoTotal = MontoHosp + variableTotal - DatosparaFactura.Anticipo;
            MontoTot = MontoTotal;

            lbMontoTotal.Text = DatosFactura.MontoTotal = "$" + MontoTotal.ToString("N2", new System.Globalization.CultureInfo("es-MX"));

        }
    }
}
