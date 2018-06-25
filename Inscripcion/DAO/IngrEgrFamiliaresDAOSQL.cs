using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Conect.Utileria;

public class IngrEgrFamiliaresDAOSQL : ADAOSocioEconomico<IngrEgrFamiliaresDTO>
{
    UConexion c;

    public SqlCommand command;

    public SqlConnection con;

    public string qwery;

    public IngrEgrFamiliaresDAOSQL()
    {
        c = new UConexion();
    }

    public void Insert(IngrEgrFamiliaresDTO obj, int id)
    {
        int x = 0;
        try
        {
            con = new SqlConnection();
            con = c.Conexion();
            using (con)
            {
                qwery = "INSERT IngrEgrFamiliares (ief_Padre,ief_Madre,ief_Usted,ief_Hermanos,ief_Conyuge,ief_Otros,ief_Total,ief_Renta,ief_Alimentacion,";
                qwery += "ief_Vestido,ief_Transporte,ief_Colegiatura,ief_Agua,ief_Electricidad,ief_GasCombustible,ief_TotalEgresos,alu_ID,ief_Telefono,ief_OtrosE,ief_IngrPer)";
                qwery += "VALUES(@ief_Padre,@ief_Madre,@ief_Usted,@ief_Hermanos,@ief_Conyuge,@ief_Otros,@ief_Total,@ief_Renta,@ief_Alimentacion,";
                qwery += "@ief_Vestido,@ief_Transporte,@ief_Colegiatura,@ief_Agua,@ief_Electricidad,@ief_GasCombustible,@ief_TotalEgresos,";
                qwery += "@alu_ID,@ief_Telefono,@ief_OtrosE,@ief_IngrPer)";
                command = new SqlCommand(qwery, con);
                command.Parameters.Add("@ief_Padre", SqlDbType.Money).Value = obj.ief_Padre;
                command.Parameters.Add("@ief_Madre", SqlDbType.Money).Value = obj.ief_Madre;
                command.Parameters.Add("@ief_Usted", SqlDbType.Money).Value = obj.ief_Usted;
                command.Parameters.Add("@ief_Hermanos", SqlDbType.Money).Value = obj.ief_Hermanos;
                command.Parameters.Add("@ief_Conyuge", SqlDbType.Money).Value = obj.ief_Conyugue;
                command.Parameters.Add("@ief_Otros", SqlDbType.Money).Value = obj.ief_Otros;
                command.Parameters.Add("@ief_Total", SqlDbType.Money).Value = obj.ief_Total;
                command.Parameters.Add("@ief_Renta", SqlDbType.Money).Value = obj.ief_Renta;
                command.Parameters.Add("@ief_Alimentacion", SqlDbType.Money).Value = obj.ief_Alimentacion;
                command.Parameters.Add("@ief_Vestido", SqlDbType.Money).Value = obj.ief_Vestido;
                command.Parameters.Add("@ief_Transporte", SqlDbType.Money).Value = obj.ief_Transporte;
                command.Parameters.Add("@ief_Colegiatura", SqlDbType.Money).Value = obj.ief_Colegiaura;
                command.Parameters.Add("@ief_Agua", SqlDbType.Money).Value = obj.ief_Agua;
                command.Parameters.Add("@ief_Electricidad", SqlDbType.Money).Value = obj.ief_Electricidad;
                command.Parameters.Add("@ief_GasCombustible", SqlDbType.Money).Value = obj.ief_GasCombustible;
                command.Parameters.Add("@ief_TotalEgresos", SqlDbType.Money).Value = obj.ief_TotalEgresos;
                command.Parameters.Add("@alu_ID", SqlDbType.Int).Value = obj.alu_ID;
                command.Parameters.Add("@ief_OtrosE", SqlDbType.Money).Value = obj.ief_OtrosE;
                command.Parameters.Add("@ief_Telefono", SqlDbType.Money).Value = obj.ief_Telefono;
                command.Parameters.Add("@ief_IngrPer", SqlDbType.VarChar).Value = obj.ief_IngrPerc;
                x = command.ExecuteNonQuery();
                con.Close();
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    public void Update(IngrEgrFamiliaresDTO obj, int id)
    {
        int x = 0;
        try
        {
            con = new SqlConnection();
            con = c.Conexion();
            using (con)
            {
                qwery = "UPDATE IngrEgrFamiliares set ief_Padre=@ief_Padre,ief_Madre=@ief_Madre,ief_Usted=@ief_Usted,";
                qwery += "ief_Hermanos =@ief_Hermanos,ief_Conyuge=@ief_Conyuge,ief_Otros=@ief_Otros,ief_Total=@ief_Total,";
                qwery += "ief_Renta =@ief_Renta,ief_Alimentacion=@ief_Alimentacion,ief_Vestido=@ief_Vestido,";
                qwery += "ief_Transporte =@ief_Transporte,ief_Colegiatura=@ief_Colegiatura,ief_Agua=@ief_Agua,";
                qwery += "ief_Electricidad =@ief_Electricidad,ief_GasCombustible=@ief_GasCombustible,ief_Telefono=@ief_Telefono,";
                qwery += "ief_TotalEgresos =@ief_TotalEgresos,ief_OtrosE=@ief_OtrosE, ief_IngrPer=@ief_IngrPer where alu_ID=@alu_ID";
                command = new SqlCommand(qwery, con);
                command.Parameters.Add("@ief_Padre", SqlDbType.Money).Value = obj.ief_Padre;
                command.Parameters.Add("@ief_Madre", SqlDbType.Money).Value = obj.ief_Madre;
                command.Parameters.Add("@ief_Usted", SqlDbType.Money).Value = obj.ief_Usted;
                command.Parameters.Add("@ief_Hermanos", SqlDbType.Money).Value = obj.ief_Hermanos;
                command.Parameters.Add("@ief_Conyuge", SqlDbType.Money).Value = obj.ief_Conyugue;
                command.Parameters.Add("@ief_Otros", SqlDbType.Money).Value = obj.ief_Otros;
                command.Parameters.Add("@ief_Total", SqlDbType.Money).Value = obj.ief_Total;
                command.Parameters.Add("@ief_Renta", SqlDbType.Money).Value = obj.ief_Renta;
                command.Parameters.Add("@ief_Alimentacion", SqlDbType.Money).Value = obj.ief_Alimentacion;
                command.Parameters.Add("@ief_Vestido", SqlDbType.Money).Value = obj.ief_Vestido;
                command.Parameters.Add("@ief_Transporte", SqlDbType.Money).Value = obj.ief_Transporte;
                command.Parameters.Add("@ief_Colegiatura", SqlDbType.Money).Value = obj.ief_Colegiaura;
                command.Parameters.Add("@ief_Agua", SqlDbType.Money).Value = obj.ief_Agua;
                command.Parameters.Add("@ief_Electricidad", SqlDbType.Money).Value = obj.ief_Electricidad;
                command.Parameters.Add("@ief_GasCombustible", SqlDbType.Money).Value = obj.ief_GasCombustible;
                command.Parameters.Add("@ief_Telefono", SqlDbType.Money).Value = obj.ief_Telefono;
                command.Parameters.Add("@ief_TotalEgresos", SqlDbType.Money).Value = obj.ief_TotalEgresos;
                command.Parameters.Add("@ief_OtrosE", SqlDbType.Money).Value = obj.ief_OtrosE;
                command.Parameters.Add("@alu_ID", SqlDbType.Int).Value = obj.alu_ID;
                command.Parameters.Add("@ief_IngrPer", SqlDbType.VarChar).Value = obj.ief_IngrPerc;
                x = command.ExecuteNonQuery();
                con.Close();
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    public bool SelectExiste(IngrEgrFamiliaresDTO obj)
    {
        bool result = false;
        try
        {
            con = new SqlConnection();
            con = c.Conexion();
            using (con)
            {
                qwery = "SELECT CAST(COUNT(1) AS BIT) FROM [IngrEgrFamiliares] WHERE (alu_ID = @alu_ID)";
                command = new SqlCommand(qwery, con);
                command.Parameters.Add("@alu_ID", SqlDbType.Int).Value = obj.alu_ID;
                result = Convert.ToBoolean(command.ExecuteScalar());
                con.Close();
            }
        }
        catch (Exception)
        {

            throw;
        }
        return result;
    }
    public bool SelectExiste(int id)
    {
        bool result = false;
        try
        {
            con = new SqlConnection();
            con = c.Conexion();
            using (con)
            {
                qwery = "SELECT CAST(COUNT(1) AS BIT) FROM [IngrEgrFamiliares] WHERE (alu_ID = @alu_ID)";
                command = new SqlCommand(qwery, con);
                command.Parameters.Add("@alu_ID", SqlDbType.Int).Value = id;
                result = Convert.ToBoolean(command.ExecuteScalar());
                con.Close();
            }
        }
        catch (Exception)
        {

            throw;
        }
        return result;
    }
    public DataTable GetTabla(int id)
    {
        DataTable dt = new DataTable();
        try
        {
            con = new SqlConnection();
            con = c.Conexion();
            using (con)
            {
                string query = "SELECT * FROM IngrEgrFamiliares where alu_ID = @alu_ID";
                command = new SqlCommand(query, con);
                command.Parameters.Add("@alu_ID", SqlDbType.Int).Value = id;
                dt.Load(command.ExecuteReader());
            }
        }
        catch (Exception)
        {
            throw;
        }
        return dt;
    }

    public void Insert(IngrEgrFamiliaresDTO obj)
    {
        throw new NotImplementedException();
    }

    public void Update(IngrEgrFamiliaresDTO obj)
    {
        throw new NotImplementedException();
    }
}