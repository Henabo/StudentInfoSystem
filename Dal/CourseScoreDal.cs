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
    public class CourseScoreDal
    {
        public List<CourseScore> SelectAll()
        {
            //修改
            DataTable table = SqliteHelper.Select("SELECT * FROM course_score where deleted=0");
            //修改
            List<CourseScore> list = new List<CourseScore>();
            foreach (DataRow row in table.Rows)
            {
                //修改
                list.Add(new CourseScore()
                {
                    id = Convert.ToInt32(row["id"]),
                    student_id = Convert.ToInt32(row["student_id"]),
                    course_id = Convert.ToInt32(row["course_id"]),
                    score = Convert.ToDouble(row["score"]),
                    add_time = Convert.ToDateTime(row["add_time"]),
                    update_time = Convert.ToDateTime(row["update_time"]),
                    deleted = Convert.ToInt32(row["deleted"])
                });
            }
            return list;
        }

        public CourseScore SelectById(CourseScore model)
        {
            //修改
            string sql = "select * from course_score where id=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("id",model.id)
            };
            DataTable table = SqliteHelper.Select(sql, ps);
            //修改
            List<CourseScore> list = new List<CourseScore>();
            //遍历数据表，将数据转存到集合中
            foreach (DataRow row in table.Rows)
            {
                //修改
                list.Add(new CourseScore()
                {
                    id = Convert.ToInt32(row["id"]),
                    student_id = Convert.ToInt32(row["student_id"]),
                    course_id = Convert.ToInt32(row["course_id"]),
                    score = Convert.ToDouble(row["score"]),
                    add_time = Convert.ToDateTime(row["add_time"]),
                    update_time = Convert.ToDateTime(row["update_time"]),
                    deleted = Convert.ToInt32(row["deleted"])
                });
            }
            //修改
            CourseScore model2 = list[0];
            return model2;
        }


        public int Add(CourseScore model)
        {
            //修改
            string sql = "insert into course_score(student_id,course_id,score,add_time) values (@admin_name,@password,@score,@add_time)";
            SQLiteParameter[] ps =
            {
                //修改
                new SQLiteParameter("@student_id",model.student_id),
                new SQLiteParameter("@course_id",model.course_id),
                new SQLiteParameter("@score",model.score),
                new SQLiteParameter("@add_time",DateTime.Now)
            };

            return SqliteHelper.Add(sql, ps);
        }

        public int Update(CourseScore model)
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
        private List<Object> updateSQL(CourseScore model)
        {
            List<SQLiteParameter> ps = new List<SQLiteParameter>();
            string sql = "update course_score set ";
            bool flag = false;
            if (model.student_id != 0)
            {
                if (flag)
                {
                    sql += ",";
                }
                sql += "student_id=@student_id";
                ps.Add(new SQLiteParameter("@student_id", model.student_id));
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

        public int UpdateScore(CourseScore model)
        {
            if (SelectById(model).deleted == 1)
            {
                return -2;
            }
            List<SQLiteParameter> ps = new List<SQLiteParameter>();
            string sql = "update course_score set score=@score where id=@id";
            ps.Add(new SQLiteParameter("@score", model.score));
            ps.Add(new SQLiteParameter("@id", model.id));

            return SqliteHelper.update(sql, ps.ToArray());
        }

        public int Delete(CourseScore model)
        {
            if (SelectById(model).deleted == 1)
            {
                //如果deleted==1，已经删除，返回-2
                return -2;
            }
            //修改
            string sql = "update course_score set deleted=1 where id=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@id",model.id),
            };
            return SqliteHelper.Delete(sql, ps);
        }
    }
}
