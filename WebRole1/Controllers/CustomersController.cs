using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebRole1.Lib;
using WebRole1.Models;

namespace WebRole1.Controllers
{
    public partial class NorthWind
    {
        public class CustomersController : ApiController
        {
            [HttpPost]
            public MVCResult<Customers> GetCustomers(Customers customers)
            {
                return CRUD<Customers>.Get(customers);
            }

            [HttpPost]
            public MVCResult<string> InsertCustomers(Customers model)
            {
                return CRUD<Customers>.Add(model);
            }

            [HttpPost]
            public MVCResult<string> UpdateCustomers(Customers model)
            {
                return CRUD<Customers>.Update(model);
            }

            [HttpPost]
            public MVCResult<string> DeleteCustomers(Customers model)
            {
                return CRUD<Customers>.Delete(model);
            }
        }
    }
}
