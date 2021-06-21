using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Entities;

namespace BusinessLogicLayer
{ 
    public class NG_Suscripcion
    {
        CD_Suscripcion cd_Suscripcion = new CD_Suscripcion();
        public void Registrar_Suscripcion(Suscripcion sus)
        {
            cd_Suscripcion.Registrar_Suscripcion(sus);
        }
    }
}
