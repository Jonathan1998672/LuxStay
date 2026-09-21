using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_MAD
{
    public class EnlaceHoteles
    {
        public int HotelID { get; set; }
        public int TipoHabID { get; set; }
        public int ServicioID { get; set; }
        public int AmenidadID { get; set; }
        public int HabitacionID {  get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Caracteristicas { get; set; }
        public int NumPisos { get; set; }
        public int NumHabitaciones { get; set; }
        public int UsuarioRegistrador { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }
        public string NombreServicio { get; set; }
        public decimal PrecioServicio { get; set; }
        public string FechaInicioOperaciones { get; set; }
        public string Nivel { get; set; }
        public decimal PrecioNoche { get; set; }
        public string PrecioFormateado { get; set; }
        public int CantPersonas { get; set; }
        public string CaractTipHab { get; set; }
        public string NombreAmenidad { get; set; }
        public decimal PrecioAmenidad { get; set; }
        public string numeroHabitacion {  get; set; }
    }
}
