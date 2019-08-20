using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHabit
{
    public class WeekDays
    {
        public string day { get; set; }
        public string week { get; set; }
        public string fullDay { get; set; }

        public WeekDays(DateTime date)
        {
            day = date.Day.ToString();
            week = date.DayOfWeek.ToString().Substring(0,3); //We only need  first 3 letters of each weeekDay
            fullDay = $"{date.DayOfWeek.ToString()}, {date.Day.ToString()} {date.ToString("MMMM")}";   // Friday, 2 May - form of current date  
        }
    }
}
