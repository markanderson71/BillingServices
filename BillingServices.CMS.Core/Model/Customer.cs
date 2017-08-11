using System;
using System.Collections.Generic;
using System.Text;


namespace BillingServices.CMS.Core.Model
{
    public class Customer
    {

        public Customer()
        {
            FirstName = string.Empty;
            MiddleName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;

        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get ; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Status { get; private set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public IEnumerable<CustomerPhone> Phone { get; set; }

        public void SetStatus(CustomerStatus.Status status)
        {
            this.Status = status.ToString();
        } 

    }
}
