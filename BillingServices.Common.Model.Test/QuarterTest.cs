using System;
using Xunit;
using BillingServices.Common.Model;

namespace BillingServices.Common.Model.Test
{
    public class QuarterTest
    {
        [Fact]
        public  void FirstDayOfQuarterIsStartDate()
        {
            Quarter quarter = new Quarter(new DateTime(2017, 01, 05));

            Assert.True(DateTime.Equals(quarter.StartDate, new DateTime(2017, 1, 1)));
        }

        [Fact]
        public void LastDayOfQuarterIsEndDate()
        {
            Quarter quarter = new Quarter(new DateTime(2017, 01, 05));

            Assert.True(DateTime.Equals(quarter.EndDate, new DateTime(2017, 03, 31)));
        }


        [Fact]
        public void NextQuarterStartDateIsStartDate()
        {
            Quarter quarter = new Quarter(new DateTime(2017, 01, 05));
            Quarter nextQuarter = quarter.Next();

            Assert.True(DateTime.Equals(nextQuarter.EndDate, new DateTime(2017, 06, 30)));
        }
     
        
    }
}


