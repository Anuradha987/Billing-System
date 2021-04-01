using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing2
{ //connects with transaction_detail table. 
    class transactionDetailBLL1
    {
        public int id { get; set; }
        public string barcode { get; set; }
        public decimal qty { get; set; }
        public decimal total { get; set; }
        public DateTime added_date { get; set; }
}
}
