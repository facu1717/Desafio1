using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using BusinessLogicLayer;
using Entities;

namespace Desafio
{
    public partial class WebForm : System.Web.UI.Page
    {
        NG_Suscriptor ng_Suscriptor = new NG_Suscriptor();
        Suscriptor suscriptor = new Suscriptor(); 
        protected void Page_Load(object sender, EventArgs e)
        {
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
            int TipoDocumento = Convert.ToInt32(ComboBox.SelectedItem.Value);
            long NumeroDocumento = long.Parse(txt_numDoc.Text);

            suscriptor = ng_Suscriptor.Buscar_Suscriptor(TipoDocumento, NumeroDocumento);

            if (suscriptor != null)
            {

                CargarCampos();
            }


            else
            {
                LimpiarCampos();
                MessageBox.Show("ERROR: No se encontro Numero de Documento");
            }
        }

        private void CargarCampos()
        {
            txt_nombre.Text = suscriptor.Nombre.ToString();
            txt_apellido.Text = suscriptor.Apellido.ToString();
            txt_direccion.Text = suscriptor.Direccion.ToString();
            txt_email.Text = suscriptor.Email.ToString();
            txt_telefono.Text = suscriptor.Telefono.ToString();
            txt_usuario.Text = suscriptor.NombreUsuario.ToString();
            txt_contraseña.Text = suscriptor.Password.ToString();
        
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
    }
}