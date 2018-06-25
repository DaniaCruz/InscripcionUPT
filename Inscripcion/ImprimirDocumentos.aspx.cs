using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inscripcion
{
    public partial class ImprimirDocumentos : System.Web.UI.Page
    {
        public static int alu_ID=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["alu_ID"] != null)
            {
                alu_ID = Convert.ToInt32(Session["alu_ID"]);
            }
            else
                Response.Redirect("FichaUPT.aspx");
        }

        protected void btnFicha_Click(object sender, EventArgs e)
        {
            MostrarPDF("Inscripcion");
        }
        public void MostrarPDF(string NDocumento)
        {
            Session["alu_ID"] = alu_ID;
            string _open = "window.open('Documento.aspx?NDocumento=" + NDocumento +"', '_blank')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

        protected void btnFicha0_Click(object sender, EventArgs e)
        {
            MostrarPDF("EstudioSE");
          
        }
    }
}