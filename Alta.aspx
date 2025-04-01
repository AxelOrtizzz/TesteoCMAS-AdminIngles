<%@ Page Title="Alta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alta.aspx.cs" Inherits="CallawayWeb.About" %>
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
                        </div>

                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="auto-style28">
                    <asp:Panel ID="Panel1" runat="server" Visible="false">
                        <asp:Button ID="BtnModel" runat="server" OnClick="BtnModel_Click" Text="Model" CssClass="custom-button" />
                        <asp:Button ID="BtnRaw_Materials" runat="server" OnClick="Button2_Click" Text="Raw_Materials" CssClass="custom-button" />
                        <asp:Button ID="BtnSpecsInd" runat="server" OnClick="BtnSpects_Click" Text="Specs" CssClass="custom-button" />
                        <asp:Button ID="BtnSpects" runat="server" OnClick="Button2_Click1" Text="Add Masive Specs" CssClass="custom-button" />
                        <asp:Button ID="BtnRawMaterials" runat="server" OnClick="Button3_Click" Text="Add Masive Raw_Materials" CssClass="custom-button" />
                        <asp:Button ID="BtnAddBOM" runat="server" OnClick="BtnAddBOM_Click" Text="Add Masive BOM" CssClass="custom-button" />
                        <asp:Button ID="BtnAddBomInd" runat="server" OnClick="AddBOMInd_Click" Text="BOM" CssClass="custom-button" />
                        <br />
                        <asp:Label ID="LbEmployee_Id0" runat="server"></asp:Label>
                        &nbsp;<asp:Label ID="LbEmployee_Id" runat="server"></asp:Label>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:Panel ID="AltaModel" runat="server" Visible="False" DefaultButton="BtGuardaModel">
                        <table class="auto-style2">
                            <tr>
                                <td class="TituloTabla" colspan="2">Setup Models</td>
                            </tr>
                            <tr>
                                <td class="auto-style26">Model: </td>
                                <td class="auto-style27" colspan="1">
                                    <asp:TextBox ID="TxtModel" runat="server" Height="14px" CssClass="TextBoxTabla" Width="254px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtModel" ErrorMessage="Requiere definir el nombre del Model." ValidationGroup="Grupo1">*</asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="TxtModel" ErrorMessage="Indique el Model" ValidationGroup="Model">*</asp:RequiredFieldValidator>
                                    <asp:Button ID="BtnSearch" runat="server" OnClick="Button6_Click" Text="Search" ValidationGroup="Model" />
                                </td>
                            </tr>
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
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="BtGuardaModel" runat="server" OnClick="BtSaveModel_Click" Text="Save" ValidationGroup="Grupo1"/>
                                    <asp:Button ID="BtnDeleteModel" runat="server" OnClick="BtnDeleteModel_Click" Text="Delete" Visible="False" />
                                    <br />
                                    <asp:Label ID="LbErrorModels" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:GridView ID="GvModels" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GvModels_SelectedIndexChanged">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True" />
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

                    <asp:Panel ID="AltaRaw_Materials" runat="server" Visible="False" DefaultButton="BtSaveRaw_Material">
                        <div style="display: flex;">
                            <div style="flex: 1; width: 65%;">
                            <table class="auto-style2">
                            <tr>
                                <td colspan="2" class="auto-style12"><span class="TituloTabla">Setup Raw_Materials</span></td>
                            </tr>
                            <tr>
                                <td class="auto-style23">Category:</td>
                                <td style="text-align: left" class="auto-style24">
                                    <asp:DropDownList ID="DDCategory0" runat="server" Height="19px" OnSelectedIndexChanged="DDCategory0_SelectedIndexChanged" style="margin-left: 0px" Width="140px" AutoPostBack="True">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>GRIP</asp:ListItem>
                                        <asp:ListItem>HD</asp:ListItem>
                                        <asp:ListItem>SF</asp:ListItem>
                                        <asp:ListItem Value="HC">HC</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="DDCategory0" ErrorMessage="Seleccione una Category." InitialValue="" ValidationGroup="Grupo2">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style23">Model:</td>
                                <td class="auto-style24" style="text-align: left">
                                    <asp:DropDownList ID="DDModels" runat="server" AppendDataBoundItems="True" AutoPostBack="True" Height="19px" OnSelectedIndexChanged="DDModels_SelectedIndexChanged" style="margin-left: 0px" Width="140px">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DDModels" ErrorMessage="Seleccione un Model" InitialValue="" ValidationGroup="Grupo2">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style15">Raw_Material:</td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="TxtRaw_Material" runat="server" CssClass="TextBoxTable" MaxLength="20" Height="19px" OnTextChanged="TxtRaw_Material_TextChanged"></asp:TextBox>
                                    <asp:Button ID="BtnSearch1" runat="server" OnClick="Button1_Click" Text="Search" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtRaw_Material" ErrorMessage="Introduzca el nombre de la Raw_Material." ValidationGroup="Grupo2">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style15">Description:</td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="__TxtRaw_Material0" runat="server" CssClass="TextBoxTable" ValidateRequestMode="Disabled" MaxLength="50" Height="19px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="__TxtRaw_Material0" ErrorMessage="Introduzca una Description." ValidationGroup="Grupo2">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style15">
                                    <asp:Label ID="LbMano" runat="server" Text="Mano"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:DropDownList ID="DDRL" runat="server" Height="19px" style="margin-left: 0px" Width="140px">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>LH</asp:ListItem>
                                        <asp:ListItem>RH</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="DDRL" ErrorMessage="Seleccione si es RH o LH" InitialValue="" ValidationGroup="Grupo2">*</asp:RequiredFieldValidator>
                                    <asp:TextBox ID="TxGrip" runat="server" MaxLength="5" Visible="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style15">
                                    <asp:Label ID="LbLongitud" runat="server" Text="Longitud:" Visible="False"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="TxLength" runat="server" Visible="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style13">Head Number:</td>
                                <td class="auto-style14" style="text-align: left">
                                    <asp:TextBox ID="TxtLoft" runat="server" CssClass="TextBoxTable" MaxLength="8" Height="19px"></asp:TextBox>
                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="__TxtRaw_Material0" ErrorMessage="Defina el tipo de material." ValidationGroup="Grupo2">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style16">Material:</td>
                                <td class="auto-style17" style="text-align: left">
                                    <asp:DropDownList ID="DDMaterial" runat="server" Height="19px" style="margin-left: 0px" Width="140px" AppendDataBoundItems="True">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="DDMaterial" ErrorMessage="Seleccione el material." InitialValue="" ValidationGroup="Grupo2">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style15">Dobla:</td>
                                <td style="text-align: left">
                                    <asp:DropDownList ID="DDIsBlend" runat="server" Height="19px" style="margin-left: 0px" Width="140px">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem Value="N">No</asp:ListItem>
                                        <asp:ListItem Value="Y">Si</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="DDIsBlend" ErrorMessage="Seleccione si tiene doblez o no." InitialValue="" ValidationGroup="Grupo2">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style15">Gender:</td>
                                <td style="text-align: left">
                                    <asp:DropDownList ID="DDGender" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>W</asp:ListItem>
                                        <asp:ListItem>M</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="DDGender" ErrorMessage="Indique el Gender" ValidationGroup="Grupo2">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td id="tdImagen" runat="server" class="auto-style15">Imagen:</td>
                                <td style="text-align: left">
                                    <asp:FileUpload ID="FileUploadImagen" runat="server" onchange="validarImagen(this);" />
                                    <asp:Label ID="LbMensajeImagen" runat="server" ForeColor="Red"></asp:Label>
                                    <br />
                                    <asp:Image ID="ImgParte" runat="server" Width="200px" Height="200px" Visible="false" />
                                    <asp:Label ID="LblNoImagen" runat="server" ForeColor="Red" Text="No hay imagen disponible" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            </table>
                            </div>
                            <div style="flex: 0 0 auto; width: 40%; display: flex; justify-content: flex-start; align-items: flex-start;"> 
                                <img id="imagenPrevia" class="style-img" src="#" alt="" style="width: 400px; height: 200px; display: none;">
                                <p id="textoPlaceholder">Vista previa de la imagen</p>
                            </div>
                        </div>
                            <table colspan="2" class="auto-style12">
                                    <asp:Button ID="BtSaveRaw_Material" runat="server" Text="Save" OnClick="BtSaveRaw_Material_Click" ValidationGroup="Grupo2" />
                                    <asp:Button ID="BtnUpdateRaw_Material" runat="server" OnClick="BtnUpdateRaw_Material_Click" Text="Update" Visible="False" />
                                    <asp:Button ID="BtnDeleteRaw_Material" runat="server" Text="Delete" OnClick="BtnDeleteRaw_Material_Click" Visible="False" />
                                    <caption>
                                    <br />
                                    <asp:Label ID="LbErrorRaw_Materials" runat="server" ForeColor="Red"></asp:Label>
                                    <br />
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="3" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="100%">
                                        <AlternatingRowStyle HorizontalAlign="Left" />
                                        <Columns>
                                            <asp:BoundField DataField="RawMaterial_Id" HeaderText="Raw Material" />
                                            <asp:BoundField DataField="RawMaterial_Desc" HeaderText="Descripción" />
                                            <asp:BoundField DataField="RL" HeaderText="RL" />
                                            <asp:BoundField DataField="Model_id" HeaderText="Model" />
                                            <asp:BoundField DataField="Loft" HeaderText="Head Number" />
                                            <asp:BoundField DataField="Shaft_Material" HeaderText="Material" />
                                            <asp:BoundField DataField="Isblend" HeaderText="Dobla" />
                                            <asp:BoundField DataField="Category" HeaderText="Category" />
                                            <asp:BoundField DataField="Date_Inserted" HeaderText="Fecha" />
                                            <asp:BoundField DataField="gender" HeaderText="Gender" />
                                            <asp:CommandField SelectText="Select" ShowSelectButton="True" />
                                        </Columns>

                                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" HorizontalAlign="Left" />
                                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#594B9C" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#33276A" />
                                    </asp:GridView>
                                    <br />
                                </caption>
                        </table>
                    </asp:Panel>

                    <asp:Panel ID="AltaLimites" runat="server" Visible="False" DefaultButton="BtSaveSpecs">
                        <table class="auto-style2">
                            <tr>
                                <td colspan="2" class="auto-style22">Alta de Specs</td>
                            </tr>
                            <tr>
                                <td class="auto-style20">Model:</td>
                                <td class="auto-style19">
                                    <asp:DropDownList ID="DDModels0" runat="server" AppendDataBoundItems="True" Height="19px" style="margin-left: 0px" Width="140px" AutoPostBack="True" OnSelectedIndexChanged="DDModels0_SelectedIndexChanged">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Seleccione un Model" ValidationGroup="Grupo3" ControlToValidate="DDModels0">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style20">
                                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" />
                                    SKU</td>
                                <td class="auto-style19">
                                    <asp:TextBox ID="TxSKU" runat="server" Enabled="False" OnTextChanged="TxSKU_TextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="TxSKU" ErrorMessage="Indique el SKU" ValidationGroup="Grupo3">*</asp:RequiredFieldValidator>
                                    <asp:Button ID="BtnSearchLimites" runat="server" OnClick="BtnSearchSpects_Click" Text="Search" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style20">Operation:</td>
                                <td class="auto-style19">
                                    <asp:DropDownList ID="DDOperations" runat="server" AppendDataBoundItems="True" Height="19px" style="margin-left: 0px" Width="140px" AutoPostBack="True" OnSelectedIndexChanged="DDOperations_SelectedIndexChanged">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Seleccione la Operation" ValidationGroup="Grupo3" ControlToValidate="DDOperations">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <caption>
                                Gender
                                <tr>
                                    <td class="auto-style20">Gender:</td>
                                    <td class="auto-style19">
                                        <asp:DropDownList ID="DDGenderLim" runat="server" OnSelectedIndexChanged="DDGenderLim_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="DDGenderLim" ErrorMessage="Introduzca el Gender." ValidationGroup="Grupo3">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style7">Head Number:</td>
                                    <td class="auto-style5">
                                        <asp:TextBox ID="TxtLoftLim" runat="server" CssClass="TextBoxTabla" Height="19px" MaxLength="8"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TxtLoftLim" ErrorMessage="Indique el tipo" ValidationGroup="Grupo3">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style20">Description de Spec:</td>
                                    <td class="auto-style19">
                                        <asp:DropDownList ID="DDdescLim" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="DDdescLim" ErrorMessage="Describa el Spec." ValidationGroup="Grupo3">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style20">Spec (Decimal):</td>
                                    <td class="auto-style19">
                                        <asp:TextBox ID="TxtSpecDec" runat="server" AutoPostBack="True" CssClass="TextBoxTabla" Height="19px" MaxLength="14" OnTextChanged="TxtLimDec_TextChanged"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="TxtSpecDec" ErrorMessage="Introduzca el Limite (Decimal)" ValidationGroup="Grupo3">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style20">Spec (Fracción):</td>
                                    <td class="auto-style19">
                                        <asp:TextBox ID="TxtSpecFrac" runat="server" CssClass="TextBoxTabla" Height="19px" MaxLength="14"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="TxtSpecFrac" EnableTheming="True" ErrorMessage="Introduzca el Spec (Fracción)" ValidationGroup="Grupo3">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style21" colspan="2">
                                        <asp:Button ID="BtSaveSpecs" runat="server" OnClick="BtSaveSpects_Click" Text="Save" ValidationGroup="Grupo3" />
                                        <asp:Button ID="BtnUpdateSpec" runat="server" OnClick="BtnUpdateSpects_Click" Text="Update" ValidationGroup="Grupo3" Visible="False" />
                                        <asp:Button ID="BtnDeleteSpec" runat="server" OnClick="BtnDeleteSpects_Click" Text="Delete" ValidationGroup="Grupo3" Visible="False" />
                                        <asp:Button ID="BtnRestartSpect" runat="server" OnClick="Button7_Click" Text="Re Start" />
                                        <br />
                                        <asp:Label ID="LbErrors" runat="server"></asp:Label>
                                        <br />
                                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="3" HorizontalAlign="Center" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" Width="100%">
                                            <AlternatingRowStyle HorizontalAlign="Left" />
                                            <Columns>
                                                <asp:BoundField DataField="Model_Id" HeaderText="Model ID" />
                                                <asp:BoundField DataField="Operation_id" HeaderText="Operation ID" />
                                                <asp:BoundField DataField="Operation" HeaderText="Operation" />
                                                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                                <asp:BoundField DataField="Head type" HeaderText="Head type" />
                                                <asp:BoundField DataField="Spect" HeaderText="Spec" />
                                                <asp:BoundField DataField="Spect Decimal" HeaderText="Decimal Value" />
                                                <asp:BoundField DataField="Spect Fraction" HeaderText="Fraction Value" />
                                                <asp:BoundField DataField="Date_Inserted" HeaderText="Date Inserted" />
                                                <asp:CommandField SelectText="Select" ShowSelectButton="True" />
                                            </Columns>
                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                            <RowStyle BackColor="#DEDFDE" ForeColor="Black" HorizontalAlign="Left" />
                                            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#594B9C" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#33276A" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </caption>
                        </table>
                    </asp:Panel>

                    <asp:Panel ID="AddMasiveSpecs" runat="server" Visible="False">
                            <table class="auto-style2">
                                <tr>
                                    <td colspan="3">
                                        <h1 style="margin-top:0;">Add Masive Specs</h1>
                                        Select excel file that contains the Specs:<br />
                                        <br />
                                        <%--<asp:FileUpload ID="FileUpload1" runat="server" />--%>
                                        <label for="BtnBrowser" class="drag-drop-area">
                                            <div>Drag and drop your file here</div>
                                            <div><small>or click to select a file</small></div>
                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                        </label>
                                        <br />
                                        <asp:Label ID="Label3" runat="server"></asp:Label>
                                        <br />
                                        <asp:Button ID="BtnReadFile" runat="server" OnClick="BtnReadFile_Click" Text="Read File" />
					
                                        <br />
                                        <asp:Label ID="Label4" runat="server" ForeColor="Red"></asp:Label>
					
                                        <br />
					
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3">
                                        <br />
                                        <asp:Button ID="BnSave" runat="server" OnClick="BnSave_MasiveSpecs" Text="Send to Database" Visible="False" />
                                        <asp:GridView ID="GridView3" runat="server" OnRowDeleting="Gridview1_RowDeleting">
                                        </asp:GridView>
                                        <asp:Label ID="LbInsertados" runat="server"></asp:Label>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2" align="center">
                                        <asp:GridView ID="GridView4" runat="server">
                                        </asp:GridView>
                                    </td>
            
                                </tr>
                                <tr>
                                    <td align="center">
                                        <br />
                                        <asp:Label ID="LbMensaje" runat="server" ForeColor="Red"></asp:Label>
                                        <asp:GridView ID="GridView5" runat="server" ForeColor="Red">
                                        </asp:GridView>
                                    </td>
            
                                </tr>
                            </table>
                    </asp:Panel>

                    <asp:Panel ID="AddMasiveRM" runat="server" Visible="False">
                            <table class="auto-style1" style="width:100%">
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
                                        <asp:Button ID="Button1" runat="server" OnClick="BtnReadRW" Text="Read File" />
                                        <br />
                                        <br />
                                        <asp:Button ID="ButtonSRW" runat="server" OnClick="BnSaveRW" Text="Save" Visible="False" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
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
                    </asp:Panel>
                        
                    <asp:Panel ID="AddBOM" runat="server" Visible="False">
                         <table class="auto-style2">
                             <tr>
                                 <td>
                                     <h1 style="margin-top:0;">Add Masive BOM</h1>
                                     Select the file with the Product and its Raw_Materials:<br /><br />
                                     <%--<asp:FileUpload ID="BtnBrowser" runat="server" /></td>--%>
                                     <label for="BtnBrowser" class="drag-drop-area">
                                         <div>Drag and drop your file here</div>
                                         <div><small>or click to select a file</small></div>
                                         <asp:FileUpload ID="BtnBrowserAB" runat="server" />
                                     </label>
                             </tr>
                             <tr>
                                 <td><asp:Label ID="Label2" runat="server"></asp:Label>
                                     <br />
                                     <asp:Button ID="Button2" runat="server" OnClick="BtnAB" Text="Read File" />
                                     <br />
                                     <br />
                                     <asp:Button ID="BtnSaveAB" runat="server" OnClick="BnSaveAB" Text="Save" Visible="False" /></td>
                             </tr>
                             <tr>
                                 <td align="center">
                                     <asp:Label ID="Label5" runat="server" ForeColor="Red"></asp:Label>
             
                                     <asp:GridView ID="GridViewAB1" runat="server">
                                     </asp:GridView>
                                     <br />
                                     <asp:Label ID="LbMessage" runat="server" Font-Bold="True"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td align="center">
                                     <asp:GridView ID="GridViewAB2" runat="server" ForeColor="Red" Visible="False">
                                     </asp:GridView>
                                 </td>
                             </tr>
                             <tr>
                                 <td align="center">
                                     <asp:GridView ID="GridViewAB3" runat="server" ForeColor="Red">
                                     </asp:GridView>
                                 </td>
                             </tr>
                         </table>
                    </asp:Panel>

                    <asp:Panel ID="AddBOMInd" runat="server" Visible="False">
                         <table class="auto-style2">
                             <tr>
                                 <td>Product:
                                     <asp:TextBox ID="TxbProduct" runat="server" CssClass="design-textbox"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TxbProduct" ErrorMessage="Indique Product" CssClass="design-validator" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                     <asp:Button ID="Button3" runat="server" OnClick="BtnSearchBM_Click" Text="Search" CssClass="design-button" />
                                 </td>
                             </tr>
                             <tr>
                                 <td>Raw_Material:
                                     <asp:TextBox ID="TxbRawMaterial" runat="server" CssClass="design-textbox"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="TxbRawMaterial" ErrorMessage="Indique Raw_Material" CssClass="design-validator" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="2">
                                     <asp:Button ID="BtnSaveBOM" runat="server" OnClick="BtnSaveBOM_Click" Text="Save" ValidationGroup="1" />
                                     <asp:ValidationSummary ID="ValidationSummary4" runat="server" ForeColor="Red" ValidationGroup="1" />
                                     <br />
                                     <asp:Label ID="Label6" runat="server" ForeColor="Red"></asp:Label>
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
                    </asp:Panel>
                    <br />
                    <br />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC0000" style="text-align: left" ValidationGroup="Grupo1" />
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="#CC0000" style="text-align: left" ValidationGroup="Grupo2" />
                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ForeColor="#CC0000" style="text-align: left" ValidationGroup="Grupo3"/>
                    <br />
                    <br />
                </td>
            </tr>
        </table>
    </article>
    <script type="text/javascript">
    function validarImagen(input) {
        const file = input.files[0];
        const labelError = document.getElementById('<%= LbMensajeImagen.ClientID %>');
        const imagenPrevia = document.getElementById('imagenPrevia');
        const textoPlaceholder = document.getElementById('textoPlaceholder');

        if (file) {
            const fileType = file.type;

            if (fileType.startsWith('image/')) {
                labelError.textContent = '';

                const lector = new FileReader();
                lector.addEventListener('load', function () {
                    // Mostrar la imagen seleccionada en la vista previa
                    imagenPrevia.src = this.result; // Mostrar en <img>
                    imagenPrevia.style.display = 'block'; // Hacer visible la imagen
                    textoPlaceholder.style.display = 'none'; // Ocultar el texto de placeholder
                });

                lector.readAsDataURL(file);
            } else {
                labelError.textContent = 'Error: Solo se permiten archivos de imagen.';
                input.value = '';
                imagenPrevia.src = '#';
                imagenPrevia.style.display = 'none';
                textoPlaceholder.style.display = 'block'; // Mostrar el texto de placeholder

                setTimeout(function () {
                    {
                        labelError.style.display = 'none';
                        
                    }
                }, 5000);
            }
        } else {
            labelError.textContent = '';
            imagenPrevia.src = '#';
            imagenPrevia.style.display = 'none';
            textoPlaceholder.style.display = 'block'; // Mostrar el texto de placeholder
        }
    }

    function mostrarImagen(imageUrl) {
        var img = document.getElementById("imagenPrevia");
        var placeholder = document.getElementById("textoPlaceholder");

        // Convertir la ruta relativa a una ruta absoluta
        var absoluteUrl = new URL(imageUrl, window.location.origin).href;

        img.src = absoluteUrl; // Asignar la URL de la imagen
        img.style.display = "block"; // Mostrar la imagen
        placeholder.style.display = "none"; // Ocultar mensaje de error
    }

    function mostrarTexto() {
        var img = document.getElementById("imagenPrevia");
        var placeholder = document.getElementById("textoPlaceholder");

        img.style.display = "none"; // Oculta la imagen
        placeholder.textContent = "No hay imagen disponible"; // Mensaje de error
        placeholder.style.display = "block"; // Mostrar mensaje de error
    }




    setInterval(function () {
        eliminarImagenes();
    }, 30000); // Ejecuta cada 30 segundos

    function eliminarImagenes() {
        fetch('Alta.aspx/EliminarImagenes', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({})
        })
            .then(response => response.json())
            .then(data => console.log("Imágenes eliminadas"))
            .catch(error => console.error("Error eliminando imágenes", error));
    }

    


    </script>
    </asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 40px;
        }
        .auto-style2 {
            width: 100%;
        }
                        
        .auto-style5 {
            height: 23px;
            text-align: left;
        }
        
        .auto-style7 {
            height: 23px;
            width: 499px;
            text-align: right;
        }
                
        .auto-style12 {
            text-align: center;
            width:100%;
        }
        .auto-style13 {
            width: 475px;
            text-align: right;
            height: 24px;
        }
        .auto-style14 {
            height: 24px;
        }
        .auto-style15 {
            width: 475px;
            text-align: right;
        }
        .auto-style16 {
            width: 475px;
            text-align: right;
            height: 26px;
        }
        .auto-style17 {
            height: 26px;
        }
                
        .auto-style19 {
            text-align: left;
        }
        .auto-style20 {
            width: 499px;
            text-align: right;
        }
        .auto-style21 {
            text-align: center;
        }
        .auto-style22 {
            font-family: Arial, Helvetica, sans-serif;
            font-size: medium;
            font-weight: bold;
            text-align: center;
        }
        .auto-style23 {
            text-align: right;
            width: 484px;
            height: 16px;
        }
        .auto-style24 {
            width: 75%;
            height: 16px;
        }
        
        .auto-style25 {
            text-align: right;
            width: 484px;
            height: 29px;
        }
        
        .auto-style26 {
            text-align: right;
            width: 484px;
            height: 26px;
        }
        .auto-style27 {
            text-align: left;
            height: 26px;
        }
        
        .auto-style28 {
            height: 10px;
        }
        
        .auto-style29 {
            text-align: left;
            height: 29px;
        }

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
