using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HS_APP;
using WindowsFormsApplication1;
using static Proyecto_MAD.GestionUsuarios;

namespace Proyecto_MAD
{
    public partial class CambiarContrasena : Form
    {
        public CambiarContrasena()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CambiarContrasena_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string NewPassword = txtNewPassword.Text;
            string ConfirmNewPassw = txtConfirmPassword.Text;
            var Usuarios = new EnlaceUsuarios();
            Usuarios.UsuarioID = HistorialPasswords.IdUsuario;
            Usuarios.PasswordAct = NewPassword;
            Usuarios.PasswordAnt1 = HistorialPasswords.PasswordAct;
            Usuarios.PasswordAnt2 = HistorialPasswords.PasswordAnt1;
            var obj = new EnlaceDB();

            if (NewPassword != ConfirmNewPassw)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NewPassword == HistorialPasswords.PasswordAct)
            {
                MessageBox.Show("La nueva contraseña debe ser diferente al actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NewPassword == HistorialPasswords.PasswordAnt1 || NewPassword == HistorialPasswords.PasswordAnt2)
            {
                MessageBox.Show("La contraseña debe ser diferente a las dos contraseñas anteriores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            obj.ActualizaHistorialPasswords(Usuarios);
            HistorialPasswords.PasswordAct = NewPassword;
            HistorialPasswords.PasswordAnt1= Usuarios.PasswordAnt1;
            HistorialPasswords.PasswordAnt2= Usuarios.PasswordAnt2;
            Close();
        }
    }
}
