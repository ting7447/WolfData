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
        public class SuppliersController : ApiController
        {
            [HttpPost]
            public MVCResult<Suppliers> GetSuppliers(Suppliers Suppliers)
            {
                return CRUD<Suppliers>.Get(Suppliers);
            }

            [HttpPost]
            public MVCResult<string> InsertSuppliers(Suppliers model)
            {
                return CRUD<Suppliers>.Add(model);
            }

            [HttpPost]
            public MVCResult<string> UpdateSuppliers(Suppliers model)
            {
                return CRUD<Suppliers>.Update(model);
            }

            [HttpPost]
            public MVCResult<string> DeleteSuppliers(Suppliers model)
            {
                return CRUD<Suppliers>.Delete(model);
            }
        }
    }

}
