using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using WebRole1.Lib;
using WebRole1.Models;

namespace WebRole1.Controllers
{
    public partial class NorthWind
    {
        public class CategoriesController : ApiController
        {

            [HttpPost]
            public MVCResult<Categories> GetCategories(Categories model)
            {
                return CRUD<Categories>.Get(model);
            }

            [HttpPost]
            public MVCResult<string> InsertCategories(Categories model)
            {
                return CRUD<Categories>.Add(model);
            }

            [HttpPost]
            public MVCResult<string> UpdateCategories(Categories model)
            {
                return CRUD<Categories>.Update(model);
            }

            [HttpPost]
            public MVCResult<string> DeleteCategories(Categories model)
            {
                return CRUD<Categories>.Delete(model);
            }
        }
    }

}