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
        public class RegionController : ApiController
        {
            [HttpPost]
            public MVCResult<Region> GetRegion(Region Region)
            {
                return CRUD<Region>.Get(Region);
            }

            [HttpPost]
            public MVCResult<string> InsertRegion(Region model)
            {
                return CRUD<Region>.Add(model);
            }

            [HttpPost]
            public MVCResult<string> UpdateRegion(Region model)
            {
                return CRUD<Region>.Update(model);
            }

            [HttpPost]
            public MVCResult<string> DeleteRegion(Region model)
            {
                return CRUD<Region>.Delete(model);
            }
        }
    }

}
