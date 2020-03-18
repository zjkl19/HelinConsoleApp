using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace HelinConsoleApp
{
    public class MyHS_Data
    {
        public int HSData_Id { get; set; }
        public Nullable<byte> Lane_Id { get; set; }
        public Nullable<System.DateTime> HSData_DT { get; set; }
        public string Oper_Direc { get; set; }
        public Nullable<byte> Axle_Num { get; set; }
        public Nullable<byte> AxleGrp_Num { get; set; }
        public Nullable<int> Gross_Load { get; set; }
        public Nullable<short> Veh_Type { get; set; }
        public Nullable<int> LWheel_1_W { get; set; }
        public Nullable<int> LWheel_2_W { get; set; }
        public Nullable<int> LWheel_3_W { get; set; }
        public Nullable<int> LWheel_4_W { get; set; }
        public Nullable<int> LWheel_5_W { get; set; }
        public Nullable<int> LWheel_6_W { get; set; }
        public Nullable<int> LWheel_7_W { get; set; }
        public Nullable<int> LWheel_8_W { get; set; }
        public Nullable<int> RWheel_1_W { get; set; }
        public Nullable<int> RWheel_2_W { get; set; }
        public Nullable<int> RWheel_3_W { get; set; }
        public Nullable<int> RWheel_4_W { get; set; }
        public Nullable<int> RWheel_5_W { get; set; }
        public Nullable<int> RWheel_6_W { get; set; }
        public Nullable<int> RWheel_7_W { get; set; }
        public Nullable<int> RWheel_8_W { get; set; }
        public Nullable<int> AxleDis1 { get; set; }
        public Nullable<int> AxleDis2 { get; set; }
        public Nullable<int> AxleDis3 { get; set; }
        public Nullable<int> AxleDis4 { get; set; }
        public Nullable<int> AxleDis5 { get; set; }
        public Nullable<int> AxleDis6 { get; set; }
        public Nullable<int> AxleDis7 { get; set; }
        public Nullable<int> Violation_Id { get; set; }
        public Nullable<byte> OverLoad_Sign { get; set; }
        public Nullable<int> Speed { get; set; }
        public Nullable<decimal> Acceleration { get; set; }
        public Nullable<int> Veh_Length { get; set; }
        public Nullable<decimal> QAT { get; set; }
        public string License_Plate { get; set; }
        public string License_Plate_Color { get; set; }
        public string F7Code { get; set; }
        public Nullable<float> ExternInfo { get; set; }
        public Nullable<int> Temp { get; set; }
        public Nullable<int> SiteID { get; set; }
    }
    /// <summary>
    /// 每日交通流量，对应“车流量统计表”
    /// </summary>
    public class DailyTraffic
    {
        public string Date { get; set; }
        public int UpStreamCount { get; set; }

        public int DownStreamCount { get; set; }

        public int TotalStreamCount { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //add 5
            //ldn c8

            int t1, t2, t3, t4, t5, t6, t7, t8;
            int m1, m2, m3, m4, m5, m6, m7, m8;

            var Gross_Load_Div = new int[] { 0, 10_000, 20_000, 30_000 };
            var Gross_Load_Dist = new List<int>();

            var StartDataTime = new DateTime(2019, 8, 13, 0, 0, 0);
            var FinishDataTime = new DateTime(2020, 3, 14, 0, 0, 0);
            var MonthArray = new int[] { 8, 9, 10, 11, 12, 1, 2, 3 };
            int FirstMonth = StartDataTime.Month; int NextMonth = FinishDataTime.Month;
            //Expression<Func<HS_Data_201908, bool>> dataPredicate = x => x.HSData_DT >= StartDataTime && x.HSData_DT <= FinishDataTime;

            try
            {
                using (var db = new HighSpeed_JCBEntities())
                {
                    #region HS_DataForAnalysis
                    var HS_DataForAnalysis = (
                        from e1 in db.HS_Data_201908
                        select new MyHS_Data
                        {
                            Acceleration = e1.Acceleration,
                            AxleGrp_Num = e1.AxleGrp_Num,
                            Axle_Num = e1.Axle_Num,
                            ExternInfo = e1.ExternInfo,
                            F7Code = e1.F7Code,
                            HSData_Id = e1.HSData_Id,
                            Veh_Length = e1.Veh_Length,
                            Veh_Type = e1.Veh_Type,
                            LWheel_1_W = e1.LWheel_1_W,
                            LWheel_2_W = e1.LWheel_2_W,
                            LWheel_3_W = e1.LWheel_3_W,
                            LWheel_4_W = e1.LWheel_4_W,
                            LWheel_5_W = e1.LWheel_5_W,
                            LWheel_6_W = e1.LWheel_6_W,
                            LWheel_7_W = e1.LWheel_7_W,
                            LWheel_8_W = e1.LWheel_8_W,
                            Lane_Id = e1.Lane_Id,
                            Oper_Direc = e1.Oper_Direc,
                            Speed = e1.Speed,
                            OverLoad_Sign = e1.OverLoad_Sign,
                            RWheel_1_W = e1.RWheel_1_W,
                            RWheel_2_W = e1.RWheel_2_W,
                            RWheel_3_W = e1.RWheel_3_W,
                            RWheel_4_W = e1.RWheel_4_W,
                            RWheel_5_W = e1.RWheel_5_W,
                            RWheel_6_W = e1.RWheel_6_W,
                            RWheel_7_W = e1.RWheel_7_W,
                            RWheel_8_W = e1.RWheel_8_W,
                            Violation_Id = e1.Violation_Id,
                            AxleDis1 = e1.AxleDis1,
                            AxleDis2 = e1.AxleDis2,
                            AxleDis3 = e1.AxleDis3,
                            AxleDis4 = e1.AxleDis4,
                            AxleDis5 = e1.AxleDis5,
                            AxleDis6 = e1.AxleDis6,
                            AxleDis7 = e1.AxleDis7,
                            HSData_DT = e1.HSData_DT,
                            Gross_Load = e1.Gross_Load
                        }
                        ).Union(
                        from e2 in db.HS_Data_201909
                        select new MyHS_Data
                        {
                            Acceleration = e2.Acceleration,
                            AxleGrp_Num = e2.AxleGrp_Num,
                            Axle_Num = e2.Axle_Num,
                            ExternInfo = e2.ExternInfo,
                            F7Code = e2.F7Code,
                            HSData_Id = e2.HSData_Id,
                            Veh_Length = e2.Veh_Length,
                            Veh_Type = e2.Veh_Type,
                            LWheel_1_W = e2.LWheel_1_W,
                            LWheel_2_W = e2.LWheel_2_W,
                            LWheel_3_W = e2.LWheel_3_W,
                            LWheel_4_W = e2.LWheel_4_W,
                            LWheel_5_W = e2.LWheel_5_W,
                            LWheel_6_W = e2.LWheel_6_W,
                            LWheel_7_W = e2.LWheel_7_W,
                            LWheel_8_W = e2.LWheel_8_W,
                            Lane_Id = e2.Lane_Id,
                            Oper_Direc = e2.Oper_Direc,
                            Speed = e2.Speed,
                            OverLoad_Sign = e2.OverLoad_Sign,
                            RWheel_1_W = e2.RWheel_1_W,
                            RWheel_2_W = e2.RWheel_2_W,
                            RWheel_3_W = e2.RWheel_3_W,
                            RWheel_4_W = e2.RWheel_4_W,
                            RWheel_5_W = e2.RWheel_5_W,
                            RWheel_6_W = e2.RWheel_6_W,
                            RWheel_7_W = e2.RWheel_7_W,
                            RWheel_8_W = e2.RWheel_8_W,
                            Violation_Id = e2.Violation_Id,
                            AxleDis1 = e2.AxleDis1,
                            AxleDis2 = e2.AxleDis2,
                            AxleDis3 = e2.AxleDis3,
                            AxleDis4 = e2.AxleDis4,
                            AxleDis5 = e2.AxleDis5,
                            AxleDis6 = e2.AxleDis6,
                            AxleDis7 = e2.AxleDis7,
                            HSData_DT = e2.HSData_DT,
                            Gross_Load = e2.Gross_Load
                        }
                        ).Union(
                        from e3 in db.HS_Data_201910
                        select new MyHS_Data
                        {
                            Acceleration = e3.Acceleration,
                            AxleGrp_Num = e3.AxleGrp_Num,
                            Axle_Num = e3.Axle_Num,
                            ExternInfo = e3.ExternInfo,
                            F7Code = e3.F7Code,
                            HSData_Id = e3.HSData_Id,
                            Veh_Length = e3.Veh_Length,
                            Veh_Type = e3.Veh_Type,
                            LWheel_1_W = e3.LWheel_1_W,
                            LWheel_2_W = e3.LWheel_2_W,
                            LWheel_3_W = e3.LWheel_3_W,
                            LWheel_4_W = e3.LWheel_4_W,
                            LWheel_5_W = e3.LWheel_5_W,
                            LWheel_6_W = e3.LWheel_6_W,
                            LWheel_7_W = e3.LWheel_7_W,
                            LWheel_8_W = e3.LWheel_8_W,
                            Lane_Id = e3.Lane_Id,
                            Oper_Direc = e3.Oper_Direc,
                            Speed = e3.Speed,
                            OverLoad_Sign = e3.OverLoad_Sign,
                            RWheel_1_W = e3.RWheel_1_W,
                            RWheel_2_W = e3.RWheel_2_W,
                            RWheel_3_W = e3.RWheel_3_W,
                            RWheel_4_W = e3.RWheel_4_W,
                            RWheel_5_W = e3.RWheel_5_W,
                            RWheel_6_W = e3.RWheel_6_W,
                            RWheel_7_W = e3.RWheel_7_W,
                            RWheel_8_W = e3.RWheel_8_W,
                            Violation_Id = e3.Violation_Id,
                            AxleDis1 = e3.AxleDis1,
                            AxleDis2 = e3.AxleDis2,
                            AxleDis3 = e3.AxleDis3,
                            AxleDis4 = e3.AxleDis4,
                            AxleDis5 = e3.AxleDis5,
                            AxleDis6 = e3.AxleDis6,
                            AxleDis7 = e3.AxleDis7,
                            HSData_DT = e3.HSData_DT,
                            Gross_Load = e3.Gross_Load
                        }
                        ).Union(
                        from e4 in db.HS_Data_201911
                        select new MyHS_Data
                        {
                            Acceleration = e4.Acceleration,
                            AxleGrp_Num = e4.AxleGrp_Num,
                            Axle_Num = e4.Axle_Num,
                            ExternInfo = e4.ExternInfo,
                            F7Code = e4.F7Code,
                            HSData_Id = e4.HSData_Id,
                            Veh_Length = e4.Veh_Length,
                            Veh_Type = e4.Veh_Type,
                            LWheel_1_W = e4.LWheel_1_W,
                            LWheel_2_W = e4.LWheel_2_W,
                            LWheel_3_W = e4.LWheel_3_W,
                            LWheel_4_W = e4.LWheel_4_W,
                            LWheel_5_W = e4.LWheel_5_W,
                            LWheel_6_W = e4.LWheel_6_W,
                            LWheel_7_W = e4.LWheel_7_W,
                            LWheel_8_W = e4.LWheel_8_W,
                            Lane_Id = e4.Lane_Id,
                            Oper_Direc = e4.Oper_Direc,
                            Speed = e4.Speed,
                            OverLoad_Sign = e4.OverLoad_Sign,
                            RWheel_1_W = e4.RWheel_1_W,
                            RWheel_2_W = e4.RWheel_2_W,
                            RWheel_3_W = e4.RWheel_3_W,
                            RWheel_4_W = e4.RWheel_4_W,
                            RWheel_5_W = e4.RWheel_5_W,
                            RWheel_6_W = e4.RWheel_6_W,
                            RWheel_7_W = e4.RWheel_7_W,
                            RWheel_8_W = e4.RWheel_8_W,
                            Violation_Id = e4.Violation_Id,
                            AxleDis1 = e4.AxleDis1,
                            AxleDis2 = e4.AxleDis2,
                            AxleDis3 = e4.AxleDis3,
                            AxleDis4 = e4.AxleDis4,
                            AxleDis5 = e4.AxleDis5,
                            AxleDis6 = e4.AxleDis6,
                            AxleDis7 = e4.AxleDis7,
                            HSData_DT = e4.HSData_DT,
                            Gross_Load = e4.Gross_Load
                        }
                        ).Union(
                        from e5 in db.HS_Data_201912
                        select new MyHS_Data
                        {
                            Acceleration = e5.Acceleration,
                            AxleGrp_Num = e5.AxleGrp_Num,
                            Axle_Num = e5.Axle_Num,
                            ExternInfo = e5.ExternInfo,
                            F7Code = e5.F7Code,
                            HSData_Id = e5.HSData_Id,
                            Veh_Length = e5.Veh_Length,
                            Veh_Type = e5.Veh_Type,
                            LWheel_1_W = e5.LWheel_1_W,
                            LWheel_2_W = e5.LWheel_2_W,
                            LWheel_3_W = e5.LWheel_3_W,
                            LWheel_4_W = e5.LWheel_4_W,
                            LWheel_5_W = e5.LWheel_5_W,
                            LWheel_6_W = e5.LWheel_6_W,
                            LWheel_7_W = e5.LWheel_7_W,
                            LWheel_8_W = e5.LWheel_8_W,
                            Lane_Id = e5.Lane_Id,
                            Oper_Direc = e5.Oper_Direc,
                            Speed = e5.Speed,
                            OverLoad_Sign = e5.OverLoad_Sign,
                            RWheel_1_W = e5.RWheel_1_W,
                            RWheel_2_W = e5.RWheel_2_W,
                            RWheel_3_W = e5.RWheel_3_W,
                            RWheel_4_W = e5.RWheel_4_W,
                            RWheel_5_W = e5.RWheel_5_W,
                            RWheel_6_W = e5.RWheel_6_W,
                            RWheel_7_W = e5.RWheel_7_W,
                            RWheel_8_W = e5.RWheel_8_W,
                            Violation_Id = e5.Violation_Id,
                            AxleDis1 = e5.AxleDis1,
                            AxleDis2 = e5.AxleDis2,
                            AxleDis3 = e5.AxleDis3,
                            AxleDis4 = e5.AxleDis4,
                            AxleDis5 = e5.AxleDis5,
                            AxleDis6 = e5.AxleDis6,
                            AxleDis7 = e5.AxleDis7,
                            HSData_DT = e5.HSData_DT,
                            Gross_Load = e5.Gross_Load
                        }
                        ).Union(
                        from e6 in db.HS_Data_202001
                        select new MyHS_Data
                        {
                            Acceleration = e6.Acceleration,
                            AxleGrp_Num = e6.AxleGrp_Num,
                            Axle_Num = e6.Axle_Num,
                            ExternInfo = e6.ExternInfo,
                            F7Code = e6.F7Code,
                            HSData_Id = e6.HSData_Id,
                            Veh_Length = e6.Veh_Length,
                            Veh_Type = e6.Veh_Type,
                            LWheel_1_W = e6.LWheel_1_W,
                            LWheel_2_W = e6.LWheel_2_W,
                            LWheel_3_W = e6.LWheel_3_W,
                            LWheel_4_W = e6.LWheel_4_W,
                            LWheel_5_W = e6.LWheel_5_W,
                            LWheel_6_W = e6.LWheel_6_W,
                            LWheel_7_W = e6.LWheel_7_W,
                            LWheel_8_W = e6.LWheel_8_W,
                            Lane_Id = e6.Lane_Id,
                            Oper_Direc = e6.Oper_Direc,
                            Speed = e6.Speed,
                            OverLoad_Sign = e6.OverLoad_Sign,
                            RWheel_1_W = e6.RWheel_1_W,
                            RWheel_2_W = e6.RWheel_2_W,
                            RWheel_3_W = e6.RWheel_3_W,
                            RWheel_4_W = e6.RWheel_4_W,
                            RWheel_5_W = e6.RWheel_5_W,
                            RWheel_6_W = e6.RWheel_6_W,
                            RWheel_7_W = e6.RWheel_7_W,
                            RWheel_8_W = e6.RWheel_8_W,
                            Violation_Id = e6.Violation_Id,
                            AxleDis1 = e6.AxleDis1,
                            AxleDis2 = e6.AxleDis2,
                            AxleDis3 = e6.AxleDis3,
                            AxleDis4 = e6.AxleDis4,
                            AxleDis5 = e6.AxleDis5,
                            AxleDis6 = e6.AxleDis6,
                            AxleDis7 = e6.AxleDis7,
                            HSData_DT = e6.HSData_DT,
                            Gross_Load = e6.Gross_Load
                        }
                        ).Union(
                        from e7 in db.HS_Data_202002
                        select new MyHS_Data
                        {
                            Acceleration = e7.Acceleration,
                            AxleGrp_Num = e7.AxleGrp_Num,
                            Axle_Num = e7.Axle_Num,
                            ExternInfo = e7.ExternInfo,
                            F7Code = e7.F7Code,
                            HSData_Id = e7.HSData_Id,
                            Veh_Length = e7.Veh_Length,
                            Veh_Type = e7.Veh_Type,
                            LWheel_1_W = e7.LWheel_1_W,
                            LWheel_2_W = e7.LWheel_2_W,
                            LWheel_3_W = e7.LWheel_3_W,
                            LWheel_4_W = e7.LWheel_4_W,
                            LWheel_5_W = e7.LWheel_5_W,
                            LWheel_6_W = e7.LWheel_6_W,
                            LWheel_7_W = e7.LWheel_7_W,
                            LWheel_8_W = e7.LWheel_8_W,
                            Lane_Id = e7.Lane_Id,
                            Oper_Direc = e7.Oper_Direc,
                            Speed = e7.Speed,
                            OverLoad_Sign = e7.OverLoad_Sign,
                            RWheel_1_W = e7.RWheel_1_W,
                            RWheel_2_W = e7.RWheel_2_W,
                            RWheel_3_W = e7.RWheel_3_W,
                            RWheel_4_W = e7.RWheel_4_W,
                            RWheel_5_W = e7.RWheel_5_W,
                            RWheel_6_W = e7.RWheel_6_W,
                            RWheel_7_W = e7.RWheel_7_W,
                            RWheel_8_W = e7.RWheel_8_W,
                            Violation_Id = e7.Violation_Id,
                            AxleDis1 = e7.AxleDis1,
                            AxleDis2 = e7.AxleDis2,
                            AxleDis3 = e7.AxleDis3,
                            AxleDis4 = e7.AxleDis4,
                            AxleDis5 = e7.AxleDis5,
                            AxleDis6 = e7.AxleDis6,
                            AxleDis7 = e7.AxleDis7,
                            HSData_DT = e7.HSData_DT,
                            Gross_Load = e7.Gross_Load
                        }
                        ).Union(
                        from e8 in db.HS_Data_202003
                        select new MyHS_Data
                        {
                            Acceleration = e8.Acceleration,
                            AxleGrp_Num = e8.AxleGrp_Num,
                            Axle_Num = e8.Axle_Num,
                            ExternInfo = e8.ExternInfo,
                            F7Code = e8.F7Code,
                            HSData_Id = e8.HSData_Id,
                            Veh_Length = e8.Veh_Length,
                            Veh_Type = e8.Veh_Type,
                            LWheel_1_W = e8.LWheel_1_W,
                            LWheel_2_W = e8.LWheel_2_W,
                            LWheel_3_W = e8.LWheel_3_W,
                            LWheel_4_W = e8.LWheel_4_W,
                            LWheel_5_W = e8.LWheel_5_W,
                            LWheel_6_W = e8.LWheel_6_W,
                            LWheel_7_W = e8.LWheel_7_W,
                            LWheel_8_W = e8.LWheel_8_W,
                            Lane_Id = e8.Lane_Id,
                            Oper_Direc = e8.Oper_Direc,
                            Speed = e8.Speed,
                            OverLoad_Sign = e8.OverLoad_Sign,
                            RWheel_1_W = e8.RWheel_1_W,
                            RWheel_2_W = e8.RWheel_2_W,
                            RWheel_3_W = e8.RWheel_3_W,
                            RWheel_4_W = e8.RWheel_4_W,
                            RWheel_5_W = e8.RWheel_5_W,
                            RWheel_6_W = e8.RWheel_6_W,
                            RWheel_7_W = e8.RWheel_7_W,
                            RWheel_8_W = e8.RWheel_8_W,
                            Violation_Id = e8.Violation_Id,
                            AxleDis1 = e8.AxleDis1,
                            AxleDis2 = e8.AxleDis2,
                            AxleDis3 = e8.AxleDis3,
                            AxleDis4 = e8.AxleDis4,
                            AxleDis5 = e8.AxleDis5,
                            AxleDis6 = e8.AxleDis6,
                            AxleDis7 = e8.AxleDis7,
                            HSData_DT = e8.HSData_DT,
                            Gross_Load = e8.Gross_Load
                        }
                        );
                    #endregion
                    Expression<Func<MyHS_Data, bool>> dataPredicate = x => x.HSData_DT >= StartDataTime && x.HSData_DT < FinishDataTime;

                    var table = HS_DataForAnalysis;

                    IEnumerable<DailyTraffic> dailyTrafficData = DataProcessing.GetDailyTraffic(table, StartDataTime, FinishDataTime);
                    //var cc = table.Where(x => EntityFunctions.TruncateTime(x.HSData_DT)>= EntityFunctions.TruncateTime(StartDataTime)).Count();

                    //每日交通流量信息数据导入excel
                    var temp1 = ExportToExcelHelper.ExportDailyTrafficVolume(dailyTrafficData.ToList());
                    
                    //重量前10的车辆数据导入excel
                    List <MyHS_Data> data = table.Where(dataPredicate).OrderByDescending(x => x.Gross_Load).Take(10).ToList();
                    var temp = ExportToExcelHelper.ExportTopGrossLoad(data);
                    
                    
                    var maxGross_Load_Vehicle = table.Where(dataPredicate).OrderByDescending(x => x.Gross_Load).FirstOrDefault();
                    var g1 = maxGross_Load_Vehicle.Gross_Load;
                    var c1 = maxGross_Load_Vehicle.Axle_Num;

                    var l1 = maxGross_Load_Vehicle.AxleDis1 + maxGross_Load_Vehicle.AxleDis2 + maxGross_Load_Vehicle.AxleDis3
                        + maxGross_Load_Vehicle.AxleDis4 + maxGross_Load_Vehicle.AxleDis5 + maxGross_Load_Vehicle.AxleDis6 + maxGross_Load_Vehicle.AxleDis7;


                    Console.WriteLine($"最大车重{g1},轴数{c1},轴距{l1}={maxGross_Load_Vehicle.AxleDis1}+{maxGross_Load_Vehicle.AxleDis2}" +
                        $"+{maxGross_Load_Vehicle.AxleDis3}+{maxGross_Load_Vehicle.AxleDis4}+{maxGross_Load_Vehicle.AxleDis5 }" +
                        $"+{maxGross_Load_Vehicle.AxleDis6}+{maxGross_Load_Vehicle.AxleDis7}");

                    //不同区间车重分布
                    for (int i = 0; i < Gross_Load_Div.Length; i++)
                    {
                        t1 = Gross_Load_Div[i];
                        if (i != Gross_Load_Div.Length - 1)
                        {
                            t2 = Gross_Load_Div[i + 1];
                            Gross_Load_Dist.Add(table.Where(x => x.Gross_Load >= t1 && x.Gross_Load < t2).Where(dataPredicate).Count());
                        }
                        else
                        {
                            Gross_Load_Dist.Add(table.Where(x => x.Gross_Load >= t1).Where(dataPredicate).Count());
                        }
                        Console.WriteLine(Gross_Load_Dist[i]);
                    }
                    try    //结果写入txt（以逗号分隔）
                    {
                        var fs = new FileStream("不同车重区间车辆数.txt", FileMode.Create);
                        var sw = new StreamWriter(fs, Encoding.Default);
                        var writeString = $"{Gross_Load_Dist[0]}";
                        for (int i = 1; i < Gross_Load_Div.Length; i++)
                        {
                            writeString = $"{writeString},{Gross_Load_Dist[i]}";
                        }
                        sw.Write(writeString);
                        sw.Close();
                        fs.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    var Speed_Div = new int[] { 0, 30, 50, 70 };
                    var Speed_Dist = new List<int>();
                    //不同区间车速分布
                    for (int i = 0; i < Speed_Div.Length; i++)
                    {
                        t1 = Speed_Div[i];
                        if (i != Speed_Div.Length - 1)
                        {
                            t2 = Speed_Div[i + 1];
                            Speed_Dist.Add(table.Where(x => x.Speed >= t1 && x.Speed < t2).Where(dataPredicate).Count());
                        }
                        else
                        {
                            Speed_Dist.Add(table.Where(x => x.Speed >= t1).Where(dataPredicate).Count());
                        }
                        Console.WriteLine(Speed_Dist[i]);
                    }
                    try
                    {
                        var fs = new FileStream("不同车速区间车辆数.txt", FileMode.Create);
                        var sw = new StreamWriter(fs, Encoding.Default);
                        var writeString = $"{Speed_Dist[0]}";
                        for (int i = 1; i < Speed_Div.Length; i++)
                        {
                            writeString = $"{writeString},{Speed_Dist[i]}";
                        }
                        sw.Write(writeString);
                        sw.Close();
                        fs.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    //不同车道分布
                    var Lane_Div = new int[] { 1, 2, 3, 4 };
                    var Lane_Dist = new List<int>();
                    for (int i = 0; i < Lane_Div.Length; i++)
                    {
                        t1 = Lane_Div[i];
                        Lane_Dist.Add(table.Where(x => x.Lane_Id == t1).Where(dataPredicate).Count());
                        Console.WriteLine(Lane_Dist[i]);
                    }
                    try
                    {
                        var fs = new FileStream("不同车道车辆数.txt", FileMode.Create);
                        var sw = new StreamWriter(fs, Encoding.Default);
                        var writeString = $"{Lane_Dist[0]}";
                        for (int i = 1; i < Lane_Div.Length; i++)
                        {
                            writeString = $"{writeString},{Lane_Dist[i]}";
                        }
                        sw.Write(writeString);
                        sw.Close();
                        fs.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    var Hour_Div = new int[] { 0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22 };
                    var Hour_Dist = new List<int>();

                    //不同区间小时分布
                    for (int i = 0; i < Hour_Div.Length; i++)
                    {
                        t1 = Hour_Div[i];
                        if (i != Hour_Div.Length - 1)
                        {
                            t2 = Hour_Div[i + 1];
                            //TODO:Convert.ToDateTime(x.HSData_DT)中x.HSData_DT为空时会抛出异常
                            Hour_Dist.Add(table.Where(x => x.HSData_DT.Value.Hour >= t1 && x.HSData_DT.Value.Hour < t2).Where(dataPredicate).Count());
                        }
                        else
                        {
                            Hour_Dist.Add(table.Where(x => x.HSData_DT.Value.Hour >= t1).Where(dataPredicate).Count());
                        }

                        Console.WriteLine(Hour_Dist[i]);
                    }
                    try
                    {
                        var fs = new FileStream("不同小时区间车辆数.txt", FileMode.Create);
                        var sw = new StreamWriter(fs, Encoding.Default);
                        var writeString = $"{Hour_Dist[0]}";
                        for (int i = 1; i < Hour_Div.Length; i++)
                        {
                            writeString = $"{writeString},{Hour_Dist[i]}";
                        }
                        sw.Write(writeString);
                        sw.Close();
                        fs.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    Hour_Div = new int[] { 0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22 };
                    var Hour_Speed_Dist = new List<double?>();

                    //不同小时区间平均车速
                    for (int i = 0; i < Hour_Div.Length; i++)
                    {
                        t1 = Hour_Div[i];
                        if (i != Hour_Div.Length - 1)
                        {
                            t2 = Hour_Div[i + 1];
                            //TODO:Convert.ToDateTime(x.HSData_DT)中x.HSData_DT为空时会抛出异常
                            Hour_Speed_Dist.Add(table.Where(x => x.HSData_DT.Value.Hour >= t1 && x.HSData_DT.Value.Hour < t2).Where(dataPredicate).Average(x => x.Speed));
                        }
                        else
                        {
                            Hour_Speed_Dist.Add(table.Where(x => x.HSData_DT.Value.Hour >= t1).Where(dataPredicate).Average(x => x.Speed));
                        }

                        Console.WriteLine(Hour_Dist[i]);
                    }
                    try
                    {
                        var fs = new FileStream("不同小时区间平均车速.txt", FileMode.Create);
                        var sw = new StreamWriter(fs, Encoding.Default);
                        var writeString = $"{Math.Round(Convert.ToDecimal(Hour_Speed_Dist[0] ?? 0.0), 1)}";
                        for (int i = 1; i < Hour_Div.Length; i++)
                        {
                            writeString = $"{writeString},{Math.Round(Convert.ToDecimal(Hour_Speed_Dist[i] ?? 0.0), 1)}";
                        }
                        sw.Write(writeString);
                        sw.Close();
                        fs.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    //周一至周日车辆数分布
                    var Week_Div = new int[,] {
                         { 5, 6, 0, 1, 2, 3, 4 }
                        , { 2, 3, 4, 5, 6, 0, 1 }
                        , { 0, 1, 2, 3, 4, 5, 6 }
                        , { 4, 5, 6, 0, 1, 2, 3 }
                        , { 2, 3, 4, 5, 6, 0, 1 }
                        , { 6, 0, 1, 2, 3, 4, 5 }
                        , { 3, 4, 5, 6, 0, 1, 2 }
                        , { 2, 3, 4, 5, 6, 0, 1 }
                    };

                    //var Week_Div = new int[] { 6, 0, 1, 2, 3, 4, 5 };    //上一个月份余数
                    //var Week_Div2 = new int[] { 3, 4, 5, 6, 0, 1, 2};    //这个月份余数
                    var Week_Dist = new List<int>();
                    m1 = MonthArray[0]; m2 = MonthArray[1]; m3 = MonthArray[2]; m4 = MonthArray[3];
                    m5 = MonthArray[4]; m6 = MonthArray[5]; m7 = MonthArray[6]; m8 = MonthArray[7];
                    for (int i = 0; i < Week_Div.GetLength(1); i++)    //参考https://www.cnblogs.com/xyrbk/p/6807956.html
                    {
                        t1 = Week_Div[0, i]; t2 = Week_Div[1, i]; t3 = Week_Div[2, i]; t4 = Week_Div[3, i];
                        t5 = Week_Div[4, i]; t6 = Week_Div[5, i]; t7 = Week_Div[6, i]; t8 = Week_Div[7, i];
                        
                        Week_Dist.Add(table.Where(x => (x.HSData_DT.Value.Day % 7 == t1 && x.HSData_DT.Value.Month == m1)
                        || (x.HSData_DT.Value.Day % 7 == t2 && x.HSData_DT.Value.Month == m2)
                        ).Where(dataPredicate).Count());
                        Console.WriteLine(Week_Dist[i]);
                    }
                    try
                    {
                        var fs = new FileStream("周一至周日车辆数.txt", FileMode.Create);
                        var sw = new StreamWriter(fs, Encoding.Default);
                        var writeString = $"{Week_Dist[0]}";
                        for (int i = 1; i < Week_Div.GetLength(1); i++)
                        {
                            writeString = $"{writeString},{Week_Dist[i]}";
                        }
                        sw.Write(writeString);
                        sw.Close();
                        fs.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    Hour_Div = new int[] { 0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22 };
                    var Hour_Weight = new List<int>();

                    //不同区间小时大于40t车数量
                    for (int i = 0; i < Hour_Div.Length; i++)
                    {
                        t1 = Hour_Div[i];
                        if (i != Hour_Div.Length - 1)
                        {
                            t2 = Hour_Div[i + 1];
                            //TODO:Convert.ToDateTime(x.HSData_DT)中x.HSData_DT为空时会抛出异常
                            Hour_Weight.Add(table.Where(x => x.HSData_DT.Value.Hour >= t1 && x.HSData_DT.Value.Hour < t2).Where(dataPredicate).Where(x => x.Gross_Load > 40000).Count());
                        }
                        else
                        {
                            Hour_Weight.Add(table.Where(x => x.HSData_DT.Value.Hour >= t1).Where(dataPredicate).Where(x => x.Gross_Load > 40000).Count());
                        }

                        Console.WriteLine(Hour_Weight[i]);
                    }
                    try
                    {
                        var fs = new FileStream("不同区间小时大于40t车数量.txt", FileMode.Create);
                        var sw = new StreamWriter(fs, Encoding.Default);
                        var writeString = $"{Hour_Weight[0]}";
                        for (int i = 1; i < Hour_Div.Length; i++)
                        {
                            writeString = $"{writeString},{Hour_Weight[i]}";
                        }
                        sw.Write(writeString);
                        sw.Close();
                        fs.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                Console.WriteLine($"计算完成！");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}