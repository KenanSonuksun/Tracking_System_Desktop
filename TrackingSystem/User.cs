using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingSystem
{
    class User
    {
        //to convert username to model from database
        public static string UserName {get;set;}
        //to convert password to model from database
        public static string Password { get; set; }
        //to convert state to model from database
        public static bool State { get; set; }
    }
}
