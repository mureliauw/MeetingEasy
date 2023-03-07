using Dapper;
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
    public partial class SignUp : System.Web.UI.Page
    {
        private string registID = "STHY202203300001";
        //private string registID = string.Empty;
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
                label_Title.Text = registDetail.Title+"-名单上报";
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
    }
}