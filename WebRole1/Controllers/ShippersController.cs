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
        public class ShippersController : ApiController
        {
            [HttpPost]
            public MVCResult<Shippers> GetShippers(Shippers Shippers)
            {
                return CRUD<Shippers>.Get(Shippers);
            }

            [HttpPost]
            public MVCResult<string> InsertShippers(Shippers model)
            {
                return CRUD<Shippers>.Add(model);
            }

            [HttpPost]
            public MVCResult<string> UpdateShippers(Shippers model)
            {
                return CRUD<Shippers>.Update(model);
            }

            [HttpPost]
            public MVCResult<string> DeleteShippers(Shippers model)
            {
                return CRUD<Shippers>.Delete(model);
            }
        }
    }

}
