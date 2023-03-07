<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Regist.aspx.cs" Inherits="MeettingEasy.Views.Regist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: right;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            font-size: xx-large;
            font-weight: normal;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr><td colspan="3" class="auto-style2" >
                <h1><asp:Label ID="title" runat="server" Text="会议预定" Font-Size="X-Large" CssClass="auto-style3"></asp:Label></h1>
                </td></tr>
            <tr>
                <td class="auto-style1">名称或用途：</td>
                <td colspan="2"><asp:TextBox ID="TextBox_name" runat="server" Width="320px" /></td>
            </tr>
            <tr>
                <td class="auto-style1">会议室选择：</td>
                <td>
                    <asp:DropDownList ID="DropDown_Rooms" runat="server" Height="17px" Width="161px" AutoPostBack="True"></asp:DropDownList>
                </td>
                <td></td>
            </tr>
            <tr> 
                <td class="auto-style1">日期和时间：</td>
                <td>

                    <asp:TextBox ID="TextBox_Date" runat="server" Width="291px" />
                    <asp:ImageButton ID="imageButton" runat="server" ImageUrl="~/Images/time.png" AlternateText="calendar" OnClick="ImageButton_Click" CausesValidation="false" Height="22px" Width="22px" />
                    <br />
                    <div id="calendar" class="calendar" visible="false" runat="server">
                        <asp:Calendar ID="CalendarDate" runat="server" OnSelectionChanged="CalendarDate_SelectionChanged" />
                    </div>

                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">时间段：</td>
                <td colspan="2"><asp:DropDownList ID="DropDown_begintime" runat="server">
                    <asp:ListItem Selected="True">8:00</asp:ListItem>
                    <asp:ListItem>8:30</asp:ListItem>
                    <asp:ListItem>9:00</asp:ListItem>
                    <asp:ListItem>9:30</asp:ListItem>
                    <asp:ListItem>10:00</asp:ListItem>
                    <asp:ListItem>10:30</asp:ListItem>
                    <asp:ListItem>11:00</asp:ListItem>
                    <asp:ListItem>11:30</asp:ListItem>
                    <asp:ListItem>12:00</asp:ListItem>
                    <asp:ListItem>13:00</asp:ListItem>
                    <asp:ListItem>14:00</asp:ListItem>
                    <asp:ListItem>15:00</asp:ListItem>
                    <asp:ListItem>16:00</asp:ListItem>
                    <asp:ListItem>17:00</asp:ListItem>
                    <asp:ListItem>18:00</asp:ListItem>
                    </asp:DropDownList>~<asp:DropDownList ID="DropDownList_endtime" runat="server">
                        <asp:ListItem>8:00</asp:ListItem>
                        <asp:ListItem>8:30</asp:ListItem>
                        <asp:ListItem>9:00</asp:ListItem>
                        <asp:ListItem>9:30</asp:ListItem>
                        <asp:ListItem>10:00</asp:ListItem>
                        <asp:ListItem>10:30</asp:ListItem>
                        <asp:ListItem>11:00</asp:ListItem>
                        <asp:ListItem>11:30</asp:ListItem>
                        <asp:ListItem>12:00</asp:ListItem>
                        <asp:ListItem>13:00</asp:ListItem>
                        <asp:ListItem>14:00</asp:ListItem>
                        <asp:ListItem>15:00</asp:ListItem>
                        <asp:ListItem>16:00</asp:ListItem>
                        <asp:ListItem>17:00</asp:ListItem>
                        <asp:ListItem Selected="True">18:00</asp:ListItem>
                   </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="auto-style1">报名模板：</td>
                <td>
                    <asp:DropDownList ID="DropDown_enrolType" runat="server" Height="16px" Width="157px" AutoPostBack="True"></asp:DropDownList>
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Label ID="Lab_info" runat="server" Text="" ForeColor="#CC3300"></asp:Label></td>
                <td>&nbsp;&nbsp; <asp:Button ID="Button_Canel" runat="server" Text="取消" OnClick="Button_Canel_Click" />&nbsp; <asp:Button ID="Button_Submit" runat="server" Text="提交" OnClick="Button_Submit_Click" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
