<%@ Page Title="Tolerances" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tolerances.aspx.cs" Inherits="CallawayWeb.Tolerances" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            font-size: large;
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
            <table class="auto-style2">
                <tr>
                    <td>
                        <table class="auto-style2">
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="LbErrors" runat="server" ForeColor="Red"></asp:Label>
                            </tr>
                            <tr>
                                <td align="right" style="width: 50%">
                                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" />
                                    Model:</td>
                                <td align="left">
                                    <asp:DropDownList ID="DDModels" runat="server" AppendDataBoundItems="True" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="DDModels_SelectedIndexChanged">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged" />
                                    SKU</td>
                                <td align="left">
                                    <asp:TextBox ID="TxSKU" runat="server" Enabled="False"></asp:TextBox>
                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Tests:</td>
                                <td align="left">
                                    <asp:DropDownList ID="DDLimites" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Tolerance Máx:</td>
                                <td align="left">
                                    <asp:TextBox ID="TxTolerance" runat="server"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxTolerance" ErrorMessage="Verifique el Valor de la Tolerance" ForeColor="Red" ValidationExpression="^-?\d+(\.\d{1,2})?$">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Tolerance Mín:</td>
                                <td align="left">
                                    <asp:TextBox ID="TxToleranceMin" runat="server"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TxToleranceMin" ErrorMessage="Verifique el Valor de la Tolerance" ForeColor="Red" ValidationExpression="^-?\d+(\.\d{1,2})?$">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="BtnSave" runat="server" OnClick="BtnSave_Click" Text="Save" />
                                    <asp:Button ID="BtnDelete" runat="server" OnClick="BtnDelete_Click" Text="Delete" />
                                    <br />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                                </td>
                            </tr>
                        </table>
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
</asp:Content>
