<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Nuevo.aspx.cs" Inherits="Desafio.Nuevo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Suscripción</title>
    <style>
        #btn_buscar {
            background-color: #6bb16b;
            color: white
        }

        #btn_aceptar {
            background-color: #6bb16b;
            color: white
        }

        #btn_cancelar {
            background-color: white
        }

        #btn_nuevo {
            background-color: #add9e6;
            color: white
        }

        #btn_modificar {
            background-color: #6c878f;
            color: white
        }
    </style>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.css" />
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script>

        function Redireccionar {
            window.location.href = 'WebForm.aspx';
        }

    </script>
</head>
<body>
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
                    <asp:Button ID="btn_buscar" runat="server" Text="Buscar" OnClick="btnBtnBuscar" />
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
                    <asp:Button ID="btn_nuevo" runat="server" Text="Nuevo" />
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
                    <asp:TextBox ID="txt_contraseña" runat="server" Height="30px" Width="140px" type="password"></asp:TextBox>
                    <asp:TextBox ID="txt_oculto" runat="server"></asp:TextBox>
                </div>
                <div class="col">
                </div>
                <div>
                    <hr />
                    <asp:Button ID="btn_aceptar" runat="server" Text="Aceptar" OnClick="btn_aceptar_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" OnClick="btn_cancelar_Click" />

                </div>
            </div>
        </div>

    </form>
</body>
</html>
