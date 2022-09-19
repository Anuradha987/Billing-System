using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Billing2
{
    public partial class Sells : Form
    {
        public Sells()
        {
            InitializeComponent();
        }

        ProductsDAL pDAL = new ProductsDAL();
        DataTable transactionDT = new DataTable();
        /*create datatable as a globle value instead of using inside the addbtnClick event. otherwise
        the DataTable table will be created on each time the add button is being pressed*/
        transactionDAL tDAL = new transactionDAL();
        transactionDetailDAL tdDAL = new transactionDetailDAL();

        private void txtbarcode_TextChanged(object sender, EventArgs e)
        {
            try
            {

                string keyword = txtbarcode.Text;
                if (keyword == "")
                {
                    pictureBox1.Image = null;
                    txtname.Text = null;
                    txtprice.Text = "0.00";
                    txtqty.Value = 0;
                    txtTotalPrice.Text = "0.00";
                    return;
                }
                else
                {
                    ProductsBLL p = pDAL.GetProductsFromBarcode(keyword);

                    pictureBox1.Image = pDAL.ConvertByteArrayToImage((byte[])p.P_Image);
                    txtname.Text = p.P_Name;
                    txtprice.Text = (p.P_Price).ToString();
                    //pictureBox1.Image = pDAL.ConvertImageToByte(img: ProductsDAL);
                    // byte[] pictureBox1 = (byte[])p.P_Image;
                    txtqty.Value = 1;
                    txtTotalPrice.Text = (txtqty.Value * Convert.ToDecimal(txtprice.Text)).ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Invalid Barcode Value");
            }
        }

        private void txtqty_ValueChanged(object sender, EventArgs e)
        { //calculating total price
            decimal qnty = txtqty.Value;
            decimal price = Decimal.Parse(txtprice.Text);

            decimal totalprice = qnty * price;
            txtTotalPrice.Text = totalprice.ToString();
        }

        private void Sells_Load(object sender, EventArgs e)
        {
            //specify columns in the data grid view
            transactionDT.Columns.Add("Barcode");
            transactionDT.Columns.Add("Name");
            transactionDT.Columns.Add("Quantity");
            transactionDT.Columns.Add("Total");
        }
        decimal subtotal;
        private void btnadd1_Click(object sender, EventArgs e)
        {
            //Set Barcode, Name, quantity, total price to the table
            string barcode = txtbarcode.Text;
            string name = txtname.Text;
            decimal qty = txtqty.Value;
            decimal totalprice = Convert.ToDecimal(txtTotalPrice.Text);

            subtotal = decimal.Parse(txtSubTotal.Text);

            subtotal = subtotal + totalprice;

            txtSubTotal.Text = subtotal.ToString();

            if (barcode == "")
            {
                MessageBox.Show("Enter the barcode");
            }
            else
            {
                transactionDT.Rows.Add(barcode, name, qty, totalprice);
                dgvAddedProducts.DataSource = transactionDT;

                //clear textboxes
                txtbarcode.Text = null;
                txtname.Text = null;
                txtprice.Text = "0.00";
                txtqty.Value = 0;
                txtTotalPrice.Text = "0.00";
                pictureBox1.Image = null;
                txtbarcode.Focus();
            }

        }
        public decimal gettingPrice;

        private void dgvAddedProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {}

        private void dgvAddedProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {}
       
        private void guna2Button1_Click(object sender, EventArgs e)
        {/*
            DataRow[] dr = transactionDT.Select();

             foreach (DataRow row in dr)
             {
                 textBox1.Text = transactionDT.Rows[0][3].ToString();
             }
            */
           /* foreach (DataRow row in transactionDT.Rows)
            {
                foreach (DataColumn column in transactionDT.Columns)
                {
                    textBox1.Text = (row[column]).ToString(); Select();
                }
            }*/
            
            for (int i = 0; i < transactionDT.Rows.Count; i++) 
            {
                 textBox1.Text = transactionDT.Rows[i][3].ToString();
            }

            gettingPrice = Convert.ToDecimal(textBox1.Text);
            subtotal = subtotal - gettingPrice;
            txtSubTotal.Text = subtotal.ToString();

            int rowIndex = dgvAddedProducts.CurrentCell.RowIndex;
             dgvAddedProducts.Rows.RemoveAt(rowIndex);


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
        }


        private void txtSubTotal_TextChanged(object sender, EventArgs e)
        {
            decimal subtotal = decimal.Parse(txtSubTotal.Text);
            decimal discount;  //decimal variable to calculate discounts
            decimal grandTotal;
            decimal vat;
            //  decimal grandTotal = ((100 - discount) / 100) * subtotal;   //GrandTotal=((100-discount%)/100)xSubTotal
            // decimal grandTotal =  subtotal- (subtotal*discount/100);

            if (subtotal>10 && subtotal <= 100)
            {
                discount = subtotal * 5 / 100;
                txtDiscount.Text = 5.ToString();

                vat = subtotal * 2 / 100;  txtvat.Text = 2.ToString();
                grandTotal = subtotal - discount+ vat;  txtgrandTotal.Text = grandTotal.ToString();
            }
            else if (subtotal > 100 && subtotal <= 500)
            {
                discount = subtotal * 10 / 100; txtDiscount.Text = 10.ToString();
                grandTotal = subtotal - discount; txtgrandTotal.Text = grandTotal.ToString();

                vat = subtotal * 5 / 100; txtvat.Text = 5.ToString();
                grandTotal = subtotal - discount + vat; txtgrandTotal.Text = grandTotal.ToString();
            }
            else
            {
                discount = subtotal * 15 / 100; txtDiscount.Text = 15.ToString();
                grandTotal = subtotal - discount; txtgrandTotal.Text = grandTotal.ToString();

                vat = subtotal * 7 / 100; txtvat.Text = 7.ToString();
                grandTotal = subtotal - discount + vat; txtgrandTotal.Text = grandTotal.ToString();
            }
        }

        //________________________________________________________________________________________________________________________________________
        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            //transactionDT
            DataTable dt = new DataTable();
            

            /*  transactionDT.CurrentRow.Selected = true;
              transactionDT.Rows.RemoveAt(transactionDT.SelectedRows[0].Index);*/
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
           /* string check = txtDiscount.Text; //string variable to check the validation 

            if (check == "")
            {
                MessageBox.Show("Please add the discount first");
            }
            else
            {
                decimal discount = decimal.Parse(txtDiscount.Text);  //decimal variable to calculate discounts
                decimal subtotal = decimal.Parse(txtSubTotal.Text);
              //  decimal grandTotal = ((100 - discount) / 100) * subtotal;   //GrandTotal=((100-discount%)/100)xSubTotal
                                                                            // decimal grandTotal =  subtotal- (subtotal*discount/100);

                if (subtotal <= 35)
                {
                    discount = subtotal * 5 / 100;
                    txtDiscount.Text = discount.ToString();
                }
                else if (subtotal>40 && subtotal <= 50)
                {
                    discount = subtotal * 10 / 100; txtDiscount.Text = discount.ToString();
                }
                else
                {
                    discount = subtotal * 15 / 100; txtDiscount.Text = discount.ToString();
                }

               // txtgrandTotal.Text = grandTotal.ToString(); 
            }*/
        }

        private void txtvat_TextChanged(object sender, EventArgs e)
        {/*
            string check = txtgrandTotal.Text;
            if (check == "")
            {
                MessageBox.Show("Set the discount and grand total");
            }
            else
            {
                decimal previousGrandTotal = decimal.Parse(txtgrandTotal.Text);
                decimal vat = decimal.Parse(txtvat.Text);
                decimal grandtotal = ((100 + vat) / 100) * previousGrandTotal;  //GT with vat = (100+Vat%)/100)xGrandTotal
                txtgrandTotal.Text = grandtotal.ToString();
            }*/
        }


        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal grandTotal = decimal.Parse(txtgrandTotal.Text);
                decimal paidAmount = decimal.Parse(txtPaidAmount.Text);
                decimal returnAmount = paidAmount - grandTotal;

                txtReturnAmount.Text = returnAmount.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show (""+ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            transactionsBLL transaction = new transactionsBLL();
            
            transaction.grandTotal = Math.Round(decimal.Parse(txtgrandTotal.Text),2);
            transaction.transaction_date = DateTime.Now;
            transaction.tax = decimal.Parse(txtvat.Text);
            transaction.discount = decimal.Parse(txtDiscount.Text);
            transaction.transactionDetails = transactionDT;

            bool success = false;

            //Actual code to insert transaction and transaction details in database
            using (TransactionScope scope = new TransactionScope())
            {
                int transactionID = -1;
                bool w = tDAL.Insert_Transaction(transaction, out transactionID);
                for (int i = 0; i < transactionDT.Rows.Count; i++)
                {
                    //get all details of products
                    transactionDetailBLL1 transactionDetail = new transactionDetailBLL1();
                    /*   string barcode = txtbarcode.Text;
                     //=--------------------------------------------------
                       ProductsBLL p = pDAL.GetProductIdFromBarcode(barcode);
                       transactionDetail.id = p.P_Id;
                       //=--------------------------------------------------
                      */
                    transactionDetail.barcode = transactionDT.Rows[i][1].ToString();
                    transactionDetail.qty = decimal.Parse(transactionDT.Rows[i][2].ToString());
                    transactionDetail.total = Math.Round(decimal.Parse(transactionDT.Rows[i][3].ToString()), 2);
                    transactionDetail.added_date = DateTime.Now;

                    //Insert transaction details inside the database
                    bool y = tdDAL.InsertTransactionDetail(transactionDetail);


                    success = w && y;
                }     //w is the value after insertion. y is the value after inserting transaction details. 
                if (success == true)
                {
                    scope.Complete();

                    //Code to print the bill
                    DGVPrinter printer = new DGVPrinter();
                    printer.Title = "\r\n\r\n\r\n SMART SHOPPING CART BILLING SYSTEM \r\n ";  // \n creates a new line \r carries the return
                    printer.SubTitle = "The next level of shopping \r\n\r\n";
                    printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    printer.PageNumbers = true;
                    printer.PageNumberInHeader = false;
                    printer.PorportionalColumns = true;
                    printer.HeaderCellAlignment = StringAlignment.Near;
                    printer.Footer = "Discount:" + txtDiscount.Text + " \r\n VAT: " + txtvat.Text + " \r\n Grand Total: "+ txtgrandTotal.Text + "\r\n\r\n\r\n" + "THANK YOU AND COME AGAIN!";
                    printer.FooterSpacing = 15;
                    printer.PrintDataGridView(dgvAddedProducts);

                    MessageBox.Show("Transaction completed");
                    dgvAddedProducts.DataSource = null;
                    dgvAddedProducts.Rows.Clear();
                    txtbarcode.Text = "";
                    txtgrandTotal.Text = "0.00";
                    txtname.Text = "";
                    txtPaidAmount.Text = "0";
                    txtqty.Value = 0;
                    txtReturnAmount.Text = "0";
                    txtSubTotal.Text = "0.00";
                    txtTotalPrice.Text = "0.00";
                    txtvat.Text = "";
                    txtDiscount.Text = "";
                    txtphoneNo.Text = "";
                    txtCardNo.Text = "";
                    txtcvcCode.Text = "";
                }
                else
                {
                    MessageBox.Show("Transaction failed");
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cashButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        
        public bool check_radiobutton(RadioButton visaBtn, RadioButton masterBtn, RadioButton paypal)
        {
            //radio button validation
            if ((visaBtn.Checked) || (masterBtn.Checked) || paypal.Checked)
            {
                label8.Text = "";
                return true;                
            }
            else
            {
                label8.Text = "You forgot to select a payment method!";
                return false;
            }
            // return true;
        }

        //Validation of textboxes of the credit card payment
        public bool textboxValidation()
        {
            if (txtphoneNo.Text.Trim() == string.Empty)
            {
                label17.Text = "Please enter your phone number";
                return false; // return because we don't want to run normal code of buton click
            }
            label17.Text = "";

            Regex phoneNumpattern = new Regex(@"[0-9]");
            if (!(phoneNumpattern.IsMatch(txtphoneNo.Text) && txtphoneNo.Text.Length == 9))
            {
                label17.Text = "Invalid Phone Number";
                return false;
            }

            label17.Text = "";

            if (txtCardNo.Text.Trim() == string.Empty)
            {
                label20.Text = "Please enter \nthe Card No";
                return false; // return because we don't want to run normal code of buton click
            }
            label20.Text = "";

            Regex cardnumber = new Regex(@"[0-9]");
            if (!(cardnumber.IsMatch(txtCardNo.Text) && txtCardNo.Text.Length == 6))
            {
                label20.Text = "Invalid Card No";
                return false;
            }
            label20.Text = "";            

            if (txtcvcCode.Text.Trim() == string.Empty)
            {
                label21.Text = "Please enter the \nCVV/CVC No";
                return false; // return because we don't want to run normal code of buton click
            }
            label21.Text = "";

            Regex cccnumber = new Regex(@"[0-9]");
            if (!(cccnumber.IsMatch(txtcvcCode.Text) && txtcvcCode.Text.Length == 3))
            {
                label21.Text = "Invalid \nCVV/CVC No";
                return false;
            }
            label21.Text = "";
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            check_radiobutton(visaBtn, masterBtn, paypal);
            textboxValidation();

            if (check_radiobutton(visaBtn, masterBtn, paypal).Equals(true) && textboxValidation().Equals(true))
            {
               /* try
                {*/
                    transactionsBLL transaction = new transactionsBLL();

                    transaction.grandTotal = Math.Round(decimal.Parse(txtgrandTotal.Text), 2);
                    transaction.transaction_date = DateTime.Now;
                    transaction.tax = decimal.Parse(txtvat.Text);
                    transaction.discount = decimal.Parse(txtDiscount.Text);
                    transaction.transactionDetails = transactionDT;

                    bool success = false;

                    //Actual code to insert transaction and transaction details in database
                    using (TransactionScope scope = new TransactionScope())
                    {
                        int transactionID = -1;
                        bool w = tDAL.Insert_Transaction(transaction, out transactionID);
                        for (int i = 0; i < transactionDT.Rows.Count; i++)
                        {
                            //get all details of products
                            transactionDetailBLL1 transactionDetail = new transactionDetailBLL1();
                            /*   string barcode = txtbarcode.Text;
                             //=--------------------------------------------------
                               ProductsBLL p = pDAL.GetProductIdFromBarcode(barcode);
                               transactionDetail.id = p.P_Id;
                               //=--------------------------------------------------
                              */
                            transactionDetail.barcode = transactionDT.Rows[i][1].ToString();
                            transactionDetail.qty = decimal.Parse(transactionDT.Rows[i][2].ToString());
                            transactionDetail.total = Math.Round(decimal.Parse(transactionDT.Rows[i][3].ToString()), 2);
                            transactionDetail.added_date = DateTime.Now;

                            //Insert transaction details inside the database
                            bool y = tdDAL.InsertTransactionDetail(transactionDetail);


                            success = w && y;
                        }     //w is the value after insertion. y is the value after inserting transaction details. 
                        if (success == true)
                        {
                            scope.Complete();

                            //Code to print the bill
                            DGVPrinter printer = new DGVPrinter();
                            printer.Title = "\r\n\r\n\r\n SMART SHOPPING CART BILLING SYSTEM \r\n ";  // \n creates a new line \r carries the return
                            printer.SubTitle = "The next level of shopping \r\n\r\n";
                            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                            printer.PageNumbers = true;
                            printer.PageNumberInHeader = false;
                            printer.PorportionalColumns = true;
                            printer.HeaderCellAlignment = StringAlignment.Near;
                            printer.Footer = "Discount:" + txtDiscount.Text + " \r\n VAT: " + txtvat.Text + " \r\n Grand Total: " + txtgrandTotal.Text + "\r\n\r\n\r\n" + "THANK YOU AND COME AGAIN!";
                            printer.FooterSpacing = 15;
                            printer.PrintDataGridView(dgvAddedProducts);

                            MessageBox.Show("Transaction completed");
                           
                        }
                        else
                        {
                            MessageBox.Show("Transaction failed");
                        }
                    }


                    //Sending the message
                     String CardName = "";
                     if (visaBtn.Checked)
                     {
                         CardName = "Visa Card";
                     }
                     if (masterBtn.Checked)
                     {
                         CardName = "Master Card";
                     }
                     if (paypal.Checked)
                     {
                         CardName = "Paypal Account";
                     }

                     String Msg = "\r\n Dear Customer, Rs." + txtgrandTotal.Text + " have been succesfully transferred from your "+CardName+"-" + txtCardNo.Text + "\r\n Thank you and come again! \r\n" + DateTime.Now;

                         const string accountSid = "AC548da52ee5513d71fe1dc352c465d38a";
                         const string authToken = "7a1f8a0c2593aafbeb5bda31b5e65f68";

                         TwilioClient.Init(accountSid, authToken);

                         MessageResource.Create(
                             from: new PhoneNumber("+1 210 981 5934"),

                             to: new PhoneNumber("+94" + txtphoneNo.Text),
                             body: Msg);
                         MessageBox.Show("Message sent");

                /* }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex + "");
                 }*/
                dgvAddedProducts.DataSource = null;
                dgvAddedProducts.Rows.Clear();
                txtbarcode.Text = "";
                txtgrandTotal.Text = "0.00";
                txtname.Text = "";
                txtPaidAmount.Text = "0";
                txtqty.Value = 0;
                txtReturnAmount.Text = "0";
                txtSubTotal.Text = "0.00";
                txtTotalPrice.Text = "0.00";
                txtvat.Text = "";
                txtDiscount.Text = "";
                txtphoneNo.Text = "";
                txtCardNo.Text = "";
                txtcvcCode.Text = "";
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            panel2.Show();
            panel4.Hide();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            panel4.Show();
            panel2.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
