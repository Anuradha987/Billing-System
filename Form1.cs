using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billing2
{
    public partial class ProductRegi : Form
    {
        public ProductRegi()
        {
            InitializeComponent();
        }
        public SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-NOPLJLAU;Initial Catalog=billing1;Integrated Security=True");
        public String ProductID;

        ProductsBLL p = new ProductsBLL();
        ProductsDAL pdal = new ProductsDAL();

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = pdal.Select();
            dgvProductsRegi.DataSource = dt;
        }

        private void productRegipicturebox_Click(object sender, EventArgs e)
        {/*
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "jpg Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image img = new Bitmap(ofd.FileName);
                productRegipicturebox.Image = img.GetThumbnailImage(600, 400, null, new IntPtr());
            }*/
            using(OpenFileDialog ofd= new OpenFileDialog() { Filter= "jpg Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All files (*.*)|*.*", Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    productRegipicturebox.Image = Image.FromFile(ofd.FileName);
                    pdal.ConvertImageToByte(productRegipicturebox.Image);
                    Select();
                }
            }

        }
        private void btnaddRegi_Click(object sender, EventArgs e)
        {
            p.P_Barcode = txtbarcodeRegi.Text;
            p.P_Name = txtnameRegi.Text;
            p.P_Price = Convert.ToDecimal(txtpriceRegi.Text);
            //p.P_Image = pdal.ConvertImageToByte(productRegipicturebox.Image);
            p.P_Image = pdal.ConvertImageToByte(productRegipicturebox.Image);

            //pdal.Insert(p);
            bool success = pdal.Insert(p);
            if (success == true)
            {
                MessageBox.Show("Product added");
                Clear();
                DataTable dt = pdal.Select();
                dgvProductsRegi.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed to add");
            }
        }

        public void Clear()
        {
            txtidRegi.Text = null;
            txtbarcodeRegi.Text = null;
            txtnameRegi.Text = null;
            txtpriceRegi.Text = null;

        }

        private void dgvProductsRegi_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void dgvProductsRegi_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtidRegi.Text = dgvProductsRegi.Rows[rowIndex].Cells[0].Value.ToString();

            txtbarcodeRegi.Text = dgvProductsRegi.Rows[rowIndex].Cells[1].Value.ToString();
            txtnameRegi.Text = dgvProductsRegi.Rows[rowIndex].Cells[2].Value.ToString();
            txtpriceRegi.Text = dgvProductsRegi.Rows[rowIndex].Cells[3].Value.ToString();

        }

        private void searchRegi_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtsearchRegi.Text;
            if (keywords != null)
            {
                DataTable dt = pdal.Search(keywords);
                dgvProductsRegi.DataSource = dt;
            }
            else
            {
                DataTable dt = pdal.Select();
                dgvProductsRegi.DataSource = dt;
              }
        }

        private void btnupdateRegi_Click(object sender, EventArgs e)
        {
            p.P_Id = int.Parse(txtidRegi.Text);
            p.P_Barcode = txtbarcodeRegi.Text;
            p.P_Name = txtnameRegi.Text;
            p.P_Price = Convert.ToDecimal(txtpriceRegi.Text);

            bool success = pdal.Update(p);
            if (success == true)
            {
                MessageBox.Show("Updated successfully");
                Clear();
                DataTable dt = pdal.Select();
                dgvProductsRegi.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Update failed");
            }
        }

        private void btndeleteRegi_Click(object sender, EventArgs e)
        {
            bool success = pdal.Delete(p);
            if (success == true)
            {
                MessageBox.Show("Delete successfully");
                Clear();
                DataTable dt = pdal.Select();
                dgvProductsRegi.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Delete failed");
            }

        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            Sells s = new Sells();
            this.Hide();
            s.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtidRegi.Text="";
            txtbarcodeRegi.Text="";
            txtnameRegi.Text="";
            txtpriceRegi.Text="";
        }

    }
}
