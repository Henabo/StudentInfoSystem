using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dal;

namespace Bll
{
    public class AdminBll
    {
        AdminDal adminDal = new AdminDal();

        public List<Admin> SelectAll()
        {
            return adminDal.SelectAll();
        }
        public bool Add(Admin ai)
        {
            return adminDal.Add(ai) > 0;
        }

        public bool login(Admin ai)
        {
            var list = adminDal.Login(ai);
            if(list.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
