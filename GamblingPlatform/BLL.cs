using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContactInfo.DALayer;

namespace ContactInfo.BLLayer
{
    class BLL
    {
        //DAL m_da = new DAL(@"Data Source=SUDA-20150527FA\SQLSERVER2008;Initial Catalog=ContactInfo;Persist Security Info=True;User ID=sa");
        DAL m_da = new DAL();

        public BLL()
        { }

        /// <summary>
        /// 查询联系人的所有信息
        /// </summary>
        /// <returns>联系人信息表</returns>
        public DataSet select_CardInfo()
        {
            string strSql = "SELECT [ContactID] as 序号,[Name] as 姓名, [Company] as 公司,[Telehone] as 手机,[Email] as 电子邮件,[Client] as 是否代理,[LastCall] as 最后一次通话  FROM [ContactInfo].[dbo].[People]";
            return m_da.exeSqlDataSet(strSql);
        }
    }

}
