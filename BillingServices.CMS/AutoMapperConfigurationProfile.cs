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
            CreateMap<string, string>().ConvertUsing(new NullStringConverter());
            CreateMap<CustomerPostViewModel, Customer>();
        }
    }


    public class NullStringConverter : ITypeConverter<string, string>
    {
       
        public string Convert(string source, string destination, ResolutionContext context)
        {
            if (String.IsNullOrEmpty(source))
            {
                return String.Empty; 
            }
            else
            {
                return source;
            }


        }
    }
}
