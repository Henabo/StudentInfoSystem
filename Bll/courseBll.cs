using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dal;

namespace Bll
{
    public class CourseBll
    {
        CourseDal courDal = new CourseDal();

        public List<Course> SelectAllCourse()  //查看所有课程
        {
            return courDal.SelectAll();
        }

        public bool AddCourse(Course cour)   //添加   
        {
            return courDal.Add(cour) > 0;
        }

        public bool DeleteCourse(Course cour) //删除
        {
            if (courDal.Delete(cour) == -2) //已经删除，不允许再次删除
                return false;
            else
                return courDal.Delete(cour) > 0;
        }

        public bool ModifyCourse(Course cour)  //修改
        {
            if (courDal.Update(cour) == -2) //已经删除，不允许修改
                return false;
            else
                return courDal.Update(cour) > 0;
        }
    }
}
