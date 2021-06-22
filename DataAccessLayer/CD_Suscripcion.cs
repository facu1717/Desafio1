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
        SqlCommand cmd = new SqlCommand();
        Suscripcion suscripcion = new Suscripcion();
        //SqlConnection cnx = new SqlConnection("Data Source=10.100.100.102\\SQLSERVER2008;User ID=pasantes;Password=sqladmin");
        SqlConnection cnx = new SqlConnection("Data Source=DESKTOP-K8CJ3KA;Initial Catalog=Desafio1;Integrated Security=True");

        public bool IsDBNull { get; private set; }

        public void Registrar_Suscripcion(Suscripcion suscripcion)
        {
            try
            {
                cnx.Open();
                string query = "insert into Suscripcion (IdSuscriptor,FechaAlta) values ('" + suscripcion.IdSuscriptor + "','" + suscripcion.FechaAlta + "')";
                SqlCommand sqlCommand = new SqlCommand(query, cnx);
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
        public Suscripcion validar_suscripcion(int id_suscriptor)
        {
            try
            {
                SqlDataReader dtr;
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "proc_ExisteSuscripcion";
                cmd.Parameters.Add(new SqlParameter("@IdSuscriptor", SqlDbType.Int));
                cmd.Parameters["@IdSuscriptor"].Value = id_suscriptor;


                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    suscripcion.IdAsociacion = Convert.ToInt32(dtr["IdAsociación"]);
                    suscripcion.IdSuscriptor = Convert.ToInt32(dtr["IdSuscriptor"]);
                    suscripcion.FechaAlta = Convert.ToDateTime(dtr["FechaAlta"]);
                    suscripcion.FechaFin = Convert.ToString(dtr["FechaFin"]); 
                    suscripcion.MotivoFin = Convert.ToString(dtr["MotivoFin"]);
                    
                }
                cnx.Close();
                cmd.Parameters.Clear();
                return suscripcion;
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
                cmd.Parameters.Clear();
            }


        }
    }
}
