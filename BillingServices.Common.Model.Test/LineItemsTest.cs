using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using BillingServices.Common.Model;

namespace BillingServices.Common.Model.Test
{

    public class LineItemsTest
    {
        [Fact]
        public void AddingOneLineItemGetsCountofone()
        {

            LineItems li = new LineItems();

            SingleLineItem sli = new SingleLineItem();
            li.Add(sli);

            Assert.Equal(1, li.Count);
            



        }


    }
}
