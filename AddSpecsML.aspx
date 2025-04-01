<%@ Page Title="Add Specs" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSpecsML.aspx.cs" Inherits="CallawayWeb.AltaLimitesML" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
     .drag-drop-area {
        display: block;
        width: 100%;
        height: 150px;
        border: 2px dashed #888;
        text-align: center;
        padding-top: 50px;
        cursor: pointer;
        background-color: #f9f9f9;
        border-radius: 8px;
        box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
        transition: background-color 0.3s ease;
    }

    .drag-drop-area:hover {
        background-color: #e0e0e0;
    }

    .drag-drop-area div {
        font-size: 14px;
        color: #555;
    }

    .drag-drop-area small {
        color: #888;
    }

    /* Estilo para el botón del FileUpload */
    #BtnBrowser {
        display: block;
        width: 100%;
        height: 100%;
        opacity: 0; /* Hace invisible el botón real */
        cursor: pointer; /* Mantiene el cursor como puntero para indicar que se puede hacer clic */
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
            <%--<td>Select the file with the sets:<br />
                <asp:Label ID="LbPath" runat="server" Text="Here will Show the path"></asp:Label>
                <br />
                <br />
                <asp:FileUpload ID="BtnBrowser" runat="server" />
            </td>--%>
            <td>
                <label for="BtnBrowser" class="drag-drop-area">
                    <div>Drag and drop your file here</div>
                    <div><small>or click to select a file</small></div>
                    <asp:FileUpload ID="BtnBrowser" runat="server" />
                </label>
                
                <br />
                <asp:Label ID="LbPath" runat="server" Text="Here will Show the path"></asp:Label>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="Label1" runat="server"></asp:Label>
                <br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Show" />
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Select if it's PUTTERS data"></asp:Label>
                <asp:CheckBox ID="CheckBox1" runat="server" />
                <asp:Button ID="BnSave" runat="server" OnClick="BnSave_Click" Text="Save" Visible="False" />
                <br />
            </td>
        </tr>
        <tr>
            <td align="center">
                <br />
                <asp:Label ID="LbErrors" runat="server" ForeColor="Red"></asp:Label>
                <asp:GridView ID="GridView2" runat="server" ForeColor="#000099">
                </asp:GridView>
                <br />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="LbMensaje" runat="server" Font-Bold="True"></asp:Label>
                <br />
                <br />
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
            </td>
        </tr>
    </table>

    <script>
        document.addEventListener("DOMContentLoaded", function () {
            var dropArea = document.querySelector(".drag-drop-area");

            dropArea.addEventListener("dragover", function (event) {
                event.preventDefault(); // Evita que el archivo se abra en otra pestaña
            });

            dropArea.addEventListener("drop", function (event) {
                event.preventDefault(); // Evita que el archivo se abra en otra pestaña

                var fileInput = document.getElementById('<%= BtnBrowser.ClientID %>');
            if (event.dataTransfer.files.length > 0) {
                fileInput.files = event.dataTransfer.files;
            }
        });
        });
    </script>
</asp:Content>
