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
using HS_APP;
using WindowsFormsApplication1;
using static Proyecto_MAD.Form1;

namespace Proyecto_MAD
{
    public partial class GestionUsuarios : Form
    {
        private bool isPasswordVisible = false;
        private bool isUsuarioSeleccionado = false;
        private static string TipoUsuario {  get; set; }
        public GestionUsuarios()
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

        private void GestionUsuarios_Load(object sender, EventArgs e)
        {
            Cargar();
            GrdUusuarios.SelectionChanged += GrdUsuarios_SelectionChanged;
            datFechNacimiento.Value = DateTime.Today.AddYears(-18);

            int id_Aleatorio = GenerarIdAleatorio();
            lbUsuarioId.Text = id_Aleatorio.ToString();

            var obj = new EnlaceDB();
            var BuscarUsuario = obj.BuscarID();

            var IDExite = BuscarUsuario.FirstOrDefault(u =>
            u.UsuarioID == int.Parse(lbUsuarioId.Text));

            if (IDExite != null)
            {
                int idAle = GenerarIdAleatorio();
                lbUsuarioId.Text = idAle.ToString();
            }
        }

        private void MostrarCellsPasswords(bool Mostrar)
        {
            GrdUusuarios.Columns["Contraseña"].Visible = Mostrar;
            GrdUusuarios.Columns["Contraseñas Anteriores"].Visible= Mostrar;
        }
        public void Cargar()
        {
            var obj = new EnlaceDB();
            var table=new DataTable();
            table=obj.Get_Usuarios();
            GrdUusuarios.DataSource = table;
            GrdUusuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            MostrarCellsPasswords(false);

        }

        public static class HistorialPasswords
        {
            public static int IdUsuario {  get; set; }
            public static string PasswordAct { get; set; }
            public static string PasswordAnt1 { get; set; }
            public static string PasswordAnt2 { get; set; }

        }
        private string GetSafeString(DataGridViewRow row, string columnName)
        {
            return row.Cells[columnName]?.Value?.ToString() ?? "";
        }
        private void GrdUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (GrdUusuarios.SelectedRows.Count > 0)
            {
                isPasswordVisible = false;
                txtPassword.PasswordChar = '*';
                txtPassword.ReadOnly = true;
                ShowPassword.Visible = true;
                lbEst.Visible = true; lbEstado.Visible = true;
                datFechNacimiento.Value = DateTime.Today.AddYears(-18);
                btnCancel.Enabled = true;
                btnNewPassword.Visible = true;
                btnHabilitar.Visible = true;
                btnSave.Text = "Modificar";

                DataGridViewRow selectedRow = GrdUusuarios.SelectedRows[0];
                lbUsuarioId.Text = selectedRow.Cells["UsuarioID"].Value.ToString();
                txtNombre.Text = selectedRow.Cells["Nombre"].Value.ToString();
                txtApellidos.Text= selectedRow.Cells["Apellidos"].Value.ToString();
                txtCorreo.Text = selectedRow.Cells["Correo"].Value.ToString();
                txtPassword.Text = selectedRow.Cells["Contraseña"].Value.ToString();
                txtNomina.Text = selectedRow.Cells["Número de Nómina"].Value.ToString();
                lbEstado.Text = selectedRow.Cells["Estado"].Value.ToString();
                TipoUsuario= selectedRow.Cells["Tipo de Usuario"].Value.ToString();

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

                string PasswordsAnts = GetSafeString(selectedRow, "Contraseñas Anteriores");

                HistorialPasswords.IdUsuario = int.Parse(lbUsuarioId.Text);
                HistorialPasswords.PasswordAct = selectedRow.Cells["Contraseña"].Value.ToString();
                HistorialPasswords.PasswordAnt1 = "";
                HistorialPasswords.PasswordAnt2 = "";
                string[] PartesP= PasswordsAnts.Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries);
                foreach (string parteP in PartesP)
                {
                    if (parteP.StartsWith("Pass1:"))
                    {
                        HistorialPasswords.PasswordAnt1= parteP.Replace("Pass1:", "").Trim() ;
                    }
                    else if (parteP.StartsWith("Pass2:"))
                    {
                        HistorialPasswords.PasswordAnt2 = parteP.Replace("Pass2:", "").Trim();
                    }
                }

