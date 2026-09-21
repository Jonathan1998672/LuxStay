using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using HS_APP;
using WindowsFormsApplication1;
using static Proyecto_MAD.Form1;
using static Proyecto_MAD.GestionUsuarios;

namespace Proyecto_MAD
{
    public partial class GestionClientes : Form
    {
        public GestionClientes()
        {
            InitializeComponent();
            this.FormClosing += Exit_FormClosing;
        }
        private void Exit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private int GenerarIdAleatorio()
        {
            var obj = new EnlaceDB();
            var BuscarCliente = obj.BuscarCliente();

            Random random = new Random();
            int NuevoID;

            do
            {
                NuevoID = random.Next(100000, 1000000);
            }
            while(BuscarCliente.Any(c=>c.ClienteID==NuevoID));

            return NuevoID;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            MenuOperativos menuOperativos = new MenuOperativos();
            menuOperativos.Show(this);
            Hide();
            
        }

        private void Cargar()
        {
            var obj = new EnlaceDB();
            var table = new DataTable();
            table = obj.Get_Clientes();
            GrdClientes.DataSource = table;
            GrdClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellidos.Clear();
            txtRFC.Clear();
            txtCorreo.Clear();
            ComEstadoCiv.SelectedIndex = 0;
            ComBoxPais.SelectedIndex = 0;
            txtCelular.Clear();
            txtTelCasa.Clear();
            datFechaNacimiento.Value = DateTime.Today.AddYears(-18);
            btnSave.Text = "Guardar";

            int id_Aleatorio = GenerarIdAleatorio();
            lbClienteId.Text = id_Aleatorio.ToString();

            btnCancel.Enabled = false;
        }
        private void GestionClientes_Load(object sender, EventArgs e)
        {
            ComEstadoCiv.SelectedIndex = 0;
            Cargar();
            GrdClientes.SelectionChanged += GrdClientes_SelectionChanged;
            int id_Aleatorio = GenerarIdAleatorio();
            lbClienteId.Text = id_Aleatorio.ToString();
            datFechaNacimiento.Value = DateTime.Today.AddYears(-18);

            var db= new EnlaceDB();
            ComBoxPais.DisplayMember = "Nombre";
            ComBoxPais.ValueMember = "PaisID";
            ComBoxPais.DataSource = db.Get_Paises();
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



        private string GetSafeString(DataGridViewRow row, string columnName)
        {
            return row.Cells[columnName]?.Value?.ToString() ?? "";
        }
        private void GrdClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (GrdClientes.SelectedRows.Count > 0)
            {
                
                datFechaNacimiento.Value = DateTime.Today.AddYears(-18);
                btnCancel.Enabled = true;

                DataGridViewRow selectedRow = GrdClientes.SelectedRows[0];
                lbClienteId.Text = selectedRow.Cells["ClienteID"].Value.ToString();
                txtNombre.Text = selectedRow.Cells["Nombre"].Value.ToString();
                txtApellidos.Text = selectedRow.Cells["Apellidos"].Value.ToString();
                txtRFC.Text = selectedRow.Cells["RFC"].Value.ToString();
                txtCorreo.Text = selectedRow.Cells["Correo"].Value.ToString();
                btnSave.Text = "Modificar";

                var db=new EnlaceDB();
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

                string telefonos = GetSafeString(selectedRow, "Teléfonos");
                txtTelCasa.Text = "";
                string[] partes = telefonos.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string parte in partes)
                {
                    if (parte.StartsWith("Cel:"))
                    {
                        txtCelular.Text = parte.Replace("Cel:", "").Trim();
                    }
                    else if (parte.StartsWith("Casa:"))
                    {
                        txtTelCasa.Text = parte.Replace("Casa:", "").Trim();
                    }
                }

                if (DateTime.TryParseExact(GetSafeString(selectedRow, "Fecha de Nacimiento"),
                "dd/MMM/yyyy",  
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime fechaNac))
                {
                    datFechaNacimiento.Value = fechaNac;
                }

                string EstadoCivil = GetSafeString(selectedRow, "Estado Civil");
                ComEstadoCiv.SelectedItem = EstadoCivil;
                ComEstadoCiv.SelectedIndex = ComEstadoCiv.FindStringExact(EstadoCivil);
            }
        }

        private bool ValidarTexto(string nombre)
        {
            return !string.IsNullOrWhiteSpace(nombre) &&
                   nombre.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        private bool ValidarCorreo(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo)) return false;

