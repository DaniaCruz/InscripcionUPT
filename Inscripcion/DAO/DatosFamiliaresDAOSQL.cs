using Conect.DTO;
using Conect.Utileria;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Conect.DAO
{
    public class DatosFamiliaresDAOSQL : IAdaoFicha<DatosFamiliaresDTO>
    {
        public SqlCommand comando { set; get; }
        public UConexion conexion { set; get; }
        public string instruccion { set; get; }
        SqlConnection con;

        public void Insert(DatosFamiliaresDTO obj, int id)
        {
            conexion = new UConexion();
            using (conexion.Conexion())
            {

                instruccion = "INSERT DatosFamiliares(daf_Nombre,daf_Edad,daf_Escolaridad,alu_ID,daf_Parentezco,alc_OcupaFam,alc_NoHijos) VALUES(@daf_Nombre,@daf_Edad,@daf_Escolaridad,@alu_ID,@daf_Parentezco,@alc_OcupaFam,@alc_NoHijos)";
                comando = new SqlCommand(instruccion,conexion.Conexion());
                comando.Parameters.Add("@daf_Nombre", SqlDbType.VarChar).Value = obj.daf_Nombre.ToUpper();
                comando.Parameters.Add("@daf_Edad", SqlDbType.Int).Value = obj.daf_Edad;
                comando.Parameters.Add("@daf_Escolaridad", SqlDbType.VarChar).Value = obj.daf_Escolaridad.ToUpper();      
                comando.Parameters.Add("@alu_ID", SqlDbType.Int).Value = id;
                comando.Parameters.Add("@daf_Parentezco", SqlDbType.VarChar).Value = obj.daf_Parentezco.ToUpper();
                comando.Parameters.Add("@alc_OcupaFam", SqlDbType.VarChar).Value = obj.daf_Ocupacion.ToUpper();
                comando.Parameters.Add("@alc_NoHijos", SqlDbType.Int).Value = obj.daf_NoHijos;
                int x = 0;
                x = comando.ExecuteNonQuery();
                conexion.Conexion().Close();
            }

        }
        public void Update(DatosFamiliaresDTO obj, int id)
        {
            conexion = new UConexion();
            using (conexion.Conexion())
            {
                instruccion = "UPDATE DatosFamiliares SET daf_Nombre=@daf_Nombre,daf_Edad=@daf_Edad,daf_Parentezco=@daf_Parentezco";
                instruccion += ",daf_Escolaridad=@daf_Escolaridad,daf_EdoCivil=@daf_EdoCivil,ocu_ID=@ocu_ID WHERE alu_ID=@alu_ID and daf_NoFamiliar=@NoFamiliar";
                comando = new SqlCommand(instruccion, conexion.Conexion());

                comando.Parameters.Add("@daf_Nombre", SqlDbType.VarChar).Value = obj.daf_Nombre.ToUpper();
                comando.Parameters.Add("@daf_Edad", SqlDbType.Int).Value = obj.daf_Edad;
                comando.Parameters.Add("@daf_Parentezco", SqlDbType.VarChar).Value = obj.daf_Parentezco.ToUpper();
                comando.Parameters.Add("@daf_Escolaridad", SqlDbType.VarChar).Value = obj.daf_Escolaridad.ToUpper();
                comando.Parameters.Add("@daf_EdoCivil", SqlDbType.VarChar).Value = obj.daf_EdoCivil.ToUpper();
                comando.Parameters.Add("@alc_OcupaFam", SqlDbType.VarChar).Value = obj.daf_Ocupacion.ToUpper();
                comando.Parameters.Add("@alu_ID", SqlDbType.Int).Value = id;
                comando.Parameters.Add("@daf_NoFamiliar", SqlDbType.Int).Value = id;
                comando.ExecuteNonQuery();
            }
        }
        public void Delete(int id)
        {
            try
            {
                int r = 0;
                conexion = new UConexion();
                con = conexion.Conexion();
                using (con)
                {
                    string query = "DELETE FROM DatosFamiliares where alu_ID = @alu_ID";
                    comando = new SqlCommand(query, con);
                    comando.Parameters.Add("@alu_ID", SqlDbType.Int).Value = id;
                    r = comando.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
        public void DeleteVacios(int id)
        {
            try
            {
                int r = 0;
                conexion = new UConexion();
                con = conexion.Conexion();
                using (con)
                {
                    string query = "DELETE FROM DatosFamiliares where alu_ID = @alu_ID and daf_Nombre=''";
                    comando = new SqlCommand(query, con);
                    comando.Parameters.Add("@alu_ID", SqlDbType.Int).Value = id;
                    r = comando.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable GetTabla(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                conexion = new UConexion();
                con = conexion.Conexion();
                using (con)
                {
                    string query = "SELECT * FROM DatosFamiliares where alu_ID = @alu_ID";
                    comando = new SqlCommand(query, con);
                    comando.Parameters.Add("@alu_ID", SqlDbType.Int).Value = id;
                    dt.Load(comando.ExecuteReader());
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }
    }
}