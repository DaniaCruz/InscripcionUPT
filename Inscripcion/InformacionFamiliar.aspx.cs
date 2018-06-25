using Conect.DAO;
using Conect.DTO;
using Inscripcion.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inscripcion
{
    public partial class InformacionFamiliar : System.Web.UI.Page , IAspirante
    {

        public static int alu_ID = 0;
        AlumnoDAOSQL alu = new AlumnoDAOSQL();
        EncuestasDAO enc = new EncuestasDAO();

        #region

        public AlumComDTO AlumComDTO
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public AlumnoDTO AlumnoDTO
        {
            get
            {
                AlumnoDTO a = new AlumnoDTO();

                return a;
            }
        }

        public DatosFamiliaresDTO DatosFamiliaresDTO
        {
            get
            {
                return llenarDatosFamiliares(4);
            }
        }

        #endregion Interfaz

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            ((Menu)Master).camabiarcolor(4);

            try
            {
                MaintainScrollPositionOnPostBack = true;


                alu_ID = alu.ObtenerID(Session["alu_NumControl"].ToString());
                if (alu_ID != 0)
                {
                    Session["alu_ID"] = alu_ID;
                    ((Menu)Master).camabiarcolor(4);
                    if (!IsPostBack)
                    {


                        if (enc.EncuestaContestada(alu_ID, 4))//si existe el alumno
                        {
                            btnGuardar.Text = "ACTUALIZAR";
                            RecuperarDatosFam();
                        }

                        else
                        {
                            btnGuardar.Text = "GUARDAR";
                             

                        }

                    }

                }
            }
            catch (Exception ex)
            {

                Mensaje("NO SE HA PODIDO REALIZAR LA OPERACIÓN , INTENTELO MÁS TARDE", "alert alert-danger");
            }



        }

        protected void rb_Hijos_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbSi1.Selected)
            {
                RequiredFieldValidator16.Visible = true;
                dprHijos.Visible = true;
                lbCuantos.Visible = true;
            }
            else
            {

                RequiredFieldValidator16.Visible = false;
                dprHijos.Visible = false;
                lbCuantos.Visible = false;
            }
        }

        protected void num_Personas_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbTabla.Visible = true;
                Tabla.Visible = true;
                TableRow[] filas = { Fila0, Fila1, Fila2, Fila3, Fila4, Fila5, Fila6, Fila6, Fila7, Fila8 };

                for (int i = 0; i < filas.Length; i++)
                    filas[i].Visible = false;

                int hijos = int.Parse(num_Personas.Text) <= 8 ? int.Parse(num_Personas.Text) : 8;
                for (int i = 0; i < hijos; i++)
                    filas[i].Visible = true;

            }
            catch (Exception)
            {

                
            }
        


        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

            FacadeAspirante fa = new FacadeAspirante(this);
            if (btnGuardar.Text == "GUARDAR")
            {
                for (int i = 0; i < int.Parse(num_Personas.Text); i++)
                {
                    fa.InsertDatosFamiliares(llenarDatosFamiliares(i), alu_ID);
                }
                fa.DeleteDatosFamiliaresR(alu_ID);
                enc.Insert(4, alu_ID);
                Response.Redirect("EstudioSocioE.aspx");
            }
            else
            {

                fa.DeleteDatosFamiliares(alu_ID);
                for (int i = 0; i < int.Parse(num_Personas.Text); i++)
                    {
                        fa.InsertDatosFamiliares(llenarDatosFamiliares(i), alu_ID);
                       
                    }
               Mensaje("TU INFORMACIÓN HA SIDO ACTUALIZADA ", "alert alert-success");

                }

            }
            catch (Exception)
            {

                Mensaje("NO SE HA PODIDO REALIZAR LA OPERACIÓN , INTENTELO MÁS TARDE", "alert alert-danger");
            }

        }    
        
        #region RECUPERA LOS DATOS DE LA BASE DE DATOS
        DataTable dt;
        public void RecuperarDatosFam()
        {
            DatosFamiliaresDAOSQL df = new DatosFamiliaresDAOSQL();
            TableRow[] filas = { Fila0, Fila1, Fila2, Fila3, Fila4, Fila5, Fila6, Fila6, Fila7, Fila8 };
            dt = df.GetTabla(alu_ID);//ESTE METODO TRAE TODOS LOS DATOS DE LOS FAMILIARES DEL ALUMNO QUE TIENE ESTE ID
            string nh = dt.Rows[0]["alc_NoHijos"].ToString();
            if (dt.Rows[0]["alc_NoHijos"].ToString() != "0") {
                
                rbSi1.Selected = true;
                dprHijos.Visible = true;
                lbCuantos.Visible = true;
                dprHijos.SelectedValue = dprHijos.Items.FindByValue(dt.Rows[0]["alc_NoHijos"].ToString()).Value;
            }
            else rbNo1.Selected = true;

            num_Personas.Text = dt.Rows.Count.ToString();
            Tabla.Visible = true;
            

            for (int i = 0; i < dt.Rows.Count; i++)//RECORRE LAS FILAS (No de familiares que tiene el aspirante) solo llenara SOLO TERMINA DE IGUALAR ELEMENTOS
            {
                
                if (i == 0)
                {
                    Fila0.Visible=true;
                    Familiar0_Nombre.Text = dt.Rows[i]["daf_Nombre"].ToString();
                    Familiar0_Edad.Text = dt.Rows[i]["daf_Edad"].ToString();
                    Familiar0_Parentezco.SelectedValue=Familiar0_Parentezco.Items.FindByText(dt.Rows[i]["daf_Parentezco"].ToString()).Value ;
                    Familiar0_Escolaridad.SelectedValue = Familiar0_Escolaridad.Items.FindByText(dt.Rows[i]["daf_Escolaridad"].ToString()).Value;
                    Familiar0_Ocupacio.Text = dt.Rows[i]["alc_OcupaFam"].ToString();
                }
                if (i == 1)
                {
                    Fila1.Visible = true;
                    Familiar1_Nombre.Text = dt.Rows[i]["daf_Nombre"].ToString();
                    Familiar1_Edad.Text =dt.Rows[i]["daf_Edad"].ToString();
                    Familiar1_Parentezco.SelectedValue = Familiar1_Parentezco.Items.FindByText(dt.Rows[i]["daf_Parentezco"].ToString()).Value;
                    Familiar1_Escolaridad.SelectedValue = Familiar1_Escolaridad.Items.FindByText(dt.Rows[i]["daf_Escolaridad"].ToString()).Value;
                    Familiar1_Ocupacio.Text = dt.Rows[i]["alc_OcupaFam"].ToString();
                }
                if (i == 2)
                {
                    Fila2.Visible = true;
                    Familiar2_Nombre.Text = dt.Rows[i]["daf_Nombre"].ToString();
                    Familiar2_Edad.Text = dt.Rows[i]["daf_Edad"].ToString();
                    Familiar2_Parentezco.SelectedValue = Familiar2_Parentezco.Items.FindByText(dt.Rows[i]["daf_Parentezco"].ToString()).Value;
                    Familiar2_Escolaridad.SelectedValue = Familiar2_Escolaridad.Items.FindByText(dt.Rows[i]["daf_Escolaridad"].ToString()).Value;
                    Familiar2_Ocupacio.Text = dt.Rows[i]["alc_OcupaFam"].ToString();
                }
                if (i == 3)
                {
                    Fila3.Visible = true;
                    Familiar3_Nombre.Text = dt.Rows[i]["daf_Nombre"].ToString();
                    Familiar3_Edad.Text = dt.Rows[i]["daf_Edad"].ToString();
                    Familiar3_Parentezco.SelectedValue = Familiar3_Parentezco.Items.FindByText(dt.Rows[i]["daf_Parentezco"].ToString()).Value;
                    Familiar3_Escolaridad.SelectedValue = Familiar3_Escolaridad.Items.FindByText(dt.Rows[i]["daf_Escolaridad"].ToString()).Value;
                    Familiar3_Ocupacio.Text = dt.Rows[i]["alc_OcupaFam"].ToString();
                }
                if (i == 4)
                {
                    Fila4.Visible = true;
                    Familiar4_Nombre.Text = dt.Rows[i]["daf_Nombre"].ToString();
                    Familiar4_Edad.Text = dt.Rows[i]["daf_Edad"].ToString();
                    Familiar4_Parentezco.SelectedValue = Familiar4_Parentezco.Items.FindByText(dt.Rows[i]["daf_Parentezco"].ToString()).Value;
                    Familiar4_Escolaridad.SelectedValue = Familiar4_Escolaridad.Items.FindByText(dt.Rows[i]["daf_Escolaridad"].ToString()).Value;
                    Familiar4_Ocupacio.Text = dt.Rows[i]["alc_OcupaFam"].ToString();
                }
                if (i == 5)
                {
                    Fila6.Visible = true;
                    Familiar5_Nombre.Text = dt.Rows[i]["daf_Nombre"].ToString();
                    Familiar5_Edad.Text = dt.Rows[i]["daf_Edad"].ToString();
                    Familiar5_Parentezco.SelectedValue = Familiar5_Parentezco.Items.FindByText(dt.Rows[i]["daf_Parentezco"].ToString()).Value;
                    Familiar5_Escolaridad.SelectedValue = Familiar5_Escolaridad.Items.FindByText(dt.Rows[i]["daf_Escolaridad"].ToString()).Value;
                    Familiar5_Ocupacio.Text = dt.Rows[i]["alc_OcupaFam"].ToString();
                }
                if (i == 6)
                {
                    Fila6.Visible = true;
                    Familiar6_Nombre.Text = dt.Rows[i]["daf_Nombre"].ToString();
                    Familiar6_Edad.Text = dt.Rows[i]["daf_Edad"].ToString();
                    Familiar6_Parentezco.SelectedValue = Familiar6_Parentezco.Items.FindByText(dt.Rows[i]["daf_Parentezco"].ToString()).Value;
                    Familiar6_Escolaridad.SelectedValue = Familiar6_Escolaridad.Items.FindByText(dt.Rows[i]["daf_Escolaridad"].ToString()).Value;
                    Familiar6_Ocupacio.Text = dt.Rows[i]["alc_OcupaFam"].ToString();
                }
                if (i == 7)
                {
                    Fila7.Visible = true;
                    Familiar7_Nombre.Text = dt.Rows[i]["daf_Nombre"].ToString();
                    Familiar7_Edad.Text = dt.Rows[i]["daf_Edad"].ToString();
                    Familiar7_Parentezco.SelectedValue = Familiar7_Parentezco.Items.FindByText(dt.Rows[i]["daf_Parentezco"].ToString()).Value;
                    Familiar7_Escolaridad.SelectedValue = Familiar7_Escolaridad.Items.FindByText(dt.Rows[i]["daf_Escolaridad"].ToString()).Value;
                    Familiar7_Ocupacio.Text = dt.Rows[i]["alc_OcupaFam"].ToString();
                }
                if (i == 8)
                {
                    Fila8.Visible = true;
                    Familiar8_Nombre.Text = dt.Rows[i]["daf_Nombre"].ToString();
                    Familiar8_Edad.Text = dt.Rows[i]["daf_Edad"].ToString();
                    Familiar8_Parentezco.SelectedValue = Familiar8_Parentezco.Items.FindByText(dt.Rows[i]["daf_Parentezco"].ToString()).Value;
                    Familiar8_Escolaridad.SelectedValue = Familiar8_Escolaridad.Items.FindByText(dt.Rows[i]["daf_Escolaridad"].ToString()).Value;
                    Familiar8_Ocupacio.Text = dt.Rows[i]["alc_OcupaFam"].ToString();
                }


            }

        }
        public DatosFamiliaresDTO llenarDatosFamiliares(int i)//
        {
            DatosFamiliaresDTO df = null;

            if (i == 0)//JALA DATOS DE LA FILA 1
            {

                df = new DatosFamiliaresDTO();
                df.daf_NoHijos = rbSi1.Selected ? int.Parse(dprHijos.SelectedValue.ToString()) : 0;
                df.daf_Nombre = Familiar0_Nombre.Text;
                df.daf_Edad = Convert.ToInt32(Familiar0_Edad.Text);
                df.daf_Escolaridad = Familiar0_Escolaridad.SelectedItem.Text;
                df.daf_Parentezco = Familiar0_Parentezco.SelectedItem.Text;
                df.daf_Ocupacion = Familiar0_Ocupacio.Text;
                return df;
            }
            if (i == 1)//JALA DATOS DE LA FILA 2
            {
                df = new DatosFamiliaresDTO();
                df.daf_NoHijos = rbSi1.Selected ? int.Parse(dprHijos.SelectedValue.ToString()) : 0;
                df.daf_Nombre = Familiar1_Nombre.Text;
                df.daf_Edad = Convert.ToInt32(Familiar1_Edad.Text);
                df.daf_Escolaridad = Familiar1_Escolaridad.SelectedItem.Text;
                df.daf_Parentezco = Familiar1_Parentezco.SelectedItem.Text;
                df.daf_Ocupacion = Familiar1_Ocupacio.Text;
                return df;
            }
            if (i == 2)
            {
                df = new DatosFamiliaresDTO();
                df.daf_NoHijos = rbSi1.Selected ? int.Parse(dprHijos.SelectedValue.ToString()) : 0;
                df.daf_Nombre = Familiar2_Nombre.Text;
                df.daf_Edad = Convert.ToInt32(Familiar2_Edad.Text);
                df.daf_Escolaridad = Familiar2_Escolaridad.SelectedItem.Text;
                df.daf_Parentezco = Familiar2_Parentezco.SelectedItem.Text;
                df.daf_Ocupacion = Familiar2_Ocupacio.Text;
                return df;
            }
            if (i == 3)
            {
                df = new DatosFamiliaresDTO();
                df.daf_NoHijos = rbSi1.Selected ? int.Parse(dprHijos.SelectedValue.ToString()) : 0;
                df.daf_Nombre = Familiar3_Nombre.Text;
                df.daf_Edad = Convert.ToInt32(Familiar3_Edad.Text);
                df.daf_Escolaridad = Familiar3_Escolaridad.SelectedItem.Text;
                df.daf_Parentezco = Familiar3_Parentezco.SelectedItem.Text;
                df.daf_Ocupacion = Familiar3_Ocupacio.Text;
                return df;
            }
            if (i == 4)
            {
                df = new DatosFamiliaresDTO();
                df.daf_NoHijos = rbSi1.Selected ? int.Parse(dprHijos.SelectedValue.ToString()) : 0;
                df.daf_Nombre = Familiar4_Nombre.Text;
                df.daf_Edad = Convert.ToInt32(Familiar4_Edad.Text); ;
                df.daf_Escolaridad = Familiar4_Escolaridad.SelectedItem.Text;
                df.daf_Parentezco = Familiar4_Parentezco.SelectedItem.Text;
                df.daf_Ocupacion = Familiar4_Ocupacio.Text;
                return df;
            }
            if (i == 5)
            {
                df = new DatosFamiliaresDTO();
                df.daf_NoHijos = rbSi1.Selected ? int.Parse(dprHijos.SelectedValue.ToString()) : 0;
                df.daf_Nombre = Familiar5_Nombre.Text;
                df.daf_Edad = Convert.ToInt32(Familiar5_Edad.Text);
                df.daf_Escolaridad = Familiar5_Escolaridad.SelectedItem.Text;

                df.daf_Parentezco = Familiar5_Parentezco.SelectedItem.Text;
                df.daf_Ocupacion = Familiar5_Ocupacio.Text;
                return df;
            }
            if (i == 6)
            {
                df = new DatosFamiliaresDTO();
                df.daf_NoHijos = rbSi1.Selected ? int.Parse(dprHijos.SelectedValue.ToString()) : 0;
                df.daf_Nombre = Familiar6_Nombre.Text;
                df.daf_Edad = Convert.ToInt32(Familiar6_Edad.Text);
                df.daf_Escolaridad = Familiar6_Escolaridad.SelectedItem.Text;
                df.daf_Parentezco = Familiar6_Parentezco.SelectedItem.Text;
                df.daf_Ocupacion = Familiar6_Ocupacio.Text;
                return df;
            }

            if (i == 7)
            {
                df = new DatosFamiliaresDTO();
                df.daf_NoHijos = rbSi1.Selected ? int.Parse(dprHijos.SelectedValue.ToString()) : 0;
                df.daf_Nombre = Familiar7_Nombre.Text;
                df.daf_Edad = Convert.ToInt32(Familiar7_Edad.Text);
                df.daf_Escolaridad = Familiar7_Escolaridad.SelectedItem.Text;
                df.daf_Parentezco = Familiar7_Parentezco.SelectedItem.Text;
                df.daf_Ocupacion = Familiar7_Ocupacio.Text;
                return df;
            }

            if (i == 8)
            {
                df = new DatosFamiliaresDTO();
                df.daf_NoHijos = rbSi1.Selected ? int.Parse(dprHijos.SelectedValue.ToString()) : 0;
                df.daf_Nombre = Familiar8_Nombre.Text;
                df.daf_Edad = Convert.ToInt32(Familiar8_Edad.Text);
                df.daf_Escolaridad = Familiar8_Escolaridad.SelectedItem.Text;
                df.daf_Parentezco = Familiar8_Parentezco.SelectedItem.Text;
                df.daf_Ocupacion = Familiar8_Ocupacio.Text;
                return df;
            }
            return null;
        }

        #endregion

        public void Mensaje(string Mensaje, string css)
        {
            lblMensaje.Visible = true;
            lblMensaje.CssClass = css;
            lblMensaje.Text = Mensaje;
        }


    }
}