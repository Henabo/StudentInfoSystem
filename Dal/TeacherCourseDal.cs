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
    public class TeacherCourseDal
    {
        public List<TeacherCourse> SelectAll()
        {
            //修改
            DataTable table = SqliteHelper.Select("SELECT * FROM teacher_course where deleted=0");
            //修改
            List<TeacherCourse> list = new List<TeacherCourse>();
            foreach (DataRow row in table.Rows)
            {
                //修改
                list.Add(new TeacherCourse()
                {
                    id = Convert.ToInt32(row["id"]),
                    teacher_id = Convert.ToInt32(row["teacher_id"]),
                    course_id = Convert.ToInt32(row["course_id"]),
                    add_time = Convert.ToDateTime(row["add_time"]),
                    update_time = Convert.ToDateTime(row["update_time"]),
                    deleted = Convert.ToInt32(row["deleted"])
                });
            }
            return list;
        }

        public TeacherCourse SelectById(TeacherCourse model)
        {
            //修改
            string sql = "select * from teacher_course where id=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("id",model.id)
            };
            DataTable table = SqliteHelper.Select(sql, ps);
            //修改
            List<TeacherCourse> list = new List<TeacherCourse>();
            //遍历数据表，将数据转存到集合中
            foreach (DataRow row in table.Rows)
            {
                //修改
                list.Add(new TeacherCourse()
                {
                    id = Convert.ToInt32(row["id"]),
                    teacher_id = Convert.ToInt32(row["teacher_id"]),
                    course_id = Convert.ToInt32(row["course_id"]),
                    add_time = Convert.ToDateTime(row["add_time"]),
                    update_time = Convert.ToDateTime(row["update_time"]),
                    deleted = Convert.ToInt32(row["deleted"])
                });
            }
            //修改
            TeacherCourse model2 = list[0];
            return model2;
        }


        public int Add(TeacherCourse model)
        {
            //修改
            string sql = "insert into teacher_course(teacher_id,course_id,add_time) " +
                "values (@teacher_id,@course_id,@add_time)";
            SQLiteParameter[] ps =
            {
                //修改
                new SQLiteParameter("@teacher_id",model.teacher_id),
                new SQLiteParameter("@course_id",model.course_id),
                new SQLiteParameter("@add_time",DateTime.Now)
            };

            return SqliteHelper.Add(sql, ps);
        }

        public int Update(TeacherCourse model)
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
        private List<Object> updateSQL(TeacherCourse model)
        {
            List<SQLiteParameter> ps = new List<SQLiteParameter>();
            string sql = "update teacher_course set ";
            bool flag = false;
            if (model.teacher_id != 0)
            {
                if (flag)
                {
                    sql += ",";
                }
                sql += "teacher_id=@teacher_id";
                ps.Add(new SQLiteParameter("@teacher_id", model.teacher_id));
                flag = true;
            }
            if (model.course_id != 0)
            {
                if (flag)
                {
                    sql += ",";
                }
                sql += "course_id=@course_id";
                ps.Add(new SQLiteParameter("@course_id", model.course_id));
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
        public int Delete(TeacherCourse model)
        {
            if (SelectById(model).deleted == 1)
            {
                //如果deleted==1，已经删除，返回-2
                return -2;
            }
            //修改
            string sql = "update teacher_course set deleted=1 where id=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@id",model.id),
            };
            return SqliteHelper.Delete(sql, ps);
        }
    }
}
