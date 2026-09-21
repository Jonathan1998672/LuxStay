using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;
using static Proyecto_MAD.Form1;


namespace Proyecto_MAD
{

    public partial class GestionHoteles : Form
    {
        private bool ServicioSelec = false;
        private bool AmenidadSelec = false;
        private bool HabitcionSelec = false;
        public GestionHoteles()
        {
            InitializeComponent();
            this.FormClosing += Exit_FormClosing;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;


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
        private int GenerarIdAleatorio()
        {
            var obj = new EnlaceDB();
            var BuscarHotel = obj.BuscarHotel(); 

            Random random = new Random();
            int nuevoId;

            do
            {
                nuevoId = random.Next(1000000, 10000000);
            }
            while (BuscarHotel.Any(h => h.HotelID == nuevoId)); 

            return nuevoId;
        }

        private void CargarHoteles(string filtro, string valor)
        {
            var obj = new EnlaceDB();
            var table = new DataTable();
            table = obj.CargarHotel(filtro, valor);
            GrdHoteles.DataSource = table;
            GrdHoteles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void CargarCaracteristicasHotel(int ID)
        {
            var obj = new EnlaceDB();
            var hoteles= obj.CargarCaractHotel(ID);

            listCaracHotel.Items.Clear();

            foreach (var hotel in hoteles)
            {
                var caracteristicas = hotel.Caracteristicas.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var c in caracteristicas)
                {
                    listCaracHotel.Items.Add(c.Trim());
                }
            }
        }


        private string GetSafeString(DataGridViewRow row, string columnName)
        {
            return row.Cells[columnName]?.Value?.ToString() ?? "";
        }
        private void GrdHoteles_SelectionChanged(object sender, EventArgs e)
        {
            if (GrdHoteles.SelectedRows.Count > 0)
            {
                btnCancelHotel.Enabled = true;

                DataGridViewRow selectedRow = GrdHoteles.SelectedRows[0];
                lbHotelID.Text = selectedRow.Cells["HotelID"].Value.ToString();
                txtNombreHotel.Text = selectedRow.Cells["Nombre de Hotel"].Value.ToString();
                txtDomicilio.Text = selectedRow.Cells["Domicilio"].Value.ToString();
                numPisos.Text = selectedRow.Cells["Pisos"].Value.ToString();
                btnSaveHotel.Text = "Modificar";
                btnSaveTH.Text = "Guardar";

                var db = new EnlaceDB();
                string Ubicacion = GetSafeString(selectedRow, "Ubicación");

                string[] Part = Ubicacion.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < Part.Length; i++)
                    Part[i] = Part[i].Trim();

                string pais = Part[0];
                string estado = Part[1];
                string ciudad = Part[2];

                int indexPais = ComBoxPais.FindStringExact(pais);
                if (indexPais >= 0)
                {
                    ComBoxPais.SelectedIndex = indexPais;

                    int paisID = (int)ComBoxPais.SelectedValue;

                    ComBoxEstado.DataSource = db.Get_EstadosPorPais(paisID);
                    ComBoxEstado.DisplayMember = "Nombre";
                    ComBoxEstado.ValueMember = "EstadoID";

                    int indexEstado = ComBoxEstado.FindStringExact(estado);
                    if (indexEstado >= 0)
                    {
                        ComBoxEstado.SelectedIndex = indexEstado;

                        int estadoID = (int)ComBoxEstado.SelectedValue;

                        ComBoxCiudad.DataSource = db.Get_CiudadesPorEstado(estadoID);
                        ComBoxCiudad.DisplayMember = "Nombre";
                        ComBoxCiudad.ValueMember = "CiudadID";

                        int indexCiudad = ComBoxCiudad.FindStringExact(ciudad);
                        if (indexCiudad >= 0)
                            ComBoxCiudad.SelectedIndex = indexCiudad;
                    }
                }

                if (DateTime.TryParseExact(GetSafeString(selectedRow, "Fecha inicio de Operaciones"),
                "dd/MMM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime fechaNac))
                {
                    datFechaOperacion.Value = fechaNac;
                }

                EnableHotelSelect(true);

                int IDhotel = int.Parse(lbHotelID.Text);
                CargarCaracteristicasHotel(IDhotel);
                CargarServicios(IDhotel);
                CargarTipHabit(IDhotel);

                lbTipHab.Text = "0";
                txtNivel.Clear();
                txtPrecioNoche.Clear();
                numPersMax.Value = 0;

                btnElimHabit.Enabled = false;
                txtNumHabi.Clear();
                btnAgreHabi.Text = "Agregar";
                HabitcionSelec = false;
                btnCancelHabi.Visible = false;
                btnElimHabit.Visible = false;

                EnableTipoHabiSelect(false);

                CargarCaracteristicasTH(0);

                CargarAmenidades(0);

                CargarHabitaciones(0);
            }
        }
        private void GestionHoteles_Load(object sender, EventArgs e)
        {
            FiltroHotel.Filtro = "TODOS";
            FiltroHotel.Valor = "";

            CargarHoteles("TODOS","");
            CargarServicios(0);
            CargarCaracteristicasTH(0);
            CargarTipHabit(0);
            CargarAmenidades(0);
            CargarHabitaciones(0);

            CoBFiltro.SelectedIndex = 0;

            int id_Aleatorio = GenerarIdAleatorio();
            lbHotelID.Text = id_Aleatorio.ToString();

            GrdHoteles.SelectionChanged += GrdHoteles_SelectionChanged;
            GrdServicios.SelectionChanged += GrdServicios_SelectionChanged;
            GrdAmenidades.SelectionChanged += GrdAmenidades_SelectionChanged;
            GrdTipoHabitacion.SelectionChanged += GrdTipoHabitacion_SelectionChanged;
            GrdHabitaciones.SelectionChanged += GrdHabitaciones_SelectionChanged;

            var db = new EnlaceDB();
            ComBoxPais.DisplayMember = "Nombre";
            ComBoxPais.ValueMember = "PaisID";
            ComBoxPais.DataSource = db.Get_Paises();
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
        private void cbPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComBoxPais.SelectedValue is int paisID)
            {
                EnlaceDB db = new EnlaceDB();
                ComBoxEstado.DisplayMember = "Nombre";
                ComBoxEstado.ValueMember = "EstadoID";
                ComBoxEstado.DataSource = db.Get_EstadosPorPais(paisID);

                ComBoxCiudad.DataSource = null;
            }
        }

        private void cbEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComBoxEstado.SelectedValue is int estadoID)
            {
                EnlaceDB db = new EnlaceDB();
                ComBoxCiudad.DisplayMember = "Nombre";
                ComBoxCiudad.ValueMember = "CiudadID";
                ComBoxCiudad.DataSource = db.Get_CiudadesPorEstado(estadoID);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            GestionServicios_Habitaciones gestionHabitaciones =new GestionServicios_Habitaciones();
            gestionHabitaciones.Show(this);
            Hide();
        }

