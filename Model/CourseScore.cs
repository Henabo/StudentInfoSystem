using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CourseScore
    {
        public int id { get; set; }

        public int student_id { get; set; }

        public int course_id { get; set; }

        public Double score { get; set; }

        public DateTime add_time { get; set; }

        public DateTime update_time { get; set; }

        public int deleted { get; set; }
    }
}
