using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using WebRole1.Lib;
using WebRole1.Models;

namespace WebRole1.Controllers
{
    public class CategoriesController : ApiController
    {

        [HttpPost]
        public MVCResult<Categories> GetCategories(int? categoryId)
        {
            var result = new MVCResult<Categories>();
            try
            {
                NorthWindEntities entity = new NorthWindEntities();
                IQueryable<Categories> query;
                DbSet<Categories> db = entity.Categories;
               
                if (categoryId != null)
                {
                    query = db.Where(x => x.CategoryID == categoryId);
                }
                else
                {
                    query = db;
                }
                
                result.PayLoad = query.ToList();
                return result;
            }
            catch(Exception ex)
            {
                result.SetError(ex.Message);
                return result;
            }
        }

        [HttpPost]
        public MVCResult<string> InsertCategories(Categories model)
        {
            var result = new MVCResult<string>();
            try
            {
                using (NorthWindEntities entity = new NorthWindEntities())
                {
                    entity.Categories.Add(model);
                    result.SetSuccess(entity.SaveChanges());
                    return result;
                }
            }
            catch(Exception ex)
            {
                result.SetError(ex.Message);
                return result;
            }
        }

        [HttpPost]
        public MVCResult<string> UpdateCategories(Categories model)
        {
            var result = new MVCResult<string>();
            try
            {
                using (NorthWindEntities entity = new NorthWindEntities())
                {
                    entity.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    result.SetSuccess(entity.SaveChanges());
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
                return result;
            }
        }

        [HttpPost]
        public MVCResult<string> DeleteCategories(int categoryId)
        {
            var result = new MVCResult<string>();
            try
            {
                using (NorthWindEntities entity = new NorthWindEntities())
                {
                    Categories model = entity.Categories.Find(categoryId);
                    entity.Categories.Remove(model);
                    result.SetSuccess(entity.SaveChanges());
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
                return result;
            }
        }

    }
}