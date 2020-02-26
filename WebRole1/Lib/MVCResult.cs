using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebRole1.Lib
{
    public class MVCResult<T>
    {
        public MVCResult()
        {
            IsSuccess = true;
            ReturnMessage = string.Empty;
        }
        /// <summary>
        /// 成功
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public string ReturnMessage { get; set; }
        /// <summary>
        /// 回傳結果
        /// </summary>
        public List<T> PayLoad { get; set; }

        public void SetSuccess(int count)
        {
            IsSuccess = true;
            ReturnMessage = string.Format("影響資料筆數：{0}", count);
        }
        /// <summary>
        /// 設定錯誤
        /// </summary>
        /// <param name="msg"></param>
        public void SetError(string msg)
        {
            IsSuccess = false;
            ReturnMessage = msg;
        }
    }
}