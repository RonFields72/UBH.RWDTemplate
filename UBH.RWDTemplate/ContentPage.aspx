<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContentPage.aspx.cs" Inherits="UBH.RWDTemplate.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="cphMainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>An example content page.</h3>
    <address>
        2790 South Thompson St
        <br />
        Springdale, AR 72764
        <br />
        <abbr title="Phone">P:</abbr>
        (479) 435-1000
    </address>

    <address>
        <strong>IT Department:</strong> <a href="mailto:IT@ubh.com">IT@ubh.com</a>
    </address>
</asp:Content>
