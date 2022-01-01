using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;




namespace LibM.DAL
{
    internal class CLS_DAL
    {
        public int hata;
        SqlConnection con = new SqlConnection();
        public CLS_DAL()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-D7R98PC\LIBRARY;Initial Catalog=Management_System;Integrated Security=True");
        }

        // Method to open sqlcon
        public void open()
        {
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        // Method to close sqlcon
        public void close()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        //Fun To Read Date
        public DataTable read(String store, SqlParameter[] pr)
        {
            DataTable dt = new DataTable();
            try
            {
                this.hata = 1;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = store;
                if (pr != null)
                {
                    cmd.Parameters.AddRange(pr);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                this.hata=0;
                return dt;
            }
            
        }

        //Excute To instert , Edit , Delete
        public void Excute(String store, SqlParameter[] pr)
        {
                      
            try
            {
                hata = 1;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = store;
                if (pr != null)
                {
                    cmd.Parameters.AddRange(pr);
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                this.hata=0;
            }
               
            
        }

    }
}
