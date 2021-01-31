using System;
using System.Collections.Generic;


namespace Task_2
{
    public class Settings
    {
        public int PrimesFrom { get; set; }
        public int PrimesTo { get; set; }

        [NonSerialized]
        public static List<Settings> SettingsList = new List<Settings>();

        public Settings(int from, int to)
        {
            PrimesFrom = from;
            PrimesTo = to;           
        }

    }
}
