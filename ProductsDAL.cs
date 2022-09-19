using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billing2
{
    class ProductsDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;



        //select method for Products module
        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM Products";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;

        }


        public byte[] ConvertImageToByte(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }   
        public Image ConvertByteArrayToImage(byte[] data)
        {
            using (MemoryStream mstream = new MemoryStream(data))
            {
                return Image.FromStream(mstream);
            }
        }



        //Inserting data into Products table.
        public bool Insert(ProductsBLL p)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
           try
            {
                String sql = "Insert into Products(P_Barcode,P_Name,P_Price,P_Image) values (@P_Barcode, @P_Name, @P_Price, @P_Image)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@P_Barcode", p.P_Barcode);
                cmd.Parameters.AddWithValue("@P_Name", p.P_Name);
                cmd.Parameters.AddWithValue("@P_Price", p.P_Price);
                cmd.Parameters.AddWithValue("@P_Image", p.P_Image);

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
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        // Update poducts in database

        public bool Update(ProductsBLL p)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {//meke poddak balanna sql eke where P_Barcode=@P_Barcode enawada kiyala anthimata.
                string sql = "Update Products SET P_Barcode=@P_Barcode, P_Name=@P_Name, P_Price=@P_Price WHERE P_Id=@P_Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@P_Id", p.P_Id);
                cmd.Parameters.AddWithValue("@P_Barcode", p.P_Barcode);
                cmd.Parameters.AddWithValue("@P_Name", p.P_Name);
                cmd.Parameters.AddWithValue("@P_Price", p.P_Price);

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        //Delete products from database
        public bool Delete(ProductsBLL p)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "Delete from Products WHERE P_Id=@P_Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@P_Id", p.P_Id);

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        //  Search Items in the DataGridView 

        public DataTable Search(string keywords)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM Products WHERE P_Barcode LIKE '%" + keywords + "%' OR P_Name LIKE '%" + keywords + "%' ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        //  Get Item details using the barcode 

        public ProductsBLL GetProductsFromBarcode(string keyword)
        {
            ProductsBLL p = new ProductsBLL();
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();


            try
            {
                string sql = "SELECT P_Name,P_Price, P_Image FROM Products WHERE P_Barcode LIKE '%" + keyword + "%' ";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                conn.Open();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    // p.P_Barcode = dt.Rows[0]["P_Barcode"].ToString();
                    p.P_Name = dt.Rows[0]["P_Name"].ToString();
                    p.P_Price = decimal.Parse(dt.Rows[0]["P_Price"].ToString());
                    p.P_Image = new MemoryStream((byte[])dt.Rows[0]["P_Image"]).ToArray();
                   // p.P_Image = ConvertByteArrayToImage(dt.Rows[0]["P_Price"]);
                    //MemoryStream ms = new MemoryStream((byte[])dt.Rows[0]["P_Image"]);
                    
                    //p.P_Image = new Image(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            conn.Close(); return p;
        }


        //Method to get product id based on barcode--------------------meka kamathi nam ayin karanna
        SqlConnection conn = new SqlConnection(myconnstrng);
        DataTable dt = new DataTable();  //hold data temporary

        public ProductsBLL GetProductIdFromBarcode(string ProductBarcode)
        {
            ProductsBLL p = new ProductsBLL();
           try
            {
                string sql = "SELECT P_Id from Products WHERE P_Barcode='" + ProductBarcode + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                conn.Open();

                adapter.Fill(dt);
                if (dt.Rows.Count > 0) 
                {
                    p.P_Id = int.Parse(dt.Rows[0]["P_Id"].ToString());
                }
                }
           catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
             finally
             {
                 conn.Close();
             }  return p;

        }
    }
}

    

