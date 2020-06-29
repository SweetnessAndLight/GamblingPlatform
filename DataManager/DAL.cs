using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data .SqlClient;

namespace DataManager.DALayer
{
    class DAL
    {
        SqlConnection sqlConn = new SqlConnection();
        SqlCommand sqlCmd = new SqlCommand();
        SqlDataAdapter sqlDtAdpt = new SqlDataAdapter();

        public DAL()
        {
            this.sqlConn.ConnectionString = @"Data Source=SUDA-20150527FA\SQLSERVER2008;Initial Catalog=ContactInfo;Persist Security Info=True;User ID=sa;Password=123456";
        }

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public void Open()
        {
            if (sqlConn.State != System.Data.ConnectionState.Open)
            {
                sqlConn.Open();
            }
        }


        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void Close()
        {
            if (sqlConn.State != System.Data.ConnectionState.Closed)
            {
                sqlConn.Close();
            }
        }


        /// <summary>
        /// 执行Sql语句
        /// </summary>
        /// <param name="strSql">Sql语句</param>
        /// <returns>执行所影响行数</returns>
        public int exeSql(string strSql)
        {
            try
            {
                sqlCmd.Connection = sqlConn;
                sqlCmd.CommandText = strSql;
                sqlCmd.CommandType = CommandType.Text;
                Open();
                return sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("对数据库执行操作失败！\n\r详细信息：" + ex.Message.ToString());
            }
            finally
            {
                Close();
            }
        }


        /// <summary>
        /// 执行Sql语句，返回查询结果集第一行第一列
        /// </summary>
        /// <param name="strSql">Sql语句</param>
        /// <returns>查询结果集第一行第一列</returns>
        public object exeSqlScaler(string strSql)
        {
            try
            {
                sqlCmd.Connection = sqlConn;
                sqlCmd.CommandText = strSql;
                sqlCmd.CommandType = CommandType.Text;
                Open();
                return sqlCmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("对数据库执行操作失败！\n\r详细信息：" + ex.Message.ToString());
            }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// 执行Sql语句，返回DataSet数据集
        /// </summary>
        /// <param name="QueryString">Sql语句</param>
        /// <returns>查询结果数据集</returns>
        public DataSet exeSqlDataSet(string strSql)
        {
            using (DataSet dst = new DataSet())
            {
                try
                {
                    Open();

                    sqlCmd.Connection = sqlConn;
                    sqlCmd.CommandText = strSql;
                    sqlCmd.CommandType = CommandType.Text;

                    sqlDtAdpt.SelectCommand = sqlCmd;
                    sqlDtAdpt.Fill(dst);

                    return dst;
                }
                catch (Exception ex)
                {
                    throw new Exception("对数据库执行操作失败！\n\r详细信息：" + ex.Message.ToString());
                }
                finally
                {
                    Close();
                }
            }


        }
    }
}
