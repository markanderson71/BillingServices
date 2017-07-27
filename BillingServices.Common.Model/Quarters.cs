using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BillingServices.Common.Model
{
    public class Quarters
    {

        List<Quarter> quarters = new List<Quarter>();

        public Quarters(DateTime dateFrom, DateTime dateTo)
        {
            if (dateFrom > dateTo)
            { 
                throw new ArgumentException(" Argument datefrom is smaller than argument dateto");
            }
                
            Quarter newQuarterDate = new Quarter(dateFrom);
            quarters.Add(newQuarterDate);
            
            while(dateTo > newQuarterDate.EndDate)
            {
                newQuarterDate = newQuarterDate.Next();
                quarters.Add(newQuarterDate);
            }                        
        }

        public IEnumerable<Quarter> QuarterItems { get; private set; }

        public int Count { get { return quarters.Count; } private set { } }

        public void AddQuarter() { quarters.Add(quarters.Last().Next()); }
    }
}
