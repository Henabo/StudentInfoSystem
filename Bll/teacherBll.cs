using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dal;

namespace Bll
{
    public class TeacherBll
    {
        TeacherDal tchDal = new TeacherDal();

        public List<Teacher> SelectAllTeacher()  //所有老师
        {
            return tchDal.SelectAll();
        }

        public bool AddTeacher(Teacher tch)
        {
            return tchDal.Add(tch) > 0;
        }
        public bool DeleteTeacher(Teacher tch)
        {
            if (tchDal.Delete(tch) == -2)
                return false;
            else
                return tchDal.Delete(tch);
        }
        public bool ModifyTeacher(Teacher tch) //修改
        {
            if (tchDal.Update(tch) == -2)
                return false;
            else
                return tchDal.Update(tch);
        }
    }
}
