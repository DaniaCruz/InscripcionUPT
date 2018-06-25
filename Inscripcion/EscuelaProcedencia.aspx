<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.master" AutoEventWireup="true" CodeBehind="EscuelaProcedencia.aspx.cs" Inherits="Inscripcion.EscuelaProcedencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/jquery-1.10.2.js"></script>
    <link href="Content/RByCHB.css" rel="stylesheet" />
    <style type="text/css"> 
    /*caso contrario, el color sera rojo*/
    form input:focus:invalid{
        border:2px solid red;
        /* otras propiedades */
    }
   </style>
         
            <div class="secciones">
                <article id="tab3">
                    <div class="row">
                        <div class="col-md-12 alert-danger" style="font-size: 15px; letter-spacing: 1px" align="center">
                            <span style="color: #921818">
                                <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label42" runat="server" ForeColor="#990000" Style="font-size: large; letter-spacing: 1px"
                                        Text="Escuela de Procedencia"></asp:Label>
                                    <br />
                                </b></span>
                        </div>
                        <br />
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4" align="right">
                            <asp:Label ID="Label20" runat="server" Style="font-size: 15px; letter-spacing: 1px" Text="Estado:"></asp:Label>
                        </div>

                        <div class="col-md-4" align="left">
                            <asp:DropDownList runat="server" class="form-control" Width="100%" ID="est_Escu_ID" AutoPostBack="True" OnSelectedIndexChanged="est_Escu_ID_SelectedIndexChanged">
                                <asp:ListItem Value="0">SELECCIONA</asp:ListItem>
                                <asp:ListItem Value="1">A</asp:ListItem>
                                <asp:ListItem Value="2">B</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="est_Escu_ID" ErrorMessage="Selecciona opción."
                                Display="Dynamic" InitialValue="0" ForeColor="#993333" Font-Bold="true" SetFocusOnError="True" Style="font-size: 13px" runat="server" ValidationGroup="AC" />
                        </div>


                        <div class="col-md-2" align="center">
                            <asp:Button ID="btnActAlumOtroEst" Width="91px" runat="server" Text="Otro" BackColor="#800020" data-toggle="modal" data-target="#exampleModalCenter"
                                BorderColor="#800020" ForeColor="#FFFFCC" Style="margin-bottom: 0" Height="31px" BorderStyle="None" CssClass="btn btn-primary" />


                            <!-- Modal -->
                            <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                                <div class="modal-dialog modal-dialog-centered" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">

                                            <asp:Label ID="Label1" runat="server" ForeColor="#990000" Style="font-size: large; letter-spacing: 1px"
                                                Text="Agregar Estado"></asp:Label>
                                            <br />

                                        </div>
                                        <div class="modal-body">
                                            <div class="row">
                                                <div class="col-md-5" align="right">
                                                    <asp:Label ID="Label2" runat="server" Style="font-size: 15px; letter-spacing: 1px" Text="Estado nuevo:"></asp:Label>
                                                    <br />
                                                    <span style="font-size: 12px">Ejemplo: HIDALGO</span>
                                                </div>
                                                <div class="col-md-6" align="left">
                                                    <asp:TextBox ID="txtEstadoN" class="form-control" pattern="^[A-Z a-z]*$"  title="Sólo se aceptan letras de la A-Z, sin acentos." MaxLength="50" Width="100%" runat="server" Style="text-transform: uppercase" ValidationGroup="NE" > </asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                        ControlToValidate="txtEstadoN" CssClass="text-danger"
                                                        ErrorMessage="Sólo se aceptan letras de la A-Z, sin acentos."
                                                        Font-Size="Medium" ForeColor="#993333" Style="font-size: 13px"
                                                        ValidationExpression="^[A-Z a-z]*$" SetFocusOnError="True" Font-Bold="true" ValidationGroup="NE" Display="Dynamic"></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEstadoN" CssClass="text-danger" Display="Dynamic" ErrorMessage="Ingresa Estado " Font-Bold="true" Font-Size="Medium" ForeColor="#993333" SetFocusOnError="True" Style="font-size: 13px" ValidationGroup="NE" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="modal-footer">

                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>

                                            <asp:Button ID="Btn_GuardarEN" Width="91px" runat="server" Text="Agregar" BackColor="#800020"  data-target="#exampleModalCenter"
                                                BorderColor="#800020" ForeColor="#FFFFCC" Autopostback="true" Style="margin-bottom: 0" Height="31px" BorderStyle="None" CssClass="btn btn-primary" ValidationGroup="NE" OnClick="Btn_GuardarEN_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>




                        </div>


                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4" align="right">
                            <asp:Label ID="Label21" runat="server" Style="font-size: 15px; letter-spacing: 1px" Text="Municipio:"></asp:Label>
                        </div>

                        <div class="col-md-4" align="left">
                            <asp:DropDownList runat="server" class="form-control" Width="100%"  ID="mun_Escu_ID" AutoPostBack="True" OnSelectedIndexChanged="mun_Escu_ID_SelectedIndexChanged">
                                <asp:ListItem Value="0">SELECCIONA</asp:ListItem>
                                <asp:ListItem Value="1">A</asp:ListItem>
                                <asp:ListItem Value="2">B</asp:ListItem>
                            </asp:DropDownList>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="mun_Escu_ID" ErrorMessage="Selecciona opción."
                                Display="Dynamic" InitialValue="0" ForeColor="#993333" Font-Bold="true" SetFocusOnError="True" Style="font-size: 13px" runat="server" ValidationGroup="AA" />
                        </div>

                        <div class="col-md-2" align="center">
                            <asp:Button ID="btnActAlumOtroMun" Width="91px" autopostback="true" runat="server" Text="Otro" BackColor="#800020" data-toggle="modal" data-target="#ModalNuevoMunicipio"
                                BorderColor="#800020" ForeColor="#FFFFCC" Style="margin-bottom: 0" Height="31px" BorderStyle="None" CssClass="btn btn-primary" ValidationGroup="AA"/>



                            <!-- Modal -->
                            <div class="modal fade" id="ModalNuevoMunicipio" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                                <div class="modal-dialog modal-dialog-centered" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">

                                            <asp:Label ID="Label3" runat="server" ForeColor="#990000" Style="font-size: large; letter-spacing: 1px"
                                                Text="Agregar Municipio"></asp:Label>
                                            <br />

                                        </div>
                                        <div class="modal-body">
                                            <div class="row">
                                                <div class="col-md-5" align="right">
                                                    <asp:Label ID="Label4" runat="server" Style="font-size: 15px; letter-spacing: 1px" Text="Municipio nuevo:"></asp:Label>
                                                    <br />
                                                    <span style="font-size: 12px">Ejemplo: TULANCINGO</span>
                                                </div>
                                                <div class="col-md-6" align="left">
                                                    <asp:TextBox ID="txtMuniN" class="form-control" pattern="^[A-Z a-z]*$"  title="Sólo se aceptan letras de la A-Z, sin acentos." MaxLength="50" Width="100%" runat="server" Style="text-transform: uppercase" > </asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                                        ControlToValidate="txtMuniN" CssClass="text-danger"
                                                        ErrorMessage="Sólo se aceptan letras de la A-Z, sin acentos."
                                                        Font-Size="Medium" ForeColor="#993333" Style="font-size: 13px"
                                                        ValidationExpression="^[A-Z a-z]*$" SetFocusOnError="True" Font-Bold="true" ValidationGroup="NM" Display="Dynamic"></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMuniN" CssClass="text-danger" Display="Dynamic" ErrorMessage="Ingresa Estado " Font-Bold="true" Font-Size="Medium" ForeColor="#993333" SetFocusOnError="True" Style="font-size: 13px" ValidationGroup="NM" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="modal-footer">

                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>

                                            <asp:Button ID="Btn_GuardarMN" Width="91px" runat="server" Text="Agregar" BackColor="#800020" 
                                                BorderColor="#800020" ForeColor="#FFFFCC" Style="margin-bottom: 0" Height="31px" BorderStyle="None" CssClass="btn btn-primary" ValidationGroup="NM" OnClick="Btn_GuardarMN_Click" />



                                        </div>
                                    </div>
                                </div>
                            </div>


                        </div>

                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4" align="right">
                            <asp:Label ID="Label22" runat="server" Style="font-size: 15px; letter-spacing: 1px" Text="*Nombre de la institución:"></asp:Label>
                        </div>
                        
                       
                        <div class="col-md-4" align="left">
                            <asp:DropDownList runat="server" class="form-control" Width="100%"  ID="esc_ID" AutoPostBack="True" >
                                <asp:ListItem Value="0">SELECCIONA</asp:ListItem>
                                <asp:ListItem Value="1">A</asp:ListItem>
                                <asp:ListItem Value="2">B</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ControlToValidate="esc_ID" ErrorMessage="Selecciona una opción."
                                Display="Dynamic" InitialValue="0" ForeColor="#993333" Font-Bold="true" SetFocusOnError="True" Style="font-size: 13px" runat="server" ValidationGroup="AC" />
                        </div>
                               
                        <div class="col-md-2" align="center">
                            <asp:Button ID="btnOtraInst" Width="91px" runat="server" Text="Otro" BackColor="#800020" data-toggle="modal" data-target="#ModalNuevaInst"
                                BorderColor="#800020" ForeColor="#FFFFCC" Style="margin-bottom: 0" Height="31px" BorderStyle="None" CssClass="btn btn-primary" />



                            <!-- Modal -->
                            <div class="modal fade" id="ModalNuevaInst" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                                <div class="modal-dialog modal-dialog-centered" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">

                                            <asp:Label ID="Label5" runat="server" ForeColor="#990000" Style="font-size: large; letter-spacing: 1px"
                                                Text="Agregar Institución"></asp:Label>
                                            <br />

                                        </div>
                                        <div class="modal-body">
                                            <div class="row">
                                                <div class="col-md-5" align="right">
                                                    <asp:Label ID="Label6" runat="server" Style="font-size: 15px; letter-spacing: 1px" Text="Institución nueva:"></asp:Label>
                                                    <br />
                                                    <span style="font-size: 12px">Ejemplo: TOLLANCINGO</span>
                                                </div>
                                                <div class="col-md-6" align="left">
                                                    <asp:TextBox ID="txtInstN" class="form-control" pattern="^[A-Z a-z]*$"  title="Sólo se aceptan letras de la A-Z, sin acentos." MaxLength="50" Width="100%" runat="server" Style="text-transform: uppercase" nkeypress="return justNumbers(event);"> </asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                                        ControlToValidate="txtInstN" CssClass="text-danger"
                                                        ErrorMessage="Sólo se aceptan letras de la A-Z, sin acentos."
                                                        Font-Size="Medium" ForeColor="#993333" Style="font-size: 13px"
                                                        ValidationExpression="^[A-Z a-z]*$" SetFocusOnError="True" Font-Bold="true" ValidationGroup="NI" Display="Dynamic"></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtInstN" CssClass="text-danger" Display="Dynamic" ErrorMessage="Ingresa nombre de la Institución " Font-Bold="true" Font-Size="Medium" ForeColor="#993333" SetFocusOnError="True" Style="font-size: 13px" ValidationGroup="NI" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="modal-footer">

                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>

                                            <asp:Button ID="Btn_GuardarIN" Width="91px" runat="server" Text="Agregar" BackColor="#800020"
                                                BorderColor="#800020" ForeColor="#FFFFCC" Style="margin-bottom: 0" Height="31px" BorderStyle="None" CssClass="btn btn-primary" ValidationGroup="NI" OnClick="Btn_GuardarIN_Click" />



                                        </div>
                                    </div>
                                </div>
                            </div>


                        </div>

                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4" align="right">
                            <asp:Label ID="Label23" runat="server" Style="font-size: 15px; letter-spacing: 1px" Text="Propedéutico cursado:"></asp:Label>
                        </div>
                        <div class="col-md-4" align="left">

                            <asp:DropDownList runat="server" class="form-control" Width="100%" ID="alc_EspBachi" AutoPostBack="True" >
                                <asp:ListItem Value="0">SELECCIONA</asp:ListItem>
                                <asp:ListItem Value="EXACTAS">EXACTAS</asp:ListItem>
                                <asp:ListItem Value="CONTABLES">CONTABLES</asp:ListItem>
                                <asp:ListItem Value="BIOLÓGICAS">BIOLÓGICAS</asp:ListItem>
                                <asp:ListItem Value="SOCIALES">SOCIALES</asp:ListItem>
                                <asp:ListItem Value="GENERAL">GENERAL</asp:ListItem>
                                <asp:ListItem>INFORMÁTICA</asp:ListItem>
                                <asp:ListItem>OTRO</asp:ListItem>
                            </asp:DropDownList>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ControlToValidate="alc_EspBachi" ErrorMessage="Selecciona una opción."
                                Display="Dynamic" InitialValue="0" ForeColor="#993333" Font-Bold="True" SetFocusOnError="True" Style="font-size: 13px" runat="server" ValidationGroup="AC" />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4" align="right">
                            <asp:Label ID="Label24" runat="server" Style="font-size: 15px; letter-spacing: 1px" Text="*Año en que concluiste:"></asp:Label>
                            <br />
                            <span style="font-size: 12px">Ejemplo: 2015</span>
                        </div>
                        <div class="col-md-2" align="left">
                            <asp:TextBox MaxLength="4" ID="txtAnnoConcluido" pattern="\d{4}"  title="Sólo se aceptan números. Deben ser 4 dígitos." class="form-control" Width="100%" runat="server" onkeypress="return SoloNumeros(event)" ValidationGroup="AC"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtAnnoConcluido" Display="Dynamic" ErrorMessage="Campo obligatorio." Style="font-size: 13px" SetFocusOnError="True" ValidationGroup="AC" Font-Bold="True" ForeColor="#993333"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="ttttt" ControlToValidate="txtAnnoConcluido" ErrorMessage="Año incorrecto."
                                Display="Dynamic" ValidationExpression="\d{4}" ForeColor="#993333" Font-Bold="true" Style="font-size: 13px" runat="server" ValidationGroup="AC" />

                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4" align="right">
                            <asp:Label ID="Label25" runat="server" Style="font-size: 15px; letter-spacing: 1px" Text="*Promedio con el que concluiste:"></asp:Label>
                            <br />
                            <span style="font-size: 12px">Ejemplo: 8.5</span>

                        </div>
                        <div class="col-md-2" align="left">
                            <asp:TextBox MaxLength="4" ID="alc_PromBachi" runat="server" class="form-control" Width="100%" onkeypress="return SoloNumeros(event)"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="alc_PromBachi" Display="Dynamic" ErrorMessage="Campo obligatorio." Style="font-size: 13px" SetFocusOnError="True" ValidationGroup="AC" Font-Bold="True" ForeColor="#993333"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" align="right">
                        </div>
                        <div class="col-md-6" align="left">
                            <asp:CustomValidator ID="CustomValiddfdfdfdfator1" runat="server" ControlToValidate="alc_PromBachi" ErrorMessage="Promedio inválido. Sólo debes ingresar un entero con 1 decimal en caso de que tu promedio sea menor a 10. Si tu promedio es 10, debes ingresar sólo el número entero 10." ValidationGroup="AC"
                                OnServerValidate="val_Promedio_ServerValidate" SetFocusOnError="True" ForeColor="#993333" Font-Bold="true" Style="font-size: 13px" Display="Dynamic"></asp:CustomValidator>
                        </div>
                        </div>
                    
