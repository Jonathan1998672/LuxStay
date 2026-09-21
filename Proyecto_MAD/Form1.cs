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
    public partial class Form1 : Form
    {
        private bool isPasswordVisible = false;

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Exit_FormClosing;
            
        }
        private void Exit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            var obj = new EnlaceDB();
            obj.CancelacionAutomatica();

            comboBox1.SelectedIndex = 0;


            RecordarUsuario.Checked = Properties.Settings.Default.RememberUser;
            if (RecordarUsuario.Checked) { 
            txtCorreo.Text=Properties.Settings.Default.SavedEmail;
            }
        }
        public static class SesionUsuario
        {
            public static string Correo { get; set; }
            public static int IDUser { get; set; }
        }


        private void button1_Click(object sender, EventArgs e)
        {

            string seleccion = comboBox1.SelectedItem.ToString();

            var CorreoIng=txtCorreo.Text;
            var PasswordIng=txtPassword.Text;
            var TipoSel= comboBox1.SelectedItem.ToString();
            var onj = new EnlaceDB();

            var BuscarUsuario=onj.BuscarID();

            var IDUser=BuscarUsuario.FirstOrDefault(u=>
            u.Correo.Equals(CorreoIng, StringComparison.OrdinalIgnoreCase));

            var UserDeshabilitado = BuscarUsuario.FirstOrDefault(u =>
            u.Correo.Equals(CorreoIng, StringComparison.OrdinalIgnoreCase) &&
            !u.Estado);


            if (string.IsNullOrWhiteSpace(txtCorreo.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Ingresa todos los campos ");
                return;
            }

            if (IDUser == null)
            {
                MessageBox.Show("No hay usuario con el correo " + CorreoIng + " en la Base de datos");
                return;
            }

            if (UserDeshabilitado != null)
            {
                MessageBox.Show("El usuario " + CorreoIng + " esta deshabilitado");
                return;
            }

            if (seleccion == "Operativo")
            {
                if (onj.IniciarSesion(CorreoIng, PasswordIng, TipoSel))
                {
                    if (RecordarUsuario.Checked)
                    {
                        Properties.Settings.Default.SavedEmail = txtCorreo.Text;
                        Properties.Settings.Default.RememberUser = true;
                    }
                    else
                    {
                        Properties.Settings.Default.SavedEmail = "";
                        Properties.Settings.Default.RememberUser = false;
                    }

                    Properties.Settings.Default.Save();

                    SesionUsuario.Correo = CorreoIng;
                    SesionUsuario.IDUser = IDUser.UsuarioID;

                    MessageBox.Show("Inicio de sesión exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MenuOperativos ventana = new MenuOperativos();
                    ventana.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (seleccion == "Administrador")
            {
                if (onj.IniciarSesion(CorreoIng, PasswordIng, TipoSel))
                {
                    if (RecordarUsuario.Checked)
                    {
                        Properties.Settings.Default.SavedEmail = txtCorreo.Text;
                        Properties.Settings.Default.RememberUser = true;
                    }
                    else
                    {
                        Properties.Settings.Default.SavedEmail = "";
                        Properties.Settings.Default.RememberUser = false;
                    }

                    Properties.Settings.Default.Save();

                    SesionUsuario.Correo = CorreoIng;
                    SesionUsuario.IDUser = IDUser.UsuarioID;

                    MessageBox.Show("Inicio de sesión exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MenuAdministradores ventana = new MenuAdministradores();
                    ventana.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
