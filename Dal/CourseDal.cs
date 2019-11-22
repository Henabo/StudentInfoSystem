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
    public class CourseDal
    {
        public Course SelectById(Course model)
        {
            string sql = "select * from course where id=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("id",model.id)
            };
            //执行查询，获取数据
            DataTable table = SqliteHelper.Select(sql, ps);
            //构造数据集合
            List<Course> list = new List<Course>();
            //遍历数据表，将数据转存到集合中
            foreach (DataRow row in table.Rows)
            {
                list.Add(new Course()
                {
                    id = Convert.ToInt32(row["id"]),
                    name = row["name"].ToString(),
                    credit = Convert.ToDouble(row["credit"]),
                    teacher = row["teacher"].ToString(),
                    time = Convert.ToInt32(row["time"]),
                    place = row["place"].ToString(),
                    capacity = Convert.ToInt32(row["capacity"]),
                    type = Convert.ToInt32(row["type"]),
                    add_time = Convert.ToDateTime(row["add_time"]),
                    update_time = Convert.ToDateTime(row["update_time"]),
                    deleted = Convert.ToInt32(row["deleted"])
                });
            }
            Course model2 = list[0];
            return model2;
        }
        public int Add(Course model)
        {
            string sql = "insert into course(name,credit,teacher,time,place,capacity,type,add_time) " +
                "values (@name,@credit,@teacher,@time,@place,@capacity,@type,@add_time)";
            //数组的初始化器
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@name",model.name),
                new SQLiteParameter("@credit",model.credit),
                new SQLiteParameter("@teacher",model.teacher),
                new SQLiteParameter("@time",model.time),
                new SQLiteParameter("@place",model.place),
                new SQLiteParameter("@capacity",model.capacity),
                new SQLiteParameter("@type",model.type),
                new SQLiteParameter("@add_time",DateTime.Now)
            };

            //执行
            return SqliteHelper.Add(sql, ps);
        }

        /// <summary>
        /// 逻辑删除，返回-2则表示已经删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns>-2，已经删除</returns>
        public int Delete(Course model)
        {
            if(SelectById(model).deleted == 1)
            {
                //如果deleted==1，已经删除，返回-2
                return -2;
            }

            string sql = "update course set deleted=1 where id=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@id",model.id),
            };
            return SqliteHelper.Delete(sql, ps);
        }

        public int Update(Course model)
        {
            if (SelectById(model).deleted == 1)
            {
                //如果deleted==1，已经删除，返回-2
                return -2;
            }
            List<Object> obj = updateSQL(model);
            string sql = obj[0].ToString();
            List<SQLiteParameter> ps = (List<SQLiteParameter>)obj[1];

            return SqliteHelper.update(sql, ps.ToArray());
        }
        private List<Object> updateSQL(Course model)
        {
            List<SQLiteParameter> ps = new List<SQLiteParameter>();
            string sql = "update course set ";
            bool flag = false;
            if (model.name != null)
            {
                if (flag)
                {
                    sql += ",";
                }
                sql += "name=@name";
                ps.Add(new SQLiteParameter("@name", model.name));
                flag = true;
            }
            if (model.credit != 0)
            {
                if (flag)
                {
                    sql += ",";
                }
                sql += "credit=@credit";
                ps.Add(new SQLiteParameter("@credit", model.credit));
                flag = true;
            }
            if (model.teacher != null)
            {
                if (flag)
                {
                    sql += ",";
                }
                sql += "teacher=@teacher";
                ps.Add(new SQLiteParameter("@teacher", model.teacher));
                flag = true;
            }
            if (model.time != 0)
            {
                if (flag)
                {
                    sql += ",";
                }
                sql += "time=@time";
                ps.Add(new SQLiteParameter("@time", model.time));
                flag = true;
            }
            if (model.place != null)
            {
                if (flag)
                {
                    sql += ",";
                }
                sql += "place=@place";
                ps.Add(new SQLiteParameter("@place", model.place));
                flag = true;
            }
            if (model.capacity != 0)
            {
                if (flag)
                {
                    sql += ",";
                }
                sql += "capacity=@capacity";
                ps.Add(new SQLiteParameter("@capacity", model.capacity));
                flag = true;
            }
            if (model.type != 0)
            {
                if (flag)
                {
                    sql += ",";
                }
                sql += "type=@type";
                ps.Add(new SQLiteParameter("@type", model.type));
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


        public List<Course> SelectAll()
        {
            //执行查询，获取数据
            DataTable table = SqliteHelper.Select("SELECT * FROM course where deleted=0");
            //构造数据集合
            List<Course> list = new List<Course>();
            //遍历数据表，将数据转存到集合中
            foreach (DataRow row in table.Rows)
            {
                list.Add(new Course()
                {
                    id = Convert.ToInt32(row["id"]),
                    name = row["name"].ToString(),
                    credit = Convert.ToDouble(row["credit"]),
                    teacher = row["teacher"].ToString(),
                    time = Convert.ToInt32(row["time"]),
                    place = row["place"].ToString(),
                    capacity = Convert.ToInt32(row["capacity"]),
                    type = Convert.ToInt32(row["type"]),
                    add_time = Convert.ToDateTime(row["add_time"]),
                    update_time = Convert.ToDateTime(row["update_time"]),
                    deleted = Convert.ToInt32(row["deleted"])
                });
            }
            return list;
        }
    }
}
