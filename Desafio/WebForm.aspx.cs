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

    }
}