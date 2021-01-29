using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using Library;



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
