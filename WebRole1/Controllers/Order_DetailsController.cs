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

            /// <summary>
            /// 使用CustomId選取訂單明細內容
            /// </summary>
            /// <param name="customer"></param>
            /// <returns></returns>
            [HttpPost]
            public MVCResult<Order_Details> GetOrderDetailByCustomerId(Customers customer)
            {
                MVCResult<Order_Details> result = new MVCResult<Order_Details>();
                result.PayLoad = new List<Order_Details>();
                try
                {
                    NorthWindEntities entity = new NorthWindEntities();
                    List<Order_Details> orderDetailList = entity.Order_Details.Where(x => x.Orders.CustomerID == customer.CustomerID).ToList();

                    result.PayLoad = orderDetailList;
                    result.SetSuccess(orderDetailList.Count(), SQLType.Select);
                    return result;
                }
                catch (Exception ex)
                {
                    result.SetError(ex.Message);
                    return result;
                }
            }

        }
    }

}
