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

        public List<Admin> SelectAll()
        {
            //修改
            DataTable table = SqliteHelper.Select("select * from admin where deleted=0");
            //修改
            List<Admin> list = new List<Admin>();
            foreach(DataRow row in table.Rows)
            {
                //修改
                list.Add(new Admin()
                {
                    id = Convert.ToInt32(row["id"]),
                    admin_name = row["admin_name"].ToString(),
                    password = row["password"].ToString(),
                    add_time = Convert.ToDateTime(row["add_time"]),
                    deleted = Convert.ToInt32(row["deleted"])
                });
            }
            return list;
        }

        public Admin SelectById(Admin model)
        {
            //修改
            string sql = "select * from admin where id=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("id",model.id)
            };
            DataTable table = SqliteHelper.Select(sql, ps);
            //修改
            List<Admin> list = new List<Admin>();
            //遍历数据表，将数据转存到集合中
            foreach (DataRow row in table.Rows)
            {
                //修改
                list.Add(new Admin()
                {
                    id = Convert.ToInt32(row["Id"]),
                    admin_name = row["admin_name"].ToString(),
                    password = row["password"].ToString(),
                    add_time = Convert.ToDateTime(row["add_time"]),
                    update_time = Convert.ToDateTime(row["update_time"]),
                    deleted = Convert.ToInt32(row["deleted"])
                });
            }
            //修改
            Admin model2 = list[0];
            return model2;
        }

        public int Add(Admin model)
        {
            //修改
            string sql = "insert into admin(admin_name,password,add_time) values (@admin_name,@password,@add_time)";
            //数组的初始化器
            SQLiteParameter[] ps =
            {
                //修改
                new SQLiteParameter("@admin_name",model.admin_name),
                new SQLiteParameter("@password",Md5Helper.GetMd5(model.password)),
                new SQLiteParameter("@add_time",DateTime.Now)
            };

            //执行
            return SqliteHelper.Add(sql, ps);
        }

        public int Update(Admin model)
        {
            if (SelectById(model).deleted == 1)
            {
                return -2;
            }
            List<Object> obj = updateSQL(model);
            string sql = obj[0].ToString();
            List<SQLiteParameter> ps = (List<SQLiteParameter>)obj[1];

            return SqliteHelper.update(sql, ps.ToArray());
        }
        private List<Object> updateSQL(Admin model)
        {
            List<SQLiteParameter> ps = new List<SQLiteParameter>();
            string sql = "update admin set ";
            bool flag = false;
            if(model.admin_name != null)
            {
                if(flag)
                {
                    sql += ",";
                }
                sql += "admin_name=@admin_name";
                ps.Add(new SQLiteParameter("@admin_name", model.admin_name));
                flag = true;
            }
            if(model.password != null)
            {
                if(flag)
                {
                    sql += ",";
                }
                sql += "password=@password";
                ps.Add(new SQLiteParameter("@password", Md5Helper.GetMd5(model.password)));
                flag = true;
            }
            if(flag)
            {
                sql += ",";
            }
            sql += "update_time=@update_time";
            ps.Add(new SQLiteParameter("@update_time",DateTime.Now));
            sql += " where id=@id";
            ps.Add(new SQLiteParameter("@id", model.id));
            List<Object> obj = new List<object>();
            obj.Add(sql);
            obj.Add(ps);
            return obj;
        }

        public int Delete(Admin model)
        {
            if (SelectById(model).deleted == 1)
            {
                //如果deleted==1，已经删除，返回-2
                return -2;
            }
            //修改
            string sql = "update admin set deleted=1 where id=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@id",model.id),
            };
            return SqliteHelper.Delete(sql, ps);
        }

        public List<Admin> Login(Admin ai)
        {
            string sql = "select * from admin";
            SQLiteParameter[] ps = new SQLiteParameter[2];
            if (ai != null)
            {
                sql += " where admin_name=@admin_name and password=@password and deleted=0";
                ps[0] = new SQLiteParameter("@admin_name", ai.admin_name);
                ps[1] = new SQLiteParameter("@password", Md5Helper.GetMd5(ai.password));
            }
            DataTable table = SqliteHelper.Select(sql, ps);
            List<Admin> list = new List<Admin>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(new Admin()
                {
                    id = Convert.ToInt32(row["Id"]),
                    admin_name = row["admin_name"].ToString(),
                    password = row["password"].ToString(),
                    add_time = Convert.ToDateTime(row["add_time"]),
                    deleted = Convert.ToInt32(row["deleted"])
                });
            }
            return list;
        }
    }
}
