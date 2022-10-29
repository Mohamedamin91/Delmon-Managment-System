using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Forms;

namespace Delmon_Managment_System
{
   
   public  class SQLCONNECTION
    {
        
        string ConnectionString = "Data Source=192.168.1.8;Initial Catalog=DelmonGroupDB;User ID=sa;password=Ram72763@";
        SqlConnection con;
        public void OpenConection()
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
        }

   
        public void CloseConnection()
        {
            con.Close();
        }


        public void ExecuteQueries(string Query_, params SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            foreach (SqlParameter parm in parameters)
            {
                cmd.Parameters.Add(parm);
            }
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd.Parameters.Clear();
        }
     
        public SqlDataReader DataReader(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }


        public object ShowDataInGridViewORCombobox(string Query_)
        {
            SqlDataAdapter adapt = new SqlDataAdapter(Query_, ConnectionString);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            object dataum = ds.Tables[0];   
            return dataum;
        }
    



}
   

}
