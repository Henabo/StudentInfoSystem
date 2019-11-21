using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Course
    {
        public int id { get; set; }

        public string name { get; set; }

        public Double credit { get; set; }

        public string teacher { get; set; }

        public int time { get; set; }

        public string place { get; set; }

        public int capacity { get; set; }

        public int type { get; set; }

        public DateTime add_time { get; set; }

        public DateTime update_time { get; set; }

        public int deleted { get; set; }

    }
}
