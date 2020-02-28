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
        public class ProductsController : ApiController
        {
            [HttpPost]
            public MVCResult<Products> GetProducts(Products Products)
            {
                return CRUD<Products>.Get(Products);
            }

            [HttpPost]
            public MVCResult<string> InsertProducts(Products model)
            {
                return CRUD<Products>.Add(model);
            }

            [HttpPost]
            public MVCResult<string> UpdateProducts(Products model)
            {
                return CRUD<Products>.Update(model);
            }

            [HttpPost]
            public MVCResult<string> DeleteProducts(Products model)
            {
                return CRUD<Products>.Delete(model);
            }
        }
    }

}
