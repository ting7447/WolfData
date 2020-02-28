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
        public class EmployeesController : ApiController
        {
            [HttpPost]
            public MVCResult<Employees> GetEmployees(Employees Employees)
            {
                return CRUD<Employees>.Get(Employees);
            }

            [HttpPost]
            public MVCResult<string> InsertEmployees(Employees model)
            {
                return CRUD<Employees>.Add(model);
            }

            [HttpPost]
            public MVCResult<string> UpdateEmployees(Employees model)
            {
                return CRUD<Employees>.Update(model);
            }

            [HttpPost]
            public MVCResult<string> DeleteEmployees(Employees model)
            {
                return CRUD<Employees>.Delete(model);
            }
        }
    }

}
