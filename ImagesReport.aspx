<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImagesReport.aspx.cs" Inherits="CallawayWeb.ImagesReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="auto-style2">
                <tr>
                    <td>
                        <asp:Label ID="LbMsg" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:GridView ID="GridView1" runat="server">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="23px" ImageUrl="~/Images/xls2.jpg" OnClick="ImageButton1_Click" Visible="False" Width="31px" />
                        <br />
    <asp:Label ID="LbErrors" runat="server"></asp:Label>
    <br />
    <asp:Label ID="LbPath" runat="server"></asp:Label>
    <br />
</asp:Content>
