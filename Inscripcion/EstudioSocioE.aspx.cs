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
    public partial class EstudioSocioE : System.Web.UI.Page
    {
        AntecedentesAluQL ante = new AntecedentesAluQL();
        AntecedentesAluPDTO aluDTO = new AntecedentesAluPDTO();
        IngrEgrFamiliaresDAOSQL ingr = new IngrEgrFamiliaresDAOSQL();
        IngrEgrFamiliaresDTO ingDTO = new IngrEgrFamiliaresDTO();
        ViviendaDAOSQL viv = new ViviendaDAOSQL();
        ViviendaDTO vivDTO = new ViviendaDTO();
        BecasDAOSQL beca = new BecasDAOSQL();
        BecasDTO becaDTO = new BecasDTO();
        AlumnoDAOSQL alu = new AlumnoDAOSQL();
        EncuestasDAO enc = new EncuestasDAO();

        public static int alu_ID = 0;
        private float miemFamilia = 0;
        private float ingrPer = 0;
        private double IMC = 0;
        private double altura = 0;
        private double peso = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                MaintainScrollPositionOnPostBack = true;


                alu_ID = alu.ObtenerID(Session["alu_NumControl"].ToString());
                if (alu_ID != 0)
                {
                    Session["alu_ID"] = alu_ID;
                    ((Menu)Master).camabiarcolor(1);
                    if (!IsPostBack)
                    {

                        if (enc.EncuestaContestada(alu_ID, 5))//si existe el alumno
                        {
                            btnAE.Text = "ACTUALIZAR";
                            BackUpTablas(alu_ID);//ESTE METODO RECUPERA TODO DE LAS TABLAS NO SE LE TIENE QUE MOVER NADA SOLO TERMINA DE IGUALAR COMPONENTES
                        }

                        else
                        {
                            btnAE.Text = "GUARDAR";

                        }

                    }

                }
            }
            catch (Exception) { }
        }


        void BackUpTablas(int id)
        {
            GetDataIngrEgr(alu_ID);
            GetDataAlu(alu_ID);
            GetDataBeca(alu_ID);
            GetDataViv(alu_ID);

        }
        //muestra los datos de la consulta
        private void GetDataIngrEgr(int id)
        {
            try
            {
                DataTable dt = ingr.GetTabla(id);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ief_Padre.Text = dt.Rows[i]["ief_Padre"].ToString();
                    ief_Madre.Text = dt.Rows[i]["ief_Madre"].ToString();
                    ief_Usted.Text = dt.Rows[i]["ief_Usted"].ToString();
                    ief_Hermanos.Text = dt.Rows[i]["ief_Hermanos"].ToString();
                    ief_Conyuge.Text = dt.Rows[i]["ief_Conyuge"].ToString();
                    ief_Otros.Text = dt.Rows[i]["ief_Otros"].ToString();
                    ief_Total.Text = dt.Rows[i]["ief_Total"].ToString();

                    ief_Renta.Text = dt.Rows[i]["ief_Renta"].ToString();
                    ief_Alimentacion.Text = dt.Rows[i]["ief_Alimentacion"].ToString();
                    ief_Vestido.Text = dt.Rows[i]["ief_Vestido"].ToString();
                    ief_Transporte.Text = dt.Rows[i]["ief_Transporte"].ToString();
                    ief_Colegiatura.Text = dt.Rows[i]["ief_Colegiatura"].ToString();
                    ief_Agua.Text = dt.Rows[i]["ief_Agua"].ToString();
                    ief_Electricidad.Text = dt.Rows[i]["ief_Electricidad"].ToString();
                    ief_GasCombustible.Text = dt.Rows[i]["ief_GasCombustible"].ToString();
                    ief_OtrosE.Text = dt.Rows[i]["ief_OtrosE"].ToString();
                    ief_TotalEgresos.Text = dt.Rows[i]["ief_TotalEgresos"].ToString();
                    ief_Telefono.Text = dt.Rows[i]["ief_Telefono"].ToString();
                }
            }
            catch (Exception) { }
        }
        private void GetDataAlu(int id)
        {
            try
            {
                DataTable dt = ante.GetTabla(id);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bool alp_EstatusJefeHogar = Convert.ToBoolean(dt.Rows[i]["alp_EstatusJefeHogar"].ToString());
                    if (alp_EstatusJefeHogar) { alp_EstatusJefeHogarSi.Selected = true; } else { alp_EstatusJefeHogarNo.Selected = true; }
                    num_Personas_DependenJH.Text = dt.Rows[i]["alp_NoPersonasDepeIngr"].ToString();
                    alp_NoDiasTrabajaJefeH.SelectedValue = dt.Rows[i]["alp_NoDiasTrabajaJefeH"].ToString();
                    alp_DineroMensualPorTrabajar.Text = dt.Rows[i]["alp_DineroMensualPorTrabajar"].ToString();
                    string alp_EstatusEmpleo = dt.Rows[i]["alp_Empleo"].ToString();
                    if (alp_EstatusEmpleo == "")
                    {
                        apl_EmpleoNo.Selected = true;
                        alp_Empleo.Visible = false;
                    }
                    else
                    {
                        apl_EmpleoSi.Selected = true;
                        alp_Empleo.Visible = true;
                        alp_Empleo.Text = dt.Rows[i]["alp_Empleo"].ToString();
                    }
                }
            }
            catch (Exception) { }
        }
        private void GetDataViv(int id)
        {
            try
            {
                DataTable dt = viv.GetTabla(id);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    viv_MaterialTecho.SelectedValue = dt.Rows[i]["viv_MaterialTecho"].ToString();
                    viv_MaterialParedes.SelectedValue = dt.Rows[i]["viv_MaterialParedes"].ToString();
                    viv_MaterialPiso.SelectedValue = dt.Rows[i]["viv_MaterialPiso"].ToString();
                    if ((dt.Rows[i]["viv_CocinaIndependiente"].ToString()).Equals("T")) { viv_CocinaIndependienteSi.Selected = true; } else { viv_CocinaIndependienteNo.Selected = true; }
                    viv_NoCuartos.SelectedValue = dt.Rows[i]["viv_NoCuartos"].ToString();
                    viv_NoDormitorios.SelectedValue = dt.Rows[i]["viv_NoDormitorios"].ToString();
                    viv_TipoVivienda.SelectedValue = dt.Rows[i]["viv_TipoVivienda"].ToString();
                    viv_Lavadora.Checked = Convert.ToBoolean(dt.Rows[i]["viv_Lavadora"].ToString());
                    viv_Cisterna.Checked = Convert.ToBoolean(dt.Rows[i]["viv_Cisterna"].ToString());
                    viv_Refrigerador.Checked = Convert.ToBoolean(dt.Rows[i]["viv_Refrigerador"].ToString());
                    viv_Drenaje.Checked = Convert.ToBoolean(dt.Rows[i]["viv_Drenaje"].ToString());
                    viv_Compu.Checked = Convert.ToBoolean(dt.Rows[i]["viv_Compu"].ToString());
                    viv_AcceInter.Checked = Convert.ToBoolean(dt.Rows[i]["viv_AcceInter"].ToString());
                    viv_Auto.Checked = Convert.ToBoolean(dt.Rows[i]["viv_Auto"].ToString());
                    viv_Moto.Checked = Convert.ToBoolean(dt.Rows[i]["viv_Moto"].ToString());
                    Horno.Checked = Convert.ToBoolean(dt.Rows[i]["viv_Horno"].ToString());
                    Electrodomes.Checked = Convert.ToBoolean(dt.Rows[i]["viv_Electrodomes"].ToString());
                    viv_Regadera.Checked = Convert.ToBoolean(dt.Rows[i]["viv_Regadera"].ToString());
                    viv_MedLuz.Checked = Convert.ToBoolean(dt.Rows[i]["viv_MedLuz"].ToString());
                    viv_Dvd.Checked = Convert.ToBoolean(dt.Rows[i]["viv_Dvd"].ToString());
                    viv_Radio.Checked = Convert.ToBoolean(dt.Rows[i]["viv_Radio"].ToString());
                    viv_TV.Checked = Convert.ToBoolean(dt.Rows[i]["viv_TV"].ToString());
                    alc_MediTransp.SelectedValue = dt.Rows[i]["viv_MedioTransporte"].ToString(); ;
                    alc_TiempoTranslado.Text = dt.Rows[i]["viv_TiempoTraslado"].ToString(); ;
                    viv_Luz.Checked = Convert.ToBoolean(dt.Rows[i]["viv_Luz"].ToString());
                    viv_AguaPotable.Checked = Convert.ToBoolean(dt.Rows[i]["viv_AguaPotable"].ToString());
                    viv_EstufaDeGas.Checked = Convert.ToBoolean(dt.Rows[i]["viv_EstufaDeGas"].ToString());
                    viv_TinacoDeAgua.Checked = Convert.ToBoolean(dt.Rows[i]["viv_TinacoAgua"].ToString());
                    viv_Gas.Checked = Convert.ToBoolean(dt.Rows[i]["viv_Gas"].ToString());
                    viv_Tele.Checked = Convert.ToBoolean(dt.Rows[i]["viv_Television"].ToString());
                    viv_Telefono.Checked = Convert.ToBoolean(dt.Rows[i]["viv_Telefono"].ToString());
                    ief_GastoPasaje.Text = dt.Rows[i]["viv_GastoPasaje"].ToString();
                }
            }
            catch (Exception) { }
        }
        private void GetDataBeca(int id)
        {
            try
            {
                DataTable dt = beca.GetTabla(id);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bool BecaAntes = Convert.ToBoolean(dt.Rows[i]["bec_BecadoAntes"].ToString());
                    if (BecaAntes) { bec_BecadoAntesSII.Selected = true; } else { bec_BecadoAntesNOO.Selected = true; }
                    bool estatusBeca = Convert.ToBoolean(dt.Rows[i]["bec_EstatusBecado"].ToString());
                    if (estatusBeca) { bec_EstatusCONAFESII.Selected = true; } else { bec_EstatusCONAFENOO.Selected = true; }
                    bool suspension = Convert.ToBoolean(dt.Rows[i]["bec_SuspensionEstudios"].ToString());
                    if (suspension) { bec_SuspenciosEstudiosSII.Selected = true; } else { bec_SuspenciosEstudiosNOO.Selected = true; }
                    bool becadoAntes = Convert.ToBoolean(dt.Rows[i]["bec_BecadoAntes"].ToString());
                    if (becadoAntes) { bec_BecadoAntesSII.Selected = true; } else { bec_BecadoAntesNOO.Selected = true; }
                    bool Oportunidades = Convert.ToBoolean(dt.Rows[i]["bec_EstatusOportunidades"].ToString());
                    if (Oportunidades) { bec_EstatusOportunidadesSII.Selected = true; } else { bec_EstatusOportunidadesNOO.Selected = true; }
                    alu_Peso.Text = dt.Rows[i]["bec_Peso"].ToString();
                    alu_Estatura.Text = dt.Rows[i]["bec_Estatura"].ToString();
                }
            }
            catch (Exception) { }
        }

        protected void alp_EstatusJefeHoga_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void val_Estatura_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                string Promedio = alu_Estatura.Text;
                decimal Promediod = Convert.ToDecimal(Promedio);

                args.IsValid = Promediod <= 6 ? true : false;

            }
            catch (Exception ex)
            {
                args.IsValid = false;
            }
        }

        protected void apl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (apl_EmpleoSi.Selected)
            {
                labelCual.Visible = true;
                alp_Empleo.Visible = true;
            }
            else if (apl_EmpleoNo.Selected)
            {
                labelCual.Visible = false;
                alp_Empleo.Visible = false;
            }
        }


        //Obtencion de los datos del formulario
        public AntecedentesAluPDTO ObtenerDatos()
        {
            AntecedentesAluPDTO anteced = new AntecedentesAluPDTO();
            try
            {
                if (alp_EstatusJefeHogarSi.Selected == true)
                    anteced.alp_EstatusJefeHogar = true;
                else
                    anteced.alp_EstatusJefeHogar = false;
                anteced.alu_ID = alu_ID;
                anteced.alp_NoPersonasDepeIngr = Convert.ToInt32(num_Personas_DependenJH.Text);
                miemFamilia = Convert.ToInt32(num_Personas_DependenJH.Text);
                anteced.alp_NoDiasTrabajaJefeH = Convert.ToInt32(alp_NoDiasTrabajaJefeH.SelectedValue);
                anteced.alp_DineroMensualPorTrabajar = Convert.ToInt32(alp_DineroMensualPorTrabajar.Text);
                if (apl_EmpleoSi.Selected == true)
                    anteced.alp_Empleo = alp_Empleo.Text;
                else
                {
                    alp_Empleo.Visible = false;
                    anteced.alp_Empleo = "";
                }
            }
            catch (Exception) { }
            return anteced;
        }
        public ViviendaDTO ObtenerVivienda()
        {
            ViviendaDTO vivien = new ViviendaDTO();
            try
            {
                vivien.alu_ID = alu_ID;
                vivien.viv_TipoVivienda = viv_TipoVivienda.SelectedValue;
                vivien.viv_MaterialTecho = viv_MaterialTecho.SelectedValue;
                vivien.viv_MaterialParedes = viv_MaterialParedes.SelectedValue;
                vivien.viv_MaterialPiso = viv_MaterialPiso.SelectedValue;

                if (viv_CocinaIndependienteSi.Selected == true)
                    vivien.viv_CocinaIndependiente = "T";
                else
                    vivien.viv_CocinaIndependiente = "F";

                vivien.viv_NoDormitorios = Convert.ToInt32(viv_NoDormitorios.SelectedValue);
                vivien.viv_NoCuartos = Convert.ToInt32(viv_NoCuartos.SelectedValue);

                vivien.viv_Lavadora = Convert.ToBoolean(viv_Lavadora.Checked);
                vivien.viv_Cisterna = Convert.ToBoolean(viv_Cisterna.Checked);
                vivien.viv_Refrigerador = Convert.ToBoolean(viv_Refrigerador.Checked);
                vivien.viv_Drenaje = Convert.ToBoolean(viv_Drenaje.Checked);
                vivien.viv_Compu = Convert.ToBoolean(viv_Compu.Checked);
                vivien.viv_AcceInter = Convert.ToBoolean(viv_AcceInter.Checked);
                vivien.viv_Auto = Convert.ToBoolean(viv_Auto.Checked);
                vivien.viv_Moto = Convert.ToBoolean(viv_Moto.Checked);
                vivien.viv_Horno = Convert.ToBoolean(Horno.Checked);
                vivien.viv_Electrodomes = Convert.ToBoolean(Electrodomes.Checked);
                vivien.viv_Regadera = Convert.ToBoolean(viv_Regadera.Checked);
                vivien.viv_MedLuz = Convert.ToBoolean(viv_MedLuz.Checked);
                vivien.viv_Dvd = Convert.ToBoolean(viv_Dvd.Checked);
                vivien.viv_Radio = Convert.ToBoolean(viv_Radio.Checked);
                vivien.viv_TV = Convert.ToBoolean(viv_TV.Checked);
                vivien.viv_Luz = Convert.ToBoolean(viv_Luz.Checked);
                vivien.viv_AguaPotable = Convert.ToBoolean(viv_AguaPotable.Checked);
                vivien.viv_EstufaDeGas = Convert.ToBoolean(viv_EstufaDeGas.Checked);
                vivien.viv_TinacoAgua = Convert.ToBoolean(viv_TinacoDeAgua.Checked);
                vivien.viv_Gas = Convert.ToBoolean(viv_Gas.Checked);
                vivien.viv_Television = Convert.ToBoolean(viv_Tele.Checked);
                vivien.viv_Telefono = Convert.ToBoolean(viv_Telefono.Checked);

                vivien.viv_MedioTransporte = alc_MediTransp.SelectedValue;
                vivien.viv_TiempoTraslado = alc_TiempoTranslado.SelectedValue;
                vivien.viv_GastoPasaje = Convert.ToInt32(ief_GastoPasaje.Text);
            }
            catch (Exception) { }
            return vivien;
        }

        public IngrEgrFamiliaresDTO ObtenerFamiliares()
        {
            IngrEgrFamiliaresDTO fam = new IngrEgrFamiliaresDTO();
            try
            {
                fam.alu_ID = alu_ID;

                float total = 0;
                int totalEgresos = 0;

                if (ief_Padre.Text != null)
                {
                    fam.ief_Padre = Convert.ToInt32(ief_Padre.Text);
                    total += Convert.ToInt32(ief_Padre.Text);
                }
                else
                    fam.ief_Padre = 0;

                if (ief_Madre.Text != null)
                {
                    fam.ief_Madre = Convert.ToInt32(ief_Madre.Text);
                    total += Convert.ToInt32(ief_Madre.Text);
                }
                else
                    fam.ief_Madre = 0;

                if (ief_Usted != null)
                {
                    fam.ief_Usted = Convert.ToInt32(ief_Usted.Text);
                    total += Convert.ToInt32(ief_Usted.Text);
                }
                else
                    fam.ief_Usted = 0;

                if (ief_Conyuge.Text != null)
                {
                    fam.ief_Conyugue = Convert.ToInt32(ief_Conyuge.Text);
                    total += Convert.ToInt32(ief_Conyuge.Text);
                }
                else
                    fam.ief_Conyugue = 0;

                if (ief_Otros.Text != null)
                {
                    fam.ief_Otros = Convert.ToInt32(ief_Otros.Text);
                    total += Convert.ToInt32(ief_Otros.Text);
                }
                else
                    fam.ief_Otros = 0;

                if (ief_Hermanos.Text != null)
                {
                    fam.ief_Hermanos = Convert.ToInt32(ief_Hermanos.Text);
                    total += Convert.ToInt32(ief_Hermanos.Text);
                }
                else
                    fam.ief_Hermanos = 0;

                ief_Total.Text = total.ToString();
                fam.ief_Total = total;
                //----------------------------------------------------------------------

                if (ief_Renta != null)
                {
                    fam.ief_Renta = Convert.ToInt32(ief_Renta.Text);
                    totalEgresos += Convert.ToInt32(ief_Renta.Text);
                }
                else
                    fam.ief_Renta = 0;

                if (ief_Alimentacion != null)
                {
                    fam.ief_Alimentacion = Convert.ToInt32(ief_Alimentacion.Text);
                    totalEgresos += Convert.ToInt32(ief_Alimentacion.Text);
                }
                else
                    fam.ief_Alimentacion = 0;

                if (ief_Vestido != null)
                {
                    fam.ief_Vestido = Convert.ToInt32(ief_Vestido.Text);
                    totalEgresos += Convert.ToInt32(ief_Vestido.Text);
                }
                else
                    fam.ief_Vestido = 0;

                if (ief_Transporte != null)
                {
                    fam.ief_Transporte = Convert.ToInt32(ief_Transporte.Text);
                    totalEgresos += Convert.ToInt32(ief_Transporte.Text);
                }
                else
                    fam.ief_Transporte = 0;

                if (ief_Colegiatura != null)
                {
                    fam.ief_Colegiaura = Convert.ToInt32(ief_Colegiatura.Text);
                    totalEgresos += Convert.ToInt32(ief_Colegiatura.Text);
                }
                else
                    fam.ief_Colegiaura = 0;

                if (ief_Agua != null)
                {
                    fam.ief_Agua = Convert.ToInt32(ief_Agua.Text);
                    totalEgresos += Convert.ToInt32(ief_Agua.Text);
                }
                else
                    fam.ief_Agua = 0;

                if (ief_Electricidad != null)
                {
                    fam.ief_Electricidad = Convert.ToInt32(ief_Electricidad.Text);
                    totalEgresos += Convert.ToInt32(ief_Electricidad.Text);
                }
                else
                    fam.ief_Electricidad = 0;

                if (ief_GasCombustible != null)
                {
                    fam.ief_GasCombustible = Convert.ToInt32(ief_GasCombustible.Text);
                    totalEgresos += Convert.ToInt32(ief_GasCombustible.Text);
                }
                else
                    fam.ief_GasCombustible = 0;

                if (ief_Telefono != null)
                {
                    fam.ief_Telefono = Convert.ToInt32(ief_Telefono.Text);
                    totalEgresos += Convert.ToInt32(ief_Telefono.Text);
                }
                else
                    fam.ief_Telefono = 0;

                if (ief_OtrosE != null)
                {
                    fam.ief_OtrosE = Convert.ToInt32(ief_OtrosE.Text);
                    totalEgresos += Convert.ToInt32(ief_OtrosE.Text);
                }
                else
                    fam.ief_OtrosE = 0;

                ief_TotalEgresos.Text = totalEgresos.ToString();
                fam.ief_TotalEgresos = totalEgresos;
                ingrPer = (total / miemFamilia);
                fam.ief_IngrPerc = ingrPer.ToString();
            }
            catch (Exception) { }
            return fam;
        }
        public BecasDTO ObtenerBecas()
        {
            BecasDTO beca = new BecasDTO();
            try
            {
                beca.alu_ID = alu_ID;

                if (bec_SuspenciosEstudiosSII.Selected == true)
                {
                    beca.bec_SuspenciosEstudios = true;
                }
                else
                    beca.bec_SuspenciosEstudios = false;

                if (bec_BecadoAntesSII.Selected == true)
                {
                    beca.bec_BecadoAntes = true;
                }
                else
                    beca.bec_BecadoAntes = false;

                if (bec_EstatusOportunidadesSII.Selected == true)
                {
                    beca.bec_EstatusOportunidades = true;
                }
                else
                    beca.bec_EstatusOportunidades = false;

                if (bec_EstatusCONAFESII.Selected == true)
                {
                    beca.bec_EstatusBecado = true;
                }
                else
                    beca.bec_EstatusBecado = false;

                beca.bec_Peso = alu_Peso.Text;
                beca.bec_Estatura = alu_Estatura.Text;

                altura = Convert.ToDouble(alu_Estatura.Text);
                peso = Convert.ToDouble(alu_Peso.Text);

                IMC = peso / (altura * altura);
                beca.bec_IMC = IMC.ToString();
            }
            catch (Exception)
            {

            }
            return beca;
        }

        protected void btnAE_Click(object sender, EventArgs e)
        {
            try
            {

                if (btnAE.Text == "GUARDAR")
                {
                    ante.Insert(ObtenerDatos(), alu_ID);
                    ingr.Insert(ObtenerFamiliares(), alu_ID);
                    viv.Insert(ObtenerVivienda(), alu_ID);
                    beca.Insert(ObtenerBecas(), alu_ID);
                    enc.Insert(5, alu_ID);

                    Response.Redirect("DatosPersonales1.aspx");
                }
                else if (btnAE.Text == "ACTUALIZAR")
                {
                    ante.UpdateLaboralesAlu(ObtenerDatos(), alu_ID);
                    ingr.Update(ObtenerFamiliares(), alu_ID);
                    viv.Update(ObtenerVivienda(), alu_ID);
                    beca.Update(ObtenerBecas(), alu_ID);

                }





            }
            catch (Exception)
            {


            }
        }

        public void Mensaje(string Mensaje, string css)
        {
            Label20.Visible = true;
            Label20.CssClass = css;
            Label20.Text = Mensaje;
        }
    }
}