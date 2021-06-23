using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using Entities;
using Encode.Funciones;
using System.Security.Cryptography;
using System.Text;

namespace Desafio
{
    public partial class Nuevo : System.Web.UI.Page
    {
        NG_Suscriptor ng_Suscriptor = new NG_Suscriptor();
        NG_Suscripcion ng_Suscripcion = new NG_Suscripcion();
        Suscriptor suscriptor = new Suscriptor();
        Suscripcion sus = new Suscripcion();
        string stKey = "jekabc%*.";
        protected void Page_Load(object sender, EventArgs e)
        {
            txt_oculto.Visible = false;
            if (!IsPostBack)
            {

                DisplayData();
            }
        }

        private void DisplayData()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("DNI", "0"));
            items.Add(new ListItem("Libreta Civica", "1"));
            ComboBox.DataSource = items;
            ComboBox.DataValueField = "Value";
            ComboBox.DataTextField = "Text";
            ComboBox.DataBind();
        }

        protected void btnBtnBuscar(object sender, EventArgs e)
        {
            MessageBox.Show("Debe crear un nuevo suscriptor, complete todos los campos");
            return;
        }

        protected void btn_aceptar_Click(object sender, EventArgs e)
        {
            bool Resultado;
            Suscriptor suscriptor = new Suscriptor();
            Resultado = validarDatos(suscriptor);

            if (Resultado == true)
            {
                suscriptor.Nombre = txt_nombre.Text;
                suscriptor.Apellido = txt_apellido.Text;
                suscriptor.Direccion = txt_direccion.Text;
                suscriptor.Email = txt_email.Text;
                suscriptor.NombreUsuario = txt_usuario.Text;
                suscriptor.Password = txt_contraseña.Text;
                suscriptor.Telefono = Convert.ToString(txt_telefono.Text);
                suscriptor.NumeroDocumento = Convert.ToInt32(txt_numDoc.Text);
                suscriptor.TipoDocumento = Convert.ToInt32(ComboBox.SelectedValue);

                //suscriptor.Password = EncriptarPassword(suscriptor.Password, stKey);

                ng_Suscriptor.Nuevo_Suscriptor(suscriptor);
                MessageBox.Show("Se ha creado un nuevo suscriptor","success");
                

            }
            else
            {
                return;
            }
            
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {

        }

        private bool validarDatos(Suscriptor suscriptor)
        {
            if (String.IsNullOrEmpty(txt_nombre.Text) == true ||
            String.IsNullOrEmpty(txt_apellido.Text) == true ||
            String.IsNullOrEmpty(txt_telefono.Text) == true ||
            String.IsNullOrEmpty(txt_email.Text) == true ||
            String.IsNullOrEmpty(txt_contraseña.Text) == true ||
            String.IsNullOrEmpty(txt_usuario.Text) == true ||
            String.IsNullOrEmpty(txt_direccion.Text) == true ||
            String.IsNullOrEmpty(txt_numDoc.Text) == true)
            {
                MessageBox.Show("Faltan campos por completar");
                return false;
            }
            else
            {
                return true;
            }
        }
       
        public static string DesencriptarPassword(string Password, string stKey)
        {

            try
            {
                TripleDESCryptoServiceProvider des;
                MD5CryptoServiceProvider hashmd5;

                byte[] keyhash, buff;
                string stringDecripted;

                hashmd5 = new MD5CryptoServiceProvider();
                keyhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(stKey));

                hashmd5 = null;
                des = new TripleDESCryptoServiceProvider();

                des.Key = keyhash;
                des.Mode = CipherMode.ECB;

                buff = Convert.FromBase64String(Password);
                stringDecripted = ASCIIEncoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buff, 0, buff.Length));


                return stringDecripted;

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static string EncriptarPassword(string Password, string stKey)
        {
            try
            {
                TripleDESCryptoServiceProvider des;
                MD5CryptoServiceProvider hashmd5;

                byte[] keyhash, buff;
                string stringEncripted;

                hashmd5 = new MD5CryptoServiceProvider();
                keyhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(stKey));

                hashmd5 = null;
                des = new TripleDESCryptoServiceProvider();

                des.Key = keyhash;
                des.Mode = CipherMode.ECB;

                buff = ASCIIEncoding.ASCII.GetBytes(Password);
                stringEncripted = Convert.ToBase64String(des.CreateDecryptor().TransformFinalBlock(buff, 0, buff.Length));


                return stringEncripted;

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}