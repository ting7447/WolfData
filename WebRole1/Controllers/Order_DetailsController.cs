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
        public class Order_DetailsController : ApiController
        {
            [HttpPost]
            public MVCResult<Order_Details> GetOrder_Details(Order_Details Order_Details)
            {
                return CRUD<Order_Details>.Get(Order_Details);
            }

            [HttpPost]
            public MVCResult<string> InsertOrder_Details(Order_Details model)
            {
                return CRUD<Order_Details>.Add(model);
            }

            [HttpPost]
            public MVCResult<string> UpdateOrder_Details(Order_Details model)
            {
                return CRUD<Order_Details>.Update(model);
            }

            [HttpPost]
            public MVCResult<string> DeleteOrder_Details(Order_Details model)
            {
                return CRUD<Order_Details>.Delete(model);
            }
        }
    }

}
