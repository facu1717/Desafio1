using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DataAccessLayer
{
    class MP_Suscriptor
    {
        private AccesoDB acceso = new AccesoDB();
        public List<Entities.Suscriptor> BuscarSuscriptor()
        {
            DataTable tabla = acceso.Leer("buscar_suscriptor", null);

        }
    }
}
