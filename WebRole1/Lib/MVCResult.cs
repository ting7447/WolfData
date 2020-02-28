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

        public void SetSuccess(int count, SQLType type)
        {
            IsSuccess = true;
            string title = "";
            switch(type)
            {
                case SQLType.Select:
                    title = "回傳";
                    break;
                case SQLType.Insert:
                    title = "新增";
                    break;
                case SQLType.Update:
                    title = "修改";
                    break;
                case SQLType.Delete:
                    title = "刪除";
                    break;
            }

            ReturnMessage = string.Format("{0}資料筆數：{1}", title, count);
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