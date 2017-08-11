using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingServices.CMS.ViewModel
{
    public class CustomerViewModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public IEnumerable<CustomerPhone> Phone { get; set; }
    }
}
