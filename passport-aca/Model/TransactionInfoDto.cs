using Passpport_Raqaba.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace passport_aca.Model
{
    public class TransactionInfoDto
    {
        public int id { get; set; }

        public int finacial_recipt_number { get; set; }

        public string full_name { get; set; }

        public int transaction_number { get; set; }

        public long nationality_number { get; set; }

        public DateTime delivery_date { get; set; }

        public string passport_number { get; set; }

        public string passport_status { get; set; }

        public DateTime create_at { get; set; }

        public DateTime update_at { get; set; }

        public string resevedName { get; set; }

        public bool state { get; set; }

        public DateTime date_of_birth { get; set; }

        public string from_who { get; set; }

        public string reason_of_stopping { get; set; }

        public int UserId { get; set; }

        public DateTime picture_date { get; set; }

        public string classification { get; set; }



    }
}
