<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.master" AutoEventWireup="true" CodeBehind="ImprimirDocumentos.aspx.cs" Inherits="Inscripcion.ImprimirDocumentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <br />
    <asp:Label ID="Label1" runat="server" Text="GUARDADO" CssClass="alert alert-success" Width="757px" Visible="False" Style="margin-left: 1px; text-align: center" Font-Bold="False" Font-Size="Large"></asp:Label>
    <div class="panel panel-default" style="background-color: #7a7a7a">
        <div class="panel-heading" style="text-align: center">
            <strong>&nbsp;NOTA:N</strong><span style="font-weight: bold">o olvides presentarte a servicios escolares con tu dos documentos impresos para seguir con tu trámite de inscripción<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ¡BIENVENIDO A LA UNIVERSIDAD POLITÉCNICA DE TULANCINGO!</span></div>


    </div>
    <br /><br />
    <div class="row">
        <div class="col-md-5" style="left: 23px; top: 0px; width: 735px"></div>
        <div class="col-md-3" style="text-align: center; left: 267px; top: 0px; width: 491px;">

            <asp:Button ID="btnFicha" runat="server" aling="right" Width="391px" Text="IMPRIMIR SOLICITUD DE INSCRIPCIÓN" class="btn btn-danger btn-lg" BackColor="#9C1315" BorderColor="#9C1315" ForeColor="#FFFFCC" Style="margin-bottom: 0" BorderStyle="None" OnClick="btnFicha_Click"  />

            <br />
            <br />
            <br />

            <asp:Button ID="btnFicha0" runat="server" aling="right" Width="391px" Text="IMPRIMIR ESTUDIO SOCIO ECONÓMICO" class="btn btn-danger btn-lg" BackColor="#9C1315" BorderColor="#9C1315" ForeColor="#FFFFCC" Style="margin-bottom: 0" BorderStyle="None" OnClick="btnFicha0_Click"  />

            <br />

        </div>
    </div>

    <br />
    <hr />
  

     

</asp:Content>
