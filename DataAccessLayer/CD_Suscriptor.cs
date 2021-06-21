using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entities;


namespace DataAccessLayer
{
    public class CD_Suscriptor
    {
        SqlConnection cnx = new SqlConnection("Data Source=DESKTOP-K8CJ3KA;Initial Catalog=Desafio1;Integrated Security=True");
        Suscriptor suscriptor = new Suscriptor();
        AccesoDB MiConexi = new AccesoDB();
        SqlCommand cmd = new SqlCommand();
        bool vexito;
        
        public bool NuevoSuscriptor(Suscriptor suscriptor)
        {
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "nuevo_suscriptor";
            try
            {
                cmd.Parameters.Add(new SqlParameter("@nom", SqlDbType.VarChar, 50));
                cmd.Parameters["@nom"].Value = suscriptor.Nombre;
                cmd.Parameters.Add(new SqlParameter("@ape", SqlDbType.VarChar, 50));
                cmd.Parameters["@ape"].Value = suscriptor.Apellido;
                cmd.Parameters.Add(new SqlParameter("@numDoc", SqlDbType.Int));
                cmd.Parameters["@numDoc"].Value = suscriptor.NumeroDocumento;
                cmd.Parameters.Add(new SqlParameter("@tipoDoc", SqlDbType.Int));
                cmd.Parameters["@tipoDoc"].Value = suscriptor.TipoDocumento;
                cmd.Parameters.Add(new SqlParameter("@dir", SqlDbType.VarChar, 50));
                cmd.Parameters["@dir"].Value = suscriptor.Direccion;
                cmd.Parameters.Add(new SqlParameter("@tel", SqlDbType.Int));
                cmd.Parameters["@tel"].Value = suscriptor.Telefono;
                cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 50));
                cmd.Parameters["@email"].Value = suscriptor.Email;
                cmd.Parameters.Add(new SqlParameter("@usuario", SqlDbType.VarChar, 50));
                cmd.Parameters["@usuario"].Value = suscriptor.NombreUsuario;
                cmd.Parameters.Add(new SqlParameter("@pw", SqlDbType.VarChar, 50));
                cmd.Parameters["@pw"].Value = suscriptor.Password;
                cnx.Open();
                cmd.ExecuteNonQuery();
                vexito = true;
            }
            catch (SqlException)
            {
                vexito = false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return vexito;
        }
        public bool ActualizarSuscriptor(Suscriptor suscriptor)
        {
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "editar_suscriptor";
            try
            {
                cmd.Parameters.Add(new SqlParameter("@nom", SqlDbType.VarChar, 50));
                cmd.Parameters["@nom"].Value = suscriptor.Nombre;
                cmd.Parameters.Add(new SqlParameter("@ape", SqlDbType.VarChar, 50));
                cmd.Parameters["@ape"].Value = suscriptor.Apellido;
                cmd.Parameters.Add(new SqlParameter("@numDoc", SqlDbType.Int));
                cmd.Parameters["@numDoc"].Value = suscriptor.NumeroDocumento;
                cmd.Parameters.Add(new SqlParameter("@tipoDoc", SqlDbType.Int));
                cmd.Parameters["@tipoDoc"].Value = suscriptor.TipoDocumento;
                cmd.Parameters.Add(new SqlParameter("@dir", SqlDbType.VarChar, 50));
                cmd.Parameters["@dir"].Value = suscriptor.Direccion;
                cmd.Parameters.Add(new SqlParameter("@tel", SqlDbType.Int));
                cmd.Parameters["@tel"].Value = suscriptor.Telefono;
                cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 50));
                cmd.Parameters["@email"].Value = suscriptor.Email;
                cmd.Parameters.Add(new SqlParameter("@usuario", SqlDbType.VarChar, 50));
                cmd.Parameters["@usuario"].Value = suscriptor.NombreUsuario;
                cmd.Parameters.Add(new SqlParameter("@pw", SqlDbType.VarChar, 50));
                cmd.Parameters["@pw"].Value = suscriptor.Password;
                cnx.Open();
                cmd.ExecuteNonQuery();
                vexito = true;
            }
            catch (SqlException)
            {
                vexito = false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return vexito;
        }

        public Suscriptor BuscarSuscriptor(int tipoDoc, long numDoc)
        {
            try
            {
                SqlDataReader dtr;
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "buscar_suscriptor";
                cmd.Parameters.Add(new SqlParameter("@tipoDoc", SqlDbType.Int));
                cmd.Parameters["@tipoDoc"].Value = tipoDoc;
                cmd.Parameters.Add(new SqlParameter("@numDoc", SqlDbType.BigInt));
                cmd.Parameters["@numDoc"].Value = numDoc;

                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    suscriptor.Nombre = Convert.ToString(dtr["Nombre"]);
                    suscriptor.Apellido = Convert.ToString(dtr["Apellido"]);
                    suscriptor.Direccion = Convert.ToString(dtr["Direccion"]);
                    suscriptor.Telefono = (int)Convert.ToInt64(dtr["Telefono"]);
                    suscriptor.Email = Convert.ToString(dtr["Email"]);
                    suscriptor.NombreUsuario = Convert.ToString(dtr["NombreUsuario"]);
                    suscriptor.Password = Convert.ToString(dtr["Password"]);
                }
                cnx.Close();
                cmd.Parameters.Clear();
                return suscriptor;
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

