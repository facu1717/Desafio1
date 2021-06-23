using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using BusinessLogicLayer;
using Entities;


namespace Desafio
{
    public partial class WebForm : System.Web.UI.Page
    {
        NG_Suscriptor ng_Suscriptor = new NG_Suscriptor();
        NG_Suscripcion ng_Suscripcion = new NG_Suscripcion();
        Suscriptor suscriptor = new Suscriptor();
        Suscripcion sus = new Suscripcion();
        bool vigente = false;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            solo_read();
            txt_oculto.Visible = false;
            txt_modificar.Visible = false;
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
                CargarCampos();
                
            }
            
        }

        private void CargarCampos()
        {
            try
            {
                txt_oculto.Text = suscriptor.IdSuscriptor.ToString();
                txt_nombre.Text = suscriptor.Nombre.ToString();
                txt_apellido.Text = suscriptor.Apellido.ToString();
                txt_direccion.Text = suscriptor.Direccion.ToString();
                txt_email.Text = suscriptor.Email.ToString();
                txt_telefono.Text = suscriptor.Telefono.ToString();
                txt_usuario.Text = suscriptor.NombreUsuario.ToString();
                txt_contraseña.Text = suscriptor.Password.ToString();

            }
            catch
            {
                MessageBox.Show("No se encontro el suscriptor");
            }


        }

        private void LimpiarCampos()
        {
            txt_nombre.Text = "";
            txt_apellido.Text = "";
            txt_direccion.Text = "";
            txt_email.Text = "";
            txt_telefono.Text = "";
            txt_usuario.Text = "";
            txt_contraseña.Text = "";
        }

        protected void btn_aceptar_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txt_modificar.Text) == true)
            {
                if (Estavigente() == false)
                {
                    Suscripcion suscripcion = new Suscripcion();
                    DateTime fechaActual = DateTime.Now;
                    suscriptor.IdSuscriptor = int.Parse(txt_oculto.Text);
                    suscripcion.IdSuscriptor = suscriptor.IdSuscriptor;
                    suscripcion.FechaAlta = fechaActual;
                    ng_Suscripcion.Registrar_Suscripcion(suscripcion);
                    MessageBox.Show("¡Se registro la suscripción correctamente!");
                    Response.Redirect("WebForm.aspx");
                }
                else
                {
                    MessageBox.Show("No puede registrar una nueva suscripción, debido a que ya tiene una vigente");
                    Response.Redirect("WebForm.aspx");
                }
            }
            else
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
                    suscriptor.Telefono = Convert.ToInt64(txt_telefono.Text);
                    suscriptor.NumeroDocumento = Convert.ToInt32(txt_numDoc.Text);
                    suscriptor.TipoDocumento = Convert.ToInt32(ComboBox.SelectedValue);

                    ng_Suscriptor.Actualizar_Suscriptor(suscriptor);
                    MessageBox.Show("Se ha modificado correctamente el suscriptor");
                    Response.Redirect("WebForm.aspx");
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el suscriptor");
                    Response.Redirect("WebForm.aspx");
                }
                
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
            if(String.IsNullOrEmpty(txt_numDoc.Text) == false )
            {
                int TipoDocumento = Convert.ToInt32(ComboBox.SelectedItem.Value);
                long NumeroDocumento = long.Parse(txt_numDoc.Text);

                suscriptor = ng_Suscriptor.Buscar_Suscriptor(TipoDocumento, NumeroDocumento);
                return suscriptor;
            }
            else
            {
                MessageBox.Show("Coloque su numero de documento");
                return null;
            }
            
        }

        protected void btn_nuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Nuevo.aspx");
        }

        private void solo_read()
        {
            txt_apellido.ReadOnly = true;
            txt_nombre.ReadOnly = true;
            txt_telefono.ReadOnly = true;
            txt_contraseña.ReadOnly = true;
            txt_email.ReadOnly = true;
            txt_direccion.ReadOnly = true;
            txt_usuario.ReadOnly = true;
        }

        private void habilitar_campos()
        {
            txt_apellido.ReadOnly = false;
            txt_nombre.ReadOnly = false;
            txt_telefono.ReadOnly = false;
            txt_contraseña.ReadOnly = false;
            txt_email.ReadOnly = false;
            txt_direccion.ReadOnly = false;
            txt_usuario.ReadOnly = false;
        }
        protected void btn_modificar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_numDoc.Text) == false)
            {
                habilitar_campos();
                f_modificar();
            }
            else
            {
                MessageBox.Show("Debe buscar el suscriptor antes de poder modificar");
            }
            
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
        private void f_modificar()
        {
            txt_modificar.Text = "modificar";
        }
    }
}