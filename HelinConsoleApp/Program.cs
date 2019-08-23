using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelinConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //ldn c5

            int t1, t2;

            var Gross_Load_Div = new int[] { 0,10_000,20_000,30_000 };
            var Gross_Load_Dist = new List<int>();

            var StartDataTime = new DateTime(2019,8,14,0,0,0);
            var FinishDataTime = new DateTime(2019, 8, 20, 23, 59, 59);

            try
            {
                using (var db =new HighSpeed_JCBEntities())
                {
                    //不同区间车重分布
                    for (int i = 0; i < Gross_Load_Div.Length; i++)
                    {
                        t1 = Gross_Load_Div[i];
                        if (i != Gross_Load_Div.Length - 1)
                        {
                            t2 = Gross_Load_Div[i + 1];
                            Gross_Load_Dist.Add(db.HS_Data.Where(x => x.Gross_Load >= t1 && x.Gross_Load < t2 && x.HSData_DT>=StartDataTime && x.HSData_DT<=FinishDataTime).Count());
                        }
                        else
                        {
                            Gross_Load_Dist.Add(db.HS_Data.Where(x => x.Gross_Load >= t1 && x.HSData_DT >= StartDataTime && x.HSData_DT <= FinishDataTime).Count());
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

                    var Speed_Div = new int[] { 0, 20, 30, 40 };
                    var Speed_Dist = new List<int>();
                    //不同区间车速分布
                    for (int i = 0; i < Speed_Div.Length; i++)
                    {
                        t1 = Speed_Div[i];
                        if (i != Speed_Div.Length - 1)
                        {
                            t2 = Speed_Div[i + 1];
                            Speed_Dist.Add(db.HS_Data.Where(x => x.Speed >= t1 && x.Speed < t2 && x.HSData_DT >= StartDataTime && x.HSData_DT <= FinishDataTime).Count());
                        }
                        else
                        {
                            Speed_Dist.Add(db.HS_Data.Where(x => x.Speed >= t1 && x.HSData_DT >= StartDataTime && x.HSData_DT <= FinishDataTime).Count());
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
                        Lane_Dist.Add(db.HS_Data.Where(x => x.Lane_Id ==t1 && x.HSData_DT >= StartDataTime && x.HSData_DT <= FinishDataTime).Count());
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
                            Hour_Dist.Add(db.HS_Data.Where(x => x.HSData_DT.Value.Hour >= t1 && x.HSData_DT.Value.Hour < t2 && x.HSData_DT >= StartDataTime && x.HSData_DT <= FinishDataTime).Count());
                        }
                        else
                        {
                            Hour_Dist.Add(db.HS_Data.Where(x => x.HSData_DT.Value.Hour >= t1 && x.HSData_DT >= StartDataTime && x.HSData_DT <= FinishDataTime).Count());
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
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
