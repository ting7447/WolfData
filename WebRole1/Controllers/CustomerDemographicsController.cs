using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebRole1.Lib;
using WebRole1.Models;

namespace WebRole1.Controllers
{
    public partial class NorthWind
    {
        public class CustomerDemographicsController : ApiController
        {
            [HttpPost]
            public MVCResult<CustomerDemographics> GetCustomerDemographics(CustomerDemographics model)
            {
                return CRUD<CustomerDemographics>.Get(model);
            }

            [HttpPost]
            public MVCResult<string> InsertCustomerDemographics(CustomerDemographics model)
            {
                return CRUD<CustomerDemographics>.Add(model);
            }

            [HttpPost]
            public MVCResult<string> UpdateCustomerDemographics(CustomerDemographics model)
            {
                return CRUD<CustomerDemographics>.Update(model);
            }

            [HttpPost]
            public MVCResult<string> DeleteCustomerDemographics(CustomerDemographics model)
            {
                return CRUD<CustomerDemographics>.Delete(model);
            }
        }
    }

}