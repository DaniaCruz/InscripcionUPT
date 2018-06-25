<%@ Page Title="Incsripción UPT" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Inscripcion._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
     <style type="text/css"> 
    /*caso contrario, el color sera rojo*/
    form input:focus:invalid{
        border:2px solid red;
        /* otras propiedades */
    }
   </style>

        <br />
  
        <%--INSTRUCCIONES--%>
                     
                      <table style=" margin-left: 42px; margin-right: 42px">
                            <tr>
                                <td>
                                    <div class="row">
                                        <div class="col-lg-2"></div>
                                        <div class="col-lg-8" style="text-align: center">
                                            <br />
                                            <asp:Label ID="Label3" runat="server" ForeColor="#990000" Style="font-size: x-large; font-family: 'Roboto' letter-spacing:1px" Text="Instrucciones:" Font-Size="X-Large"></asp:Label>
                                            <br />
                                            <br />
                                            <p class="text-justify" style="line-height: 13px; font-size: x-large; font-family: 'Roboto'">
                                                <span style="font-size: 13px">Este procedimiento es tu solicitud de inscripción a la Univerisdad Politécnica de Tulancingo.
                                                <br />
                                                <br />
                                                    1.-Ingresa tu matrícula a 7 dígitos.
                                                <br />
                                                <br />
                                                    2.-Contesta los cuestionarios una vez que ingreses.
                                                <br />
                                                <br />
                                                    3.-Una vez concluidos los pasos anteriores podrás descargar tu solicitud de inscripción y tu estudio socioeconómico, los cuales deberás presentar en la oficina de servicios escolres. </span>
                                            </p>
                                        </div>
                                    </div>
                               </td>
                            </tr>
                        </table>
     
        <br />
        <br />

     <%--Matricula--%>
        
    <div class="row">
        <div class="col-lg-2"></div>
        <div class="col-lg-8">

            <asp:Label ID="LMatricula" runat="server" Text=" " Visible="false"></asp:Label>
            <center>
            <table>
                <tr>
                    <td style="width: 267px; text-align: right">
                        <br /><br />
                        <asp:TextBox MaxLength="7" ID="alu_NumControl" pattern="[0-9]{1,9}(\.[0-9]{0,2})?$"  title="Sólo se permiten números. Debes ingresar 7 dígitos." type="text" class="form-control" onkeyup="this.value=this.value.toUpperCase()" runat="server" Width="232px" Height="35px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="alu_NumControl" CssClass="text-danger" ErrorMessage="Sólo se permiten números. Debes ingresar 7 dígitos." Font-Bold="True"
                            Font-Size="Small" ForeColor="#993333" Style="font-size: 13px" ValidationExpression="\d{7}" SetFocusOnError="True"></asp:RegularExpressionValidator>
                    </td>
                    <td style="text-align: left; width: 101px;">
                        <asp:Button ID="btnIngresar" Width="91px" runat="server" Text="Ingresar" BackColor="#800020" BorderColor="#800020" ForeColor="#FFFFCC" Style="margin-bottom: 0" Height="31px" BorderStyle="None" CssClass="btn btn-primary" OnClick="btnIngresar_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center" class="text-justify" colspan="2">
                        <strong>
                            <asp:Label ID="lblMensaje" runat="server" Text="MensajeError" Visible="False" ForeColor="#993333" Style="font-size: 13px"></asp:Label>
                        </strong>
                    </td>
                </tr>

            </table>
                </center>
            <br />
            <br />

        </div>
    </div>  
    
            
    <br />
    <br />
</asp:Content>