using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using MeettingEasy.Model;

namespace MeettingEasy.Views
{
    public partial class Detail : System.Web.UI.Page
    {
        //private string registID = "STHY202203300001";
        private string registID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count > 0)
                registID = Request.QueryString["registID"].ToString();
            if (!IsPostBack)
                DataBindding();
        }

        private void DataBindding()
        {
            using (IDbConnection connection = new SqlConnection(CommonTools.connectionString))
            {
                string ID = registID;
                RegistDetail registDetail = connection.QueryFirst<RegistDetail>("select * from RegistDetail where ID=@ID", new { ID });
                label_Title.Text = registDetail.Title;
                label_Room.Text = registDetail.Name;
                string str_datetime = registDetail.Regdt_begin.ToString("yyyy年MM月dd日 HH:mm") + "~" + registDetail.Regdt_end.ToString("HH:mm");
                label_DateTime.Text = str_datetime;
                if (registDetail.Reason != null)
                    label_reason.Text = "拒绝原因：" + registDetail.Reason;
                else
                    label_EnroledCount.Text = string.Format("已报名：{0}人", registDetail.EnroledCount.ToString());
                if (registDetail.ServiceIDs != null)
                {
                    string[] serviceIDs = registDetail.ServiceIDs.Split(',');
                    string serviceNames = string.Empty;
                    foreach (string id in serviceIDs)
                    {
                        UserInfo Service = connection.QueryFirst<UserInfo>("select top 1 * from UserInfo where ID=@ID", new { id });
                        serviceNames = serviceNames + Service.Name + "-" + Service.Tel + " ";
                    }
                    label_Service.Text = serviceNames;
                }
                if (registDetail.ProtectIDs != null)
                {
                    string[] protectIDs = registDetail.ProtectIDs.Split(',');
                    string protectNames= string.Empty;
                    foreach (string id in protectIDs)
                    {
                        UserInfo Service = connection.QueryFirst<UserInfo>("select top 1 * from UserInfo where ID=@ID", new { id });
                        protectNames = protectNames + Service.Name + "-" + Service.Tel + " ";
                    }
                    label_Protect.Text = protectNames;
                }            

            }
            return;
        }

        protected void button_close_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowRooms.aspx");
        }
    }
}