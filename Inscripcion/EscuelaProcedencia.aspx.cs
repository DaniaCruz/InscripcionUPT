﻿using Conect.DAO;
using Conect.DTO;
using Conect.Utileria;
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
    public partial class EscuelaProcedencia : System.Web.UI.Page, IAspirante

    {
        #region
        UControl con = new UControl();
        CMunicipiosDAO muni = new CMunicipiosDAO();
        CeEstadosDAO est = new CeEstadosDAO();
        ceEscuelas esc = new ceEscuelas();
        EncuestasDAO enc = new EncuestasDAO();
        public static int alu_ID = 0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

            MaintainScrollPositionOnPostBack = true;

            AlumnoDAOSQL alu = new AlumnoDAOSQL();
            ((Menu)Master).camabiarcolor(3);


            if (!IsPostBack)
            {
                if (Session["alu_ID"] != null)
                {
                    alu_ID= (int)Session["alu_ID"];

                    EstablecerInicio();
                    if (enc.EncuestaContestada(alu_ID, 3))//si existe el alumno
                    {
                        btnGuardar.Text = "ACTUALIZAR";
                        BackUpTablas(alu_ID);

                    }
                    else
                    {
                        btnGuardar.Text = "GUARDAR";
                    }

                }
            }
        }

        public void EstablecerInicio()
        {
            
            LlenarCombo(est_Escu_ID, UControl.estado);
            LlenarCombo(mun_Escu_ID, con.Municipios(est_Escu_ID.SelectedValue));
            LlenarCombo(esc_ID,con.Escuelas());
        }






        protected void val_Promedio_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                string Promedio = alc_PromBachi.Text;
             

                decimal Promediod = Convert.ToDecimal(Promedio);

                args.IsValid = Promediod <= 10? true:false;
             
            }
            catch (Exception ex)
            {
                args.IsValid = false;
            }
        }

        protected void btnAC_Click(object sender, EventArgs e)
        {


            if (IsValid) {
                try
                 {
                    FacadeAspirante fa = new FacadeAspirante(this);
                    int id = (int)Session["alu_ID"];
                    
                        fa.UpdateEscuela(id);
                        enc.Insert(3, id);
                      
                    
                    if (btnGuardar.Text=="GUARDAR")
                    {
                        Response.Redirect("InformacionFamiliar.aspx");
                    }

                  
                  

                }
                catch (Exception ex)
                {

                    throw;
                }
               
               }

        }
        #region RECUPERA LOS DATOS DE LA BASE DE DATOS
        DataTable dt;

        void BackUpTablas(int id)
        {

            AlumComDAOSQL ac = new AlumComDAOSQL();
     
  GetDataAlumCom(ac.GetTabla(id));
            
           
          


        }

        public void GetDataAlumCom(DataTable tbl)
        {
            DataRow columna = tbl.Rows[0];
            LlenarCombo(esc_ID, con.Escuela(int.Parse(columna["mun_Escue_ID"].ToString())));
            est_Escu_ID.SelectedValue = est_Escu_ID.Items.FindByValue(columna["est_Escue_ID"].ToString()).Value;
            LlenarCombo(mun_Escu_ID, con.Municipios(est_Escu_ID.SelectedValue));
            mun_Escu_ID.SelectedValue = mun_Escu_ID.Items.FindByValue(columna["mun_Escue_ID"].ToString()).Value;
            alc_EspBachi.SelectedValue = alc_EspBachi.Items.FindByValue(columna["alc_EspBachill"].ToString()).Value;
            LlenarCombo(esc_ID, con.Escuela(int.Parse(mun_Escu_ID.SelectedValue)));
            esc_ID.SelectedValue = esc_ID.Items.FindByValue(columna["esc_ID"].ToString()).Value;
            txtAnnoConcluido.Text = columna["alc_AnioTerminoBachi"].ToString();
            alc_PromBachi.Text = columna["alc_PromBachi"].ToString();
        }

        #endregion
        #region Obtencion de los datos para la bd de acuerdo al modelo
        public AlumnoDTO AlumnoDTO
        {
            get
            {
                return llenarAlumno();
            }
        }
        AlumnoDTO llenarAlumno()
        {
            AlumnoDTO a = new AlumnoDTO();

            return a;
        }

        public AlumComDTO AlumComDTO
        {
            get
            {
                return llenarAlumCom();
            }
        }

        public DatosFamiliaresDTO DatosFamiliaresDTO
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        AlumComDTO llenarAlumCom()
        {
            AlumComDTO alc_Curp = new AlumComDTO();

            alc_Curp.alc_PromBachi = float.Parse(alc_PromBachi.Text);
            

            alc_Curp.alc_AnioTerminoBachi = txtAnnoConcluido.Text;
            alc_Curp.mun_Escue_ID = int.Parse(mun_Escu_ID.SelectedValue);
            alc_Curp.est_Escue_ID = int.Parse(est_Escu_ID.SelectedValue);

            alc_Curp.esc_ID = int.Parse(esc_ID.SelectedValue);
            alc_Curp.alc_EspBachill= alc_EspBachi.SelectedItem.ToString();
            return alc_Curp;
        }


        #endregion
        public void LlenarCombo(DropDownList cb, DataSet ds)
        {

            cb.DataSource = ds;
           cb.DataTextField = ds.Tables[0].Columns[1].ToString();
            cb.DataValueField = ds.Tables[0].Columns[0].ToString();
            cb.DataMember = ds.Tables[0].TableName;
            cb.DataBind();
        }

        protected void mun_Escu_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarCombo(esc_ID, con.Escuela(int.Parse(mun_Escu_ID.SelectedValue)));

        }

        protected void est_Escu_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarCombo(mun_Escu_ID, con.Municipios(est_Escu_ID.SelectedValue));
            if (mun_Escu_ID.SelectedValue.ToString()!="")
            {
              LlenarCombo(esc_ID, con.Escuela(int.Parse(mun_Escu_ID.SelectedValue)));
            }
            
        }

        protected void Btn_GuardarEN_Click(object sender, EventArgs e)
        {

            try
            {
                est.Insert(txtEstadoN.Text.ToUpper());
                est.Update(txtEstadoN.Text.ToUpper());

                LlenarCombo(est_Escu_ID, con.Estados2());
              

                DataSet estN = est.Consult(txtEstadoN.Text.ToUpper());
                est_Escu_ID.SelectedValue = est_Escu_ID.Items.FindByValue(estN.Tables[0].Rows[0]["est_ID"].ToString()).Value;

                LlenarCombo(mun_Escu_ID, con.Municipios(est_Escu_ID.SelectedValue));
                txtEstadoN.Text = "";
            }
            catch (Exception ex)
            {


            }
        }

        protected void Btn_GuardarMN_Click(object sender, EventArgs e)
        {
            try
            {
                muni.Insert(txtMuniN.Text.ToUpper(), int.Parse(est_Escu_ID.SelectedValue.ToString()));
                muni.Update(txtMuniN.Text.ToUpper());
                LlenarCombo(mun_Escu_ID, con.Municipios(est_Escu_ID.SelectedValue));

                DataSet munN = muni.Consult(txtMuniN.Text.ToUpper());
                mun_Escu_ID.SelectedValue = mun_Escu_ID.Items.FindByValue(munN.Tables[0].Rows[0]["mun_ID"].ToString()).Value;

                LlenarCombo(esc_ID, con.Escuela(int.Parse(mun_Escu_ID.SelectedValue)));

                txtMuniN.Text = "";
            }
            catch (Exception ex)
            {


            }
        }

        protected void Btn_GuardarIN_Click(object sender, EventArgs e)
        {
            try
            {
                esc.Insert(txtInstN.Text.ToUpper(), mun_Escu_ID.SelectedValue.ToString());
                esc.Update(txtInstN.Text.ToUpper());
                LlenarCombo(esc_ID, con.Escuela(int.Parse(mun_Escu_ID.SelectedValue)));

                DataSet InstN = esc.Consult(txtInstN.Text.ToUpper());
                esc_ID.SelectedValue = esc_ID.Items.FindByValue(InstN.Tables[0].Rows[0]["mun_ID"].ToString()).Value;


                txtMuniN.Text = "";
            }
            catch (Exception ex)
            {


            }
        }

        protected void aluu_Uni_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (aluu_UniSi.Selected == true)
            {
                aaa.Visible = true;
                aaa.Attributes.Add("style", "background-color: #F2DEDE");
                Label27.Visible = true;
                Label26.Visible = true;
                Label7.Visible = true;
                Label8.Visible = true;
                Label11.Visible = true;
                Label14.Visible = true;
                Label17.Visible = true;
                Label18.Visible = true;
                Label19.Visible = true;
                alu_UniEstado.Visible = true;
                alu_UniMun.Visible = true;
                alu_Universidad.Visible = true;
                alu_CarreraU.Visible = true;
                alu_UniAnno.Visible = true;
                alu_UniProm.Visible = true;
                Button2.Visible = true;
                Button5.Visible = true;
                Button7.Visible = true;
                RequiredFieldValidator4.Visible = true;
                RequiredFieldValidator7.Visible = true;
                RequiredFieldValidator9.Visible = true;
                RequiredFieldValidator13.Visible = true;
                RequiredFieldValidator14.Visible = true;
                RequiredFieldValidator16.Visible = true;
                CustomValidator1.Visible = true;
                RegularExpressionValidator7.Visible = true;
            }
            else if (aluu_UniNo.Selected == true)
            {
                aaa.Visible = false;
                aaa.Attributes.Add("style", "background-color: #ffffff");
                Label27.Visible = false;
                Label26.Visible = false;
                Label7.Visible = false;
                Label8.Visible = false;
                Label11.Visible = false;
                Label14.Visible = false;
                Label17.Visible = false;
                Label18.Visible = false;
                Label19.Visible = false;
                alu_UniEstado.Visible = false;
                alu_UniMun.Visible = false;
                alu_Universidad.Visible = false;
                alu_CarreraU.Visible = false;
                alu_UniAnno.Visible = false;
                alu_UniProm.Visible = false;
                Button2.Visible = false;
                Button5.Visible = false;
                Button7.Visible = false;
                RequiredFieldValidator4.Visible = false;
                RequiredFieldValidator7.Visible = false;
                RequiredFieldValidator9.Visible = false;
                RequiredFieldValidator13.Visible = false;
                RequiredFieldValidator14.Visible = false;
                RequiredFieldValidator16.Visible = false;
                CustomValidator1.Visible = false;
                RegularExpressionValidator7.Visible = false;
            }
        }

        public void Mensaje(string Mensaje, string css)
        {
            Label28.Visible = true;
            Label28.CssClass = css;
            Label28.Text = Mensaje;
        }
    }
}