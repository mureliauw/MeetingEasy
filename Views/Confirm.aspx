<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="MeettingEasy.Views.Confirm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td colspan="4" class="auto-style2">
                    <h2 class="auto-style1">
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
                <td>审核：</td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonConfirm" runat="server" Height="25px" Width="153px">
                        <asp:ListItem Selected="True" Value="true">同意</asp:ListItem><asp:ListItem Value="false">拒绝</asp:ListItem>                        
                    </asp:RadioButtonList>
                </td>
                <td>拒绝原因：</td>
                <td><asp:TextBox ID="textbox_reason" runat="server" MaxLength="100"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="label_info" runat="server" ForeColor="#FF3300"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4" class="auto-style2">
                    <%--<input id="button_close" type="button" value="返回" onclick="window.close();"  />--%>
                    <asp:Button ID="Button_close" runat="server" Text="返回" OnClick="Button_close_Click" />
                    <asp:Button ID="Button_isConfirm" runat="server" Text="确认" OnClick="Button_isConfirm_Click" />
                </td>
            </tr>
            
        </table>
    </form>
</body>
</html>