            string[] dominiosPermitidos = { "@email.com", "@gmail.com", "@hotmail.com", "@outlook.com" };
            return dominiosPermitidos.Any(dominio => correo.EndsWith(dominio, StringComparison.OrdinalIgnoreCase));
        }

        private bool ValidarRFC(string rfc)
        {
            if (string.IsNullOrWhiteSpace(rfc))
                return false;

            string patron = @"^(?=.*[A-ZÑ])(?=.*\d)[A-ZÑ\d]{12,}$";

            return Regex.IsMatch(rfc.ToUpper(), patron);
        }

        private bool ValidarTelefono(string telefono)
        {
            return !string.IsNullOrWhiteSpace(telefono) &&
                   telefono.Length >= 7 &&
                   telefono.All(char.IsDigit);
        }

        private bool EsMayorEdad(DateTime fechaNacimiento)
        {
            DateTime fechaActual = DateTime.Today;
            int edad = fechaActual.Year - fechaNacimiento.Year;

            if (fechaNacimiento.Date > fechaActual.AddYears(-edad))
            {
                edad--;
            }

            return edad >= 18;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidarTexto(txtNombre.Text))
            {
                lbErrorNombre.Visible = true;
                txtNombre.Focus();
                return;
            }
            else lbErrorNombre.Visible = false;

            if (!ValidarTexto(txtApellidos.Text))
            {
                lbErrorApellidos.Visible = true;
                txtApellidos.Focus();
                return;
            }
            else lbErrorApellidos.Visible=false;

            if (!ValidarTexto(ComBoxCiudad.Text))
            {
                lbErrorCiudad.Visible = true;
                ComBoxCiudad.Focus();
                return;
            }
            else lbErrorCiudad.Visible=false;

            if(!ValidarRFC(txtRFC.Text))
            {
                lbErrorRFC.Visible = true;
                txtRFC.Focus();
                return;
            }
            else lbErrorRFC.Visible=false;

            if (!ValidarCorreo(txtCorreo.Text))
            {
                lbErrorCorreo.Visible = true;
                txtCorreo.Focus();
                return;
            }
            else lbErrorCorreo.Visible = false;

            if (string.IsNullOrWhiteSpace(txtTelCasa.Text)) { }
            else
            {
                if (!ValidarTelefono(txtTelCasa.Text))
                {
                    lbErrorTelef1.Visible = true;
                    txtTelCasa.Focus();
                    return;
                }
                else lbErrorTelef1.Visible = false;
            }

            if (!ValidarTelefono(txtCelular.Text))
            {
                lbErrorTelef2.Visible = true;
                txtCelular.Focus();
                return;
            }
            else lbErrorTelef2.Visible = false;

            if (!EsMayorEdad(datFechaNacimiento.Value))
            {
                lbErrorFechaNac.Visible = true;
                txtTelCasa.Focus();
                return;
            }
            else lbErrorFechaNac.Visible = false;


            string fechaFormateada = datFechaNacimiento.Value.ToString("dd/MM/yyyy");
            
            var Clientes=new EnlaceClientes();
            Clientes.ClienteID=int.Parse(lbClienteId.Text);
            Clientes.Nombre=txtNombre.Text;
            Clientes.Apellidos=txtApellidos.Text;
            Clientes.RFC = txtRFC.Text;
            Clientes.Correo=txtCorreo.Text;
            Clientes.EstadoCivil = ComEstadoCiv.Text;
            Clientes.FechaNacimiento = fechaFormateada;
            Clientes.UsuarioModificador = SesionUsuario.IDUser;
            Clientes.Pais = ComBoxPais.Text;
            Clientes.Ciudad= ComBoxCiudad.Text;
            Clientes.Estado= ComBoxEstado.Text;
            Clientes.Celular= txtCelular.Text;
            Clientes.TelefonoCasa=txtTelCasa.Text;

            var obj = new EnlaceDB();

            var BuscarCliente = obj.BuscarCliente();

            var IdExiste=BuscarCliente.FirstOrDefault(c=>
            c.ClienteID==Clientes.ClienteID);

            if (IdExiste != null)
            {
                DialogResult respuesta = MessageBox.Show(
            $"¿Está seguro que desea actualizar los datos del cliente {IdExiste.Correo}?",
            "Confirmar actualización",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);

                if (respuesta == DialogResult.Yes)
                {
                    obj.ActualizaCliente(Clientes);
                    MessageBox.Show("Usuario actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cargar();
                }
            }
            else
            {
                obj.CrearCliente(Clientes);
                Cargar();
                LimpiarCampos();
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            Cargar();
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
