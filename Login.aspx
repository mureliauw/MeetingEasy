<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MeettingEasy.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 214px;
        }
        .auto-style2 {
            width: 185px;
        }
        .auto-style3 {
            width: 44%;
        }
        .auto-style4 {
            width: 214px;
            height: 23px;
            text-align: right;
        }
        .auto-style5 {
            width: 185px;
            height: 23px;
        }
        .auto-style6 {
            text-align: right;
        }
        .auto-style8 {
            text-align: center;
        }
        .auto-style9 {
            width: 214px;
            text-align: right;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <table class="auto-style3">
                <tr>
                    <td colspan="2" class="auto-style8" ><asp:Label ID="title" runat="server" Text="MeettingEasy"></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style4">账号：</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TextBox_ID" runat="server"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td class="auto-style9">密码：</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox_PWD" runat="server"></asp:TextBox>
                    </td>
                </tr>
                                <tr>
                    <td colspan="2" class="auto-style6" ><asp:Label ID="errorInfo" runat="server" ForeColor="#CC3300"></asp:Label></td>
                </tr>
                 <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        <asp:Button ID="button_Login" runat="server" Text="登录" OnClick="button_Login_Click"/>
                     </td>
                </tr>
            </table>
            
        </div>
        
    </form>
</body>
</html>
