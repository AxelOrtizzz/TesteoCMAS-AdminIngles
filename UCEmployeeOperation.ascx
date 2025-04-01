<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCEmployeeOperation.ascx.cs" Inherits="CallawayWeb.UCEmployee_IdOperation" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style4 {
        
        font-family: Arial, Helvetica, sans-serif;
    }
    .auto-style5 {
        text-align: left;
    }
    .auto-style6 {
        font-family: Arial, Helvetica, sans-serif;
        text-align: right;
    }
    .auto-style7 {
        font-family: Arial, Helvetica, sans-serif;
        text-align: center;
    }
    .auto-style8 {
        font-family: Arial, Helvetica, sans-serif;
        text-align: left;
    }
    .auto-style9 {
        text-align: center;
    }
</style>

<table class="auto-style1" align="center">
    <tr>
        <td class="auto-style6" style="width: 50%">Employee_Id:</td>
        <td>
            <asp:TextBox ID="TxbEmployeeId" runat="server" MaxLength="9"></asp:TextBox>
        </td>
        <td rowspan="3">
            <asp:Button ID="BtnSearch" runat="server" OnClick="Button1_Click" Text="Search" />
        </td>
    </tr>
    <tr>
        <td class="auto-style6">Employee Name:</td>
        <td>
            <asp:TextBox ID="TxbEmployeeName" runat="server" MaxLength="50"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style6">Shop Floor Area:</td>
        <td>
            <asp:DropDownList ID="DDAreaOp" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="DDArea_SelectedIndexChanged">
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style6">Operation:</td>
        <td colspan="2">
            <asp:DropDownList ID="DDoperations" runat="server" AppendDataBoundItems="True">
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style7" colspan="3">
            <asp:Button ID="BtnAddOperation" runat="server" Text="Add Operation" OnClick="Button2_Click" />
            <br />
            <asp:Label ID="LbErrors" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:Button ID="BtnRestart" runat="server" OnClick="Button3_Click" Text="Re Start" />
        </td>
    </tr>
    <tr>
        <td class="auto-style4" colspan="3">
            <asp:Panel ID="Panel1" runat="server">
                <table align="center" class="auto-style1">
                    <tr>
                        <td class="auto-style9">Operations registered for this Employee_Id:<br />
                            <asp:Label ID="LbID" runat="server"></asp:Label>
                            <asp:Label ID="LbNombre" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:CommandField SelectText="Delete" ShowSelectButton="True" />
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td class="auto-style8" colspan="3" align="center">
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField SelectText="Select" ShowSelectButton="True" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </td>
    </tr>
</table>

