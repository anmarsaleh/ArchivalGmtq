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
        public DataTable recivedata(int ID)
        {
            DataACCESSlayer DAL = new DataACCESSlayer();
            DataTable Dt = new DataTable();
            SqlParameter[] PARAM = new SqlParameter[1];
            PARAM[0] = new SqlParameter("@ID", SqlDbType.Int);
            PARAM[0].Value = ID;
            Dt = DAL.selectData("ReciveData", PARAM);
            DAL.CLOSE();
            return Dt;
        }
        public DataTable exeproc(int ID)
        {
            DataACCESSlayer DAL = new DataACCESSlayer();
            DataTable Dt = new DataTable();
            SqlParameter[] PARAM = new SqlParameter[1];
            PARAM[0] = new SqlParameter("@ID", SqlDbType.Int);
            PARAM[0].Value = ID;
            Dt = DAL.selectData("CreateFileg", PARAM);
            DAL.CLOSE();
            return Dt;
        }

        public DataTable transdata(int ID)
        {
            DataACCESSlayer DAL = new DataACCESSlayer();
            DataTable Dt = new DataTable();
            SqlParameter[] PARAM = new SqlParameter[1];
            PARAM[0] = new SqlParameter("@ID", SqlDbType.Int);
            PARAM[0].Value = ID;
            Dt = DAL.selectData("TransData", PARAM);
            DAL.CLOSE();
            return Dt;
        }

        public DataTable DetailTrans(int ID)
        {
            DataACCESSlayer DAL = new DataACCESSlayer();
            DataTable Dt = new DataTable();
            SqlParameter[] PARAM = new SqlParameter[1];
            PARAM[0] = new SqlParameter("@TID", SqlDbType.Int);
            PARAM[0].Value = ID;
            Dt = DAL.selectData("DetailTrans", PARAM);
            DAL.CLOSE();
            return Dt;
        }

        public DataTable GET_data(int ID, int num)
        {
            DataACCESSlayer DAL = new DataACCESSlayer();
            DataTable Dt = new DataTable();
            SqlParameter[] PARAM = new SqlParameter[2];
            PARAM[0] = new SqlParameter("@id", SqlDbType.Int);
            PARAM[0].Value = ID;
            PARAM[1] = new SqlParameter("@num", SqlDbType.Int);
            PARAM[1].Value = @num;
            Dt = DAL.selectData("selectdata", PARAM);
            DAL.CLOSE();
            return Dt;
        }
        public DataTable insertdata(int Docid,int KindID,string PublicN ,string InnerN,string DateOfDoc,int DistID ,int DepartID, string SubjectDoc,string DocName ,string fileex,string RemaindDate,int userid,string CreatedDate, byte[] DATAFILE ,int num)
        {
            DataACCESSlayer DAL = new DataACCESSlayer();
            DataTable Dt = new DataTable();
            SqlParameter[] PARAM = new SqlParameter[15];
            PARAM[0] = new SqlParameter("@Docid", SqlDbType.Int);
            PARAM[0].Value = Docid;
            PARAM[1] = new SqlParameter("@KindID", SqlDbType.Int);
            PARAM[1].Value = KindID;
            PARAM[2] = new SqlParameter("@PublicN",SqlDbType.NChar);
            PARAM[2].Value = PublicN;
            PARAM[3] = new SqlParameter("@InnerN", SqlDbType.NVarChar);
            PARAM[3].Value = InnerN;
            PARAM[4] = new SqlParameter("@DateOfDoc", SqlDbType.VarChar);
            PARAM[4].Value = DateOfDoc;
            PARAM[5] = new SqlParameter("@DistID", SqlDbType.Int);
            PARAM[5].Value = DistID;
            PARAM[6] = new SqlParameter("@DepartID", SqlDbType.Int);
            PARAM[6].Value = DepartID;
            PARAM[7] = new SqlParameter("@SubjectDoc", SqlDbType.NVarChar);
            PARAM[7].Value = SubjectDoc;
            PARAM[8] = new SqlParameter("@DocName", SqlDbType.NVarChar);
            PARAM[8].Value = DocName;
            PARAM[9] = new SqlParameter("@fileex", SqlDbType.NVarChar);
            PARAM[9].Value = fileex;
            PARAM[10] = new SqlParameter("@RemaindDate", SqlDbType.VarChar);
            PARAM[10].Value = RemaindDate;
            PARAM[11] = new SqlParameter("@userid", SqlDbType.Int);
            PARAM[11].Value = userid;
            PARAM[12] = new SqlParameter("@CreatedDate", SqlDbType.VarChar);
            PARAM[12].Value = CreatedDate;
            PARAM[13] = new SqlParameter("@DATAFILE", SqlDbType.VarBinary);
            PARAM[13].Value = DATAFILE;
            PARAM[14] = new SqlParameter("@num", SqlDbType.Int);
            PARAM[14].Value = num;
            Dt = DAL.selectData("insertdata", PARAM);
            DAL.CLOSE();
            return Dt;
        }

        public DataTable insertintodoc(int docid, int KindID, string PublicN, string InnerN, string DateOfDoc, int DistID, int DepartID, string SubjectDoc, string DocName, string fileex, string RemaindDate, int userid, string CreatedDate , int num)
        {
            DataACCESSlayer DAL = new DataACCESSlayer();
            DataTable Dt = new DataTable();
            SqlParameter[] PARAM = new SqlParameter[14];
            PARAM[0] = new SqlParameter("@KindID", SqlDbType.Int);
            PARAM[0].Value = KindID;
            PARAM[1] = new SqlParameter("@PublicN", SqlDbType.NChar);
            PARAM[1].Value = PublicN;
            PARAM[2] = new SqlParameter("@InnerN", SqlDbType.NVarChar);
            PARAM[2].Value = InnerN;
            PARAM[3] = new SqlParameter("@DateOfDoc", SqlDbType.VarChar);
            PARAM[3].Value = DateOfDoc;
            PARAM[4] = new SqlParameter("@DistID", SqlDbType.Int);
            PARAM[4].Value = DistID;
            PARAM[5] = new SqlParameter("@DepartID", SqlDbType.Int);
            PARAM[5].Value = DepartID;
            PARAM[6] = new SqlParameter("@SubjectDoc", SqlDbType.NVarChar);
            PARAM[6].Value = SubjectDoc;
            PARAM[7] = new SqlParameter("@DocName", SqlDbType.NVarChar);
            PARAM[7].Value = DocName;
            PARAM[8] = new SqlParameter("@fileex", SqlDbType.NVarChar);
            PARAM[8].Value = fileex;
            PARAM[9] = new SqlParameter("@RemaindDate", SqlDbType.VarChar);
            PARAM[9].Value = RemaindDate;
            PARAM[10] = new SqlParameter("@userid", SqlDbType.Int);
            PARAM[10].Value = userid;
            PARAM[11] = new SqlParameter("@CreatedDate", SqlDbType.VarChar);
            PARAM[11].Value = CreatedDate;
            PARAM[12] = new SqlParameter("@num", SqlDbType.VarChar);
            PARAM[12].Value = num;
            PARAM[13] = new SqlParameter("@docid", SqlDbType.Int);
            PARAM[13].Value = docid;
            Dt = DAL.selectData("insertintodoc", PARAM);
            DAL.CLOSE();
            return Dt;
        }
        public DataTable insertintodatatemp(int Docid, byte[] DATAFILE)
        {
            DataACCESSlayer DAL = new DataACCESSlayer();
            DataTable Dt = new DataTable();
            SqlParameter[] PARAM = new SqlParameter[2];
            PARAM[0] = new SqlParameter("@Docid", SqlDbType.Int);
            PARAM[0].Value = Docid;
            PARAM[1] = new SqlParameter("@DATAFILE", SqlDbType.VarBinary);
            PARAM[1].Value = DATAFILE;
            Dt = DAL.selectData("insertintodatatemp", PARAM);
            DAL.CLOSE();
            return Dt;
        }

    }

}
