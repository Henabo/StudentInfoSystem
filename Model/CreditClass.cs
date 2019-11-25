using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CreditClass
    {
        public int id { get; set; }

        public string student_class { get; set; }

        public Double credit_limit { get; set; }
        
        public DateTime add_time { get; set; }

        public DateTime update_time { get; set; }

        public int deleted { get; set; } 
    }
}
