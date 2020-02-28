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
        public class TerritoriesController : ApiController
        {
            [HttpPost]
            public MVCResult<Territories> GetTerritories(Territories Territories)
            {
                return CRUD<Territories>.Get(Territories);
            }

            [HttpPost]
            public MVCResult<string> InsertTerritories(Territories model)
            {
                return CRUD<Territories>.Add(model);
            }

            [HttpPost]
            public MVCResult<string> UpdateTerritories(Territories model)
            {
                return CRUD<Territories>.Update(model);
            }

            [HttpPost]
            public MVCResult<string> DeleteTerritories(Territories model)
            {
                return CRUD<Territories>.Delete(model);
            }
        }
    }

}
