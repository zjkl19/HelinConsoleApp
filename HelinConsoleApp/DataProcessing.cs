using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelinConsoleApp
{
    public class DataProcessing
    {

        public static IEnumerable<DailyTraffic> GetDailyTraffic(IQueryable<MyHS_Data> table,DateTime StartDataTime,DateTime FinishDataTime)
        {
            DailyTraffic dailyTraffic;
            var currTime = StartDataTime;
            //var cc = table.Where(x => EntityFunctions.TruncateTime(x.HSData_DT)>= EntityFunctions.TruncateTime(StartDataTime)).Count();
            while (currTime.AddDays(1)<=FinishDataTime)
            {
                var k1 = currTime;
                var k2 = currTime.AddDays(1);

                var cc = table.Where(x => x.HSData_DT >= k1 && x.HSData_DT < k2).Count();
                dailyTraffic = new DailyTraffic
                {
                    Date = currTime.ToString("m")
                    ,UpStreamCount = table.Where(x => x.HSData_DT >= k1 && x.HSData_DT < k2 && (x.Lane_Id == 1 || x.Lane_Id == 2)).Count()
                    ,DownStreamCount = table.Where(x => x.HSData_DT >= k1 && x.HSData_DT < k2 && (x.Lane_Id == 3 || x.Lane_Id == 4)).Count()
                    ,TotalStreamCount = table.Where(x => x.HSData_DT >= k1 && x.HSData_DT < k2).Count()

                };
                currTime = k2;
                yield return dailyTraffic;
            }
            
  
        }
    }
}
