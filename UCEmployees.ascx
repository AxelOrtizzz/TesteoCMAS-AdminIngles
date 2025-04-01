<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCEmployees.ascx.cs" Inherits="CallawayWeb.UCEmployees" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .newStyle1 {
        font-family: Arial, Helvetica, sans-serif;
    }
    .auto-style2 {
        font-family: Arial, Helvetica, sans-serif;
        text-align: center;
        height: 22px;
    }
    .auto-style3 {
        font-family: Arial, Helvetica, sans-serif;
        text-align: right;
    }
    .auto-style4 {
        text-align: left;
    }
    .auto-style5 {
        font-family: Arial, Helvetica, sans-serif;
        height: 22px;
    }
    .auto-style6 {
        font-family: Arial, Helvetica, sans-serif;
        text-align: right;
        height: 39px;
    }
    .auto-style7 {
        text-align: left;
        height: 39px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style3" style="width: 30%">Employee Id:</td>
        <td class="auto-style4" style="width: 40%">
    <asp:TextBox ID="TxbEmployeeID" runat="server" AutoPostBack="True" MaxLength="9"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="TxbEmployeeID" 
        ErrorMessage="Indique número del asociado" ForeColor="Red">*</asp:RequiredFieldValidator>
</td>
        <td rowspan="2">
            <asp:Button ID="BtnSearch" runat="server" OnClick="Button1_Click1" Text="Search" ValidationGroup="1" />
        </td>
    </tr>
    <tr>
        <td class="auto-style6">Name:</td>
        <td class="auto-style7">
    <asp:TextBox ID="TxbName" runat="server" MaxLength="50" Width="350px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="TxbName" 
        ErrorMessage="Indique el nombre del asociado." ForeColor="Red">*</asp:RequiredFieldValidator>
</td>
    </tr>
    <tr>
        <td class="auto-style3">Shop Floor area:</td>
        <td class="auto-style4" colspan="2">
            <asp:DropDownList ID="DDArea" runat="server" AppendDataBoundItems="True">
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DDArea" ErrorMessage="Indique Area." ForeColor="Red">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">Status:</td>
        <td class="auto-style4" colspan="2">
            <asp:DropDownList ID="DDEstado" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem Value="1">Enabed</asp:ListItem>
                <asp:ListItem Value="0">Disabled</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">Password:</td>
        <td class="auto-style4" colspan="2">
            <asp:TextBox ID="TxPassword" runat="server" MaxLength="5"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="center" class="auto-style2" colspan="3">
            <asp:Button ID="BtnSave" runat="server" OnClick="Button1_Click" Text="Save" />
            <asp:Button ID="BtnDelete" runat="server" OnClick="Button2_Click" Text="Delete" />
            <br />
            <asp:Label ID="LbErrors" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
        </td>
    </tr>
    <tr>
        <td align="center" class="auto-style5" colspan="3">
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
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

