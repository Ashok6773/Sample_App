using System.Data;
using System.Data.SqlClient;

namespace Sample_App.Service
{
    public class Helper
    {
        //public LogWritter log = new LogWritter();
        public string GetConnectionString()
        {
            string strConnect = "Server=LAPTOP-UE26NCLP;Database=DEMO;Trusted_Connection=True;MultipleActiveResultSets=true";
            return strConnect;
        }

        public DataTable getData_Datatable(Dictionary<string, object> stringargs, string SpName, string database = "")
        {
            DataTable dt = new DataTable();
            SqlCommand comm = new SqlCommand();
            SqlConnection con = new SqlConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                con.ConnectionString = GetConnectionString();

                //log.WriteLog(" ConnectionString : " + con.ConnectionString);

                con.Open();
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = SpName;
                comm.Connection = con;
                foreach (var element in stringargs)
                {
                    comm.Parameters.AddWithValue(element.Key, element.Value);
                }
                da.SelectCommand = comm;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                //log.WriteLog(" getData_Datatable error : " + ex.Message.ToString());
                throw;
            }
            finally
            {
                comm.Dispose();
                con.Close();
            }
            return dt;
        }

        public DataSet getData_DataSet(Dictionary<string, object> stringargs, string SpName, string database = "")
        {
            DataSet dst = new DataSet();
            SqlCommand comm = new SqlCommand();
            SqlConnection con = new SqlConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                con.ConnectionString = GetConnectionString();
                //log.WriteLog(" ConnectionString : " + con.ConnectionString);
                con.Open();
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = SpName;
                comm.Connection = con;
                foreach (var element in stringargs)
                {
                    comm.Parameters.AddWithValue(element.Key, element.Value);

                }
                da.SelectCommand = comm;
                da.Fill(dst);
            }
            catch (Exception ex)
            {
                //log.WriteLog(" getData_Datatable error : " + ex.Message.ToString());
                throw;
            }
            finally
            {
                comm.Dispose();
                con.Close();
            }
            return dst;
        }

        public void voidData(Dictionary<string, object> param, string SpName, string database = "")
        {
            SqlCommand comm = new SqlCommand();
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = GetConnectionString();
                con.Open();
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = SpName;
                comm.Connection = con;
                foreach (var element in param)
                {
                    comm.Parameters.AddWithValue(element.Key, element.Value);
                }
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                comm.Dispose();
                con.Close();
            }
        }

    }
}
