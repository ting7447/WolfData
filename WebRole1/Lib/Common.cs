using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WebRole1.Lib
{
    public class Common<T>

    {
        /// <summary>
        /// 取出Entity名稱，並檢查PK是否存在
        /// </summary>
        public void GetKeyId(T model)
        {
            string keyId = "";
            T EntityObj = default(T);
            EntityObj = Activator.CreateInstance<T>();
            PropertyInfo[] pis = EntityObj.GetType().GetProperties();
            foreach (var pi in pis)
            {
                if (!string.IsNullOrEmpty(pi.Name) &&
                    pi.Name.ToLower().Contains("id"))
                {
                    keyId = pi.Name;
                    break;
                }
            }

            if (string.IsNullOrEmpty(keyId))
            {
                throw new Exception("未設定PK");
            }
        }
    }
}