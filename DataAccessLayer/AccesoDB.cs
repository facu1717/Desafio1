using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DataAccessLayer
{
    public class AccesoDB
    {
        private SqlConnection conexion;

        private void Abrir()
        {
            conexion = new SqlConnection("Data Source = 10.100.100.102\\SQLSERVER2008; Persist Security Info = False; User ID = pasantes; Password = sqladmin; Initial Catalog = DesafioEncode");
            conexion.Open();
        }
        private void Cerrar()
        {
            conexion.Close();
            conexion = null;
            GC.Collect();
        }
        public SqlCommand CrearComando(string nombre, List<SqlParameter> parametros)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandText = nombre;
            comando.CommandType = CommandType.StoredProcedure;
            if (parametros != null && parametros.Count > 0)
            {
                comando.Parameters.AddRange(parametros.ToArray());
            }
            return comando;
        }
        //Leer cualquier procedimiento almacenado y que nos llene una tabla
        public DataTable Leer(string nombre, List<SqlParameter> parametros)
        {
            Abrir();
            DataTable tabla = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter();
            adap.Fill(tabla);
            adap = null;
            Cerrar();
            return tabla;
        }
        //
        public int Escrbir(string nombre, List<SqlParameter> parametros)
        {

            int filasAfectas = 0;
            Abrir();
            SqlCommand comando = CrearComando(nombre, parametros);
            try
            {
                filasAfectas = comando.ExecuteNonQuery();
            }
            catch
            {
                filasAfectas = -1;
            }

            Cerrar();
            return filasAfectas;

        }
        //Crear parametros sin nombre
        public SqlParameter CrearParametro(string nombre, string valor)
        {
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = nombre;
            parametro.Value = valor;
            parametro.DbType = DbType.String;
            return parametro;
        }
        public SqlParameter CrearParametro(string nombre, int valor)
        {
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = nombre;
            parametro.Value = valor;
            parametro.DbType = DbType.Int32;
            return parametro;
        }
        public DataTable ejecutar_consulta(string sql)
        {
            Abrir();
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            comando.CommandText = sql;
            tabla.Load(comando.ExecuteReader());
            Cerrar();
            return tabla;
        }
    }
}



