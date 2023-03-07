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
    public partial class Confirm : System.Web.UI.Page
    {
        //private string registID = "STHY202203300002";
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
                    string protectNames = string.Empty;
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
        protected void Button_isConfirm_Click(object sender, EventArgs e)
        {
            string confirmResult = RadioButtonConfirm.SelectedValue;
            if (confirmResult == "false" && textbox_reason.Text.Trim() == string.Empty)
            {
                CommonTools.ShowMessageBox("请填写拒绝原因！");
                label_info.Text = "请填写拒绝原因！";
                return;
            }

            using (IDbConnection connection = new SqlConnection(CommonTools.connectionString))
            {
                int result;
                try
                {
                    if (confirmResult == "false")
                        result = connection.Execute(string.Format("update RegistInfo set Status = '已拒绝',Reason = '{0}' where ID='{1}'", textbox_reason.Text.Trim(), registID));
                    else
                        result = connection.Execute(string.Format("update RegistInfo set Status = '已预订',EnroledCount = 0 where ID='{0}'", registID));
                    if (result > 0)
                        CommonTools.ShowMessageBox("审核完成！", "ShowRooms.aspx");
                }
                catch (Exception ex)
                {
                    label_info.Text = "抱歉，提交失败，请联系管理员。失败原因：" + ex.Message;
                    CommonTools.ShowMessageBox("抱歉，提交失败，请联系管理员。失败原因：" + ex.Message);
                }

                //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "close", "<script language='javascript' type='text/javascript'>window.opener.location.reload(true);window.close();</script>");
            }
        }

        protected void Button_close_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowRooms.aspx");
        }
    }
}