        private void EnableHotelSelect(bool Estado)
        {
            txtCaractHotel.Enabled = Estado;
            btnAgrCaracHot.Enabled = Estado;
            btnElimCaracHot.Enabled = Estado;
            listCaracHotel.Enabled = Estado;
            GrdServicios.Enabled = Estado;
            btnAgrServ.Enabled = Estado;
            txtServicios.Enabled = Estado;
            txtPrecioServicio.Enabled = Estado;
            btnCancelHotel.Enabled = Estado;
            GrdTipoHabitacion.Enabled = Estado;
            txtNivel.Enabled = Estado;
            txtPrecioNoche.Enabled = Estado;
            numPersMax.Enabled = Estado;
            btnSaveTH.Enabled = Estado;
            txtAmenidad.Enabled = Estado;
            txtPrecioAmenidad.Enabled= Estado;

        }
        private bool ValidarTexto(string nombre)
        {
            return !string.IsNullOrWhiteSpace(nombre) &&
                   nombre.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '-' || c == '/') ;
        }
        private bool ValidarNumero(string Numero)
        {
            if (string.IsNullOrWhiteSpace(Numero) || !Numero.All(char.IsDigit))
            {
                return false;
            }

            if (long.TryParse(Numero, out long numeroTelefono))
            {
                return numeroTelefono > 0;
            }

            return false;
        }
        private bool ValidarUbicacion(string ubicacion, Label lblError)
        {
            if (string.IsNullOrWhiteSpace(ubicacion))
            {
                lblError.Text = "La ubicación no puede estar vacía";
                return false;
            }

            if (ubicacion.Length < 5)
            {
                lblError.Text = "La ubicación debe tener al menos 5 caracteres";
                return false;
            }

            if (ubicacion.Length > 150)
            {
                lblError.Text = "La ubicación no puede exceder los 150 caracteres";
                return false;
            }

            foreach (char c in ubicacion)
            {
                if (!(char.IsLetterOrDigit(c) ||
                      char.IsWhiteSpace(c) ||
                      c == '-' ||
                      c == ',' ||
                      c == '#' ||
                      c == '.' ||
                      c == 'á' || c == 'é' || c == 'í' || c == 'ó' || c == 'ú' ||
                      c == 'Á' || c == 'É' || c == 'Í' || c == 'Ó' || c == 'Ú' ||
                      c == 'ñ' || c == 'Ñ'))
                {
                    lblError.Text = $"Carácter no permitido: '{c}'. Se permiten letras, números, espacios y los símbolos # - , .";
                    return false;
                }
            }

            if (!ubicacion.Any(char.IsLetter))
            {
                lblError.Text = "La ubicación debe contener al menos una letra";
                return false;
            }

            lblError.Text = "";
            return true;
        }
        private void btnSaveHotel_Click(object sender, EventArgs e)
        {
            if (!ValidarTexto(txtNombreHotel.Text))
            {
                lbErrorNombre.Visible = true;
                txtNombreHotel.Focus();
                return;
            }
            else lbErrorNombre.Visible = false;

            if (!ValidarTexto(ComBoxCiudad.Text))
            {
                lbErrorCiudad.Visible = true;
                ComBoxCiudad.Focus();
                return;
            }
            else lbErrorCiudad.Visible = false;

            if (!ValidarUbicacion(txtDomicilio.Text, lbErrorDomicilio))
            {
                lbErrorDomicilio.Visible = true;
                numPisos.Focus();
                return;
            }
            else lbErrorDomicilio.Visible = false;

            if (!ValidarNumero(numPisos.Text))
            {
                lbErrorNumPisos.Visible = true;
                numPisos.Focus();
                return;
            }
            else lbErrorNumPisos.Visible = false;

            string fechaFormateada = datFechaOperacion.Value.ToString("dd/MM/yyyy");

            var Hoteles = new EnlaceHoteles();
            Hoteles.HotelID=int.Parse(lbHotelID.Text);
            Hoteles.Nombre=txtNombreHotel.Text;
            Hoteles.Domicilio = txtDomicilio.Text;
            Hoteles.NumPisos= int.Parse(numPisos.Text);
            Hoteles.UsuarioRegistrador = SesionUsuario.IDUser;
            Hoteles.FechaInicioOperaciones = fechaFormateada;
            Hoteles.Pais=ComBoxPais.Text;
            Hoteles.Estado=ComBoxEstado.Text;
            Hoteles.Ciudad=ComBoxCiudad.Text;

            var obj = new EnlaceDB();

            var BuscarHotel = obj.BuscarHotel();

            var HotelExiste = BuscarHotel.FirstOrDefault(h =>
            h.HotelID == Hoteles.HotelID);

            if(HotelExiste != null)
            {
                DialogResult respuesta = MessageBox.Show(
            $"¿Está seguro que desea actualizar el hotel {HotelExiste.Nombre}?",
            "Confirmar actualización",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);

                if (respuesta == DialogResult.Yes)
                {
                    obj.ActualizaHotel(Hoteles);
                    CargarHoteles(FiltroHotel.Filtro, FiltroHotel.Valor);
                }
            }
            else
            {
                obj.CrearHotel(Hoteles);
                CargarHoteles(FiltroHotel.Filtro, FiltroHotel.Valor);
                EnableHotelSelect(true);
            }


        }

