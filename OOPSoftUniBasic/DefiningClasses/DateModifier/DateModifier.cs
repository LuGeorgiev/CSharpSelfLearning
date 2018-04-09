using System;
using System.Collections.Generic;
using System.Linq;

namespace DateModifier
{
    public class DateModifier
    {
        private int dateDifference;

        public int DateDifference
        {
            get { return dateDifference; }
            private set { dateDifference = value; }
        }

        public DateModifier(string firstDate, string secondDate)
        {
            var firstInfo = firstDate.Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var secondInfo = secondDate.Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var initialDate = new DateTime(firstInfo[0], firstInfo[1], firstInfo[2]);
            var endDate = new DateTime(secondInfo[0], secondInfo[1], secondInfo[2]);

            var timeSpan = endDate - initialDate;

            this.DateDifference = Math.Abs((int)timeSpan.TotalDays);
        }
    }
}
