using Library;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Task_2
{
    public static class PrimesListLocker
    {
        private static readonly object _sync = new object();
        private static List<int> _primes = new List<int>();
        private static CountdownEvent _waiter;
        public static List<int> GetPrimes()
        {
            foreach (var settings in Settings.SettingsList)
            {
                new Thread(delegate (object state) { AddPrimesToListLock(settings); }).Start();
            }
            _waiter.Wait();
            _primes = _primes.Distinct().OrderBy(n => n).ToList();
            return _primes;
        }
        public static void SetWaiter(int initalCount)
        {
            _waiter = new CountdownEvent(initalCount);
        }
        private static void AddPrimesToListLock(Settings settings)
        {
            lock (_sync)
            {
                _primes.AddRange(new PrimesSearcher(settings.PrimesFrom, settings.PrimesTo).FindPrimes(true));
            }
            _waiter.Signal();
        }
    }
}
