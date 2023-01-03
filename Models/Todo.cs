using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace digitaldiaryBackend.Models
{
    public class Todo
    {
        [Key]
        public int tid { get; set; }
        public string task { get; set; }
        public string status { get; set; }
    }
}
