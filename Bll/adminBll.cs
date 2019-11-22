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
        AdminDal miDal = new AdminDal();

        public List<Admin> SelectAll()
        {
            return miDal.SelectAll();
        }
        public bool Add(Admin ai)
        {
            return miDal.Add(ai) > 0;
        }

        public bool login(Admin ai)
        {
            var list = miDal.Login(ai);
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
