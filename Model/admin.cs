using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Admin
    {
        public int id { get; set; }
        public string admin_name { get; set; }
        public string password { get; set; }
        public string add_time{ get; set; }
        public string update_time { get; set; }
        public int deleted { get; set; }
    }
}
