using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_MAD
{
    public class EnlaceFactura
    {

        public Guid FacturaID { get; set; }
        public Guid ReservacionID { get; set; }
        public decimal MontoServicios { get; set; }
        public decimal MontoHospedaje { get; set; }
        public decimal MontoTotal { get; set; }
        public string Pais { get; set; }
    }
}
