using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passport_aca.Model
{
    public class TransactionViewModel
    {
        public int id { get; set; }
        public int transaction_number { get; set; }
        public int finacial_recipt_number { get; set; }
        public string picture_date { get; set; }
        public string full_name { get; set; }
        public string passport_status { get; set; }
        public string fromWho { get; set; }
        public string delivery_date { get; set; }

        public int TotalOfTransaction { get; set; }


    }
}
