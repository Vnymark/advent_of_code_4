using System;
using System.Collections.Generic;
using System.Text;

namespace advent_of_code_4
{
    class Guard
    {
        public int Id { get; set; }
        public List<Sleep> SleepLists { get; set; }
        public int TotalSleep { get; set; }
        public int MinuteMostAsleep { get; set; }
        public int TimesAsleepMostMinute { get; set; }
        
        public void CountTotalSleep()
        {
            var totalSleep = 0;
            if (this.SleepLists != null)
            {
                foreach (var sleep in this.SleepLists)
                {
                    if (sleep.GuardId == this.Id)
                    {
                        totalSleep += sleep.GetMinuteDifference();
                    }
                }
            }
            this.TotalSleep = totalSleep;
        }
        
        public void CountMinuteMostAsleep()
        {
            List<int> returnList = new List<int>();
            var returnMinute = 0;
            int[] minutes = new int[60];
            if (this.SleepLists != null)
            {
                foreach (var sleep in this.SleepLists)
                {
                    int i = 0;
                    while (i < 60)
                    {
                        if (i < int.Parse(sleep.MinuteWakingUp) && i >= int.Parse(sleep.MinuteFallingAsleep))
                        {
                            minutes[i] += 1;
                        }
                        i++;
                    }
                }
            }

            var mostMinuteAsleep = 0;
            var m = 0;
            foreach (var minute in minutes)
            {
                if (minute > mostMinuteAsleep)
                {
                    mostMinuteAsleep = minute;
                    returnMinute = m;
                }
                m++;
            }
            this.MinuteMostAsleep = returnMinute;
            this.TimesAsleepMostMinute= mostMinuteAsleep;
        }
    }
}
