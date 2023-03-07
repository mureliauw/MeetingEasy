<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowRooms.aspx.cs" Inherits="MeettingEasy.Views.ShowRooms" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script>
        function goto()
        {
            //alert('成功!');
            /*var width = 1000;  //模态窗口的宽度
            var height = 500;   //模态窗口的高度
            var url = "Detail.aspx"; //模态窗口的url地址
            this.window.showModalDialog(url);//, null, 'dialogWidth=' + width + 'px;dialogHeight=' + height + 'px;help:no;status:no');*/
        }
    </script>
    <style type="text/css">
        .auto-style1 {
            height: 25px;
        }

        .auto-style2 {
            text-align: center;
        }

        #popupcontent {
            position: absolute;
            left:350px;
            top:200px;
            visibility: hidden;
            overflow: hidden;
            border: 1px solid #CCC;
            background-color: #F9F9F9;
            border: 1px solid #333;
            padding: 5px;
        }
        .auto-style3 {
            left: -109px;
            top: 454px;
        }
    </style>
    
</head>
<body>    
    <form id="form1" runat="server">
        <div id="popupcontent" class="auto-style3">这是一个DIV弹窗效果!</div>
        <table>
            <tr>
                <td colspan="2" class="auto-style2">
                    <h1>会议展示</h1>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label runat="server" ID="Lab_registsInfo" /></td>
                <td class="auto-style1">
                    <asp:Button ID="Button_Regist" runat="server" OnClick="Button_Regist_Click" Text="+ 预约会场" />
                    </td>
                </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="Grid_registMeettings" runat="server" OnRowCommand="GridView_RowCommand" CellPadding="11" Font-Size="9pt" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowDataBound="Grid_registMeettings_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="编号" />
                            <asp:BoundField DataField="Title" HeaderText="标题" />
                            <asp:BoundField DataField="Name" HeaderText="会议室"  />
                            <asp:BoundField DataField="Regdt_begin" HeaderText="开始时间" />
                            <asp:BoundField DataField="Regdt_end" HeaderText="结束时间" />
                            <asp:BoundField DataField="Status" HeaderText="状态" />
                            <asp:BoundField DataField="CreateTime" HeaderText="预约时间" />
                            <asp:BoundField DataField="EnroledCount" HeaderText="已报名" />
                            <asp:ButtonField ButtonType="Button" CommandName="buttonDetail"  Text="详情" />
                            <asp:ButtonField ButtonType="Button" CommandName="buttonConfirm"  Text="确认" />
                            <asp:ButtonField ButtonType="Button" CommandName="buttonShare"  Text="分享" />
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />                        
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </td>                
            </tr>
            <tr>
                <td>
                    
                    <asp:Label ID="LabelInfo" runat="server"></asp:Label>
                    
                </td>
                <td></td>
            </tr>

        </table>
    </form>
</body>
</html>

