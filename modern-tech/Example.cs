using System;

namespace modern_tech
{
    public class Example  {
        /// <summary>
        /// Use tuples to return values instead of using out variables
        /// </summary>
        /// <returns></returns>
        public static (DateTime start, DateTime end) GenerateSubscription(DateTime startDate) {

            // WRONG... doesn´t take into account leap years or culture
            _ = new DateTime(startDate.Year + 1, startDate.Month, startDate.Day);

            // CORRECT!
            DateTime end = startDate.AddYears(1);

            return (startDate, end);
        }
    }
}
