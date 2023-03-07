<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="MeettingEasy.Views.Detail" %>

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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td colspan="4" class="auto-style2">
                    <h2>
                    <asp:Label ID="label_Title" runat="server"/>
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
                    <asp:Label ID="label_EnroledCount" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="label_reason" runat="server" ForeColor="#FF3300" />
                </td>
            </tr>
            <tr>
                <td colspan="4" class="auto-style1">
                    <asp:Button ID="button_output" runat="server" Text="导出" />
                    <asp:Button ID="button_close" runat="server" Text="返回" OnClick="button_close_Click" />
<%--                    <input id="button_close" type="button" value="返回" onclick="window.close();"  />--%>
                </td>
                </tr>
        </table>
    </form>
</body>
</html>
