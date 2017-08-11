using System;
using System.Collections.Generic;
using System.Text;

namespace BillingServices.CMS.Core.Model
{
    public static class CustomerStatus
    {
        public enum Status { Unknown, InActive, Active};

        public static Status Convert(string status)
        {
             Status convertedStatus = Status.Unknown;

            try {
                switch (status.ToLower())
                {

                    case "active":
                        convertedStatus = Status.Active;
                        break;
                    case "inactive":
                        convertedStatus = Status.InActive;
                        break;
                    case "unknown":
                        convertedStatus = Status.Unknown;
                        break;
                }
            }
            catch (Exception)
            {
                convertedStatus = Status.Unknown;
            }

            return convertedStatus;

        }
    }
}
