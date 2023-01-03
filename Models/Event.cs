using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace digitaldiaryBackend.Models
{
    public class Event
    {

        [Key]
        public int eid { get; set; }
        public int  uid{ get; set; }
        public string sdate { get; set; }

        public string edate { get; set; }
        public string time { get; set; }

        public string title { get; set; }

        public string description { get; set; }
    }
}
