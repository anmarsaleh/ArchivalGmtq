using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace GEMTQ_Arch
{ 
    class DataACCESSlayer
    {
        SqlConnection sqlconnection; 
        public DataACCESSlayer()
        {
            sqlconnection = new SqlConnection(Properties.Settings.Default.MyCnn);
        }
         
        public void open()
        {
            if (sqlconnection.State != ConnectionState.Open)
            {
                sqlconnection.Open();
            }
        }
        public void CLOSE()
        {
            if (sqlconnection.State == ConnectionState.Open)
            {
                sqlconnection.Close();
            }
        }
        public DataTable selectData(string stored_procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();    
            sqlcmd.CommandType = CommandType.StoredProcedure;   
            sqlcmd.CommandText = stored_procedure; 
            sqlcmd.Connection = sqlconnection;
            if(param!=null) 
            {
                for (int i = 0; i < param.Length; i++) 
                {
                    sqlcmd.Parameters.Add(param[i]);
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);  
            DataTable Dt = new DataTable(); 
            da.Fill(Dt); 
            return Dt;
        }
        public void Executecommand(string stored_procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlconnection;

            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param); 
            }
            sqlcmd.ExecuteNonQuery();
        }

    }


  



     
}














