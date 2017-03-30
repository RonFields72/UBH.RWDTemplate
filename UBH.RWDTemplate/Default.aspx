<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UBH.RWDTemplate._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="cphMainContent" runat="server">
    <div class="jumbotron">
        <h1>Responsive Web Template</h1>
        <p class="lead">
            This is a sample content page using Bootstrap 3.1.1. Bootstrap is a mobile-first responsive framework that easily integrates with ASP.NET.
        </p>
        <p>
            <a href="http://getbootstrap.com/" class="btn btn-primary btn-large">Learn more about Bootstrap</a>
        </p>
    </div>
    <div class="row">
        <div class="col-md-4">
            <h2>4-Wide Column #1</h2>
            <p>
                4 columns wide in Bootstrap using the col-md-4 class.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>4-Wide Column #2</h2>
            <p>
                4 columns wide in Bootstrap using the col-md-4 class.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>4-Wide Column #3</h2>
            <p>
                4 columns wide in Bootstrap using the col-md-4 class.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>
    <div class="row">
        <div class="col-md-8">
            <h2>8-wide column</h2>
            <p>
                This is 8 columns wide in Bootstrap!
            </p>
        </div>
        <div class="col-md-4">
            <h2>4-wide column</h2>
            <p>
                This is 4 columns wide in Bootstrap!
            </p>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <h2>6-wide column</h2>
            <p>
                This is 6 columns wide in Bootstrap!
            </p>
        </div>
        <div class="col-md-6">
            <h2>6-wide column</h2>
            <p>
                This is 6 columns wide in Bootstrap!
            </p>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <h2>6-wide column</h2>
            <p>
                This is 6 columns wide in Bootstrap!
            </p>
        </div>
        <div class="col-md-2">
            <h2>2-wide column</h2>
            <p>
                This is 2 columns wide in Bootstrap!
            </p>
        </div>
        <div class="col-md-2">
            <h2>2-wide column</h2>
            <p>
                This is 2 columns wide in Bootstrap!
            </p>
        </div>
        <div class="col-md-2">
            <h2>2-wide column</h2>
            <p>
                This is 2 columns wide in Bootstrap!
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Text="First Value" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Second Value" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Third Value" Value="3"></asp:ListItem>
                </asp:DropDownList>
            </p>
        </div>
    </div>

</asp:Content>
