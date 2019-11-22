using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TeacherCourse
    {
        public int id { get; set; }

        public int teacher_id { get; set; }

        public int course_id { get; set; }

        public DateTime add_time { get; set; }

        public DateTime update_time { get; set; }

        public int deleted { get; set; }
    }
}
