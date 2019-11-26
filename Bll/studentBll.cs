using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dal;

namespace Bll
{
    public class StudentBll
    {
        StudentDal StuDal = new StudentDal();

        public List<Student> SelectAllStudent()   //所有学生
        {
            return stuDal.SelectAll();
        }

        public List<Course> SelectStuCourse(Student stu)  //学生课表
        {
            //没找到Dal用的那个方法
        }

        public bool AddStudent(Student stu)
        {
            return stuDal.Add(stu) > 0;
        }
        public bool DeleteStudent(Student stu)
        {
            if (stuDal.Delete(stu) == -2)
                return false;
            else
                return stuDal.Delete(stu) > 0;
        }
        public bool ModifyStudent(Student stu)  //修改
        {
            if (stuDal.Delete(stu) == -2)
                return false;
            else
                return stuDal.Update(stu) > 0;
        }
    }
}
