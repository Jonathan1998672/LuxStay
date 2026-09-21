using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_MAD
{
    public class EnlaceReservaciones
    {
        public Guid ReservacionID {  get; set; }
        public decimal Anticipo { get; set; }
        public decimal PrecioNoche { get; set; }
        public bool CheckIn {  get; set; }
        public bool CheckOut { get; set; }
        public string Estatus { get; set; }
        public string FechaCheckIn {  get; set; }
        public string FechaCheckOut { get; set;}
        public DateTime FechCheckIn { get; set; }
        public DateTime FechCheckOut { get; set; }
        public int CantidadPersonas {  get; set; }
        public int UsuarioRegistro {  get; set; }
        public int TipoHabID {  get; set; }
        public int HabitacionID {  get; set; }
        public int ClienteID { get; set; }

    }
}
