﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing2
{ //holds the summery of trasactions, connects with transactions table.
    class transactionsBLL
    {
        public int id { get; set; }
        public decimal grandTotal { get; set; }
        public DateTime transaction_date { get; set; }
        public decimal tax { get; set; }
        public decimal discount { get; set; }
        public DataTable transactionDetails { get; set; }
    }
}
