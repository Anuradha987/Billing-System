using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing2
{
    class ProductsBLL
    {
        public int P_Id { get; set; }
        public string P_Barcode { get; set; }
        public string P_Name { get; set; }
        public decimal P_Price { get; set; }
        public byte[] P_Image { get; set; }
        //public string P_Image { get; set; }
    }
}
