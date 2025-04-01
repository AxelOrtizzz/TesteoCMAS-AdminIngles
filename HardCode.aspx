<%@ Page Title="HardCode" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HardCode.aspx.cs" Inherits="CallawayWeb.HardCode" %>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
            </hgroup>
        </div>
    </section>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <article>
        <table class="auto-style2 ">
            <tr>
                <td class="auto-style28 loginCenter">
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
                                <asp:TextBox ID="TxbPassword" runat="server" CssClass="input" TextMode="Password" Placeholder="Password"></asp:TextBox>
                            </div>
                            <div class="field">
                                <asp:Button ID="BtnLogin" runat="server" CssClass="button" Text="Login" OnClick="BtnLogin_Click" />
                            </div>
                            <asp:Label ID="LbErrors0" runat="server" ForeColor="Red"></asp:Label>
                            <asp:Label ID="LbErrors" runat="server" ForeColor="Red"></asp:Label>
                        </div>

                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="auto-style28">
                    <asp:Panel ID="Panel1" runat="server" Visible="false">
                        <asp:Label ID="LbEmployee_Id0" runat="server"></asp:Label>
                        &nbsp;<asp:Label ID="LbEmployee_Id" runat="server"></asp:Label>
                        <table class="auto-style2">
                            <tr>
                                <td class="auto-style25">Description:</td>
                                <td class="auto-style29">
                                    <asp:TextBox ID="TxtModelDesc" runat="server" CssClass="TextBoxTabla" Width="254px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtModelDesc" ErrorMessage="Requiere una Description del Model." ValidationGroup="Grupo1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style25">Model Or:</td>
                                <td class="auto-style29">
                                    <asp:TextBox ID="TxtModelOr" runat="server" CssClass="TextBoxTabla" Width="254px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style25">Order:</td>
                                <td class="auto-style29">
                                    <asp:TextBox ID="TxtModelOrder" runat="server" CssClass="TextBoxTabla" Width="254px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        </article>
    </asp:Content>
