using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BillingServices.Common.Model.Test
{
    public class DateRangeTest
    {
        [Fact]
        public void DateRangeThrowsErrorIfDateFromisearlierthandateto()
        {
            Assert.Throws<ArgumentException>(() => new Quarters(new DateTime(2017, 3, 15), new DateTime(2017, 2, 15)));
        }

        [Fact]
        public void DateRangeReturnsCorrectDuractionForAWeek()
        {
            int DaysInWeek = 7;
            DateRange dp = new DateRange(new DateTime(2017, 5, 10), new DateTime(2017, 5, 17));

            Assert.Equal(DaysInWeek, dp.Duration);
        }
    }
}
