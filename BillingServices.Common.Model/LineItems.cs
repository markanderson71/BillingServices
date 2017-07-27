using System;
using System.Collections.Generic;
using System.Text;

namespace BillingServices.Common.Model
{
    public class LineItems
    {
        private List<ILineItem> listItems = new List<ILineItem>();

        public void Add(ILineItem item)
        {
            listItems.Add(item);
        }


        public int Count { get { return listItems.Count; } set { } }



    }
}
