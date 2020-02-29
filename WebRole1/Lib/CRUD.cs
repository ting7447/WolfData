using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using WebRole1.Models;
using System.Linq.Dynamic;
using System.ComponentModel.DataAnnotations;

namespace WebRole1.Lib
{
    public class CRUD<T>
        where T : class
    {

        /// <summary>
        /// 取得資料
        /// </summary>
        /// <param name="model">單一或多key值</param>
        /// <returns></returns>
        public static MVCResult<T> Get(T model)
        {
            var result = new MVCResult<T>();
            try
            {
                T obj = default(T);
                obj = Activator.CreateInstance<T>();
                PropertyInfo[] pis = obj.GetType().GetProperties();
                
                string keyId = "";
                string sqlstring = "1 = 1 ";

                foreach (var pi in pis)
                {
                    //判斷attribute是否為key
                    var keyAttribute =   
                        Attribute.GetCustomAttribute(
                            pi, 
                            typeof(KeyAttribute)
                        ) as KeyAttribute;

                    if (!string.IsNullOrEmpty(pi.Name) &&
                        keyAttribute != null)
                    {
                        keyId = pi.Name;
                        if (model != null)
                        {
                            object objVal = model.GetType().GetProperty(keyId).GetValue(model);
                            if(objVal != null)
                            {
                                var columnValue = model.GetType().GetProperty(keyId).GetValue(model).ToString();
                                string datatype = model.GetType().GetProperty(keyId).PropertyType.Name;
                                if (!string.IsNullOrEmpty(columnValue))
                                {
                                    sqlstring += " AND " + keyId + " = ";
                                    if (datatype == "String")
                                        sqlstring += "'";
                                    sqlstring += columnValue ;
                                    if (datatype == "String")
                                        sqlstring += "'";
                                }
                            }

                        }
                    }
                }

                NorthWindEntities entity = new NorthWindEntities();
                IQueryable<T> query;
                DbSet<T> db = entity.Set<T>();

                query = db.Where(sqlstring);
                result.SetSuccess(query.Count(), SQLType.Select);
                result.PayLoad = query.ToList();
                return result;
            }
            catch(Exception ex)
            {
                result.SetError(ex.Message);
                return result;
            }
        }

        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static MVCResult<string> Add(T model)
        {
            var result = new MVCResult<string>();
            try
            {
                using (NorthWindEntities entity = new NorthWindEntities())
                {
                    entity.Set<T>().Add(model);
                    result.SetSuccess(entity.SaveChanges(),SQLType.Insert);
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
                return result;
            }
        }

        /// <summary>
        /// 修改資料 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static MVCResult<string> Update(T model)
        {
            var result = new MVCResult<string>();
            try
            {
                using (NorthWindEntities entity = new NorthWindEntities())
                {
                    entity.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    result.SetSuccess(entity.SaveChanges(),SQLType.Update);
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
                return result;
            }
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static MVCResult<string> Delete(T model)
        {
            var result = new MVCResult<string>();
            try
            {
                using (NorthWindEntities entity = new NorthWindEntities())
                {
                    //T obj = entity.Set<T>().Find(model);
                    entity.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                    entity.Set<T>().Remove(model);
                    result.SetSuccess(entity.SaveChanges(),SQLType.Delete);
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