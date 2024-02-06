using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passport_aca.Model
{
    public class PageingDtocs
    {
        public List<TransactionViewModel> TransactionList { get; set; } = new List<TransactionViewModel>();
        public int TotalOfTransaction { get; set; }

    }
}
