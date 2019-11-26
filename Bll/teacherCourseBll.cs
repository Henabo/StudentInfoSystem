using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dal;

namespace Bll
{
    public class TeacherCourseBll
    {
        TeacherCourseDal tchCourseDal = new TeacherCourseDal();

        //查看老师课表
        public List<TeacherCourse> SelectTeacherCourse(TeacherCourse tchCourse)
        {
            TeacherCourse tchCourse = tchCourseDal.SelectById();
            list<Course> searchedCour = new list<Course>();
            searchedCour.Add(tchCourse);
            return searchedCour;
        }
    }

}
