using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dal
{
    public class CreditClassDal
    {
        public List<CreditClass> SelectAll()
        {
            //修改
            DataTable table = SqliteHelper.Select("SELECT * FROM credit_class where deleted=0");
            //修改
            List<CreditClass> list = new List<CreditClass>();
            foreach (DataRow row in table.Rows)
            {
                //修改
                list.Add(new CreditClass()
                {
                    id = Convert.ToInt32(row["id"]),
                    student_class = row["student_class"].ToString(),
                    credit_limit = Convert.ToDouble(row["credit_limit"]),
                    add_time = Convert.ToDateTime(row["add_time"]),
                    update_time = Convert.ToDateTime(row["update_time"]),
                    deleted = Convert.ToInt32(row["deleted"])
                });
            }
            return list;
        }

        public CreditClass SelectById(CreditClass model)
        {
            //修改
            string sql = "select * from credit_class where id=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("id",model.id)
            };
            DataTable table = SqliteHelper.Select(sql, ps);
            //修改
            List<CreditClass> list = new List<CreditClass>();
            foreach (DataRow row in table.Rows)
            {
                //修改
                list.Add(new CreditClass()
                {
                    id = Convert.ToInt32(row["id"]),
                    student_class = row["student_class"].ToString(),
                    credit_limit = Convert.ToDouble(row["credit_limit"]),
                    add_time = Convert.ToDateTime(row["add_time"]),
                    update_time = Convert.ToDateTime(row["update_time"]),
                    deleted = Convert.ToInt32(row["deleted"])
                });
            }
            //修改
            CreditClass model2 = list[0];
            return model2;
        }

        public int Add(CreditClass model)
        {
            //修改
            string sql = "insert into credit_class(student_class,credit_limit,add_time) values (@student_class,@credit_limit,@add_time)";
            //数组的初始化器
            SQLiteParameter[] ps =
            {
                //修改
                new SQLiteParameter("@student_class",model.student_class),
                new SQLiteParameter("@credit_limit",model.credit_limit),
                new SQLiteParameter("@add_time",DateTime.Now)
            };

            //执行
            return SqliteHelper.Add(sql, ps);
        }

        public int Update(CreditClass model)
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
        private List<Object> updateSQL(CreditClass model)
        {
            List<SQLiteParameter> ps = new List<SQLiteParameter>();
            string sql = "update course_score set ";
            bool flag = false;
            if (model.student_class != null)
            {
                if (flag)
                {
                    sql += ",";
                }
                sql += "student_class=@student_class";
                ps.Add(new SQLiteParameter("@student_class", model.student_class));
                flag = true;
            }
            if (model.credit_limit != 0)
            {
                if (flag)
                {
                    sql += ",";
                }
                sql += "credit_limit=@credit_limit";
                ps.Add(new SQLiteParameter("@credit_limit", model.credit_limit));
                flag = true;
            }
            if (flag)
            {
                sql += ",";
            }
            sql += "update_time=@update_time";
            ps.Add(new SQLiteParameter("@update_time", DateTime.Now));
            sql += " where id=@id";
            ps.Add(new SQLiteParameter("@id", model.id));
            List<Object> obj = new List<object>();
            obj.Add(sql);
            obj.Add(ps);
            return obj;
        }

        public int Delete(CreditClass model)
        {
            if (SelectById(model).deleted == 1)
            {
                //如果deleted==1，已经删除，返回-2
                return -2;
            }
            //修改
            string sql = "update credit_class set deleted=1 where id=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@id",model.id),
            };
            return SqliteHelper.Delete(sql, ps);
        }
    }
}
