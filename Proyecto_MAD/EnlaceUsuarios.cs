using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HS_APP
{
    public class EnlaceUsuarios
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string PasswordAct { get; set; }
        public string PasswordAnt1 { get; set; }
        public string PasswordAnt2 { get; set; }
        public string NumeroNomina { get; set; }
        public string Celular {  get; set; }
        public string TelefonoCasa { get; set; }
        public string TipoUsuario { get; set; }
        public string FechaNacimiento { get; set; }
        public int UsuarioRegistrador { get; set; }
        public bool Estado {  get; set; }
    }
}
