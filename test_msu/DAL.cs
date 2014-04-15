using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace test_msu
{
    class DAL
    {

        public DataSet GET_STATES_Craiglistcars(string procName)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();
            SqlDataAdapter das = new SqlDataAdapter();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DBCars"].ConnectionString;
            SqlCommand cmd = new SqlCommand(procName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            das.SelectCommand = cmd;
            das.Fill(ds);
            return ds;
        }

        public void SaveTransaction_Cars(string StateId, string StartStatus, string EndStatus,string procName)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBCars"].ConnectionString;
                SqlCommand cmd = new SqlCommand(procName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Add(new SqlParameter("@stateid", StateId));
                cmd.Parameters.Add(new SqlParameter("@StartStatus", StartStatus));
                cmd.Parameters.Add(new SqlParameter("@EndStatus  ", EndStatus));
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveLeadsData(string PostingId,string CarId,string Title,string PhoneNo,string Price,string Url,string sellername,
            string State_Name,string City,string Address,string Zip,string Mileage,string State_ID,
            string Description,string Model,string Extcolor,string Doors,
            string Engine,string Trans,string Fuel,string Drive,string CusEmailId)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBCars"].ToString();
                string sysName = System.Environment.MachineName;
                SqlCommand cmd = new SqlCommand("USP_SAVE_LEADSDATA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Add(new SqlParameter("@PostingId", PostingId));
                cmd.Parameters.Add(new SqlParameter("@CarId", CarId));
                cmd.Parameters.Add(new SqlParameter("@Title", Title));
                cmd.Parameters.Add(new SqlParameter("@PhoneNo", PhoneNo));
                cmd.Parameters.Add(new SqlParameter("@Price", Price));
                cmd.Parameters.Add(new SqlParameter("@Url", Url));
                cmd.Parameters.Add(new SqlParameter("@sellername", sellername));
                cmd.Parameters.Add(new SqlParameter("@State_Name", State_Name));
                cmd.Parameters.Add(new SqlParameter("@City", City));
                cmd.Parameters.Add(new SqlParameter("@Address", Address));
                cmd.Parameters.Add(new SqlParameter("@Zip", Zip));
                cmd.Parameters.Add(new SqlParameter("@Mileage", Mileage));
                cmd.Parameters.Add(new SqlParameter("@State_ID", State_ID));
                cmd.Parameters.Add(new SqlParameter("@Description", Description));
                cmd.Parameters.Add(new SqlParameter("@Model", Model));
                cmd.Parameters.Add(new SqlParameter("@Extcolor", Extcolor));
                cmd.Parameters.Add(new SqlParameter("@Doors", Doors));
                cmd.Parameters.Add(new SqlParameter("@Engine", Engine));
                cmd.Parameters.Add(new SqlParameter("@Trans", Trans));
                cmd.Parameters.Add(new SqlParameter("@Fuel", Fuel));
                cmd.Parameters.Add(new SqlParameter("@Drive", Drive));
                cmd.Parameters.Add(new SqlParameter("@CusEmailId", CusEmailId));
                cmd.Parameters.Add(new SqlParameter("@sysname", sysName));
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }

        public void del_history(string query)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DBCars"].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }

        #region old procs
        //public void SaveGlobal(string title, string price, string phno, string location, string desc, string name, int state, string url)
        //{
        //    try
        //    {
        //        SqlConnection con = new SqlConnection("Data Source=HUGO999-PC;Initial Catalog=carleads1;Integrated Security=True");
        //        string sysName = System.Environment.MachineName;
        //        SqlCommand cmd = new SqlCommand("Usp_Save_Leads_Global", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        con.Open();
        //        //title,desc,location,place,name,phno,price,url
        //        cmd.Parameters.Add(new SqlParameter("@title", title));
        //        cmd.Parameters.Add(new SqlParameter("@location", location));
        //        cmd.Parameters.Add(new SqlParameter("@price", price));
        //        cmd.Parameters.Add(new SqlParameter("@phno", phno));
        //        cmd.Parameters.Add(new SqlParameter("@url", url));
        //        cmd.Parameters.Add(new SqlParameter("@desc", desc));
        //        cmd.Parameters.Add(new SqlParameter("@state", state));
        //        cmd.Parameters.Add(new SqlParameter("@name", name));
        //        cmd.Parameters.Add(new SqlParameter("@sysname", System.Environment.MachineName));
        //        cmd.ExecuteNonQuery();
        //        con.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        //throw ex;
        //    }
        //}


        //public void SaveoodleData(string title, string sname, string phno, string price, string state, string city, string desc, string url)
        //{
        //    try
        //    {
        //        SqlConnection con = new SqlConnection("Data Source=HUGO999-PC;Initial Catalog=carleads1;Integrated Security=True");
        //        string sysName = System.Environment.MachineName;
        //        SqlCommand cmd = new SqlCommand("Usp_Save_Leads_Oodle", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        con.Open();
        //        //title,desc,location,place,name,phno,price,url
        //        cmd.Parameters.Add(new SqlParameter("@title", title));
        //        cmd.Parameters.Add(new SqlParameter("@state", state));
        //        cmd.Parameters.Add(new SqlParameter("@city", city));
        //        cmd.Parameters.Add(new SqlParameter("@price", price));
        //        cmd.Parameters.Add(new SqlParameter("@phno", phno));
        //        cmd.Parameters.Add(new SqlParameter("@url", url));
        //        cmd.Parameters.Add(new SqlParameter("@desc", desc));
        //        cmd.Parameters.Add(new SqlParameter("@name", sname));
        //        cmd.Parameters.Add(new SqlParameter("@sysname", System.Environment.MachineName));
        //        cmd.ExecuteNonQuery();
        //        con.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        //throw ex;
        //    }
        //}


        //public void SaveebayData(string title, string sname, string phno, string price, string location, string desc, string url, string state)
        //{
        //    try
        //    {
        //        SqlConnection con = new SqlConnection("Data Source=HUGO999-PC;Initial Catalog=carleads1;Integrated Security=True");
        //        string sysName = System.Environment.MachineName;
        //        SqlCommand cmd = new SqlCommand("Usp_Save_Leads_EBay", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        con.Open();
        //        //title,desc,location,place,name,phno,price,url
        //        cmd.Parameters.Add(new SqlParameter("@title", title));
        //        cmd.Parameters.Add(new SqlParameter("@location", location));
        //        cmd.Parameters.Add(new SqlParameter("@price", price));
        //        cmd.Parameters.Add(new SqlParameter("@phno", phno));
        //        cmd.Parameters.Add(new SqlParameter("@url", url));
        //        cmd.Parameters.Add(new SqlParameter("@desc", desc));
        //        cmd.Parameters.Add(new SqlParameter("@name", sname));
        //        cmd.Parameters.Add(new SqlParameter("@state", state));
        //        cmd.Parameters.Add(new SqlParameter("@sysname", System.Environment.MachineName));
        //        cmd.ExecuteNonQuery();
        //        con.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        //throw ex;
        //    }
        //}


        //public void SaveBackPageLeads(string title, string price, string phno, string state, string url)
        //{
        //    try
        //    {
        //        SqlConnection con = new SqlConnection("Data Source=HUGO999-PC;Initial Catalog=carleads1;Integrated Security=True");
        //        string sysName = System.Environment.MachineName;
        //        SqlCommand cmd = new SqlCommand("Usp_Save_Leads_BackPage", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        con.Open();
        //        //title,desc,location,place,name,phno,price,url
        //        cmd.Parameters.Add(new SqlParameter("@title", title));
        //        cmd.Parameters.Add(new SqlParameter("@price", price));
        //        cmd.Parameters.Add(new SqlParameter("@phno", phno));
        //        cmd.Parameters.Add(new SqlParameter("@url", url));
        //        cmd.Parameters.Add(new SqlParameter("@state", state));
        //        cmd.Parameters.Add(new SqlParameter("@sysname", System.Environment.MachineName));
        //        cmd.ExecuteNonQuery();
        //        con.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        //throw ex;
        //    }
        //}


        //public void saveClazLeads(string title, string price, string city, string phno, string url, string desc)
        //{
        //    try
        //    {
        //        SqlConnection con = new SqlConnection("Data Source=HUGO999-PC;Initial Catalog=carleads1;Integrated Security=True");
        //        string sysName = System.Environment.MachineName;
        //        SqlCommand cmd = new SqlCommand("Usp_Save_Leads_Claz", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        con.Open();
        //        cmd.Parameters.Add(new SqlParameter("@title", title));
        //        cmd.Parameters.Add(new SqlParameter("@price", price));
        //        cmd.Parameters.Add(new SqlParameter("@phno", phno));
        //        cmd.Parameters.Add(new SqlParameter("@url", url));
        //        cmd.Parameters.Add(new SqlParameter("@city", city));
        //        //cmd.Parameters.Add(new SqlParameter("@desc", desc));
        //        cmd.Parameters.Add(new SqlParameter("@sysname", System.Environment.MachineName));
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        //throw ex;
        //    }
        //}


        //public void SaveLocanto_Leads(string title, string desc, string state, string city, string price, string phno, string url)
        //{
        //    try
        //    {
        //        SqlConnection con = new SqlConnection("Data Source=HUGO999-PC;Initial Catalog=carleads1;Integrated Security=True");
        //        string sysName = System.Environment.MachineName;
        //        SqlCommand cmd = new SqlCommand("Usp_Save_Leads_Locanto", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        con.Open();
        //        //title,desc,location,place,name,phno,price,url
        //        cmd.Parameters.Add(new SqlParameter("@title", title));
        //        cmd.Parameters.Add(new SqlParameter("@state", state));
        //        cmd.Parameters.Add(new SqlParameter("@city", city));
        //        cmd.Parameters.Add(new SqlParameter("@price", price));
        //        cmd.Parameters.Add(new SqlParameter("@phno", phno));
        //        cmd.Parameters.Add(new SqlParameter("@url", url));
        //        cmd.Parameters.Add(new SqlParameter("@desc", desc));
        //        cmd.Parameters.Add(new SqlParameter("@sysname", System.Environment.MachineName));
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        //throw ex;
        //    }
        //}

        #endregion

        public void SaveGlobal(string title, string price, string phno, string location, string desc, string name, int a, string url)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBCars"].ToString();
                string sysName = System.Environment.MachineName;
                SqlCommand cmd = new SqlCommand("Usp_Save_Leads_Global", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Add(new SqlParameter("@title", title));
                cmd.Parameters.Add(new SqlParameter("@price", price));
                cmd.Parameters.Add(new SqlParameter("@phno", phno));
                cmd.Parameters.Add(new SqlParameter("@location", location));
                cmd.Parameters.Add(new SqlParameter("@desc", desc));
                cmd.Parameters.Add(new SqlParameter("@name", name));
                cmd.Parameters.Add(new SqlParameter("@state", a));
                cmd.Parameters.Add(new SqlParameter("@url", url));
                cmd.Parameters.Add(new SqlParameter("@sysname", sysName));
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }

        public DataSet Get_Categories(string procName)
        {
         
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DBCars"].ConnectionString;
            SqlDataAdapter das = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(procName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            das.SelectCommand = cmd;
            das.Fill(ds);
            return ds;
       
        }
    }
}
