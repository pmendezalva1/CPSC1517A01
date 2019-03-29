<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>A05 - Planned Assessment</h1>
        <p class="lead">Planned Assessment Project by Patricia Mendez-Alva</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Lab Documententation</h2>
            <p>
                Here, I'll be listing everything to do with my project, which is A05 - Planned Assessment. 
            </p>
            <p>
                Current issues:
                -The page will load but the SQL server fails to connect due to phantom issues (ex. unacceptable column name that wasn't called for)
                -Due to this, the drop down lists won't load.
                -Searches also fail.
                -Parser error when trying to boot from Default. Booting from Form A via Ctrl + F5 works just fine.
            </p>
        </div>        
    </div>

</asp:Content>
