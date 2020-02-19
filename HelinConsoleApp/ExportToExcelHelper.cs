using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.Diagnostics;

namespace HelinConsoleApp
{
    /// <summary>
    /// 将重量前n的车辆信息导出到excel
    /// </summary>
    public class ExportToExcelHelper
    {
        /// <summary>
        /// 导出重量前n的车辆信息
        /// </summary>
        /// <returns></returns>
        public static int ExportTopGrossLoad(List<MyHS_Data> data)
        {
            var file = new FileInfo("导出的重量前n车辆数据.xlsx");
            var sheetName = "sheet1";
            try
            {
                using (var package = new ExcelPackage(file))
                {
                    //var worksheet = package.Workbook.Worksheets.Add(sheetName);    //新建
                    var worksheet = package.Workbook.Worksheets[sheetName];    //已有
                    worksheet.Cells[1, 1].Value = "序号"; worksheet.Cells[1, 2].Value = "车道";
                    worksheet.Cells[1, 3].Value = "时间"; worksheet.Cells[1, 4].Value = "方向";
                    worksheet.Cells[1, 5].Value = "轴数"; worksheet.Cells[1, 6].Value = "总重（kg）";
                    worksheet.Cells[1, 7].Value = "车速（km/h）"; worksheet.Cells[1, 8].Value = "轴1重";
                    worksheet.Cells[1, 9].Value = "轴2重"; worksheet.Cells[1, 10].Value = "轴3重";
                    worksheet.Cells[1, 11].Value = "轴4重"; worksheet.Cells[1, 12].Value = "轴5重";
                    worksheet.Cells[1, 13].Value = "轴6重"; worksheet.Cells[1, 14].Value = "轴距1";
                    worksheet.Cells[1, 15].Value = "轴距2"; worksheet.Cells[1, 16].Value = "轴距3";
                    worksheet.Cells[1, 17].Value = "轴距4"; worksheet.Cells[1, 18].Value = "轴距5";
                    for (int i = 0; i < data.Count; i++)
                    {
                        worksheet.Cells[i + 2, 1].Value = i + 1; worksheet.Cells[i + 2, 2].Value = data[i].Lane_Id;
                        worksheet.Cells[i + 2, 3].Value = (data[i].HSData_DT ?? DateTime.Now).ToString("g"); worksheet.Cells[i + 2, 4].Value = data[i].Oper_Direc;
                        worksheet.Cells[i + 2, 5].Value = data[i].Axle_Num;
                        worksheet.Cells[i + 2, 6].Value = data[i].Gross_Load;
                        worksheet.Cells[i + 2, 7].Value = data[i].Speed;
                        worksheet.Cells[i + 2, 8].Value = (data[i].LWheel_1_W + data[i].RWheel_1_W);
                        worksheet.Cells[i + 2, 9].Value = (data[i].LWheel_2_W + data[i].RWheel_2_W);
                        worksheet.Cells[i + 2, 10].Value = (data[i].LWheel_3_W + data[i].RWheel_3_W);
                        worksheet.Cells[i + 2, 11].Value = (data[i].LWheel_4_W + data[i].RWheel_4_W);
                        worksheet.Cells[i + 2, 12].Value = (data[i].LWheel_5_W + data[i].RWheel_5_W);
                        worksheet.Cells[i + 2, 13].Value = (data[i].LWheel_6_W + data[i].RWheel_6_W);
                        worksheet.Cells[i + 2, 14].Value = Math.Round((data[i].AxleDis1 ?? 0.00m) * 0.001m, 2);
                        worksheet.Cells[i + 2, 15].Value = Math.Round((data[i].AxleDis2 ?? 0.00m) * 0.001m, 2);
                        worksheet.Cells[i + 2, 16].Value = Math.Round((data[i].AxleDis3 ?? 0.00m) * 0.001m, 2);
                        worksheet.Cells[i + 2, 17].Value = Math.Round((data[i].AxleDis4 ?? 0.00m) * 0.001m, 2);
                        worksheet.Cells[i + 2, 18].Value = Math.Round((data[i].AxleDis5 ?? 0.00m) * 0.001m, 2);
                    }
                    package.Save();
                }
                return 1;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                return 0;
            }

        }
    }
}
