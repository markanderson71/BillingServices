using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingServices.CMS.ViewModel
{
    public class CustomerPostViewModel
    {

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IEnumerable<PhoneNumber> Phone { get; set; }


    }
}
