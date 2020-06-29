using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataManager.DALayer;

namespace DataManager.BLLayer
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
            string strSql = "SELECT [ID] as 期数,[FirstNum] as 第一个数,"
                + "[SecondNum] as 第二个数,[ThirdNum] as 第三个数,[FourthNum] as 第四个数,"
                + "[FifthNum] as 第五个数,[SixthNum] as 第六个数,[SeventhNum] as 第七个数 "
                +"FROM [GamblingPlatform].[dbo].[SuperLotto]";
            return m_da.exeSqlDataSet(strSql);
        }
    }

}
