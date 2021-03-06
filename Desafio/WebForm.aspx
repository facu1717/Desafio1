<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="Desafio.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Suscripción</title>
    <style>
        #btn_buscar { background-color: #6bb16b; color: white}
        #btn_aceptar {background-color: #6bb16b; color:white}
        #btn_cancelar {background-color: white}
        #btn_nuevo {background-color: #add9e6; color:white}
        #btn_modificar {background-color: #6c878f; color:white}
        body {
            background-image: url('https://image.freepik.com/foto-gratis/fondo-gris-claro-liso-liso_8087-1195.jpg');
            background-repeat: no-repeat;
            background-size: cover;
        }
    </style>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.css"/>
    <link rel="stylesheet" type="text/css" href="C:\Users\OficialDeSeguridad\Downloads\Desafio1\Desafio1\Desafio\datatables\datatables.min.css" />
    <link rel="stylesheet" type="text/css" href="C:\Users\OficialDeSeguridad\Downloads\Desafio1\Desafio1\Desafio\datatables\DataTables-1.10.25\css\dataTables.bootstrap5.min.css" />
    
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script src ="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="C:\Users\OficialDeSeguridad\Downloads\Desafio1\Desafio1\Desafio\datatables\datatables.min.js"></script>
    
</head>
<body >
    <form id="form1" runat="server">
        <div class="container">
            
            <h1><a href="https://localhost:44342/WebForm.aspx">Suscripción</a></h1>
            <br />
            <h2>Para realizar la suscripción, complete los siguientes datos:</h2>
            <br />
            <div class="row align-items-start">
                <h3>Buscar Suscriptor</h3>
                <br />
                <div class="col">
                    <asp:Label ID="Label1" runat="server" Text="Label">Tipo Documento</asp:Label><br />
                    <asp:DropDownList ID="ComboBox" runat="server" Height="30px" Width="140px"></asp:DropDownList>
                </div>
                <div class="col">
                    <asp:Label ID="Label2" runat="server" Text="Label">Numero Documento</asp:Label><br />
                    <asp:TextBox type="number" ID="txt_numDoc" runat="server" Height="30px" Width="140px"></asp:TextBox>
                </div>
                <div class="col">
                    <asp:Button  ID="btn_buscar" runat="server" Text="Buscar" OnClick="btnBtnBuscar" />
                </div>
            </div>
            <hr />
            <div class="row align-items-center">
                <h3>Datos del Suscriptor</h3>
                <br />
                <div class="col">
                    <asp:Label ID="Label3" runat="server" Text="Label">Nombre</asp:Label><br />
                    <asp:TextBox ID="txt_nombre" runat="server" Height="30px" Width="140px"></asp:TextBox>
                </div>
                <div class="col">
                    <asp:Label ID="Label4" runat="server" Text="Label">Apellido</asp:Label><br />
                    <asp:TextBox ID="txt_apellido" runat="server" Height="30px" Width="140px"></asp:TextBox>
                </div>
                <div class="col">
                    <asp:Button ID="btn_nuevo" runat="server" Text="Nuevo" OnClick="btn_nuevo_Click" />
                </div>
            </div>
            <div class="row align-items-end">
                <div class="col">
                    <asp:Label ID="Label5" runat="server" Text="Label">Dirección</asp:Label><br />
                    <asp:TextBox ID="txt_direccion" runat="server" Height="30px" Width="140px"></asp:TextBox>
                </div>
                <div class="col">
                    <asp:Label ID="Label6" runat="server" Text="Label">Email</asp:Label><br />
                    <asp:TextBox ID="txt_email" runat="server" Height="30px" Width="140px"></asp:TextBox>
                </div>
                <div class="col">
                    <asp:Button ID="btn_modificar" runat="server" Text="Modificar" OnClick="btn_modificar_Click" />
                </div>
            </div>
            <div class="row align-items-end">
                <div class="col">
                    <asp:Label ID="Label7" runat="server" Text="Label">Telefono</asp:Label><br />
                    <asp:TextBox ID="txt_telefono" runat="server" Height="30px" Width="140px"></asp:TextBox>
                </div>
            </div>
            <hr />
            <div class="row align-items-end">
                <div class="col">
                    <asp:Label ID="Label8" runat="server" Text="Label">Nombre de Usuario</asp:Label><br />
                    <asp:TextBox ID="txt_usuario" runat="server" Height="30px" Width="140px"></asp:TextBox>
                </div>
                <div class="col">
                    <asp:Label ID="Label9" runat="server" Text="Label">Contraseña</asp:Label><br />
                    <asp:TextBox ID="txt_contraseña" runat="server" Height="30px" Width="140px" type ="password"></asp:TextBox>
                    <asp:TextBox ID="txt_oculto" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txt_modificar" runat="server"></asp:TextBox>
                </div>
                <div class="col">
                    <asp:Label ID="lbl" runat="server" Text="Label">Contraseña desencriptada</asp:Label>
                    <br />
                    <asp:TextBox ID="txt_desencriptada" runat="server" Height="30px" Width="140px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btn_desencriptar" runat="server" Text="Desencriptar" OnClick="btn_desencriptar_Click" />
                </div>
                <div>
                    <hr />
                    <asp:Button ID="btn_aceptar" runat="server" Text="Aceptar" OnClick="btn_aceptar_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" OnClick="btn_cancelar_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btn_tabla" runat="server" Text="Ver tabla" OnClick="btn_tabla_Click"  />
                    <asp:Button ID="btn_confirmar_guardado" runat="server" Style="display: none;" OnClick = "btn_confirmar_guardado_Click"/>
                </div>
            </div>
        </div>
        
    </form>
</body>
</html>
