using passport_aca.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;


namespace Passpport_Raqaba.Model
{
    public class Administrator
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Validity { get; set; }
        [Required]
        public string name { get; set; }

        public bool state { get; set; }

        public List<TransactionInfo> transactions { get; set; }


    }
}
