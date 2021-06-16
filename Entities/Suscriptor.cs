using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Suscriptor
    {
        public int IdSuscriptor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int NumeroDocumento { get; set; }
        public int TipoDocumento { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
    }
}
