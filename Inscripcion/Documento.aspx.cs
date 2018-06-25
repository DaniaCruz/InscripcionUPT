using Conect.DAO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inscripcion
{
    public partial class Documento : System.Web.UI.Page
    {
        


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["alu_ID"] != null)
            {

                string alu_NDocumento = Page.Request.QueryString["NDocumento"].ToString();
                int alu_ID = Convert.ToInt32(Session["alu_ID"]);

                if (alu_NDocumento == "Inscripcion")
                {

                    
                    imprimirPDFInscripcion();
                    //DataSet dsPDF = new DataSet();
                    //if (DocDAO.Consulta_Documentos(ref dsPDF, alu_ID, alu_NDocumento))
                    //{
                    //    Visualizar(dsPDF, alu_NDocumento);
                    //}

                }

                else if (alu_NDocumento == "EstudioSE")
                {
                    //string alu_Examen = Page.Request.QueryString["Examen"].ToString();
                    //DataSet objDatos = new DataSet();

                    imprimirEstudioSE();


                }
                else
                    Response.Redirect("Default.aspx");

            }
        }

        //public void Visualizar(DataSet Doc, string alu_Documento)
        //public void Visualizar(string alu_Documento)
        //{
        //    Byte[] bytes = (Byte[])Doc.Tables[0].Rows[0][alu_Documento];
        //    Response.Buffer = true;
        //    Response.Charset = "";
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    Response.ContentType = "application/pdf";
        //    Response.AddHeader("Content-Disposition", "inline; filename=" + Doc.Tables[0].Rows[0]["alu_NumControl"]);
        //    Response.BinaryWrite(bytes);
        //    Response.Flush();
        //    Response.End();


        //}
        //private void imprimirPDF(DataSet Datos, string TipoExamen)
        //{
        private void imprimirPDFInscripcion()
        {
            string cadenaFinal = "";
            string path = Server.MapPath("/img/encabezado1.png");

            cadenaFinal += "<img src='" + path + "' Height='110' Width='550' aling='center'/>";
            cadenaFinal += "<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FOTO</p>";
            cadenaFinal += "<table><tbody><tr><td style='text-align: right;'><span style='font-size: 10;'><span style='color: black; font-family: Tahoma;'>Fecha:</span></span></td><td style='text-align: center;' bgcolor='#D8D8D8'><strong><span style='font-size: 11;'><span style='color: black; fontfamily:Arial;'>" + "10/12/2001" + "</span></span></strong></td><td style='text-align: right;'><span style='font-size: 10;'><span style='color: black; font-family:Tahoma;'>Matricula asignada:</span></span></td><td style='text-align: center;' bgcolor='#D8D8D8'><strong><span style='font-size: 11;'><span style='color: black; font-family: Arial;'>" + "1530049" + "</span></span></strong></td><td></td><td></td></tr></tbody></table>";



            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";


            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#800020'><strong><span style='font-size: 8;'><span style='color: white; font-family: Tahoma;'>l.INFORMACIÓN BÁSICA DEL ALUMNO</span></span></strong></td></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";



            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Nombre: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "ANA LAURA" + "</span></span></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "GOMEZ" + "</span></span></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "ORTIZ" + "</span></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'>Apellido paterno</span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'>Apellido materno</span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'>Nombre</span></em></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "<tr>";

            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Lugar de nacimiento: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "TULANCINGO" + "</span></span></td>";
            cadenaFinal += "<td style='text-align: right;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Género: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "FEMENINO" + "</span></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td>&nbsp;</td>";
            cadenaFinal += "<td><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'>.</span></em></span></td>";
            cadenaFinal += "<td>&nbsp;</td>";
            cadenaFinal += "<td>&nbsp;</td>";
            cadenaFinal += "</tr>";

            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Fecha de nacimiento: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "10/05/1997" + "</span></span></td>";
            cadenaFinal += "<td bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Edad: </span></span></strong><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "21" + "</span></span></td>";
            cadenaFinal += "<td bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Estado Civil: </span></span></strong><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "AY DEJALE" + "</span></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'>dd/mm/aaaa</span></em></span></td>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";



            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";


            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#800020'><strong><span style='font-size: 8;'><span style='color: white; font-family: Tahoma;'>ll.INFORMACIÓN DEL DOMICILIO</span></span></strong></td></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";


            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Dirección: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "JUAREZ" + "</span></span></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "2 / 3" + "</span></span></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "CALTENGO" + "</span></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'>Calle</span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'>No. Ext / No. Int</span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'>Colonia</span></em></span></td>";
            cadenaFinal += "</tr>";

            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "TULANCINGO" + "</span></span></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "TULANCINGO" + "</span></span></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "HIDALGO" + "</span></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'>Municipio</span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'>Población</span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'>Estado</span></em></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "<tr>";

            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "4565522" + "</span></span></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "7786546844" + "</span></span></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "8546548" + "</span></span></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "ljncs@lkcd.com" + "</span></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'>Código postal</span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'>Teléfono (particular)</span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'>Teléfono Celular</span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'>E-mail</span></em></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "<tr>";

            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Facebook: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "facelolo" + "</span></span></td>";
            cadenaFinal += "<td style='text-align: right;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Twitter: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "pajarito" + "</span></span></td>";
            cadenaFinal += "</tr>";

            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";




            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";


            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#800020'><strong><span style='font-size: 8;'><span style='color: white; font-family: Tahoma;'>lll.Información Familiar</span></span></strong></td></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";

            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Nombre del padre: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "DON PAPÁ" + "</span></span></td>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Ocupación: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "TRABAJAR" + "</span></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Nombre de la madre: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' ><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "DOÑA MAMÁ" + "</span></span></td>";
            cadenaFinal += "<td style='text-align: left;' ><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Ocupación: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' ><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "TRABAJAR" + "</span></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Ud. ó su familia hablan alguna lengua indigena: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "NO" + "</span></span></td>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Cual: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "N/A" + "</span></span></td>";
            cadenaFinal += "</tr>";

            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";


            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";

            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#800020'><strong><span style='font-size: 8;'><span style='color: white; font-family: Tahoma;'>lV.SELECCIÓN DE CARRERA </span></span></strong></td></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";

            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";

            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Carrera en la que desea quedar inscrito(a): </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "INGENIERÍA EN SISTEMAS COMPUTACIONALES" + "</span></span></td>";
            cadenaFinal += "</tr>";

            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";


            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";


            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#800020'><strong><span style='font-size: 8;'><span style='color: white; font-family: Tahoma;'>V.ANTECEDENTES DE INSTITUCIÓN DE PROCEDENCIA</span></span></strong></td></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";


            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";

            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Nombre de la institución: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "CBTIS" + "</span></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Propedéutico cursado: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' ><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "EXACTAS" + "</span></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>TSU en: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "ARQUITECTURA" + "</span></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' ><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Año en que concluyó: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' ><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "2015" + "</span></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;'bgcolor='#D8D8D8' ><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Promedio con el que cóncluyo: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;'bgcolor='#D8D8D8' ><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "8.5" + "</span></span></td>";
            cadenaFinal += "</tr>";

            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";



            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";


            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#800020'><strong><span style='font-size: 8;'><span style='color: white; font-family: Tahoma;'>Vl.ANTECEDENTES DE INSTITUCIÓN DE EDUCACIÓN SUPERIOR DE PROCEDENCIA</span></span></strong></td></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";

            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";

            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>¿Ha realizado estudios en el nivel superior? </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "NO" + "</span></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Nombre de la institución: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' ><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "N/A" + "</span></span></td>";
            cadenaFinal += "</tr>";

            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";



            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";


            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#800020'><strong><span style='font-size: 8;'><span style='color: #800020; font-family: Tahoma;'>Universidad Politécnica de Tulancingo</span></span></strong></td></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";
            string nom = "SocioEconomico";
            imprimirPDF(cadenaFinal, nom);
        }

        private void imprimirEstudioSE()
        {

            string cadenaFinal = "";
            string path = Server.MapPath("/img/logoSE.png");

            cadenaFinal += "<img src='" + path + "' Height='110' Width='550' aling='center'/>";
            cadenaFinal += "<table><tbody><tr><td style='text-align: right;'><span style='font-size: 10;'><span style='color: black; font-family: Tahoma;'>Fecha:</span></span></td><td style='text-align: center;' bgcolor='#D8D8D8'><strong><span style='font-size: 11;'><span style='color: black; fontfamily:Arial;'>" + "10/12/2001" + "</span></span></strong></td><td style='text-align: right;'><span style='font-size: 10;'><span style='color: black;font-family: Tahoma;'>Tipo de Beca:</span></span></td><td style='text-align: center;'bgcolor='#D8D8D8'><strong><span style='font-size: 9;'><span style='color: black; font-family: Arial;'>O ECONÓMICA</span><br /><span style='color: black; font-family: Arial;'>O ALIMENTICIA</span></span></strong></td><td style='text-align: right;'><span style='font-size: 10;'><span style='color: black; font-family:Tahoma;'>Matricula asignada:</span></span></td><td style='text-align: center;' bgcolor='#D8D8D8'><strong><span style='font-size: 11;'><span style='color: black; font-family: Arial;'>" + "1530049" + "</span></span></strong></td><td></td></tr></tbody></table>";



            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";

            //INFORMACION BASICA DEL ALUMNO
            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#800020'><strong><span style='font-size: 8;'><span style='color: white; font-family: Tahoma;'>l.INFORMACIÓN BÁSICA DEL ALUMNO</span></span></strong></td></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";

            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Nombre: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "ANA LAURA" + "</span></span></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "GOMEZ" + "</span></span></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "ORTIZ" + "</span></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'>Apellido paterno</span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'>Apellido materno</span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'>Nombre</span></em></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";

            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Carrera: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "Ingeniería en Sistemas Computacionales" + "</span></span></td>";
            cadenaFinal += "<td style='text-align: right;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>CURP: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "OIMY970303MHGRCY06" + "</span></span></td>";
            cadenaFinal += "<td style='text-align: right;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Género: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "FEMENINO" + "</span></span></td>";
            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";
            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";

            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Correo Electrónico: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "asdfghjk@gmail.com" + "</span></span></td>";
            cadenaFinal += "<td style='text-align: right;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Teléfono de Casa: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "7751234567" + "</span></span></td>";
            cadenaFinal += "<td style='text-align: right;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Teléfono Celular: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "7751234567" + "</span></span></td>";
            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";

            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";

            //DIRECCION DE ORIGEN
            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#800020'><strong><span style='font-size: 8;'><span style='color: white; font-family: Tahoma;'>ll.INFORMACIÓN DEL DOMICILIO DE ORIGEN (FAMILIAR)</span></span></strong></td></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";

            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Dirección: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "JUAREZ" + "</span></span></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "2 / 3" + "</span></span></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "CALTENGO" + "</span></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'>Calle</span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'>No. Ext / No. Int</span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'>Colonia</span></em></span></td>";
            cadenaFinal += "</tr>";

            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "TULANCINGO" + "</span></span></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "TULANCINGO" + "</span></span></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "HIDALGO" + "</span></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'>Municipio</span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'>Localidad</span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'>Estado</span></em></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "<tr>";



            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Código Postal: </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "43760" + "</span></span></td>";
            cadenaFinal += "<td style='text-align: right;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'> </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: center;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + " " + "</span></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";


            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "<td style='text-align: center;'><span style='font-size: 6;'><em><span style='color: black; font-family: Calibri;'> </span></em></span></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";


            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#ffffff'><strong><span style='font-size: 8;'><span style='color: white; font-family: Tahoma;'> UNIVERSIDAD POLITECNICA DE TULANCINGO </span></span></strong></td></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";

            //DIRECCION DE ORIGEN
            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";
            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#800020'><strong><span style='font-size: 8;'><span style='color: white; font-family: Tahoma;'>lll.INFORMACIÓN RELATIVA A BECAS Y APOYOS</span></span></strong></td></td>";
            cadenaFinal += "</tr>";
            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";



            cadenaFinal += "<table>";
            cadenaFinal += "<tbody>";


            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>¿Alguna vez has tenido que suspender tus estudios por 6 meses o más debido a problemas económicos? </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "NO" + "</span></span></td>";
            cadenaFinal += "</tr>";

            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>¿Tienes hijos o dependientes económicos?</span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' ><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "NO" + "</span></span></td>";
            cadenaFinal += "</tr>";

            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>¿Trabajas o haces alguna actividad que ayude al gasto del hogar?</span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "NO" + "</span></span></td>";
            cadenaFinal += "</tr>";

            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>¿Tienes algún tipo de discapacidad?</span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' ><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "NO" + "</span></span></td>";
            cadenaFinal += "</tr>";

            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;'  bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>La vivienda donde vive tu familia es:</span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;'  bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "NO" + "</span></span></td>";
            cadenaFinal += "</tr>";

            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>¿Actualmente rentas?</span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' ><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "NO" + "</span></span></td>";
            cadenaFinal += "</tr>";

            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>¿Eres tu el jefe del hogar?</span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "NO" + "</span></span></td>";
            cadenaFinal += "</tr>";

            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Para trasladarte del lugar donde vives a la Universidad, ¿Qué medio de transporte usas?</span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' ><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "NO" + "</span></span></td>";
            cadenaFinal += "</tr>";

            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>¿Cuánto es el tiempo que ocupas en trasladarte del lugar donde vives hasta la Universidad? (EN MINUTOS)</span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "20" + "</span></span></td>";
            cadenaFinal += "</tr>";

            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>¿Estudias y trabajas?</span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "NO" + "</span></span></td>";
            cadenaFinal += "</tr>";

            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Peso (kilogramos):</span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "00" + "</span></span></td>";
            cadenaFinal += "</tr>";

            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Estatura (metros):</span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "1.57" + "</span></span></td>";
            cadenaFinal += "</tr>";

            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Índice de Masa Corporal (IMC): </span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "9000" + "</span></span></td>";
            cadenaFinal += "</tr>";

            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Total de ingresos:</span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "8000" + "</span></span></td>";
            cadenaFinal += "</tr>";

            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Total de gastos:</span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;' bgcolor='#D8D8D8'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "900" + "</span></span></td>";
            cadenaFinal += "</tr>";

            cadenaFinal += "<tr>";
            cadenaFinal += "<td style='text-align: left;'><strong><span style='font-size: 8;'><span style='color: black; font-family: Tahoma;'>Ingreso Per Cápita:</span></span></strong></td>";
            cadenaFinal += "<td style='text-align: left;'><span style='font-size: 8;'><span style='color: black; font-family: Arial;'>" + "8000" + "</span></span></td>";
            cadenaFinal += "</tr>";

            cadenaFinal += "</tbody>";
            cadenaFinal += "</table>";

            string nom = "SocioEconomico";
            imprimirPDF(cadenaFinal, nom);
        }
        private void imprimirPDF(string cadenaFinal, string nom)
        {
            Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);

            try
            {
                PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);

                //Open PDF Document to write data 
                pdfDoc.Open();




                cadenaFinal += "";

                //Assign Html content in a string to write in PDF 
                string strContent = cadenaFinal;

                //Read string contents using stream reader and convert html to parsed conent 
                var parsedHtmlElements = HTMLWorker.ParseToList(new StringReader(strContent), null);

                //Get each array values from parsed elements and add to the PDF document 
                foreach (var htmlElement in parsedHtmlElements)
                    pdfDoc.Add(htmlElement as IElement);

                //Close your PDF 
                pdfDoc.Close();

                Response.ContentType = "application/pdf";

                //Set default file Name as current datetime 
                Response.AddHeader("content-disposition", "attachment; filename=" + nom + ".pdf");
                System.Web.HttpContext.Current.Response.Write(pdfDoc);


                Response.Flush();
                Response.End();

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}
