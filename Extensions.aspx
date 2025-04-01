<%@ Page Title="Extensions" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Extensions.aspx.cs" Inherits="CallawayWeb.Extensiones" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            margin-top: 0px;
        }
        .auto-style4 {
            width: 50%;
            height: 26px;
        }
        .auto-style5 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="auto-style28 loginCenter">
        <asp:Panel ID="Panel2" runat="server">
            <div class="form card auto-style2">
                <div class="card_header">
                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="24" height="24">
                        <path fill="none" d="M0 0h24v24H0z"></path>
                        <path fill="currentColor" d="M4 15h2v5h12V4H6v5H4V3a1 1 0 0 1 1-1h14a1 1 0 0 1 1 1v18a1 1 0 0 1-1 1H5a1 1 0 0 1-1-1v-6zm6-4V8l5 4-5 4v-3H2v-2h8z"></path>
                    </svg>
                    <h1 class="form_heading">Sign in</h1>
                </div>
                <div class="field">
                    <label for="TextBox3">Username</label>
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="input" Placeholder="Username"></asp:TextBox>
                </div>
                <div class="field">
                    <label for="TextBox4">Password</label>
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="input" TextMode="Password" Placeholder="Password"></asp:TextBox>
                </div>
                <div class="field">
                    <asp:Button ID="Button3" runat="server" CssClass="button" Text="Login" OnClick="Button3_Click" />
                </div>
                <asp:Label ID="LbErrors0" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </asp:Panel>
    </div>

    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <asp:ImageButton ID="ImageButton1" runat="server" Height="29px" ImageUrl="~/Images/xls2.jpg" OnClick="ImageButton1_Click" Width="35px" />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Salir" />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table class="auto-style2">
                    <tr>
                        <td align="right" colspan="2" style="width: 50%">Start date:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" TargetControlID="TextBox1" />
                            <br />
                        </td>
                        <td align="right">End Date:<asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style3"></asp:TextBox>
                            <cc1:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" TargetControlID="TextBox2" />
                        </td>
                        <td align="left">
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">Employee_Id:</td>
                        <td align="left" colspan="2">
                            <asp:Label ID="LbEmployee_Id0" runat="server" Font-Bold="True" Visible="False"></asp:Label>
                            <asp:Label ID="LbEmployee_Id" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Order:
                            <asp:TextBox ID="TxOrder" runat="server" ValidationGroup="1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxOrder" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                            <asp:Button ID="BtnSearch" runat="server" OnClick="BtnSearch_Click" Text="Search" />
                        </td>
                        <td colspan="3">Line:
                            <asp:TextBox ID="TxLinea" runat="server" Enabled="False" ValidationGroup="1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxLinea" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Liberar" ValidationGroup="1" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" onrowdatabound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
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
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="LbErrors" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <br />
</asp:Content>
