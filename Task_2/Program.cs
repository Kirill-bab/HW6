using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using Library;
using System.Threading;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var exception = "null";
            bool success = true;
            var timer = Stopwatch.StartNew();
            var primes = new List<int>();
            try
            {
                SetUp();
                primes = PrimesListLocker.GetPrimes();
            }
            catch (Exception e)
            {
                exception = e.GetType().ToString();
                success = false;
                primes = null;
            }
            timer.Stop();

            TearDown(exception, success, timer.Elapsed, primes);
        }

        private static void SetUp()
        {
            Settings.SettingsList = JsonConverter.
                Deserialize<List<Settings>>(FileWorker.Read("settings.json"));
            Settings.SettingsList.RemoveAll(s => s == null);

            PrimesListLocker.SetWaiter(Settings.SettingsList.Count);
        }

        private static void TearDown(string exception, bool success, TimeSpan duration, List<int> primes)
        {
            var result = new Result(success, exception, duration, primes);
            FileWorker.Write("result.json",JsonConverter.Serialize(result));
        }

        

        
    }
}
