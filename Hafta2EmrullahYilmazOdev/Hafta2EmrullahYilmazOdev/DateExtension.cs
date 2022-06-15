using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta2EmrullahYilmazOdev
{
    public static class DateExtension
{
        public static string GetDate(this DateTime date, DateTime dtbefore)
        {        
            TimeSpan diffResult = date - dtbefore; //differecence
            string result =($"{diffResult.Days} gün { diffResult.Hours} saat {diffResult.Minutes} dakika önce");
            return result;
        }

    }   
}
