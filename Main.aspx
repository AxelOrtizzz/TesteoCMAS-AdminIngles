<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="CallawayWeb._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="ContentTitle">
        <hgroup>
            <h1>CMAS</h1>
            <h2>ADMINISTRATOR</h2>
        </hgroup>
        <img alt="You can't argue with physics." class="auto-style3" src="Images/IsacN.jpg" style="height:450px; width:420px;" />
    </div>
        <%--<ol class="round">
        <li class="one">
            <h5>Alta de Raw_Materials</h5>
            Esta sección permitirá dar de alta Raw_Materials con las que se alimenta el sistema.</li>
        <li class="two">
            <h5>Report</h5>
            En esta sección podrá Show los resultados de producción.</li>
    </ol>--%>
    <%--<img alt="You can't argue with physics." class="auto-style3" src="Images/juniors-2018-xj_2___2.png" />--%>
</asp:Content>
<%--<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>CMAS Admin</h1>
            </hgroup>
        </div>
    </section>
</asp:Content>--%>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        @import url('https://fonts.googleapis.com/css2?family=Boldonse&family=Quicksand:wght@700&family=Rajdhani:wght@300;400;500;600;700&display=swap');
    .ContentTitle {
        display: flex;
        align-items: center;
        justify-content: space-between;
        text-align: left;
        width: 100%;
        max-width: 800px; /* Ajusta según necesidad */
        margin: auto;
    }

    hgroup {
        display: flex;
        flex-direction: column;
    }

    h1 {
        font-size: 120px;
        margin-bottom: 2px;
        color: red;
        line-height: 1; /* Mantiene las líneas más juntas */
        margin-top: 0;
        font-family: "Boldonse", system-ui;
  font-weight: 400;
  font-style: normal;
    }

    h2 {
        font-size: 32px;
        font-weight: lighter;
        margin: 0;
        margin-top: -10px; /* Reduce aún más el espacio superior */
        line-height: 1; /* Mantiene las líneas más juntas */
        text-align: right;
    }

    .ContentTitle img {
        height: 450px;
        width: 420px;
        object-fit: cover;
    }
    </style>
</asp:Content>

