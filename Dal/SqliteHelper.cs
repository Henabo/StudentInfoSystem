using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{

    public static class SqliteHelper
    {
        
        private static string connStr = ConfigurationManager.ConnectionStrings["sqlite"].ConnectionString;
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public static int Delete(string sql, params SQLiteParameter[] ps)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddRange(ps);

                conn.Open();

                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sql">sql语句字符串</param>
        /// <param name="ps">sql语句的参数</param>
        /// <returns></returns>
        public static int Add(string sql, params SQLiteParameter[] ps)
        {
            using(SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddRange(ps);

                conn.Open();

                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 更改
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public static int update(string sql, params SQLiteParameter[]ps)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddRange(ps);

                conn.Open();

                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 查询一行一列数据
        /// </summary>
        /// <param name="sql">sql 语句</param>
        /// <param name="param">参数</param>
        /// <returns>返回 首行首列</returns>
        public static object ExecuteScale(string sql, params SQLiteParameter[] ps)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    conn.Open();
                    if (ps != null)
                    {
                        cmd.Parameters.AddRange(ps);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 查询多行数据
        /// </summary>
        /// <param name="sql">sql语句字符串</param>
        /// <returns>
        ///     DataTable返回sql查询的列表
        /// </returns>
        public static DataTable Select(string sql)
        {
            //构造连接对象
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                //构造桥接器对象
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn);
                //数据表对象
                DataTable table = new DataTable();
                //将数据存到table中
                adapter.Fill(table);
                //返回数据表
                return table;
            }
        }
        /// <summary>
        /// 条件查询语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public static DataTable Select(string sql,params SQLiteParameter[] ps)
        {
            //构造连接对象
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                //构造桥接器对象
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn);
                //添加参数
                adapter.SelectCommand.Parameters.AddRange(ps);
                //数据表对象
                DataTable table = new DataTable();
                //将数据存到table中
                adapter.Fill(table);
                //返回数据表
                return table;
            }
        }
    }


}
