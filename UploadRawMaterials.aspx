<%@ Page Title="Alta" Language="C#" MasterPageFile="~/Produccion.Master" AutoEventWireup="true" CodeBehind="UploadRawMaterials.aspx.cs" Inherits="CallawayWeb.UploadParts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
         .drag-drop-area {
        display: inline-grid;
    width: 50%;
    height: 150px;
    border: 2px dashed #888;
    text-align: center;
    padding-top: 10px;
    cursor: pointer;
    background-color: #f9f9f9;
    border-radius: 8px;
    box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
    transition: background-color 0.3s ease;
    justify-content: center;
    align-content: space-around;
    justify-items: center;
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
    <table class="auto-style1">
        <tr>
            <td><h1 style="margin-top:0;">Add Masive Raw Materials</h1>
                Select excel file that contains the Raw_Materials:<br/><br/>
                <%--<asp:FileUpload ID="FileUpload1" runat="server" />--%>
                <label for="BtnBrowser" class="drag-drop-area">
                    <div>Drag and drop your file here</div>
                    <div><small>or click to select a file</small></div>
                    <asp:FileUpload ID="FileUploadRW" runat="server" />
                </label>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelRW1" runat="server"></asp:Label>
                <br />
                <asp:Button ID="BtnReadFile" runat="server" OnClick="BtnReadRW" Text="Read File" />
                <br />
                <br />
                <asp:Button ID="BnSave" runat="server" OnClick="BnSaveRW" Text="Save" Visible="False" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="LbErrors" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <asp:Label ID="LbErrors1" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <asp:Label ID="LbModel" runat="server" Visible="False"></asp:Label>
&nbsp;
                <asp:Label ID="LbDescripcion" runat="server" Font-Bold="True" ForeColor="#0000CC" Visible="False"></asp:Label>
                <asp:GridView ID="GridViewRW2" runat="server" OnSelectedIndexChanged="GridViewRW2_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField SelectText="Register model" ShowSelectButton="True" />
                        <asp:TemplateField HeaderText="Description">
                            <ItemTemplate>
                            <asp:TextBox ID="TxDescripcion" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <asp:GridView ID="GridViewRW1" runat="server">
                </asp:GridView>
                <br />
                <asp:GridView ID="GridViewRW3" runat="server" Visible="False">
                </asp:GridView>
                <br />
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

            var fileInput = document.getElementById('<%= FileUploadRW.ClientID %>');
        if (event.dataTransfer.files.length > 0) {
            fileInput.files = event.dataTransfer.files;
        }
    });
    });
    </script>
</asp:Content>