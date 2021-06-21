using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer
{
    public class CD_Suscripcion
    {
        SqlConnection cnx = new SqlConnection("Data Source=DESKTOP-K8CJ3KA;Initial Catalog=Desafio1;Integrated Security=True");
        public void Registrar_Suscripcion(Suscripcion suscripcion)
        {
            try
            {
                cnx.Open();
                string query = "insert into Suscripcion (IdSuscriptor,FechaAlta) values ('" + suscripcion.IdSuscriptor + "','" + suscripcion.FechaAlta + "')";
                SqlCommand sqlCommand = new SqlCommand(query,cnx);
                sqlCommand.ExecuteNonQuery();
                cnx.Close();
            }
            catch (SqlException)
            {
                throw new Exception();
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                
            }



        }
    }
}
