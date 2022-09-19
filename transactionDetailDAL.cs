using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billing2
{
    class transactionDetailDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        public bool InsertTransactionDetail(transactionDetailBLL1 td)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);
            /*try
            {*/
                string sql = "INSERT INTO tbl_transaction_detail(barcode, qty, total, added_date) VALUES (@barcode, @qty, @total, @added_date)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@barcode", td.barcode);
                cmd.Parameters.AddWithValue("@qty", td.qty);
                cmd.Parameters.AddWithValue("@total", td.total);
                cmd.Parameters.AddWithValue("@added_date", td.added_date);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
           /* }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {*/
                conn.Close();
           // }
            return isSuccess;
        }

    }
}
