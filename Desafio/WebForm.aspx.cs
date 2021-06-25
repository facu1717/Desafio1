using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Encode.Funciones;
using BusinessLogicLayer;
using Entities;
using System.Security.Cryptography;
using System.Text;

namespace Desafio
{
    public partial class WebForm : System.Web.UI.Page
    {
        NG_Suscriptor ng_Suscriptor = new NG_Suscriptor();
        NG_Suscripcion ng_Suscripcion = new NG_Suscripcion();
        Suscriptor suscriptor = new Suscriptor();
        Suscripcion sus = new Suscripcion();
        bool vigente = false;
        string stKey = "ABCabc123";
        protected void Page_Load(object sender, EventArgs e)
        {
            solo_read();
            txt_oculto.Visible = false;
            txt_modificar.Visible = false;
            btn_modificar.Visible = false;

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

            if (buscar() != null)
            {
                txt_desencriptada.Visible = true;
                btn_desencriptar.Visible = true;
                lbl.Visible = true;
                btn_modificar.Visible = true;
                CargarCampos();
            }

        }

        private void CargarCampos()
        {
            try
            {
                Suscriptor suscriptor = buscar();
                txt_oculto.Text = suscriptor.IdSuscriptor.ToString();
                txt_nombre.Text = suscriptor.Nombre.ToString();
                txt_apellido.Text = suscriptor.Apellido.ToString();
                txt_direccion.Text = suscriptor.Direccion.ToString();
                txt_email.Text = suscriptor.Email.ToString();
                txt_telefono.Text = suscriptor.Telefono.ToString();
                txt_usuario.Text = suscriptor.NombreUsuario.ToString();
                txt_contraseña.Text = DesencriptarPassword(suscriptor.Password, stKey);

            }
            catch
            {
                MessageBox.Show("No se encontro el suscriptor");
                btn_modificar.Visible = false;

            }


        }

        protected void btn_aceptar_Click(object sender, EventArgs e)
        {
            Suscriptor suscriptor1 = buscar();
            if (String.IsNullOrEmpty(txt_modificar.Text) == true)
            {
                if (txt_numDoc.Text == "")
                {
                    MessageBox.Show("Ingrese tipo y numero de documento","info");
                    return;
                }
                long digitos = (long)Math.Floor(Math.Log10(long.Parse(txt_numDoc.Text)) + 1);
                if (digitos != 8)
                {
                    MessageBox.Show("Cantidad de dígitos del numero de documento no válida", "error");
                    return;

                }
                if(suscriptor1.Nombre == null)
                {
                    MessageBox.Show("No existe un suscriptor con estos datos","info");
                    LimpiarCampos();
                    return;
                }
                if (Estavigente() == false)
                {

                    MessageBox.ShowConfirmation("Estas seguro que desea registrar una nueva suscripcion?", "Atencion", "Aceptar", "Cancelar", "$('#" + btn_confirmar_guardado.ClientID + "').click();");

                }
                else
                {
                    MessageBox.Show("No puede registrar una nueva suscripción, debido a que ya tiene una vigente", "error");

                }
            }
            else
            {
                bool Resultado;
                Suscriptor suscriptor = new Suscriptor();
                Resultado = validarDatos();

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

                    suscriptor.Password = EncriptarPassword(suscriptor.Password, stKey);

                    ng_Suscriptor.Actualizar_Suscriptor(suscriptor);
                    MessageBox.Show("Se ha modificado correctamente el suscriptor", "success");
                    LimpiarCampos();
                    txt_numDoc.Enabled = true;
                    ComboBox.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el suscriptor", "error");

                }

            }


        }
        protected void btn_confirmar_guardado_Click(object sender, EventArgs e)
        {
            try
            {

                Suscriptor suscriptor = buscar();
                Suscriptor suscriptorNuevo = new Suscriptor();
                Suscripcion suscripcion = new Suscripcion();
                DateTime fechaActual = DateTime.Now;
                suscriptorNuevo.IdSuscriptor = int.Parse(suscriptor.IdSuscriptor.ToString());
                suscripcion.IdSuscriptor = suscriptorNuevo.IdSuscriptor;
                suscripcion.FechaAlta = fechaActual;
                ng_Suscripcion.Registrar_Suscripcion(suscripcion);
                MessageBox.Show("¡Se registro la suscripción correctamente!", "success", "Bien hecho");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", "Ocurrio un error");

            }
        }
        private bool Estavigente()
        {
            Suscriptor suscriptor = buscar();
            sus = ng_Suscripcion.Validar_suscripcion(suscriptor.IdSuscriptor);
            if (sus.FechaFin == "")
            {
                vigente = true;
            }

            return vigente;
        }
        private Suscriptor buscar()
        {
            try
            {
                if (txt_numDoc.Text == "")
                {
                    MessageBox.Show("Ingrese tipo y numero de documento", "info");
                    return null;
                }

                long digitos = (long)Math.Floor(Math.Log10(long.Parse(txt_numDoc.Text)) + 1);

                if (digitos != 8)
                {
                    MessageBox.Show("Cantidad de dígitos del numero de documento no válida", "error");
                    return null;
                }

                if (String.IsNullOrEmpty(txt_numDoc.Text) == false)
                {
                    txt_numDoc.Enabled = true;
                    ComboBox.Enabled = true;
                    int TipoDocumento = Convert.ToInt32(ComboBox.SelectedItem.Value);
                    long NumeroDocumento = long.Parse(txt_numDoc.Text);

                    suscriptor = ng_Suscriptor.Buscar_Suscriptor(TipoDocumento, NumeroDocumento);
                    return suscriptor;
                }
                else
                {
                    MessageBox.Show("Coloque su numero de documento", "info");
                    return null;
                }

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Ocurrio algo", "error");
                return null;
            }
            

        }

