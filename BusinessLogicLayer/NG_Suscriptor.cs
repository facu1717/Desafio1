using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Entities;


namespace BusinessLogicLayer
{
    public class NG_Suscriptor
    {
        CD_Suscriptor CD_Suscriptor = new CD_Suscriptor();

        public bool Nuevo_Suscriptor (Suscriptor suscriptor)
        {
            return CD_Suscriptor.NuevoSuscriptor(suscriptor);
        }

        public bool Actualizar_Suscriptor (Suscriptor suscriptor)
        {
            return CD_Suscriptor.ActualizarSuscriptor(suscriptor);
        }

        public Suscriptor Buscar_Suscriptor (int tipoDoc, long numDoc)
        {
            return CD_Suscriptor.BuscarSuscriptor(tipoDoc,numDoc);
        }


    }
}
