using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace advent_of_code_4
{
    class Program
    {
        public static List<Sleep> SleepList;
        public static List<Guard> GuardList;

        static void Main(string[] args)
        {
            var unsortedInput = @"../../../input.txt";
            List<string> SortedInput = File.ReadLines(unsortedInput).OrderBy(s => s).ToList();

            Guard guard = null;
            Sleep sleep = null;
            GuardList = new List<Guard>();
            SleepList = new List<Sleep>();
            foreach (var row in SortedInput)
            {
                if (row.Contains("#"))
                {
                    guard = new Guard
                    {
                        Id = int.Parse(row.Substring(26, 4))
                    };
                }
                else if (row.Contains("asleep") && guard != null)
                {
                    sleep = new Sleep
                    {
                        GuardId = guard.Id,
                        MinuteFallingAsleep = row.Substring(15, 2)
                    };
                }
                else if (row.Contains("wakes"))
                {
                    sleep.MinuteWakingUp = row.Substring(15, 2);
                    SleepList.Add(sleep);
                    
                    if (!GuardList.Any(p => p.Id == guard.Id))
                    {
                        guard.SleepLists = SleepList.Where(x => x.GuardId == guard.Id).ToList();
                        GuardList.Add(guard);
                    }
                    else
                    {
                        Guard oldGuard = GuardList.Find(p => p.Id == guard.Id);
                        if (oldGuard.SleepLists != null)
                        {
                            oldGuard.SleepLists.Add(sleep);
                        }
                    }
                    
                }
            }

            foreach(Guard g in GuardList)
            {
                g.CountTotalSleep();
                g.CountMinuteMostAsleep();
            }

            //Strategy One
            GuardList.Sort((x, y) => x.TotalSleep.CompareTo(y.TotalSleep));
            var guardMostAsleep = GuardList.Last();
            Console.WriteLine(
                "Id: {0} Minute most often spent asleep: {1} Times spent sleeping during that minute: {2} Total sleep: {3} Answer: {4}",
                guardMostAsleep.Id,
                guardMostAsleep.MinuteMostAsleep,
                guardMostAsleep.TimesAsleepMostMinute,
                guardMostAsleep.TotalSleep,
                (guardMostAsleep.Id * guardMostAsleep.MinuteMostAsleep)
            );

            //Strategy Two
            GuardList.Sort((x, y) => x.TimesAsleepMostMinute.CompareTo(y.TimesAsleepMostMinute));
            var guardMostSameMinute = GuardList.Last();
            Console.WriteLine(
                "Id: {0} Minute most often spent asleep: {1} Times spent sleeping during that minute: {2} Total sleep: {3} Answer: {4}",
                guardMostSameMinute.Id,
                guardMostSameMinute.MinuteMostAsleep,
                guardMostSameMinute.TimesAsleepMostMinute,
                guardMostSameMinute.TotalSleep,
                (guardMostSameMinute.Id * guardMostSameMinute.MinuteMostAsleep)
            );

            Console.ReadKey();
        }
    }
}
