using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingSystem
{
    class Global
    {
        public static int count { get; set; } = 0;
        public static string[,] totalArray { get; set; } = new string[100, 100];
        public static int numberOfElement { get; set; } = 0;
        public static List<PointLatLng> globalPoints { get; set; } = new List<PointLatLng>();
        public static bool State { get; set; } 
        public static int index { get; set; }=0;
        public static int move { get; set; } = 0;
    }
}
