using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; 
using System.Data;
namespace GEMTQ_Arch
{
    class selectdata
    { 
        public DataTable GET_data(int ID)
        {
            DataACCESSlayer DAL = new DataACCESSlayer();
            DataTable Dt = new DataTable();
            SqlParameter[] PARAM = new SqlParameter[1];
            PARAM[0] = new SqlParameter("@id", SqlDbType.Int);
            PARAM[0].Value = ID;
            Dt = DAL.selectData("selectdata", PARAM);
            DAL.CLOSE();
            return Dt;
        }
    }

}
