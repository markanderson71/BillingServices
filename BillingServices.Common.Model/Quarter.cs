using System;

namespace BillingServices.Common.Model
{
    public class Quarter
    {


        public Quarter(DateTime dateinQuarter)
        {
            int quarterNumber = (dateinQuarter.Month - 1) / 3 + 1;
            StartDate = new DateTime(dateinQuarter.Year, (quarterNumber - 1) * 3 + 1, 1);
            EndDate = StartDate.AddMonths(3).AddDays(-1);

        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public Quarter Next()
        {
            return new Quarter(EndDate.AddDays(1));
        }






    }
}
