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
    public partial class ShowRooms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowRegistsInfo();
                ShowRegistList();
            }
        }
        private void ShowRegistsInfo()
        {
            using (IDbConnection connection = new SqlConnection(CommonTools.connectionString))
            {
                //当月第一天0时0分0秒：
                DateTime thisMonthBegin = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date;
                //当月最后一天23时59分59秒：
                DateTime thisMonthEnd = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date.AddMonths(1).AddSeconds(-1);
                //上月第一天0时0分0秒：
                DateTime lastMonthBegin = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date.AddMonths(-1);
                //上月最后一天23时59分59秒：
                DateTime lastMonthEnd = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date.AddSeconds(-1);
                //当年第一天0时0分0秒：
                DateTime thisYearBegin = DateTime.Now.AddMonths(1 - DateTime.Now.Month).AddDays(1 - DateTime.Now.Day).Date;
                //当年最后一天23时59分59秒：
                DateTime thisYearEnd = DateTime.Now.AddMonths(13 - DateTime.Now.Month).AddDays(1 - DateTime.Now.Day).Date.AddSeconds(-1);

                int thisMouthRegisCount = connection.QueryFirst<int>("select count(*) from RegistInfo where CreateTime>=@thisMonthBegin and CreateTime<=@thisMonthEnd", new { thisMonthBegin, thisMonthEnd });
                int lastMouthRegisCount = connection.QueryFirst<int>("select count(*) from RegistInfo where CreateTime>=@lastMonthBegin and CreateTime<=@lastMonthEnd", new { lastMonthBegin, lastMonthEnd });
                int thisYearRegisCount = connection.QueryFirst<int>("select count(*) from RegistInfo where CreateTime>=@thisYearBegin and CreateTime<=@thisYearEnd", new { thisYearBegin, thisYearEnd });
                int registtingCount = connection.QueryFirst<int>("select count(*) from RegistInfo where Status='预订中'");

                Lab_registsInfo.Text = string.Format("当月已申请会议：{0} 场；上月已申请会议：{1} 场；全年已申请会议：{2} 场；待确认会议：{3} 场。 ", thisMouthRegisCount.ToString(), lastMouthRegisCount.ToString(), thisYearRegisCount.ToString(), registtingCount.ToString());
            }                
            return;
        }
        private void ShowRegistList()
        {
            using (IDbConnection connection = new SqlConnection(CommonTools.connectionString))
            {
                List<RegistList> registList = connection.Query<RegistList>("select * from RegistList ORDER BY CreateTime DESC ").ToList();                
                Grid_registMeettings.DataSource = registList;
                Grid_registMeettings.DataBind();
            }
            return;
        }
        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = Grid_registMeettings.Rows[index];
            TableCell cellName = selectedRow.Cells[0];
            string selectID = cellName.Text;
            string selectStatus = selectedRow.Cells[6].Text;
            switch (e.CommandName)
            {
                case "buttonDetail"://详情
                    Response.Redirect(string.Format("Detail.aspx?registID={0}", selectID));
                    //CommonTools.ShowDialogForm("Detail.aspx", "registID", selectID, 500, 400);
                    //Response.Write(string.Format("<script>window.showModelessDialog('Detail.aspx?registID={0}', null, 'dialogWidth=500px;dialogHeight=400px;help:no;status:no')</script>", selectID));
                    break;
                case "buttonConfirm"://确认
                    Response.Redirect(string.Format("Confirm.aspx?registID={0}", selectID));
                    //CommonTools.ShowDialogForm("Confirm.aspx", "registID", selectID, 500, 200);
                    //RegisterClientScriptBlock()
                    //RegisterStartupScript();
                    break;
                case "buttonShare"://分享
                    break;
                default:
                    break;
            }

            using (IDbConnection connection = new SqlConnection(CommonTools.connectionString))
            {

            }
            if (e.CommandName == "buttonDetail")
            {

            }

        }

        protected void Grid_registMeettings_RowDataBound(object sender, GridViewRowEventArgs e)
        {            
            GridViewRow selectedRow = e.Row;
            string status = selectedRow.Cells[5].Text;
            switch (status)
            {
                case "已预订":
                    selectedRow.Cells[9].Visible = false;
                    break;
                case "预订中":
                    selectedRow.Cells[8].Visible = false;
                    selectedRow.Cells[10].Visible = false;
                    break;
                case "已拒绝":
                    selectedRow.Cells[9].Visible = false;
                    selectedRow.Cells[10].Visible = false;
                    break;
                default:
                    break;
            }
        }


        private void ApplyConfirmM()
        {
            return;
        }

        private void ShowDetail()
        {
            return;
        }

        private void ShareURL()
        {
            return;
        }

        protected void Button_Regist_Click(object sender, EventArgs e)
        {
            Response.Redirect("Regist.aspx");
        }
    }
}