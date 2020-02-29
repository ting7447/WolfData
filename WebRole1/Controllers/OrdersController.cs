using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebRole1.Lib;
using WebRole1.Models;
using Newtonsoft.Json;

namespace WebRole1.Controllers
{
    public partial class NorthWind
    {
        public class OrdersController : ApiController
        {
            [HttpPost]
            public MVCResult<Orders> GetOrders(Orders Orders)
            {
                MVCResult<Orders> orders = CRUD<Orders>.Get(Orders);
                return orders;
            }

            [HttpPost]
            public MVCResult<string> InsertOrders(Orders model)
            {
                return CRUD<Orders>.Add(model);
            }

            [HttpPost]
            public MVCResult<string> UpdateOrders(Orders model)
            {
                return CRUD<Orders>.Update(model);
            }

            [HttpPost]
            public MVCResult<string> DeleteOrders(Orders model)
            {
                return CRUD<Orders>.Delete(model);
            }

        }
    }

}
