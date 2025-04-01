<%@ Page Title="Training" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Training.aspx.cs" Inherits="CallawayWeb.Entrenamiento" %>
<%@ Register src="UCEmployees.ascx" tagname="UCEmployee_Ids" tagprefix="uc1" %>
<%@ Register src="UCEmployeeOperation.ascx" tagname="UCEmployee_IdOperation" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style10 {
            width: 100%;
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="auto-style28 loginCenter">
                <asp:Panel ID="Login" runat="server">
                    <div class="form card auto-style2">
                        <div class="card_header">
                            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="24" height="24">
                                <path fill="none" d="M0 0h24v24H0z"></path>
                                <path fill="currentColor" d="M4 15h2v5h12V4H6v5H4V3a1 1 0 0 1 1-1h14a1 1 0 0 1 1 1v18a1 1 0 0 1-1 1H5a1 1 0 0 1-1-1v-6zm6-4V8l5 4-5 4v-3H2v-2h8z"></path>
                            </svg>
                            <h1 class="form_heading">Sign in</h1>
                        </div>
                        <div class="field">
                            <label for="TxbUser">Username</label>
                            <asp:TextBox ID="TxbUser" runat="server" CssClass="input" Placeholder="Username"></asp:TextBox>
                        </div>
                        <div class="field">
                            <label for="TxbPassword">Password</label>
                            <asp:TextBox ID="TxbPass" runat="server" CssClass="input" TextMode="Password" Placeholder="Password"></asp:TextBox>
                        </div>
                        <div class="field">
                            <asp:Button ID="BtnLogin" runat="server" CssClass="button" Text="Login" OnClick="BtnLogin_Click" />
                        </div>
                        <asp:Label ID="LbErrors0" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                </asp:Panel>
            </div>
            <br />
            <asp:Label ID="LbEmployee_Id0" runat="server"></asp:Label>
            <asp:Label ID="LbEmployee_Id" runat="server"></asp:Label>
            <asp:Panel ID="Panel1" runat="server" Visible="False">
                <table class="auto-style2">
                    <tr>
                        <td>
                            <asp:Button ID="BtnEmployee" runat="server" BackColor="#EFEEEF" OnClick="BtnEmployee_Ids_Click" Text="Employees" ValidationGroup="2" />
                        </td>
                        <td>
                            <asp:Button ID="BtnOperations0" runat="server" BackColor="#EFEEEF" OnClick="BtnOperations_Click" Text="Operations" ValidationGroup="3" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Panel ID="PnlEmployee" runat="server" Visible="False">
                                Adding and removing Employees<br />
                                <uc1:UCEmployee_Ids ID="UCEmployee_Ids" runat="server" />
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Panel ID="PnlOperations" runat="server" Visible="False">
                                Operations and Employees Relationship<br />
                                <uc2:UCEmployee_IdOperation ID="UCEmployee_IdOperation1" runat="server" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