        private void btnAgrCaracHot_Click(object sender, EventArgs e)
        {
            if (!ValidarTexto(txtCaractHotel.Text))
            {
                lbErrorCaracteristicas.Visible = true;
                txtCaractHotel.Focus();
                return;
            }
            else lbErrorCaracteristicas.Visible = false;

            var Hoteles = new EnlaceHoteles();
            Hoteles.HotelID = int.Parse(lbHotelID.Text);
            Hoteles.Caracteristicas=txtCaractHotel.Text;

            var obj= new EnlaceDB();
            obj.CargarCaracteristicas(Hoteles);

            txtCaractHotel.Clear();

            int IDhotel = int.Parse(lbHotelID.Text);
            CargarCaracteristicasHotel(IDhotel);
        }

        private void LimpiarCampos()
        {
            txtNombreHotel.Clear();
            txtDomicilio.Clear();
            numPisos.Value=0;
            ComBoxPais.SelectedIndex = 0;
            listCaracHotel.Items.Clear();
            datFechaOperacion.Value = DateTime.Today.AddYears(-18);
            btnSaveHotel.Text = "Guardar";

            int id_Aleatorio = GenerarIdAleatorio();
            lbHotelID.Text = id_Aleatorio.ToString();

            btnCancelHotel.Enabled = false;
            EnableHotelSelect(false);
            CargarTipHabit(0);
        }
        private void btnCancelHotel_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            CargarHoteles(FiltroHotel.Filtro, FiltroHotel.Valor);
            CargarServicios(0);

