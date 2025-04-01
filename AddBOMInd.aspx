<%@ Page Title="Alta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBOMInd.aspx.cs" Inherits="CallawayWeb.AltaProductRaw_MaterialInd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        
    /* Estilos para los TextBox */
    /* Estilos para los TextBox */
    .design-textbox {
        width: 220px;
        padding: 8px;
        border: 1px solid #ccc;
        border-radius: 5px;
        font-size: 14px;
        outline: none;
    }

    .design-textbox:focus {
        border-color: #007bff;
        box-shadow: 0 0 5px rgba(0, 123, 255, 0.5);
    }

    /* Estilos para los RequiredFieldValidator */
    .design-validator {
        color: red;
        font-weight: bold;
        margin-left: 5px;
    }

    /* Estilos para el botón */
    .design-button {
        background-color: #007bff;
        color: white;
        border: none;
        padding: 8px 12px;
        border-radius: 5px;
        cursor: pointer;
        font-size: 14px;
        margin-left: 10px;
    }

    .design-button:hover {
        background-color: #0056b3;
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
    <table class="auto-style2">
        <tr>
            <td>Product:
                <asp:TextBox ID="TxbProduct" runat="server" CssClass="design-textbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxbProduct" ErrorMessage="Indique Product" CssClass="design-validator" ValidationGroup="1">*</asp:RequiredFieldValidator>
                <asp:Button ID="BtnSearch" runat="server" OnClick="BtnSearchBM_Click" Text="Search" CssClass="design-button" />
            </td>
        </tr>
        <tr>
            <td>Raw_Material:
                <asp:TextBox ID="TxbRawMaterial" runat="server" CssClass="design-textbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxbRawMaterial" ErrorMessage="Indique Raw_Material" CssClass="design-validator" ValidationGroup="1">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="BtnSaveBOM" runat="server" OnClick="BtnSaveBOM_Click" Text="Save" ValidationGroup="1" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />
                <br />
                <asp:Label ID="LbErrors" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="GridViewBOM" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridViewBOM_SelectedIndexChanged">
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
</asp:Content>