        protected void btn_nuevo_Click(object sender, EventArgs e)
        {

            string script = @"window.location.href='Nuevo.aspx';";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "Redireccionar", script, true);
        }

        private void LimpiarCampos()
        {
            txt_apellido.Text = "";
            txt_nombre.Text = "";
            txt_telefono.Text = "";
            txt_contraseña.Text = "";
            txt_email.Text = "";
            txt_direccion.Text = "";
            txt_usuario.Text = "";

        }
        private void solo_read()
        {
            txt_apellido.Enabled = false;
            txt_nombre.Enabled = false;
            txt_telefono.Enabled = false;
            txt_contraseña.Enabled = false;
            txt_email.Enabled = false;
            txt_direccion.Enabled = false;
            txt_usuario.Enabled = false;
            txt_desencriptada.Enabled = false;
        }

        private void habilitar_campos()
        {

            txt_apellido.Enabled = true;
            txt_nombre.Enabled = true;
            txt_telefono.Enabled = true;
            txt_contraseña.Enabled = true;
            txt_email.Enabled = true;
            txt_direccion.Enabled = true;
            txt_usuario.Enabled = true;
        }
        protected void btn_modificar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_numDoc.Text) == false)
            {
                txt_desencriptada.Visible = false;
                btn_desencriptar.Visible = false;
                lbl.Visible = false;
                txt_numDoc.Enabled = false;
                ComboBox.Enabled = false;
                habilitar_campos();
                f_modificar();
            }
            else
            {
                MessageBox.Show("Debe buscar el suscriptor antes de poder modificar", "info");
            }

        }
        private bool validarDatos()
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
                MessageBox.Show("Faltan campos por completar", "error");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void f_modificar()
        {
            txt_modificar.Text = "modificar";
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
                stringEncripted = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buff, 0, buff.Length));


                return stringEncripted;

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void btn_desencriptar_Click(object sender, EventArgs e)
        {
            

            if (validarDatos() == true)
            {
                Suscriptor suscriptor = buscar();
                txt_desencriptada.Text = DesencriptarPassword(suscriptor.Password, stKey);
            }
            else
            {
                MessageBox.Show("Debe buscar un suscriptor para poder desencriptar", "error");
            }


        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm.aspx");
        }
        private void validarDoc()
        {
            int digitos = (int)Math.Floor(Math.Log10(int.Parse(txt_numDoc.Text)) + 1);
            if (digitos != 8)
            {
                MessageBox.Show("Cantidad de dígitos del numero de documento no válida", "error");
                return;

            }

        }
    }

}