<%@ Page Title="Report" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="CallawayWeb.Contact" %>

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
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">

         <asp:View ID="Tab2" runat="server">
             <table align="center" cellpadding="0" cellspacing="0" class="auto-style2">
                 <tr>
                     <td style="text-align: center">
                         <h1 style="margin-top:0;">Order Results</h1>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         <div class="search-container-wrapper">
                            <div class="search-container">
                                <div class="search-bar">
                                    <asp:TextBox ID="TxtOrder" runat="server" CssClass="search-input" placeholder="Product order..."></asp:TextBox>
                                    <asp:Button ID="BtnSearchOrder" runat="server" OnClick="BtnSearchOrder_Click" CssClass="search-icon" Text="🔍" ForeColor="White" />
                                </div>
                                <div class="glow"></div>
                            </div>
                        </div>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="3" HorizontalAlign="Center" Width="100%">
                             <AlternatingRowStyle HorizontalAlign="Left" />
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
                 <tr>
                     <td align="center">
                         <asp:ImageButton ID="ImageButton2" runat="server" Height="35px" ImageUrl="~/Images/xls2.jpg" OnClick="ImageButton2_Click" style="text-align: right" Visible="False" Width="35px" />
                         <br />
                         <br />
                         <asp:Label ID="LbNoData2" runat="server" Text="There is no order data." Visible="False"></asp:Label>
                         <br />
                         <h3>
                             <asp:Label ID="Label1" runat="server" Text="Result Tests" Visible="False"></asp:Label>
                         </h3>
                         <asp:GridView ID="GridView3" runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="3" HorizontalAlign="Center" Width="100%">
                             <AlternatingRowStyle HorizontalAlign="Left" />
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
                         <asp:ImageButton ID="ImageButton3" runat="server" Height="35px" ImageUrl="~/Images/xls2.jpg" OnClick="ImageButton3_Click" Visible="False" Width="35px" />
                         <br />
                         <asp:Label ID="LbNoData3" runat="server" Text="There is no data from tests results." Visible="False"></asp:Label>
                         <br />   
                         <h3>
                             <asp:Label ID="Label2" runat="server" Text="Rework" Visible="False"></asp:Label>
                         </h3>
                         <br />
                         <asp:GridView ID="GridView4" runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="3" HorizontalAlign="Center" Width="100%">
                             <AlternatingRowStyle HorizontalAlign="Left" />
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
                         <asp:ImageButton ID="ImageButton4" runat="server" Height="35px" ImageUrl="~/Images/xls2.jpg" OnClick="ImageButton4_Click" Visible="False" Width="35px" />
                         <br />
                         <asp:Label ID="LbNoData4" runat="server" Text="There is no data from Rework." Visible="False"></asp:Label>
                         <br />  
                         <br />
                         <h3>
                             <asp:Label ID="Label3" runat="server" Text="Pieces Produced by the Order" Visible="False"></asp:Label>
                         </h3>
                         <asp:GridView ID="GridView5" runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="3" HorizontalAlign="Center" Width="100%">
                             <AlternatingRowStyle HorizontalAlign="Left" />
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
                         <asp:ImageButton ID="ImageButton5" runat="server" Height="35px" ImageUrl="~/Images/xls2.jpg" OnClick="ImageButton5_Click" Visible="False" Width="35px" />
                         <br />
                         <asp:Label ID="LbNoData5" runat="server" Text="There is no data from products." Visible="False"></asp:Label>
                         <br /> 
                     </td>
                 </tr>
                 <tr>
                     <td align="center">
                         <br />
                         <h3><strong>
                             <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Employee_Ids" Visible="False"></asp:Label>
                             </strong></h3>
                         <asp:GridView ID="GridView6" runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="3" HorizontalAlign="Center" Width="100%">
                             <AlternatingRowStyle HorizontalAlign="Left" />
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
                         <asp:ImageButton ID="ImageButton6" runat="server" Height="35px" ImageUrl="~/Images/xls2.jpg" OnClick="ImageButton6_Click" Visible="False" Width="35px" />
                         <br />
                         <asp:Label ID="LbNoData6" runat="server" Text="There is no data from Employees" Visible="False"></asp:Label>
                         <br />    
                     </td>
                 </tr>
             </table>
             <h3>&nbsp;</h3>
             <br />
             <br />
             <br />
    </asp:View>
    <asp:View ID="Tab3" runat="server">
        <table cellpadding=0 cellspacing=0 align="center" class="auto-style2">
            <tr>
                <td style="text-align: center;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <br />
                    <br />
                </td>
            </tr>
        </table>
    </asp:View>
    </asp:MultiView>
    <br />
    <asp:Label ID="LbErrors" runat="server" ForeColor="Maroon"></asp:Label>
    <br />
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }

        h1{
            color: #000;
            letter-spacing: 4px;
            font-size: 25px;
            font-family: "Quicksand", sans-serif;
            font-optical-sizing: auto;
            font-weight: 300;
            font-style: normal;
        }

        .search-container-wrapper {
            display: flex;
            justify-content: center;
            width: 100%;
            margin-top: 15px;
        }

        .search-container {
            position: relative;
            width: 400px;
        }

        .search-bar {
            position: relative;
            display: flex;
            align-items: center;
            background-color: #ebebeb;
            border-radius: 8px;
            padding: 10px;
            overflow: hidden;
            transition: all 0.3s ease;
        }

        .search-input {
            width: 100%;
            border: none;
            background: none;
            color: black;
            font-size: 16px;
            padding: 10px;
            outline: none;
        }

        .search-input::placeholder {
            color: #aaa;
        }

        .search-icon {
            display: flex;
            align-items: center;
            justify-content: center;
            padding: 10px;
            background-color: #333;
            border-radius: 9%;
            margin-left: 11px;
            cursor: pointer;
            transition: background-color 0.3s ease;
            border: none;
            color: white;
            font-size: 15px;
            padding-left: 15px;
            padding-right: 15px;
        }

        .search-icon:hover {
            background-color: #555;
        }

        .search-bar:hover {
            box-shadow: 0 0 15px rgba(255, 255, 255, 0.2);
        }

        .search-bar:focus-within {
            box-shadow: 0 0 30px rgba(255, 255, 255, 0.4);
        }

        .glow {
            position: absolute;
            top: 50%;
            left: 50%;
            width: 100%;
            height: 200%;
            border-radius: 100px;
            background: radial-gradient(circle, rgba(255, 255, 255, 0.1), transparent);
            transition: all 0.5s ease;
            transform: translate(-50%, -50%) scale(0);
            z-index: -1;
        }

        .search-bar:hover + .glow {
            transform: translate(-50%, -50%) scale(1);
        }

        .search-bar:focus-within + .glow {
            transform: translate(-50%, -50%) scale(1.2);
            background: radial-gradient(circle, rgba(255, 255, 255, 0.2), transparent);
        }
        </style>
</asp:Content>
