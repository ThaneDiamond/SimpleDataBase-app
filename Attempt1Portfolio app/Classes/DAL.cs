using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attempt1Portfolio_app.Classes
{
    internal class DAL
    {

        private SqlConnection _conn;
        private void connection()
        {
            string connStr = @"Data Source=THANEPC;Initial Catalog=TestDB;Integrated Security=True;TrustServerCertificate=True";
            _conn = new SqlConnection(connStr);
        }

        public DataSet loadTable(string tableName)
        {
            try
            {
                
                connection();
                _conn.Open();
                
                string query = $"SELECT * FROM [{tableName}]";
                SqlCommand cmd = new SqlCommand(query, _conn);
                SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);

                
                DataSet ds = new DataSet();
                dAdapter.Fill(ds);

                
                _conn.Close();
                return ds;
                
           
            }
            catch (Exception ex)
            {
                MessageBox.Show("Expception:"+ ex.Message);
                return null;
            }
        }
        
        public void Insert(string CustomerID, string SalesPID, DateTime OrderDate, string tableName)
        {
            SalesOrder record = new SalesOrder(int.Parse(CustomerID), int.Parse(SalesPID),OrderDate);

            connection();
            _conn.Open();

            string query = $"INSERT INTO [{tableName}] ([CustomerID], [SalespersonPersonID], [OrderDate]) VALUES (@CustomerID, @SalesPID, @OrderDate)";
            SqlCommand cmd = new SqlCommand(query, _conn);

            cmd.Parameters.AddWithValue("@CustomerID", record._customerID);
            cmd.Parameters.AddWithValue("@SalesPID", record._salesPID);
            cmd.Parameters.AddWithValue("@OrderDate", record._orderDate);

            
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Exception:" + ex.Message);

            }
            
            
            _conn.Close();


        }

        public void Delete(string CustomerID,string tableName)
        {
            connection();
            _conn.Open();

            string query = $"DELETE FROM [{tableName}] WHERE [CustomerID] = @CustomerID";
            SqlCommand cmd =new SqlCommand(query, _conn);

            cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Exception:"+ex.Message);
            }
            _conn.Close ();
        }
    }
}