<%--ESTUDIAS ALGU POSGRADO O MAESTRIA--%>
                    <div class="row">
                                <div class="col-md-6" align="justify">
                                    <asp:Label ID="Label40" runat="server" Style="font-size: 15px; letter-spacing: 1px" Text="¿Te inscribirás a alguna maestría o doctorado?"></asp:Label>
                                </div>
                                <div class="col-md-3" align="left">
                                    <asp:RadioButtonList ID="aluu_Uni" runat="server" RepeatDirection="Horizontal" Height="20px" Width="103px" AutoPostBack="True" OnSelectedIndexChanged="aluu_Uni_SelectedIndexChanged">
                                        <asp:ListItem id="aluu_UniSi" Text="Si"/>
                                        <asp:ListItem id="aluu_UniNo" Text="No" Selected="True"/>
                                    </asp:RadioButtonList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="aluu_Uni" ErrorMessage="Selecciona una opción."
                                        Display="Dynamic" ForeColor="#993333" Font-Bold="true" SetFocusOnError="True" Style="font-size: 13px" runat="server" ValidationGroup="AE" />
                                </div>
                            </div>
                    <br />
















                    <div id="hhh" runat="server">
                    <div class="row">
                        <div class="col-md-12 alert-danger" id="aaa" runat="server"  style="font-size: 15px; letter-spacing: 1px; background-color: #FFFFFF;" align="center">
                            <span style="color: #921818" >
                                <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label7" runat="server" ForeColor="#990000" Visible="false" Style="font-size: large; letter-spacing: 1px"
                                        Text="Universidad de Procedencia"></asp:Label>
                                    <br />
                                </b></span>
                        </div>
                        <br />
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4" align="right">
                            <asp:Label ID="Label8" runat="server" Style="font-size: 15px; letter-spacing: 1px" Text="Estado:" Visible="False" ></asp:Label>
                        </div>

                        <div class="col-md-4" align="left">
                            <asp:DropDownList runat="server" class="form-control" Width="100%" ID="alu_UniEstado" Visible="False">
                                <asp:ListItem Value="0">SELECCIONA</asp:ListItem>
                                <asp:ListItem Value="1">A</asp:ListItem>
                                <asp:ListItem Value="2">B</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="alu_UniEstado" ErrorMessage="Selecciona opción."
                                Display="Dynamic" InitialValue="0" ForeColor="#993333" Font-Bold="true" SetFocusOnError="True" Style="font-size: 13px" runat="server" ValidationGroup="AC" Visible="False" />
                        </div>


                        <div class="col-md-2" align="center">
                            <asp:Button ID="Button2" Width="91px" runat="server" Text="Otro" BackColor="#800020" data-toggle="modal" data-target="#exampleModalCenter"
                                BorderColor="#800020" ForeColor="#FFFFCC" Style="margin-bottom: 0" Height="31px" BorderStyle="None" CssClass="btn btn-primary" Visible="False" />


                            <!-- Modal -->
                            <div class="modal fade" id="modalNuevoEstadoUni" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                                <div class="modal-dialog modal-dialog-centered" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">

                                            <asp:Label ID="Label9" runat="server" ForeColor="#990000" Style="font-size: large; letter-spacing: 1px"
                                                Text="Agregar Estado"></asp:Label>
                                            <br />

                                        </div>
                                        <div class="modal-body">
                                            <div class="row">
                                                <div class="col-md-5" align="right">
                                                    <asp:Label ID="Label10" runat="server" Style="font-size: 15px; letter-spacing: 1px" Text="Estado nuevo:"></asp:Label>
                                                    <br />
                                                    <span style="font-size: 12px">Ejemplo: HIDALGO</span>
                                                </div>
                                                <div class="col-md-6" align="left">
                                                    <asp:TextBox ID="txtEstadoUN" class="form-control" MaxLength="50" Width="100%" runat="server" Style="text-transform: uppercase" nkeypress="return justNumbers(event);"> </asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtEstadoUN" CssClass="text-danger"
                                                        ErrorMessage="Sólo se aceptan letras de la A-Z, sin acentos." Font-Size="Medium" ForeColor="#993333" Style="font-size: 13px" ValidationExpression="^[A-Z a-z]*$" SetFocusOnError="True" Font-Bold="true" ValidationGroup="NE" Display="Dynamic"></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEstadoUN" CssClass="text-danger" Display="Dynamic" ErrorMessage="Ingresa Estado " Font-Bold="true" Font-Size="Medium" ForeColor="#993333" SetFocusOnError="True" Style="font-size: 13px" ValidationGroup="UNE" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="modal-footer">

                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>

                                            <asp:Button ID="Button4" Width="91px" runat="server" Text="Agregar" BackColor="#800020" data-toggle="modal" data-target="#exampleModalCenter"
                                                BorderColor="#800020" ForeColor="#FFFFCC" Style="margin-bottom: 0" Height="31px" BorderStyle="None" CssClass="btn btn-primary" ValidationGroup="UNE" />
                                        </div>
                                    </div>
                                </div>
                            </div>




                        </div>


                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4" align="right">
                            <asp:Label ID="Label11" runat="server" Style="font-size: 15px; letter-spacing: 1px" Text="Municipio:" Visible="False"></asp:Label>
                        </div>

                        <div class="col-md-4" align="left">
                            <asp:DropDownList runat="server" class="form-control" Width="100%" ID="alu_UniMun" Visible="False">
                                <asp:ListItem Value="0">SELECCIONA</asp:ListItem>
                                <asp:ListItem Value="1">A</asp:ListItem>
                                <asp:ListItem Value="2">B</asp:ListItem>
                            </asp:DropDownList>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="alu_UniMun" ErrorMessage="Selecciona opción."
                                Display="Dynamic" InitialValue="0" ForeColor="#993333" Font-Bold="true" SetFocusOnError="True" Style="font-size: 13px" runat="server" ValidationGroup="AC" Visible="False" />
                        </div>

                        <div class="col-md-2" align="center">
                            <asp:Button ID="Button5" Width="91px" runat="server" Text="Otro" BackColor="#800020" data-toggle="modal" data-target="#ModalNuevoMunicipio"
                                BorderColor="#800020" ForeColor="#FFFFCC" Style="margin-bottom: 0" Height="31px" BorderStyle="None" CssClass="btn btn-primary" Visible="False" />



                            <!-- Modal -->
                            <div class="modal fade" id="ModalNuevoMunicipioUni" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                                <div class="modal-dialog modal-dialog-centered" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">

                                            <asp:Label ID="Label12" runat="server" ForeColor="#990000" Style="font-size: large; letter-spacing: 1px"
                                                Text="Agregar Municipio"></asp:Label>
                                            <br />

                                        </div>
                                        <div class="modal-body">
                                            <div class="row">
                                                <div class="col-md-5" align="right">
                                                    <asp:Label ID="Label13" runat="server" Style="font-size: 15px; letter-spacing: 1px" Text="Municipio nuevo:"></asp:Label>
                                                    <br />
                                                    <span style="font-size: 12px">Ejemplo: TULANCINGO</span>
                                                </div>
                                                <div class="col-md-6" align="left">
                                                    <asp:TextBox ID="txtMunUN" class="form-control" MaxLength="50" Width="100%" runat="server" Style="text-transform: uppercase" nkeypress="return justNumbers(event);"> </asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                                                        ControlToValidate="txtMunUN" CssClass="text-danger"
                                                        ErrorMessage="Sólo se aceptan letras de la A-Z, sin acentos."
                                                        Font-Size="Medium" ForeColor="#993333" Style="font-size: 13px"
                                                        ValidationExpression="^[A-Z a-z]*$" SetFocusOnError="True" Font-Bold="true" ValidationGroup="NM" Display="Dynamic"></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtMunUN" CssClass="text-danger" Display="Dynamic" ErrorMessage="Ingresa Estado " Font-Bold="true" Font-Size="Medium" ForeColor="#993333" SetFocusOnError="True" Style="font-size: 13px" ValidationGroup="UNM" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="modal-footer">

                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>

                                            <asp:Button ID="Button6" Width="91px" runat="server" Text="Agregar" BackColor="#800020" data-toggle="modal" data-target="#exampleModalCenter"
                                                BorderColor="#800020" ForeColor="#FFFFCC" Style="margin-bottom: 0" Height="31px" BorderStyle="None" CssClass="btn btn-primary" ValidationGroup="UNM" />



                                        </div>
                                    </div>
                                </div>
                            </div>


                        </div>

                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4" align="right">
                            <asp:Label ID="Label14" runat="server" Style="font-size: 15px; letter-spacing: 1px" Text="*Nombre de la institución:" Visible="False"></asp:Label>
                        </div>

                        <div class="col-md-4" align="left">
                            <asp:DropDownList runat="server" class="form-control" Width="100%" ID="alu_Universidad" Visible="False">
                                <asp:ListItem Value="0">SELECCIONA</asp:ListItem>
                                <asp:ListItem Value="1">A</asp:ListItem>
                                <asp:ListItem Value="2">B</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="alu_Universidad" ErrorMessage="Selecciona una opción."
                                Display="Dynamic" InitialValue="0" ForeColor="#993333" Font-Bold="true" SetFocusOnError="True" Style="font-size: 13px" runat="server" ValidationGroup="AC" Visible="False" />
                        </div>

                        <div class="col-md-2" align="center">
                            <asp:Button ID="Button7" Width="91px" runat="server" Text="Otro" BackColor="#800020" data-toggle="modal" data-target="#ModalNuevaInst"
                                BorderColor="#800020" ForeColor="#FFFFCC" Style="margin-bottom: 0" Height="31px" BorderStyle="None" CssClass="btn btn-primary" Visible="False" />



                            <!-- Modal -->
                            <div class="modal fade" id="ModalNuevaUni" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                                <div class="modal-dialog modal-dialog-centered" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">

                                            <asp:Label ID="Label15" runat="server" ForeColor="#990000" Style="font-size: large; letter-spacing: 1px"
                                                Text="Agregar Institución"></asp:Label>
                                            <br />

                                        </div>
                                        <div class="modal-body">
                                            <div class="row">
                                                <div class="col-md-5" align="right">
                                                    <asp:Label ID="Label16" runat="server" Style="font-size: 15px; letter-spacing: 1px" Text="Institución nueva:"></asp:Label>
                                                    <br />
                                                    <span style="font-size: 12px">Ejemplo: UNIVERSIDAD POLITECNICA DE TLANCINGO</span>
                                                </div>
                                                <div class="col-md-6" align="left">
                                                    <asp:TextBox ID="txtUniN" class="form-control" MaxLength="50" Width="100%" runat="server" Style="text-transform: uppercase" nkeypress="return justNumbers(event);"> </asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                                                        ControlToValidate="txtUniN" CssClass="text-danger"
                                                        ErrorMessage="Sólo se aceptan letras de la A-Z, sin acentos."
                                                        Font-Size="Medium" ForeColor="#993333" Style="font-size: 13px"
                                                        ValidationExpression="^[A-Z a-z]*$" SetFocusOnError="True" Font-Bold="true" ValidationGroup="NI" Display="Dynamic"></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtUniN" CssClass="text-danger" Display="Dynamic" ErrorMessage="Ingresa nombre de la Institución " Font-Bold="true" Font-Size="Medium" ForeColor="#993333" SetFocusOnError="True" Style="font-size: 13px" ValidationGroup="NI" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="modal-footer">

                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>

                                            <asp:Button ID="Button8" Width="91px" runat="server" Text="Agregar" BackColor="#800020" data-toggle="modal" data-target="#exampleModalCenter"
                                                BorderColor="#800020" ForeColor="#FFFFCC" Style="margin-bottom: 0" Height="31px" BorderStyle="None" CssClass="btn btn-primary" ValidationGroup="NM" />



                                        </div>
                                    </div>
                                </div>
                            </div>


                        </div>

                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4" align="right">
                            <asp:Label ID="Label17" runat="server" Style="font-size: 15px; letter-spacing: 1px" Text="Carrera cursada:" Visible="False"></asp:Label>
                        </div>
                        <div class="col-md-4" align="left">

                            <asp:DropDownList runat="server" class="form-control" Width="100%" required ID="alu_CarreraU" Visible="False">
                                <asp:ListItem Value="0">SELECCIONA</asp:ListItem>
                                <asp:ListItem Value="1">EXACTAS</asp:ListItem>
                                <asp:ListItem Value="2">CONTABLES</asp:ListItem>
                                <asp:ListItem Value="3">BIOLÓGICAS</asp:ListItem>
                            </asp:DropDownList>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="alu_CarreraU" ErrorMessage="Selecciona una opción."
                                Display="Dynamic" InitialValue="0" ForeColor="#993333" Font-Bold="True" SetFocusOnError="True" Style="font-size: 13px" runat="server" ValidationGroup="AC" Visible="False" />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4" align="right">
                            <asp:Label ID="Label18" runat="server" Style="font-size: 15px; letter-spacing: 1px" Text="*Año en que concluiste:" Visible="False"></asp:Label>
                            <br />
                             <asp:Label ID="Label26" runat="server" Style="font-size: 12px" Text="Ejemplo: 2015" Visible="False"></asp:Label>
                        </div>
                        <div class="col-md-2" align="left">
                            <asp:TextBox MaxLength="4" ID="alu_UniAnno" class="form-control" Width="100%" runat="server" onkeypress="return justNumbers(event);" Visible="False"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="alu_UniAnno" ErrorMessage="Sólo se aceptan números del 0 - 9."
                                Display="Dynamic" ValidationExpression="\d{4}" ForeColor="#993333" Font-Bold="true" Style="font-size: 13px" runat="server" ValidationGroup="AC" Visible="False" />

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="alu_UniAnno" Display="Dynamic" ErrorMessage="Campo obligatorio." Style="font-size: 13px" SetFocusOnError="True" ValidationGroup="AC" Font-Bold="True" ForeColor="#993333" Visible="False"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4" align="right">
                            <asp:Label ID="Label19" runat="server" Style="font-size: 15px; letter-spacing: 1px" Text="*Promedio con el que concluiste:" Visible="False"></asp:Label>
                            <br />
                            <asp:Label ID="Label27" runat="server" Style="font-size: 12px" Text="Ejemplo: 8.5" Visible="False"></asp:Label>
                        </div>
                        <div class="col-md-2" align="left">
                            <asp:TextBox MaxLength="3" ID="alu_UniProm" runat="server" class="form-control" Width="100%" Visible="False"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" Style="font-size: 13px" ControlToValidate="alu_UniProm" ErrorMessage="Campo obligatorio." SetFocusOnError="True" ValidationGroup="AC" Font-Bold="True" ForeColor="#993333" Visible="False"></asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" align="right">
                        </div>
                        <div class="col-md-6" align="left">
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="alc_PromBachi" ErrorMessage="Promedio inválido. Sólo debes ingresar un entero con 1 decimal en caso de que tu promedio sea menor a 10. Si tu promedio es 10, debes ingresar sólo el número entero 10." ValidationGroup="AC"
                                OnServerValidate="val_Promedio_ServerValidate" SetFocusOnError="True" ForeColor="#993333" Font-Bold="true" Style="font-size: 13px" Display="Dynamic" Visible="False"></asp:CustomValidator>
                        </div>
                        </div>    
                    </div>



                    <center>
                        <br />                             
                        <asp:Label ID="Label28" runat="server" Text="GUARDADO" CssClass="alert alert-success" Width="757px" Visible="False" style="margin-left: 1px; text-align:center" Font-Bold="False" Font-Size="Large"></asp:Label>
                        <br />
                        <br />
                                    <asp:Button ID="btnGuardar" runat="server" aling="right" href="tab2" Width="223px" Text="Siguiente" class="btn btn-danger btn-lg" BackColor="#9C1315" autopostback="true" BorderColor="#9C1315" ForeColor="#FFFFCC" Style="margin-bottom: 0" BorderStyle="None" ValidationGroup="AC" OnClick="btnAC_Click"/>
                    </center> 
                        
                </article>
                    </div>


    <script language="javascript" type="text/javascript">
        $('#aluu_UniNo').select(function (e) {

            // Resetear, por si acaso has estado jugando con la otra propiedad
            $('#hhh').css('visibility', 'visible');

            if ($('#hhh').is(":visible")) {
                $('#hhh').css('display', 'none');
            } else {
                $('#h').css('display', 'block');
            }
        });
    </script>


         <script language="javascript" type="text/javascript">


        function SoloNumeros(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode < 48 || charCode > 57)
                return false;
            return true;

        }

        function pulsar(e) {
            tecla = (document.all) ? e.keyCode : e.which;
            return (tecla != 13);
        }
    </script>


</asp:Content>
