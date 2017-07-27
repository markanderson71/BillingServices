using System;
using System.Collections.Generic;
using System.Text;

namespace BillingServices.Common.Model
{
    public class DateRange
    {


        public DateRange(DateTime dateFrom , DateTime dateTo)
        {

            if (dateFrom > dateTo)
            {
                throw new ArgumentException(" Argument datefrom is smaller than argument dateto");
            }

            this.DateFrom = dateFrom;
            this.DateTo = dateTo;
        }

        public DateTime DateFrom { get; private set; }
        public DateTime DateTo { get; private set; }

        public int Duration { get { return DateTo.Subtract(DateFrom).Days; } set { } }


    }
}
