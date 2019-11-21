using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Common;

namespace Dal
{
    public class  AdminDal
    {
        /// <summary>
        /// select admin 查询 admin 
        /// </summary>
        /// <returns></returns>
        public List<Admin> SelectAll()
        {
            //执行查询，获取数据
            DataTable table = SqliteHelper.Select("SELECT * FROM admin where deleted=0");
            //构造数据集合
            List<Admin> list = new List<Admin>();
            //遍历数据表，将数据转存到集合中
            foreach(DataRow row in table.Rows)
            {
                list.Add(new Admin()
                {
                    id = Convert.ToInt32(row["Id"]),
                    admin_name = row["admin_name"].ToString(),
                    password = row["password"].ToString(),
                    add_time = row["add_time"].ToString(),
                    update_time = row["update_time"].ToString(),
                    deleted = Convert.ToInt32(row["deleted"])
                });
            }
            return list;
        }

        public List<Admin> Login(Admin ai)
        {
            string sql = "select * from admin";
            SQLiteParameter[] ps = new SQLiteParameter[2];
            if(ai != null)
            {
                sql += " where admin_name=@admin_name and password=@password";
                ps[0] = new SQLiteParameter("@admin_name", ai.admin_name);
                ps[1] = new SQLiteParameter("@password", Md5Helper.GetMd5(ai.password));
            }
            //执行查询，获取数据
            DataTable table = SqliteHelper.Select(sql,ps);
            
            //构造数据集合
            List<Admin> list = new List<Admin>();
            //遍历数据表，将数据转存到集合中
            foreach (DataRow row in table.Rows)
            {
                list.Add(new Admin()
                {
                    id = Convert.ToInt32(row["Id"]),
                    admin_name = row["admin_name"].ToString(),
                    password = row["password"].ToString(),
                    add_time = row["add_time"].ToString(),
                    update_time = row["update_time"].ToString(),
                    deleted = Convert.ToInt32(row["deleted"])
                });
            }
            return list;
        }

        public int Add(Admin ai)
        {
            string sql = "insert into admin(admin_name,password,add_time) values (@admin_name,@password,@add_time)";
            //数组的初始化器
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@admin_name",ai.admin_name),
                new SQLiteParameter("@password",Md5Helper.GetMd5(ai.password)),
                new SQLiteParameter("@add_time",DateTime.Now)
            };

            //执行
            return SqliteHelper.Add(sql, ps);
        }

        public int Update(Admin ai)
        {
            List<Object> obj = updateSQL(ai);
            string sql = obj[0].ToString();
            List<SQLiteParameter> ps = (List<SQLiteParameter>)obj[1];

            return SqliteHelper.update(sql, ps.ToArray());
        }
        /// <summary>
        /// 拼接update的sql语句
        /// </summary>
        /// <param name="ai"></param>
        /// <returns></returns>
        private List<Object> updateSQL(Admin ai)
        {
            List<SQLiteParameter> ps = new List<SQLiteParameter>();
            string sql = "update admin set ";
            bool flag = false;
            if(ai.admin_name != null)
            {
                if(flag)
                {
                    sql += ",";
                }
                sql += "admin_name=@admin_name";
                ps.Add(new SQLiteParameter("@admin_name", ai.admin_name));
                flag = true;
            }
            if(ai.password != null)
            {
                if(flag)
                {
                    sql += ",";
                }
                sql += "password=@password";
                ps.Add(new SQLiteParameter("@password", Md5Helper.GetMd5(ai.password)));
                flag = true;
            }
            if(flag)
            {
                sql += ",";
            }
            sql += "update_time=@update_time";
            ps.Add(new SQLiteParameter("@update_time",DateTime.Now));
            if(ai.id == 0)
            {
                throw new MyException("ID不能为空");
            }
            sql += " where id=@id";
            ps.Add(new SQLiteParameter("@id", ai.id));
            List<Object> obj = new List<object>();
            obj.Add(sql);
            obj.Add(ps);
            return obj;
        }

        public int Delete(Admin ai)
        {
            string sql = "delete from admin where id=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@id",ai.id),
            };
            return SqliteHelper.Delete(sql, ps);
        }
    }
}
