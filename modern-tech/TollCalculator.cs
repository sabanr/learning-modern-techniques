using System;


namespace modern_tech
{
    public static class TollCalculator {

        private enum TimeBand {
            MorningRush,
            DayTime,
            EveningRush,
            Overnight
        }

        private static bool IsWeekDay(DateTime timeOfToll) =>
            timeOfToll.DayOfWeek switch {
                DayOfWeek.Saturday => false,
                DayOfWeek.Sunday => false,
                _ => true

            };

        private static TimeBand GetTimeBand(DateTime timeOfToll) {
            int hour = timeOfToll.Hour;

            if (hour < 6)
                return TimeBand.Overnight;
            else if (hour < 10)
                return TimeBand.MorningRush;
            else if (hour < 16)
                return TimeBand.DayTime;
            else if (hour > 20)
                return TimeBand.EveningRush;
            else {
                return TimeBand.Overnight;
            }
        }

        public static decimal PeakTimePremiumImperative(DateTime timeOfToll, bool inbound) {
            if (IsWeekDay(timeOfToll)) {
                if (inbound) {
                    var timeBand = GetTimeBand(timeOfToll);

                    if (timeBand == TimeBand.MorningRush)
                        return 2.00m;
                    else if (timeBand == TimeBand.DayTime)
                        return 1.50m;
                    else if (timeBand == TimeBand.EveningRush)
                        return 1.00m;
                    else {
                        return 0.75m;
                    }

                } else {
                    var timeBand = GetTimeBand(timeOfToll);

                    if (timeBand == TimeBand.MorningRush)
                        return 1.00m;
                    else if (timeBand == TimeBand.DayTime)
                        return 1.50m;
                    else if (timeBand == TimeBand.EveningRush)
                        return 2.00m;
                    else {
                        return 0.75m;
                    }
                }
            } else {
                return 1.00m;
            }
        }

        // RIGHT WAY! 50 lines of code to 8, plus more clear!

        public static decimal PeakTimePremium(DateTime timeOfToll, bool inbound) =>
            (IsWeekDay(timeOfToll), GetTimeBand(timeOfToll), inbound) switch {
                (true, TimeBand.MorningRush, true) => 2.00m,
                (true, TimeBand.MorningRush, false) => 1.00m,
                (true, TimeBand.DayTime, _) => 1.50m,
                (true, TimeBand.EveningRush, true) => 1.00m,
                (true, TimeBand.EveningRush, false) => 2.00m,
                (true, TimeBand.Overnight, _) => 0.75m,
                (false, _, _) => 1.00m,
            };
    }
}
