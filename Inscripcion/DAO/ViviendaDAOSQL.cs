using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Conect.Utileria;

public class ViviendaDAOSQL : ADAOSocioEconomico<ViviendaDTO>
{
    UConexion c;
    public SqlCommand command;

    public SqlConnection con;

    public string qwery;
    public ViviendaDAOSQL()
    {
        c = new UConexion();
    }

    public void Insert(ViviendaDTO obj, int id)
    {
        int x = 0;
        try
        {
            con = new SqlConnection();
            con = c.Conexion();
            using (con)
            {
                qwery = "INSERT INTO Vivienda (viv_MaterialTecho,viv_MaterialParedes,viv_MaterialPiso,viv_CocinaIndependiente,viv_NoCuartos,viv_NoDormitorios,";
                qwery += "viv_TipoVivienda,alu_ID,viv_Lavadora,viv_Cisterna,viv_Refrigerador,viv_Drenaje,viv_Compu,viv_AcceInter,viv_Auto,viv_Moto,viv_Horno,";
                qwery += "viv_Electrodomes,viv_Regadera,viv_MedLuz,viv_Dvd,viv_Radio,viv_TV,viv_MedioTransporte,viv_TiempoTraslado,viv_Luz,viv_AguaPotable,";
                qwery += "viv_EstufaDeGas,viv_TinacoAgua,viv_Gas,viv_Television,viv_Telefono,viv_GastoPasaje) values (@viv_MaterialTecho,";
                qwery += "@viv_MaterialParedes,@viv_MaterialPiso,@viv_CocinaIndependiente,@viv_NoCuartos,@viv_NoDormitorios,@viv_TipoVivienda,@alu_ID,";
                qwery += "@viv_Lavadora,@viv_Cisterna,@viv_Refrigerador,@viv_Drenaje,@viv_Compu,@viv_AcceInter,@viv_Auto,@viv_Moto,@viv_Horno,@viv_Electrodomes,";
                qwery += "@viv_Regadera,@viv_MedLuz,@viv_Dvd,@viv_Radio,@viv_TV,@viv_MedioTransporte,@viv_TiempoTraslado,@viv_Luz,@viv_AguaPotable,";
                qwery += "@viv_EstufaDeGas,@viv_TinacoAgua,@viv_Gas,@viv_Television,@viv_Telefono,@viv_GastoPasaje)";


                command = new SqlCommand(qwery, con);
                command.Parameters.Add("@viv_MaterialTecho", SqlDbType.VarChar).Value = obj.viv_MaterialTecho.ToUpper();
                command.Parameters.Add("@viv_MaterialParedes", SqlDbType.VarChar).Value = obj.viv_MaterialParedes.ToUpper();
                command.Parameters.Add("@viv_MaterialPiso", SqlDbType.VarChar).Value = obj.viv_MaterialPiso.ToUpper();
                command.Parameters.Add("@viv_CocinaIndependiente", SqlDbType.VarChar).Value = obj.viv_CocinaIndependiente.ToUpper();
                command.Parameters.Add("@viv_NoCuartos", SqlDbType.Int).Value = obj.viv_NoCuartos;
                command.Parameters.Add("@viv_NoDormitorios", SqlDbType.Int).Value = obj.viv_NoDormitorios;
                command.Parameters.Add("@viv_TipoVivienda", SqlDbType.VarChar).Value = obj.viv_TipoVivienda.ToUpper();
                command.Parameters.Add("@alu_ID", SqlDbType.Int).Value = obj.alu_ID;
                command.Parameters.Add("@viv_Lavadora", SqlDbType.Bit).Value = obj.viv_Lavadora;
                command.Parameters.Add("@viv_Cisterna", SqlDbType.Bit).Value = obj.viv_Cisterna;
                command.Parameters.Add("@viv_Refrigerador", SqlDbType.Bit).Value = obj.viv_Refrigerador;
                command.Parameters.Add("@viv_Drenaje", SqlDbType.Bit).Value = obj.viv_Drenaje;
                command.Parameters.Add("@viv_Compu", SqlDbType.Bit).Value = obj.viv_Compu;
                command.Parameters.Add("@viv_AcceInter", SqlDbType.Bit).Value = obj.viv_AcceInter;
                command.Parameters.Add("@viv_Auto", SqlDbType.Bit).Value = obj.viv_Auto;
                command.Parameters.Add("@viv_Moto", SqlDbType.Bit).Value = obj.viv_Moto;
                command.Parameters.Add("@viv_Horno", SqlDbType.Bit).Value = obj.viv_Horno;
                command.Parameters.Add("@viv_Electrodomes", SqlDbType.Bit).Value = obj.viv_Electrodomes;
                command.Parameters.Add("@viv_Regadera", SqlDbType.Bit).Value = obj.viv_Regadera;
                command.Parameters.Add("@viv_MedLuz", SqlDbType.Bit).Value = obj.viv_MedLuz;
                command.Parameters.Add("@viv_Dvd", SqlDbType.Bit).Value = obj.viv_Dvd;
                command.Parameters.Add("@viv_Radio", SqlDbType.Bit).Value = obj.viv_Radio;
                command.Parameters.Add("@viv_TV", SqlDbType.Bit).Value = obj.viv_TV;
                command.Parameters.Add("@viv_MedioTransporte", SqlDbType.VarChar).Value = obj.viv_MedioTransporte.ToUpper();
                command.Parameters.Add("@viv_TiempoTraslado", SqlDbType.VarChar).Value = obj.viv_TiempoTraslado.ToUpper();
                command.Parameters.Add("@viv_Luz", SqlDbType.Bit).Value = obj.viv_Luz;
                command.Parameters.Add("@viv_AguaPotable", SqlDbType.Bit).Value = obj.viv_AguaPotable;
                command.Parameters.Add("@viv_EstufaDeGas", SqlDbType.Bit).Value = obj.viv_EstufaDeGas;
                command.Parameters.Add("@viv_TinacoAgua", SqlDbType.Bit).Value = obj.viv_TinacoAgua;
                command.Parameters.Add("@viv_Gas", SqlDbType.Bit).Value = obj.viv_Gas;
                command.Parameters.Add("@viv_Television", SqlDbType.Bit).Value = obj.viv_Television;
                command.Parameters.Add("@viv_Telefono", SqlDbType.Bit).Value = obj.viv_Telefono;
                command.Parameters.Add("@viv_GastoPasaje", SqlDbType.Money).Value = obj.viv_GastoPasaje;
                x = command.ExecuteNonQuery();
                con.Close();
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    public void Update(ViviendaDTO obj, int id)
    {
        int x = 0;
        try
        {
            con = new SqlConnection();
            con = c.Conexion();
            using (con)
            {
                qwery = "update Vivienda set viv_MaterialTecho=@viv_MaterialTecho,viv_MaterialParedes=@viv_MaterialParedes,viv_MaterialPiso=@viv_MaterialPiso,viv_CocinaIndependiente=@viv_CocinaIndependiente,viv_NoCuartos=@viv_NoCuartos,";
                qwery += "viv_NoDormitorios=@viv_NoDormitorios,viv_TipoVivienda=@viv_TipoVivienda,viv_Lavadora=@viv_Lavadora,viv_Cisterna=@viv_Cisterna,viv_Refrigerador=@viv_Refrigerador,viv_Drenaje=@viv_Drenaje,";
                qwery += "viv_Compu=@viv_Compu,viv_AcceInter=@viv_AcceInter,viv_Auto=@viv_Auto,viv_Moto=@viv_Moto,viv_Horno=@viv_Horno,viv_Electrodomes=@viv_Electrodomes,viv_Regadera=@viv_Regadera,viv_MedLuz=@viv_MedLuz,viv_Dvd=@viv_Dvd,viv_Radio=@viv_Radio,viv_TV=@viv_TV,";
                qwery += "viv_MedioTransporte=@viv_MedioTransporte,viv_TiempoTraslado=@viv_TiempoTraslado,viv_Luz=@viv_Luz,viv_AguaPotable=@viv_AguaPotable,viv_EstufaDeGas=@viv_EstufaDeGas,viv_TinacoAgua=@viv_TinacoAgua,viv_Gas=@viv_Gas,viv_Television=@viv_Television,viv_Telefono=@viv_Telefono,viv_GastoPasaje=@viv_GastoPasaje where alu_ID=@alu_ID";


                command = new SqlCommand(qwery, con);
                command.Parameters.Add("@viv_MaterialTecho", SqlDbType.VarChar).Value = obj.viv_MaterialTecho.ToUpper();
                command.Parameters.Add("@viv_MaterialParedes", SqlDbType.VarChar).Value = obj.viv_MaterialParedes.ToUpper();
                command.Parameters.Add("@viv_MaterialPiso", SqlDbType.VarChar).Value = obj.viv_MaterialPiso.ToUpper();
                command.Parameters.Add("@viv_CocinaIndependiente", SqlDbType.VarChar).Value = obj.viv_CocinaIndependiente.ToUpper();
                command.Parameters.Add("@viv_NoCuartos", SqlDbType.Int).Value = obj.viv_NoCuartos;
                command.Parameters.Add("@viv_NoDormitorios", SqlDbType.Int).Value = obj.viv_NoDormitorios;
                command.Parameters.Add("@viv_TipoVivienda", SqlDbType.VarChar).Value = obj.viv_TipoVivienda.ToUpper();
                command.Parameters.Add("@viv_Lavadora", SqlDbType.Bit).Value = obj.viv_Lavadora;
                command.Parameters.Add("@viv_Cisterna", SqlDbType.Bit).Value = obj.viv_Cisterna;
                command.Parameters.Add("@viv_Refrigerador", SqlDbType.Bit).Value = obj.viv_Refrigerador;
                command.Parameters.Add("@viv_Drenaje", SqlDbType.Bit).Value = obj.viv_Drenaje;
                command.Parameters.Add("@viv_Compu", SqlDbType.Bit).Value = obj.viv_Compu;
                command.Parameters.Add("@viv_AcceInter", SqlDbType.Bit).Value = obj.viv_AcceInter;
                command.Parameters.Add("@viv_Auto", SqlDbType.Bit).Value = obj.viv_Auto;
                command.Parameters.Add("@viv_Moto", SqlDbType.Bit).Value = obj.viv_Moto;
                command.Parameters.Add("@viv_Horno", SqlDbType.Bit).Value = obj.viv_Horno;
                command.Parameters.Add("@viv_Electrodomes", SqlDbType.Bit).Value = obj.viv_Electrodomes;
                command.Parameters.Add("@viv_Regadera", SqlDbType.Bit).Value = obj.viv_Regadera;
                command.Parameters.Add("@viv_MedLuz", SqlDbType.Bit).Value = obj.viv_MedLuz;
                command.Parameters.Add("@viv_Dvd", SqlDbType.Bit).Value = obj.viv_Dvd;
                command.Parameters.Add("@viv_Radio", SqlDbType.Bit).Value = obj.viv_Radio;
                command.Parameters.Add("@viv_TV", SqlDbType.Bit).Value = obj.viv_TV;
                command.Parameters.Add("@viv_MedioTransporte", SqlDbType.VarChar).Value = obj.viv_MedioTransporte.ToUpper();
                command.Parameters.Add("@viv_TiempoTraslado", SqlDbType.VarChar).Value = obj.viv_TiempoTraslado.ToUpper();
                command.Parameters.Add("@viv_Luz", SqlDbType.Bit).Value = obj.viv_Luz;
                command.Parameters.Add("@viv_AguaPotable", SqlDbType.Bit).Value = obj.viv_AguaPotable;
                command.Parameters.Add("@viv_EstufaDeGas", SqlDbType.Bit).Value = obj.viv_EstufaDeGas;
                command.Parameters.Add("@viv_TinacoAgua", SqlDbType.Bit).Value = obj.viv_TinacoAgua;
                command.Parameters.Add("@viv_Gas", SqlDbType.Bit).Value = obj.viv_Gas;
                command.Parameters.Add("@viv_Television", SqlDbType.Bit).Value = obj.viv_Television;
                command.Parameters.Add("@viv_Telefono", SqlDbType.Bit).Value = obj.viv_Telefono;
                command.Parameters.Add("@viv_GastoPasaje", SqlDbType.Money).Value = obj.viv_GastoPasaje;
                command.Parameters.Add("@alu_ID", SqlDbType.Int).Value = obj.alu_ID;
                x = command.ExecuteNonQuery();
                con.Close();
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    public bool SelectExiste(ViviendaDTO obj)
    {
        bool result = false;
        try
        {
            con = new SqlConnection();
            con = c.Conexion();
            using (con)
            {
                qwery = "SELECT CAST(COUNT(1) AS BIT) FROM [Vivienda] WHERE (alu_ID = @alu_ID)";
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
                qwery = "SELECT CAST(COUNT(1) AS BIT) FROM [Vivienda] WHERE (alu_ID = @alu_ID)";
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
                string query = "SELECT * FROM Vivienda where alu_ID = @alu_ID";
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

    public void Insert(ViviendaDTO obj)
    {
        throw new NotImplementedException();
    }

    public void Update(ViviendaDTO obj)
    {
        throw new NotImplementedException();
    }
}