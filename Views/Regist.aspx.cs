using Dapper;
using MeettingEasy;
using MeettingEasy.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeettingEasy.Views
{
    public partial class Regist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RoomsBinding();
                EnrolTypeBinding();
            }
        }

        private void RoomsBinding()
        {
            using (IDbConnection connection = new SqlConnection(CommonTools.connectionString))
            {
                List<Room> Rooms = connection.Query<Room>("select * from Room").ToList();
                if (Rooms != null)
                {
                    DropDown_Rooms.Items.Clear();
                    foreach (Room room in Rooms)
                    {
                        ListItem item = new ListItem();
                        item.Value = room.ID.ToString();
                        item.Text = room.Name;
                        DropDown_Rooms.Items.Add(item);
                    }
                } 
            }
            return;
        }

        private void EnrolTypeBinding()
        {
            using (IDbConnection connection = new SqlConnection(CommonTools.connectionString))
            {
                List<Dic> enrolTypes = connection.Query<Dic>("select * from Dic where Type='EnrolModels' order by Notes").ToList();
                if (enrolTypes != null)
                {
                    DropDown_enrolType.Items.Clear();
                    foreach (Dic enroltype in enrolTypes)
                    {
                        ListItem item = new ListItem();
                        item.Value = enroltype.ID;
                        item.Text = enroltype.Text;
                        DropDown_enrolType.Items.Add(item);
                    }
                }
                return;
            }
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {            
            using (IDbConnection connection = new SqlConnection(CommonTools.connectionString))
            {
                RegistInfo regist = new RegistInfo();
                string seed = CommonTools.GetSeeds();
                regist.ID = "STHY"+DateTime.Now.Date.ToString("yyyyMMdd") + seed;
                regist.Title = TextBox_name.Text.Trim();
                regist.Rid = Convert.ToInt32(DropDown_Rooms.SelectedValue);
                List<DateTime> list = GetDatetime();
                regist.Regdt_begin = list[0]; 
                regist.Regdt_end = list[1];
                regist.Type = DropDown_enrolType.SelectedValue;
                regist.Status = "预订中";
                regist.CreateTime = DateTime.Now;
                connection.Open();
                IDbTransaction dbTransaction = connection.BeginTransaction();
                try
                {
                    int count = connection.Execute("Insert into RegistInfo(ID,Title,Rid,Regdt_begin,Regdt_end,Type,Status,CreateTime) values(@ID, @Title, @Rid, @Regdt_begin, @Regdt_end, @Type, @Status, @CreateTime)", regist, dbTransaction);
                    CommonTools.SetSeeds(seed, connection, dbTransaction);
                    dbTransaction.Commit();
                    //Lab_info.Text = "提交成功！";
                    CommonTools.ShowMessageBox("提交成功！", "ShowRooms.aspx");
                }
                catch(Exception ex)
                {
                    dbTransaction.Rollback();
                    Lab_info.Text = "抱歉，提交失败，请联系管理员。失败原因：" + ex.Message;
                    CommonTools.ShowMessageBox("抱歉，提交失败，请联系管理员。失败原因：" + ex.Message);
                }
            }
        }

        private List<DateTime> GetDatetime()
        {
            string date = TextBox_Date.Text;
            string begintime = DropDown_begintime.SelectedValue;
            string endtime = DropDownList_endtime.SelectedValue;

            DateTime begindatetime = Convert.ToDateTime(date + " " + begintime + ":00");
            DateTime enddatetime = Convert.ToDateTime(date + " " + endtime + ":00");
            List<DateTime> list = new List<DateTime>();
            list.Add(begindatetime);
            list.Add(enddatetime);
            return list;
        }



        protected void ImageButton_Click(object sender, ImageClickEventArgs e)
        {
            calendar.Visible = !calendar.Visible;
        }

        protected void CalendarDate_SelectionChanged(object sender, EventArgs e)
        {
            TextBox_Date.Text = CalendarDate.SelectedDate.ToShortDateString();

            // 隐藏日历
            calendar.Visible = false;

            //设置日历下textbox的焦点，方便用户输入。移除或改变下行代码设置为您自己的控件
            DropDown_begintime.Focus();
        }

        protected void Button_Canel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowRooms.aspx");
        }
    }
}