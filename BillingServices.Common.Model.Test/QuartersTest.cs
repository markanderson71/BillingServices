using System;
using System.Collections.Generic;
using System.Text;
using BillingServices.Common.Model;
using Xunit;

namespace BillingServices.Common.Model.Test
{
    public class QuartersTest
    {

        [Fact]
        public void datesacrossQuartersGeneratesCorrectQuaters()
        {
            Quarters quarters = new Quarters(new DateTime(2017, 1, 15), new DateTime(2017, 05, 15));

            Assert.Equal(quarters.Count, 2);

        }

        [Fact]
        public void addIncreasesCountByOne()
        {
            Quarters quarters = new Quarters(new DateTime(2017, 1, 15), new DateTime(2017, 05, 15));
            int expectedQuarter = quarters.Count + 1;

            quarters.AddQuarter();
            
            Assert.Equal(quarters.Count, expectedQuarter);
        }

        [Fact]
        public void QuarterItemsforsinglequarterareOne()
        {
            Quarters quarters = new Quarters(new DateTime(2017, 1, 15), new DateTime(2017, 03, 15));
            int expectedQuartterCount = 1;

            Assert.Equal(quarters.Count, expectedQuartterCount);

        }

        [Fact]
        public void ThrowsErrorIfDateFromisearlierthandateto()
        {
            Assert.Throws<ArgumentException>(() => new Quarters(new DateTime(2017, 3, 15), new DateTime(2017, 2, 15)));
        }

    }
}
