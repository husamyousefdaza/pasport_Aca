using passport_aca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace passport_aca.Data
{
    public class SearchModel
    {

        public SearchModel()
        {
            finacial_recipt_number = new List<Dto>();
            full_name = new List<Dto>();
            transaction_number = new List<Dto>();
            passport_number = new List<Dto>();

        }
        public List<Dto> finacial_recipt_number { get; set; }
        public List<Dto> full_name { get; set; }
        public List<Dto> transaction_number { get; set; }
        public List<Dto> passport_number { get; set; }
        public string Massage { get; set; }
        public int statuscode { get; set; }

    }
}
