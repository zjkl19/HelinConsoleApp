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

    class Program
    {
        static void Main(string[] args)
        {
            //add 5
            //ldn c8

            int t1, t2;

            var Gross_Load_Div = new int[] { 0, 10_000, 20_000, 30_000 };
            var Gross_Load_Dist = new List<int>();

            var StartDataTime = new DateTime(2019, 11, 21, 0, 0, 0);
            var FinishDataTime = new DateTime(2019, 12, 21, 0, 0, 0);


            //Expression<Func<HS_Data_201908, bool>> dataPredicate = x => x.HSData_DT >= StartDataTime && x.HSData_DT <= FinishDataTime;

            try
            {
                using (var db = new HighSpeed_JCBEntities())
                {
                    #region HS_DataForAnalysis
                    var HS_DataForAnalysis = (
                        from c in db.HS_Data_201911
                        select new MyHS_Data
                        {
                            Acceleration = c.Acceleration,
                            AxleGrp_Num = c.AxleGrp_Num,
                            Axle_Num = c.Axle_Num,
                            ExternInfo = c.ExternInfo,
                            F7Code = c.F7Code,
                            HSData_Id = c.HSData_Id,
                            Veh_Length = c.Veh_Length,
                            Veh_Type = c.Veh_Type,
                            LWheel_1_W = c.LWheel_1_W,
                            LWheel_2_W = c.LWheel_2_W,
                            LWheel_3_W = c.LWheel_3_W,
                            LWheel_4_W = c.LWheel_4_W,
                            LWheel_5_W = c.LWheel_5_W,
                            LWheel_6_W = c.LWheel_6_W,
                            LWheel_7_W = c.LWheel_7_W,
                            LWheel_8_W = c.LWheel_8_W,
                            Lane_Id = c.Lane_Id,
                            Oper_Direc = c.Oper_Direc,
                            Speed = c.Speed,
                            OverLoad_Sign = c.OverLoad_Sign,
                            RWheel_1_W = c.RWheel_1_W,
                            RWheel_2_W = c.RWheel_2_W,
                            RWheel_3_W = c.RWheel_3_W,
                            RWheel_4_W = c.RWheel_4_W,
                            RWheel_5_W = c.RWheel_5_W,
                            RWheel_6_W = c.RWheel_6_W,
                            RWheel_7_W = c.RWheel_7_W,
                            RWheel_8_W = c.RWheel_8_W,
                            Violation_Id = c.Violation_Id,
                            AxleDis1 = c.AxleDis1,
                            AxleDis2 = c.AxleDis2,
                            AxleDis3 = c.AxleDis3,
                            AxleDis4 = c.AxleDis4,
                            AxleDis5 = c.AxleDis5,
                            AxleDis6 = c.AxleDis6,
                            AxleDis7 = c.AxleDis7,
                            HSData_DT = c.HSData_DT,
                            Gross_Load = c.Gross_Load
                        }
                        ).Union(
                        from e in db.HS_Data_201912
                        select new MyHS_Data
                        {
                            Acceleration = e.Acceleration,
                            AxleGrp_Num = e.AxleGrp_Num,
                            Axle_Num = e.Axle_Num,
                            ExternInfo = e.ExternInfo,
                            F7Code = e.F7Code,
                            HSData_Id = e.HSData_Id,
                            Veh_Length = e.Veh_Length,
                            Veh_Type = e.Veh_Type,
                            LWheel_1_W = e.LWheel_1_W,
                            LWheel_2_W = e.LWheel_2_W,
                            LWheel_3_W = e.LWheel_3_W,
                            LWheel_4_W = e.LWheel_4_W,
                            LWheel_5_W = e.LWheel_5_W,
                            LWheel_6_W = e.LWheel_6_W,
                            LWheel_7_W = e.LWheel_7_W,
                            LWheel_8_W = e.LWheel_8_W,
                            Lane_Id = e.Lane_Id,
                            Oper_Direc = e.Oper_Direc,
                            Speed = e.Speed,
                            OverLoad_Sign = e.OverLoad_Sign,
                            RWheel_1_W = e.RWheel_1_W,
                            RWheel_2_W = e.RWheel_2_W,
                            RWheel_3_W = e.RWheel_3_W,
                            RWheel_4_W = e.RWheel_4_W,
                            RWheel_5_W = e.RWheel_5_W,
                            RWheel_6_W = e.RWheel_6_W,
                            RWheel_7_W = e.RWheel_7_W,
                            RWheel_8_W = e.RWheel_8_W,
                            Violation_Id = e.Violation_Id,
                            AxleDis1 = e.AxleDis1,
                            AxleDis2 = e.AxleDis2,
                            AxleDis3 = e.AxleDis3,
                            AxleDis4 = e.AxleDis4,
                            AxleDis5 = e.AxleDis5,
                            AxleDis6 = e.AxleDis6,
                            AxleDis7 = e.AxleDis7,
                            HSData_DT = e.HSData_DT,
                            Gross_Load = e.Gross_Load
                        }
                        );
                    #endregion
                    Expression<Func<MyHS_Data, bool>> dataPredicate = x => x.HSData_DT >= StartDataTime && x.HSData_DT < FinishDataTime;

                    var table = HS_DataForAnalysis;

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
                    var Week_Div = new int[] { 12, 13, 14, 15, 9, 10, 11 };
                    var Week_Dist = new List<int>();
                    for (int i = 0; i < Week_Div.Length; i++)
                    {
                        t1 = Week_Div[i];
                        Week_Dist.Add(table.Where(x => x.HSData_DT.Value.Day == t1).Where(dataPredicate).Count());
                        Console.WriteLine(Week_Dist[i]);
                    }
                    try
                    {
                        var fs = new FileStream("周一至周日车辆数.txt", FileMode.Create);
                        var sw = new StreamWriter(fs, Encoding.Default);
                        var writeString = $"{Week_Dist[0]}";
                        for (int i = 1; i < Week_Div.Length; i++)
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
                            Hour_Weight.Add(table.Where(x => x.HSData_DT.Value.Hour >= t1 && x.HSData_DT.Value.Hour < t2).Where(dataPredicate).Where(x=>x.Gross_Load>40000).Count());
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