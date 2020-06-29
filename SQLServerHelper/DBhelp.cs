using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;

namespace SQLServerHelper
{
    public class DBhelp
    {
        private static DBhelp dbhelp = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        private DBhelp()
        {
        }

        /// <summary>
        /// 构造单例模式
        /// </summary>
        /// <returns></returns>
        public static DBhelp Create()
        {
            if (dbhelp == null)
                dbhelp = new DBhelp();
            return dbhelp;
        }

        /// <summary>
        /// 连接字符串
        /// </summary>
        string conString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        /// <summary>
        /// 返回一行一列，带参数
        /// </summary>
        /// <param name="sqlstr">sql语句</param>
        /// <param name="sp"></param>
        /// <returns></returns>
        public int ExecuteScalar(string sqlstr, params SqlParameter[] sp)
        {
            SqlConnection con = new SqlConnection(conString);

            try
            {
                con.Open();
                SqlCommand com = new SqlCommand(sqlstr, con);
                com.Parameters.AddRange(sp);
                return (int)com.ExecuteScalar();
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 返回一行一列，不带参数
        /// </summary>
        /// <param name="sqlstr">sql语句</param>
        /// <param name="sp"></param>
        /// <returns></returns>
        public int ExecuteScalar(string sqlstr)
        {
            SqlConnection con = new SqlConnection(conString);

            try
            {
                con.Open();
                SqlCommand com = new SqlCommand(sqlstr, con);

                return Convert.ToInt32(com.ExecuteScalar());
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 返回读取器对象，带参数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sp"></param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string sql, params SqlParameter[] sp)
        {
            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand(sql, con);
                com.Parameters.AddRange(sp);
                return com.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                con.Close();
                throw ex;
            }
        }

        /// <summary>
        /// 返回读取器对象，不带参数
        /// </summary>
        /// <param name="sqlStr">sql语句</param>
        /// <param name="sp"></param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string sqlStr)
        {
            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand(sqlStr, con);
                return com.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                con.Close();
                throw ex;
            }
        }

        /// <summary>
        /// 返回数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sp"></param>
        /// <returns></returns>
        public DataSet ExecuteAdater(string sql, params SqlParameter[] sp)
        {
            SqlConnection con = new SqlConnection(conString);

            try
            {
                SqlCommand com = new SqlCommand(sql, con);
                com.Parameters.AddRange(sp);
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "a");
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 返回数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sp"></param>
        /// <returns></returns>
        public DataSet ExecuteAdater(string sql)
        {
            SqlConnection con = new SqlConnection(conString);

            try
            {
                SqlCommand com = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "a");
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 返回受影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="type"></param>
        /// <param name="sp"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, CommandType type = CommandType.Text, params SqlParameter[] sp)
        {
            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand(sql, con);
                com.Parameters.AddRange(sp);
                com.CommandType = type;
                return com.ExecuteNonQuery();
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 返回受影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql)
        {
            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand(sql, con);
                return com.ExecuteNonQuery();
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 利用自带函数
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableName()
        {
            List<string> rtnTN = new List<string>();
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            string[] restrictions = new string[4];
            restrictions[1] = "dbo";
            //restrictions[2] = "TABLE_NAME";
            DataTable rtntable = conn.GetSchema("Tables", restrictions);
            conn.Close();
            //for (int i = 0; i < rtntable.Rows.Count; i++)
            //{
            //    rtnTN.Add(rtntable.Rows[i]["TABLE_NAME"].ToString());
            //}

            return rtntable;
        }
    }
}
