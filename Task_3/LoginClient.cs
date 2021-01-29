using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Task_3
{
    class LoginClient
    {   
        private static int _fails;
        private static int _successes;
        private bool _switch;
        private static ConcurrentQueue<User> _users = new ConcurrentQueue<User>();
        public static CountdownEvent Waiter { get; private set; }
        public LoginClient()
        {
            _switch = false;
            ThreadPool.QueueUserWorkItem(TryLogin);
        }

        private void TryLogin(object state)
        {
            while (_users.TryDequeue(out var user))
            {
                if (!string.IsNullOrEmpty(Login(user.Login, user.Password)))
                {
                    Interlocked.Increment(ref _successes);
                }
                else
                {
                    Interlocked.Increment(ref _fails);
                }
                Waiter.Signal();
            } 
        }
        private string Login(string login, string password)
        {
            _switch = !_switch;
            Thread.Sleep((int)(new Random().NextDouble() * 1000));
            if (_switch)
            {
                return Guid.NewGuid().ToString();
            }
            return null;
        }
        public static int GetLoginsCount()
        {
            return _users.Count;
        }
        public static void FillUserList(User[] users)
        {
            if (users.Length == 0 || users == null) return;
            foreach (var user in users)
            {
                _users.Enqueue(user);
            }
        }
        public static (int, int) GetAttempts()
        {
            return (_successes, _fails);
        }
        public static void SetWaiter(int count)
        {
            Waiter = new CountdownEvent(count);
        }
    }
}
