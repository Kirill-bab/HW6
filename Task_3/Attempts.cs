using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
    public class Attempts
    {
        public int Successes { get; set; }
        public int Fails { get; set; }

        public Attempts( int successes, int fails)
        {
            Successes = successes;
            Fails = fails;
        }
    }
}
