using System;
using System.Collections.Generic;
using System.Text;

namespace advent_of_code_4
{
    class Sleep
    {
        public int GuardId { get; set; }
        public string MinuteFallingAsleep { get; set; }
        public string MinuteWakingUp { get; set; }
        
        public int GetMinuteDifference()
        {
            var minuteDifference = 0;
            minuteDifference = int.Parse(this.MinuteWakingUp) - int.Parse(this.MinuteFallingAsleep);
            return minuteDifference;
        }
    }
}
