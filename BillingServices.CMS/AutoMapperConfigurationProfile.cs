using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BillingServices.CMS.ViewModel;
using BillingServices.CMS.Core.Model;

namespace BillingServices.CMS
{
    public class AutoMapperConfigurationProfile:Profile
    {
        public AutoMapperConfigurationProfile()
        {
            CreateMap<CustomerPostViewModel, Customer>();
        }
    }
}
