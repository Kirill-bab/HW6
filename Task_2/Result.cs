﻿using System;
using System.Collections.Generic;

namespace Task_2
{
    public class Result
    {
        public bool Success { get; }
        public string Error { get; }
        public string Duration { get; }
        public string Primes { get; }

        public Result(bool success, string error, TimeSpan duration, List<int> primes)
        {
            Success = success;
            Error = error;
            Duration = duration.ToString();
            Primes = primes == null ? "null" : $"[{String.Join(",", primes)}]";
        }
    }
}
