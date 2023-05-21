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

      public string ConnectionString = "Data Source=192.168.1.8;Initial Catalog=DelmonGroupDB;User ID=sa;password=Ram72763@";
     //public string ConnectionString = "Data Source=AMIN-PC;Initial Catalog=DelmonGroupDB;Persist Security Info=True;User ID=sa;password=Ram72763@";

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
     
        public SqlDataReader DataReader(string Query_, params SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            foreach (SqlParameter parm in parameters)
            {
                cmd.Parameters.Add(parm);
            }
            SqlDataReader dr = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            return dr;

        }


        public object ShowDataInGridViewORCombobox(string Query_, params SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            foreach (SqlParameter parm in parameters)
            {
                cmd.Parameters.Add(parm);
            }
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            object dataum = ds.Tables[0];
            cmd.Parameters.Clear();
            return dataum;
           


        }




    }
   

}
