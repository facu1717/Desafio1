using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Suscripcion
    {
        public int IdAsociacion { get; set; }
        public int IdSuscriptor { get; set; }
        public string FechaAlta { get; set; }
        public string FechaFin { get; set; }
        public string MotivoFin { get; set; }

    }
}
