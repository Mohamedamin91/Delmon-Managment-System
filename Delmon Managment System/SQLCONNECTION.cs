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

        // Dev server
        public string ConnectionString0 = "Data Source=192.168.1.153;Initial Catalog=DelmonGroupDB;User ID=sa;password=Ram72763@";


        // Production server
        public string ConnectionString = "Data Source=192.168.1.8;Initial Catalog=DelmonGroupDB;User ID=sa;password=Ram72763@";
        public string ConnectionString2 = "Data Source=192.168.1.8;Initial Catalog=DelmonRealState;User ID=sa;password=Ram72763@";
        public string ConnectionString3 = "Data Source=192.168.1.8;Initial Catalog=DelmonGroupAssests;User ID=sa;password=Ram72763@";
        public string ConnectionString4 = "Data Source=192.168.1.8;Initial Catalog=DelmonPrintersLog;User ID=sa;password=Ram72763@";
        // public string ConnectionString = "Data Source=AMIN-PC;Initial Catalog=DelmonGroupDB;Persist Security Info=True;User ID=sa;password=Ram72763@";

        public SqlConnection con;
        public void OpenConection0()
        {
            con = new SqlConnection(ConnectionString0);
            con.Open();
        }



        public void OpenConection()
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
        }
        public void OpenConection2()
        {
            con = new SqlConnection(ConnectionString2);
            con.Open();
        }
        public void OpenConection3()
        {
            con = new SqlConnection(ConnectionString3);
            con.Open();
        }
        public void OpenConection4()
        {
            con = new SqlConnection(ConnectionString4);
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


        public DataTable ShowDataInGridViewORCombobox(string Query_, params SqlParameter[] parameters)
        {
            using (SqlCommand cmd = new SqlCommand(Query_, con))
            {
                foreach (SqlParameter parm in parameters)
                {
                    cmd.Parameters.Add(parm);
                }

                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);

                cmd.Parameters.Clear();

                // Return the DataTable directly
                return ds.Tables[0];
            }
        }


    }


}
