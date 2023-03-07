using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dapper;
using MeettingEasy.Model;

namespace MeettingEasy
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void button_Login_Click(object sender, EventArgs e)
        {            
            UserInfo user = CheckUser(TextBox_ID.Text.Trim(), TextBox_PWD.Text.Trim());
            if (user != null)
            {
                Session["UserInfo"] = user;//保存session
                Response.Redirect(@"\Views\ShowRooms.aspx");//跳转页面
            }
            else
            {
                errorInfo.Text = "账号或密码错误！";//提醒登录失败
                return; 
            }
            
        }

        public static UserInfo CheckUser(string id, string pwd)
        {
            using (IDbConnection connection = new SqlConnection(CommonTools.connectionString))
            {
                return connection.Query<UserInfo>("select * from UserInfo where ID=@ID and Pwd=@Pwd", new { ID = id, Pwd = pwd }).FirstOrDefault();
                
            }
        }

    }
}