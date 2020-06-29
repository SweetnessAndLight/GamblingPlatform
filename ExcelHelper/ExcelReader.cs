using System;
using System.IO;
using System.Collections;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.POIFS;
using NPOI.Util;
using System.Data;

namespace ExcelHelper
{
    public class ExcelReader
    {
        HSSFWorkbook hssfWorkbook;

        public DataTable ReadExcelFile(string filePath)
        {
            DataTable dt=new DataTable();

            #region 初始化信息
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    hssfWorkbook = new HSSFWorkbook(fileStream);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion

            ISheet sheet = hssfWorkbook.GetSheetAt(0);
            IEnumerator rows = sheet.GetRowEnumerator();

            for (int i = 0; i < (sheet.GetRow(0).LastCellNum); i++)
            {
                dt.Columns.Add((Convert.ToChar((int)'A') + i).ToString());
            }

            while (rows.MoveNext())
            {
                HSSFRow row = (HSSFRow)rows.Current;
                DataRow dr = dt.NewRow();
                for (int i = 0; i < row.LastCellNum; i++)
                {
                    ICell cell = row.GetCell(i);
                    if (cell == null)
                    {
                        dr[i] = null;
                    }
                    else
                    {
                        dr[i] = cell.ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
                return dt;
        }
    }
}