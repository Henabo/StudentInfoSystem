using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Teacher
    {
        public int id { get; set; }

        public int teacher_id { get; set; }

        public string name { get; set; }

        public int sex { get; set; }

        public int age { get; set; }

        public string position { get; set; }

        public string password { get; set; }

        public DateTime add_time { get; set; }

        public DateTime update_time { get; set; }

        public int deleted { get; set; }
    }
}
