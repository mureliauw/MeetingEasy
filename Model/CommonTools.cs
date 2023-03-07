using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using MeettingEasy.Model;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace MeettingEasy
{
    /// <summary>
    /// 公共类
    /// </summary>
    public class CommonTools
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DB_connectionString"].ToString();

        /// <summary>
        /// 获取预约流水种子
        /// </summary>
        /// <returns>种子号</returns>
        public static string GetSeeds()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                string defaultSeed = "0001";
                RegistInfo registInfo = connection.Query<RegistInfo>("select TOP 1 * from RegistInfo order by CreateTime DESC").FirstOrDefault();
                //无数据时重置
                if (registInfo == null)
                    return defaultSeed;
                //跨天重置
                if (registInfo.CreateTime.Date < DateTime.Now.Date)
                    return defaultSeed;

                Dic seed = connection.Query<Dic>("select * from Dic where ID='seed0'").FirstOrDefault();
                //有种返回，无种默认
                if (seed != null)
                    return seed.Text;
                else
                    return defaultSeed;
            }
        }

        /// <summary>
        /// 回写预约流水种子
        /// 外部需要传递事务
        /// 以保证数据的完整性
        /// </summary>
        /// <param name="key">原种子</param>
        /// <param name="dbConnection">数据库连接</param>
        /// <param name="dbTransaction">事务传递</param>
        public static void SetSeeds(string key, IDbConnection dbConnection, IDbTransaction dbTransaction)
        {
                int seed = Convert.ToInt32(key);
                seed += 1;
                if (seed == 10000)
                    seed = 1;
                string count = seed.ToString();
                for (int i = 0; i < 4 - seed.ToString().Length; i++)
                    count = "0" + count;
                int result = dbConnection.Execute("update Dic set Text=@Text where ID='seed0'", new { Text = count }, dbTransaction);
        }
        /// <summary>
        /// 弹出式页面(无参数)
        /// </summary>
        /// <param name="Url">页面名称</param>
        /// <param name="width">弹框宽度</param>
        /// <param name="height">弹框高度</param>
        public static void ShowDialogForm(string Url,int width, int height)
        {
            //ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>goto();</script>");
            string command = string.Format("<script>window.showModelessDialog('{0}', null, 'dialogWidth={1}px;dialogHeight={2}px;help:no;status:no')</script>", Url, width.ToString(), height.ToString());
            HttpContext.Current.Response.Write(command);
        }
        /// <summary>
        /// 弹出式页面(1个参数)
        /// </summary>
        /// <param name="Url">页面名称</param>
        /// <param name="key">参数名</param>
        /// <param name="value">参数值</param>
        /// <param name="width">弹框宽度</param>
        /// <param name="height">弹框高度</param>
        public static void ShowDialogForm(string Url, string key, string value, int width, int height)
        {
            string command = string.Format("<script>window.showModelessDialog('{0}?{1}={2}', null, 'dialogWidth={3}px;dialogHeight={4}px;help:no;status:no')</script>", Url, key, value, width.ToString(), height.ToString()) ;
            HttpContext.Current.Response.Write(command);
        }
        /// <summary>
        /// 弹出式页面(多个参数)
        /// </summary>
        /// <param name="Url">页面名称</param>
        /// <param name="paras">参数表(key/value)</param>
        /// <param name="width">弹框宽度</param>
        /// <param name="height">弹框高度</param>
        public static void ShowDialogForm(string Url, Hashtable paras, int width, int height)
        {
            string command = string.Format("<script>window.showModelessDialog('{0}?", Url);
            foreach (DictionaryEntry para in paras)
            {
                command += para.Key + "=" + para.Value + "&";
            }
            //删除结尾多余的"&"
            command.Remove(command.Length - 1);
            command += string.Format("', null, 'dialogWidth={1}px;dialogHeight={2}px;help:no;status:no')</script>", width.ToString(), height.ToString());
            HttpContext.Current.Response.Write(command);
        }
        /// <summary>
        /// 提醒框
        /// </summary>
        /// <param name="content">提醒内容</param>
        public static void ShowMessageBox(string content)
        {
            HttpContext.Current.Response.Write(string.Format("<script>alert('{0}')</script>", content));
        }
        /// <summary>
        /// 提醒并跳转
        /// </summary>
        /// <param name="content">提醒内容</param>
        /// <param name="url">跳转页面</param>
        public static void ShowMessageBox(string content,string url)
        {
            HttpContext.Current.Response.Write(string.Format("<script>alert('{0}');window.location='{1}'</script>", content, url));
        }
        /// <summary>
        /// 确认框
        /// </summary>
        /// <param name="content">提醒内容</param>
        public static void ShowConfirmBox(string content)
        {
            //HttpContext.Current.Response.Write(string.Format("<script>if (window.confirm('{0}')){} else {return};</script>", content));
        }
    }
}