            lbTipHab.Text = "0";
            txtNivel.Clear();
            txtPrecioNoche.Clear();
            numPersMax.Value = 0;
            CargarTipHabit(0);
            CargarCaracteristicasTH(0);
            CargarAmenidades(0);
            CargarHabitaciones(0);
            EnableTipoHabiSelect(false);
        }

        private void btnElimCaracHot_Click(object sender, EventArgs e)
        {
            if (listCaracHotel.SelectedItem != null)
            {
                listCaracHotel.Items.Remove(listCaracHotel.SelectedItem);
            }
            else
            {
                MessageBox.Show("Selecciona una característica para eliminar.", "Aviso");
                return;
            }

            string caracteristicas = string.Join(", ", listCaracHotel.Items.Cast<string>());

            var Hoteles = new EnlaceHoteles();
            Hoteles.HotelID = int.Parse(lbHotelID.Text);
            Hoteles.Caracteristicas = caracteristicas;
            var obj=new EnlaceDB();
            obj.EliminarCaaracteristica(Hoteles);

        }

        private void CargarServicios(int ID)
        {
            var obj = new EnlaceDB();
            var table = new DataTable();
            table = obj.Get_Servicios(ID);
            GrdServicios.DataSource = table;
            GrdServicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            GrdServicios.Columns["ServicioID"].Visible = false;
            GrdServicios.Columns["HotelID"].Visible = false;
        }

        private static class ServicioSeleccionado
        {
            public static int IdServicio { get; set; }

        }

        private static class AmenidadSeleccionado
        {
            public static int IdAmenidad { get; set; }

        }

        private static class HabitacionSeleccionado
        {
            public static int IdHabitacion { get; set; }

        }
        private void GrdServicios_SelectionChanged(object sender, EventArgs e)
        {
            if (GrdServicios.SelectedRows.Count > 0)
            {
                btnElimServi.Enabled = true;

                DataGridViewRow selectedRow = GrdServicios.SelectedRows[0];
                txtServicios.Text = selectedRow.Cells["Servicio"].Value.ToString();
                string precioConFormato = selectedRow.Cells["Precio"].Value.ToString();
                string soloNumero = new string(precioConFormato.Where(c => char.IsDigit(c) || c == '.').ToArray());
                txtPrecioServicio.Text = soloNumero;
                ServicioSeleccionado.IdServicio= int.Parse(selectedRow.Cells["ServicioID"].Value.ToString());
                ServicioSelec = true;
                btnAgrServ.Text = "Modificar";
                btnCancServ.Visible = true;
            }
        }

        
        private void btnAgrServ_Click(object sender, EventArgs e)
        {
            var Hoteles = new EnlaceHoteles();
            Hoteles.HotelID = int.Parse(lbHotelID.Text);
            Hoteles.NombreServicio = txtServicios.Text;
            decimal precio;
            if (decimal.TryParse(txtPrecioServicio.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out precio))
            {
                Hoteles.PrecioServicio = precio;
            }
            else
            {
                MessageBox.Show("Por favor ingresa un precio válido (ej. 99.99).");
                return;
            }

            Hoteles.ServicioID = ServicioSeleccionado.IdServicio;

            var obj = new EnlaceDB();

            var BuscarNombreServ = obj.BuscarServicio(Hoteles.HotelID);

            var NombreExiste = BuscarNombreServ.FirstOrDefault(n =>
            n.NombreServicio == Hoteles.NombreServicio);

            if (NombreExiste != null && !ServicioSelec)
            {
                MessageBox.Show("Este Servicio ya existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else{
                if(!ServicioSelec) {
                    obj.CrearServicios(Hoteles);
                }
                else
                {
                    obj.ActualizaServicios(Hoteles);
                    btnAgrServ.Text = "Agregar";
                    ServicioSelec = false;
                    btnElimServi.Enabled = false;
                    btnCancServ.Visible = false;

                }

                CargarServicios(Hoteles.HotelID);
            } 

            txtServicios.Clear();
            txtPrecioServicio.Clear();
        }

        private void btnElimServi_Click(object sender, EventArgs e)
        {
            var Hoteles = new EnlaceHoteles();
            Hoteles.HotelID = int.Parse(lbHotelID.Text);
            Hoteles.ServicioID = ServicioSeleccionado.IdServicio;

            var obj=new EnlaceDB();
            obj.BorrarServicio(Hoteles);

            CargarServicios(Hoteles.HotelID);

            btnElimServi.Enabled=false;
            txtServicios.Clear();
            txtPrecioServicio.Clear();
            btnAgrServ.Text = "Agregar";
            ServicioSelec = false;
            btnCancServ.Visible = false;
        }

        private void btnCancServ_Click(object sender, EventArgs e)
        {
            btnElimServi.Enabled = false;
            txtServicios.Clear();
            txtPrecioServicio.Clear();
            btnAgrServ.Text = "Agregar";
            ServicioSelec = false;
            btnCancServ.Visible = false;
        }

        private static class FiltroHotel
        {
            public static string Filtro { get; set; }
            public static string Valor { get; set; }

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string Filtro = CoBFiltro.Text;
            string valor = txtFiltro.Text;
            if (Filtro == "TODOS")
            {
                FiltroHotel.Filtro = Filtro;
                FiltroHotel.Valor = valor;
                CargarHoteles(Filtro, "");
            }
            else if (Filtro == "PAIS")
            {
                FiltroHotel.Filtro = Filtro;
                FiltroHotel.Valor = valor;
                CargarHoteles(Filtro, valor);
            }
            else if (Filtro == "NOMBRE")
            {
                FiltroHotel.Filtro = Filtro;
                FiltroHotel.Valor = valor;
                CargarHoteles(Filtro, valor);
            }
        }

        private void EnableTipoHabiSelect(bool Estado)
        {
            txtAmenidad.Enabled = Estado;
            txtPrecioAmenidad.Enabled= Estado;
            btnCancelAmen.Enabled = Estado;
            btnAgrAmen.Enabled= Estado;
            btnElimCaracTH.Enabled= Estado;
            GrdAmenidades.Enabled = Estado;
            txtCaracteristicas.Enabled = Estado;
            btnAgrCaracTH.Enabled = Estado;
            listBoxCaracTipHab.Enabled = Estado;
            btnCancelTIPHAB.Enabled = Estado;

            GrdHabitaciones.Enabled = Estado;
            txtNumHabi.Enabled = Estado;
            btnAgreHabi.Enabled = Estado;
            btnCancelHabi.Enabled = Estado;
            btnElimHabit.Enabled = Estado;

        }
        public void CargarTipHabit(int ID)
        {
            var obj = new EnlaceDB();
            var table = new DataTable();
            table = obj.Get_TipoHabitaciones(ID);
            GrdTipoHabitacion.DataSource = table;
            GrdTipoHabitacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            GrdTipoHabitacion.Columns["TipoHabID"].Visible = false;
        }

        private void GrdTipoHabitacion_SelectionChanged(object sender, EventArgs e)
        {
            if (GrdTipoHabitacion.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = GrdTipoHabitacion.SelectedRows[0];
                lbTipHab.Text = selectedRow.Cells["TipoHabID"].Value.ToString();
                txtNivel.Text = selectedRow.Cells["Nivel"].Value.ToString();
                string precioConFormato = selectedRow.Cells["Precio Noche por persona"].Value.ToString();
                string soloNumero = new string(precioConFormato.Where(c => char.IsDigit(c) || c == '.').ToArray());
                txtPrecioNoche.Text = soloNumero;
                numPersMax.Text = selectedRow.Cells["Personas maximas permitidas"].Value.ToString();
                btnSaveTH.Text = "Modificar";

                EnableTipoHabiSelect(true);
                btnElimHabit.Enabled = false;
                txtNumHabi.Clear();
                btnAgreHabi.Text = "Agregar";
                HabitcionSelec = false;
                btnCancelHabi.Visible = false;
                btnElimHabit.Visible = false;


                int IDTipHab = int.Parse(lbTipHab.Text);
                CargarCaracteristicasTH(IDTipHab);
                CargarAmenidades(IDTipHab);
                CargarHabitaciones(IDTipHab);

            }
        }

        private void btnSaveTH_Click(object sender, EventArgs e)
        {
            if (!ValidarTexto(txtNivel.Text))
            {
                lbErrorNivel.Visible = true;
                txtNivel.Focus();
                return;
            }
            else lbErrorNivel.Visible = false;

            if (!ValidarNumero(numPersMax.Text))
            {
                lbErrorPersMax.Visible = true;
                numPersMax.Focus();
                return;
            }
            else lbErrorPersMax.Visible = false;

            var TipoHabitaciones = new EnlaceHoteles();
            TipoHabitaciones.HotelID = int.Parse(lbHotelID.Text);
            TipoHabitaciones.Nivel = txtNivel.Text;
            TipoHabitaciones.CantPersonas = int.Parse(numPersMax.Text);
            TipoHabitaciones.UsuarioRegistrador = SesionUsuario.IDUser;
            decimal precio;
            if (decimal.TryParse(txtPrecioNoche.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out precio))
            {
                TipoHabitaciones.PrecioNoche = precio;
            }
            else
            {
                MessageBox.Show("Por favor ingresa un precio válido (ej. 99.99).");
                return;
            }
            var obj = new EnlaceDB();
            var BuscarIDTipHot = obj.BuscarTipoHabitacion(TipoHabitaciones.HotelID);

            TipoHabitaciones.TipoHabID = int.Parse(lbTipHab.Text);
            var IdExiste = BuscarIDTipHot.FirstOrDefault(n =>
            n.TipoHabID == TipoHabitaciones.TipoHabID);

            if (IdExiste != null && !ServicioSelec)
            {
                DialogResult respuesta = MessageBox.Show(
            $"¿Está seguro que desea actualizar el Tipo de habitación {IdExiste.Nivel}?",
            "Confirmar actualización",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);

                if (respuesta == DialogResult.Yes)
                {
                    obj.ActualizaTipoHabitacion(TipoHabitaciones);
                    CargarTipHabit(TipoHabitaciones.HotelID);
                }
            }
            else
            {
                obj.CrearTipoHabitacion(TipoHabitaciones);
                CargarTipHabit(TipoHabitaciones.HotelID);
                txtNivel.Clear();
                txtPrecioNoche.Clear();
                numPersMax.Value = 0;
            }

        }

        private void btnCancelTIPHAB_Click(object sender, EventArgs e)
        {
            lbTipHab.Text = "0";
            txtNivel.Clear();
            txtPrecioNoche.Clear();
            numPersMax.Value = 0;
            btnSaveTH.Text = "Guardar";

            EnableTipoHabiSelect(false);

            int ID = int.Parse(lbHotelID.Text);
            CargarTipHabit(ID);

            CargarCaracteristicasTH(0);
            CargarHabitaciones(0);
            CargarAmenidades(0);
        }

        private void CargarCaracteristicasTH(int ID)
        {
            var obj = new EnlaceDB();
            var TipHab = obj.CargarCaractTipoHab(ID);

            listBoxCaracTipHab.Items.Clear();

            foreach (var TipoHabi in TipHab)
            {
                var caracteristicas = TipoHabi.CaractTipHab.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var c in caracteristicas)
                {
                    listBoxCaracTipHab.Items.Add(c.Trim());
                }
            }
        }
        private void btnAgrCaracTH_Click(object sender, EventArgs e)
        {
            if (!ValidarTexto(txtCaracteristicas.Text))
            {
                lbErrorCarac.Visible = true;
                txtCaracteristicas.Focus();
                return;
            }
            else lbErrorCarac.Visible = false;

            var tipHabitacion = new EnlaceHoteles();
            tipHabitacion.TipoHabID = int.Parse(lbTipHab.Text);
            tipHabitacion.CaractTipHab = txtCaracteristicas.Text;

            var obj = new EnlaceDB();
            obj.crearCaracteristicasTH(tipHabitacion);

            txtCaracteristicas.Clear();

            int IDTipHab = int.Parse(lbTipHab.Text);
            CargarCaracteristicasTH(IDTipHab);
        }

        private void btnElimCaracTH_Click_1(object sender, EventArgs e)
        {
            if (listBoxCaracTipHab.SelectedItem != null)
            {
                listBoxCaracTipHab.Items.Remove(listBoxCaracTipHab.SelectedItem);
            }
            else
            {
                MessageBox.Show("Selecciona una característica para eliminar.", "Aviso");
                return;
            }

            string caracteristicas = string.Join(", ", listBoxCaracTipHab.Items.Cast<string>());

            var TipHab = new EnlaceHoteles();
            TipHab.TipoHabID = int.Parse(lbTipHab.Text);
            TipHab.CaractTipHab = caracteristicas;
            var obj = new EnlaceDB();
            obj.EliminarCaracteristicaTipHab(TipHab);
        }

        private void CargarAmenidades(int ID)
        {
            var obj = new EnlaceDB();
            var table = new DataTable();
            table = obj.Get_Amenidades(ID);
            GrdAmenidades.DataSource = table;
            GrdAmenidades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            GrdAmenidades.Columns["AmenidadID"].Visible = false;
            GrdAmenidades.Columns["TipoHabitacion"].Visible = false;
        }
        private void GrdAmenidades_SelectionChanged(object sender, EventArgs e)
        {
            if (GrdAmenidades.SelectedRows.Count > 0)
            {
                btnElimAmenidadTH.Enabled = true;

                DataGridViewRow selectedRow = GrdAmenidades.SelectedRows[0];
                txtAmenidad.Text = selectedRow.Cells["Amenidad"].Value.ToString();
                string precioConFormato = selectedRow.Cells["Precio"].Value.ToString();
                string soloNumero = new string(precioConFormato.Where(c => char.IsDigit(c) || c == '.').ToArray());
                txtPrecioAmenidad.Text = soloNumero;
                AmenidadSeleccionado.IdAmenidad = int.Parse(selectedRow.Cells["AmenidadID"].Value.ToString());
                AmenidadSelec = true;
                btnAgrAmen.Text = "Modificar";
                btnCancelAmen.Visible = true;
            }
        }
        private void btnCancelAmen_Click(object sender, EventArgs e)
        {
            btnElimAmenidadTH.Enabled = false;
            txtAmenidad.Clear();
            txtPrecioAmenidad.Clear();
            btnAgrAmen.Text = "Agregar";
            AmenidadSelec = false;
            btnCancelAmen.Visible = false;
        }

        private void btnAgrAmen_Click(object sender, EventArgs e)
        {
            var Hoteles = new EnlaceHoteles();
            Hoteles.TipoHabID = int.Parse(lbTipHab.Text);
            Hoteles.NombreAmenidad = txtAmenidad.Text;
            decimal precio;
            if (decimal.TryParse(txtPrecioAmenidad.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out precio))
            {
                Hoteles.PrecioAmenidad = precio;
            }
            else
            {
                MessageBox.Show("Por favor ingresa un precio válido (ej. 99.99).");
                return;
            }

            Hoteles.AmenidadID = AmenidadSeleccionado.IdAmenidad;

            var obj = new EnlaceDB();

            var BuscarNomAmenidad = obj.BuscarAmenidad(Hoteles.TipoHabID);

            var NombreExiste = BuscarNomAmenidad.FirstOrDefault(n =>
            n.NombreAmenidad == Hoteles.NombreAmenidad);

            if (NombreExiste != null && !AmenidadSelec)
            {
                MessageBox.Show("Esta amenidad ya existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (!AmenidadSelec)
                {
                    obj.CrearAmenidades(Hoteles);
                }
                else
                {
                    obj.ActualizaAmenidades(Hoteles);
                    btnAgrAmen.Text = "Agregar";
                    AmenidadSelec = false;
                    btnElimAmenidadTH.Enabled = false;
                    btnCancelAmen.Visible = false;

                }

                CargarAmenidades(Hoteles.TipoHabID);
            }

            txtAmenidad.Clear();
            txtPrecioAmenidad.Clear();
        }

        private void btnElimAmenidadTH_Click(object sender, EventArgs e)
        {
            var Hoteles = new EnlaceHoteles();
            Hoteles.TipoHabID = int.Parse(lbTipHab.Text);
            Hoteles.AmenidadID = AmenidadSeleccionado.IdAmenidad;

            var obj = new EnlaceDB();
            obj.BorrarAmenidad(Hoteles);

            CargarAmenidades(Hoteles.TipoHabID);

            btnElimAmenidadTH.Enabled = false;
            txtAmenidad.Clear();
            txtPrecioAmenidad.Clear();
            btnAgrAmen.Text = "Agregar";
            AmenidadSelec = false;
            btnCancelAmen.Visible = false;
        }

        private void GrdHabitaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (GrdHabitaciones.SelectedRows.Count > 0)
            {
                btnElimHabit.Enabled = true;

                DataGridViewRow selectedRow = GrdHabitaciones.SelectedRows[0];
                txtNumHabi.Text = selectedRow.Cells["Numero habitación"].Value.ToString();
                HabitacionSeleccionado.IdHabitacion = int.Parse(selectedRow.Cells["HabitacionID"].Value.ToString());
                HabitcionSelec = true;
                btnAgreHabi.Text = "Modificar";
                btnCancelHabi.Visible = true;
                btnElimHabit.Visible = true;
            }
        }
        private void CargarHabitaciones(int ID)
        {
            var obj = new EnlaceDB();
            var table = new DataTable();
            table = obj.Get_Habitaciones(ID);
            GrdHabitaciones.DataSource = table;
            GrdHabitaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            GrdHabitaciones.Columns["HabitacionID"].Visible = false;
            GrdHabitaciones.Columns["TipoHabitacion"].Visible = false;
        }
        private void btnAgreHabi_Click(object sender, EventArgs e)
        {
            var Hoteles = new EnlaceHoteles();
            int IDHOTEL=int.Parse(lbHotelID.Text);
            Hoteles.TipoHabID = int.Parse(lbTipHab.Text);
            Hoteles.numeroHabitacion = txtNumHabi.Text;
            
            Hoteles.HabitacionID = HabitacionSeleccionado.IdHabitacion;

            var obj = new EnlaceDB();

            var BuscarNumHabitacion = obj.BuscarHabitacion(Hoteles.TipoHabID);

            var NumeroExiste = BuscarNumHabitacion.FirstOrDefault(n =>
            n.numeroHabitacion == Hoteles.numeroHabitacion);

            if (NumeroExiste != null && !HabitcionSelec)
            {
                MessageBox.Show("Este numero de habitación ya existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (!HabitcionSelec)
                {
                    obj.CrearHabitaciones(Hoteles);
                    CargarTipHabit(IDHOTEL);
                    CargarHoteles(FiltroHotel.Filtro, FiltroHotel.Valor);
                }
                else
                {
                    obj.ActualizaHabitacion(Hoteles);
                    btnAgreHabi.Text = "Agregar";
                    HabitcionSelec = false;
                    btnElimHabit.Enabled = false;
                    btnCancelHabi.Visible = false;
                    btnElimHabit.Visible = false;

                }

                CargarHabitaciones(Hoteles.TipoHabID);
            }

            txtNumHabi.Clear();
        }

        private void btnElimHabit_Click(object sender, EventArgs e)
        {
            var Hoteles = new EnlaceHoteles();
            Hoteles.TipoHabID = int.Parse(lbTipHab.Text);
            Hoteles.HabitacionID = HabitacionSeleccionado.IdHabitacion;
            int IDHOTEL = int.Parse(lbHotelID.Text);

            var obj = new EnlaceDB();
            try
            {
                obj.BorrarHabitacion(Hoteles);

                CargarHabitaciones(Hoteles.TipoHabID);

                btnElimHabit.Enabled = false;
                txtNumHabi.Clear();
                btnAgreHabi.Text = "Agregar";
                HabitcionSelec = false;
                btnCancelHabi.Visible = false;
                btnElimHabit.Visible = false;

                CargarTipHabit(IDHOTEL);
                CargarHoteles(FiltroHotel.Filtro, FiltroHotel.Valor);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "No se pudo eliminar la habitación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnCancelHabi_Click(object sender, EventArgs e)
        {
            btnElimHabit.Enabled = false;
            txtNumHabi.Clear();
            btnAgreHabi.Text = "Agregar";
            HabitcionSelec = false;
            btnCancelHabi.Visible = false;
            btnElimHabit.Visible = false;
        }

        private void btnagregarUbicacion_Click(object sender, EventArgs e)
        {
            Ubicaciones ubicaciones = new Ubicaciones();
            ubicaciones.ShowDialog();
            var db = new EnlaceDB();
            ComBoxPais.DisplayMember = "Nombre";
            ComBoxPais.ValueMember = "PaisID";
            ComBoxPais.DataSource = db.Get_Paises();
        }
    }
}
