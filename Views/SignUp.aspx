<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="MeettingEasy.Views.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body> 
    <form id="form1" runat="server">
        <table>
            <tr>
                <td colspan="4" class="auto-style2">
                    <h2 class="auto-style1">
                        <asp:Label ID="label_Title" runat="server" ></asp:Label>
                    </h2>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">时间：</td>
                <td>
                    <asp:Label ID="label_DateTime" runat="server"></asp:Label>
                </td>
                <td class="auto-style1">地点：</td>
                <td>
                    <asp:Label ID="label_Room" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">会务：</td>
                <td>
                    <asp:Label ID="label_Service" runat="server"></asp:Label>
                </td>
                <td class="auto-style1">保障：</td>
                <td>
                    <asp:Label ID="label_Protect" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="Gridview_Sign" runat="server" AutoGenerateColumns="False"></asp:GridView>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