                if (DateTime.TryParseExact(GetSafeString(selectedRow, "Fecha de Nacimiento"),
                "dd/MMM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime fechaNac))
                {
                    datFechNacimiento.Value = fechaNac;
                }


                btnHabilitar.Text = lbEstado.Text == "Habilitado" ? "Deshabilitar" : "Habilitar";
                btnHabilitar.BackColor = btnHabilitar.Text == "Habilitar" ? Color.LightGreen : Color.LightCoral;

            }
        }
        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            var obj=new EnlaceDB();
            int IDUsuario= int.Parse(lbUsuarioId.Text); 
            string EstadoAct= lbEstado.Text;
            string Correo = txtCorreo.Text;
            string UsuarioSesion = SesionUsuario.Correo;

            if (Correo == UsuarioSesion)
            {
                MessageBox.Show("No puedes deshabilitar Usuario conectado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (EstadoAct == "Habilitado")
                {
                    if (obj.CambiarEstado(IDUsuario))
                    {
                        Cargar();
                        lbEstado.Text = "Deshabilitado";
                        MessageBox.Show("Usuario Deshabilitado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("IdUsuario no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (EstadoAct == "Deshabilitado")
                {
                    if (obj.CambiarEstado(IDUsuario))
                    {
                        Cargar();
                        lbEstado.Text = "Habilitado";
                        MessageBox.Show("Usuario Habilitado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("IdUsuario no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                btnHabilitar.Text = lbEstado.Text == "Habilitado" ? "Deshabilitar" : "Habilitar";
                btnHabilitar.BackColor = btnHabilitar.Text == "Habilitar" ? Color.LightGreen : Color.LightCoral;
            }
            
        }

        private void btnNewPassword_Click(object sender, EventArgs e)
        {
            CambiarContrasena cambiarContrasena = new CambiarContrasena();
            cambiarContrasena.ShowDialog();

            isPasswordVisible = false;

            if (!isPasswordVisible)
            {
                txtPassword.PasswordChar = '*';
            }

            txtPassword.Text = HistorialPasswords.PasswordAct;
            Cargar();

        }

        private bool ValidarNombre(string nombre)
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

        private bool ValidarPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                return false;

            bool tieneMayuscula = password.Any(char.IsUpper);
            bool tieneMinuscula = password.Any(char.IsLower);
            bool tieneEspecial = password.Any(c => !char.IsLetterOrDigit(c));

            return tieneMayuscula && tieneMinuscula && tieneEspecial;
        }

        private bool ValidarNomina(string nomina)
        {
            if (string.IsNullOrWhiteSpace(nomina) || nomina.Length != 8)
                return false;

            bool letrasValidas = nomina.Take(3).All(char.IsUpper);

            bool numerosValidos = nomina.Skip(3).Take(5).All(char.IsDigit);

            return letrasValidas && numerosValidos;
        }

        private bool ValidarTelefono(string telefono)
        {
            return !string.IsNullOrWhiteSpace(telefono) &&
                   telefono.Length >=7 &&
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
            if (!ValidarCorreo(txtCorreo.Text))
            {
                lbErrorCorreo.Visible = true;
                txtCorreo.Focus();
                return;
            }
            else lbErrorCorreo.Visible = false;

            if (!ValidarPassword(txtPassword.Text))
            {
                lbErrorPassword.Visible = true;
                txtPassword.Focus();
                return;
            }
            else lbErrorPassword.Visible = false;

            if (!ValidarNombre(txtNombre.Text))
            {
                lbErrorNombre.Visible = true;
                txtNombre.Focus();
                return;
            }
            else lbErrorNombre.Visible = false;

            if (!ValidarNombre(txtApellidos.Text))
            {
                lbErrorApellidos.Visible = true;
                txtApellidos.Focus();
                return;
            }
            else lbErrorApellidos.Visible = false;

            if (!ValidarNomina(txtNomina.Text) && TipoUsuario!="Administrador")
            {
                lbErrorNomina.Visible = true;
                txtNomina.Focus();
                return;
            }
            else lbErrorNomina.Visible = false;

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

            if (!EsMayorEdad(datFechNacimiento.Value))
            {
                lbErrorFechaNac.Visible = true;
                txtTelCasa.Focus();
                return;
            }
            else lbErrorFechaNac.Visible = false;

            string fechaFormateada = datFechNacimiento.Value.ToString("dd/MM/yyyy");

            var Usuarios = new EnlaceUsuarios();
            Usuarios.UsuarioID = int.Parse(lbUsuarioId.Text);
            Usuarios.Nombre = txtNombre.Text;
            Usuarios.Apellidos = txtApellidos.Text;
            Usuarios.Correo = txtCorreo.Text;
            Usuarios.PasswordAct = txtPassword.Text;
            Usuarios.NumeroNomina = txtNomina.Text;
            Usuarios.TipoUsuario = "Operativo";
            Usuarios.FechaNacimiento = fechaFormateada;
            Usuarios.UsuarioRegistrador= SesionUsuario.IDUser;
            Usuarios.TelefonoCasa=txtTelCasa.Text;
            Usuarios.Celular=txtCelular.Text;

            var obj = new EnlaceDB();

            var BuscarUsuario = obj.BuscarID();

            var CorreoExiste = BuscarUsuario.FirstOrDefault(u =>
            u.Correo == Usuarios.Correo);

            var NominaExiste = BuscarUsuario.FirstOrDefault(u =>
            u.NumeroNomina==Usuarios.NumeroNomina);

            var IDExite = BuscarUsuario.FirstOrDefault(u =>
            u.UsuarioID == Usuarios.UsuarioID);

            if(IDExite != null){
                DialogResult respuesta = MessageBox.Show(
            $"¿Está seguro que desea actualizar los datos del usuario {IDExite.Correo}?",
            "Confirmar actualización",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);

                if (respuesta == DialogResult.Yes)
                {
                    obj.ActualizarUsuario(Usuarios);
                    MessageBox.Show("Usuario actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cargar();
                }
            }
            else
            {
                if (CorreoExiste != null)
                {
                    MessageBox.Show("Correo " + Usuarios.Correo + " ya esta registrado por otro usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (NominaExiste != null)
                {
                    MessageBox.Show("El numero de nomina " + Usuarios.NumeroNomina + " ya esta registrado con el usuario " + NominaExiste.Correo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                obj.CrearUsuario(Usuarios);
                LimpiarCampos();
                Cargar();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            Cargar();
        }

        private int GenerarIdAleatorio()
        {
            var obj = new EnlaceDB();
            var BuscarUsuario = obj.BuscarID();

            Random random = new Random();
            int IDNuevo;
            do
            {
                IDNuevo = random.Next(1000, 10000);
            } while (BuscarUsuario.Any(U => U.UsuarioID == IDNuevo));

            return IDNuevo;
        }
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCorreo.Clear();
            txtPassword.Clear();
            txtNomina.Clear();
            txtApellidos.Clear();
            txtCelular.Clear();
            txtTelCasa.Clear();
            datFechNacimiento.Value = DateTime.Today.AddYears(-18);
            btnSave.Text = "Guardar";

            int id_Aleatorio = GenerarIdAleatorio();
            lbUsuarioId.Text = id_Aleatorio.ToString();

            var obj = new EnlaceDB();
            var BuscarUsuario = obj.BuscarID();

            var IDExite = BuscarUsuario.FirstOrDefault(u =>
            u.UsuarioID == int.Parse(lbUsuarioId.Text));

            if (IDExite != null)
            {
                int idAle = GenerarIdAleatorio();
                lbUsuarioId.Text = idAle.ToString();
            }

            btnCancel.Enabled = false;
            ShowPassword.Visible = false;
            btnNewPassword.Visible = false;
            btnHabilitar.Visible = false;
            txtPassword.ReadOnly = false;
            txtPassword.PasswordChar = '\0';
            lbEst.Visible = false; lbEstado.Visible = false;
        }

        private void ShowPassword_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }
    }
}
