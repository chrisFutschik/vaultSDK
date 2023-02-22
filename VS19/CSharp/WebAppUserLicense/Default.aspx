<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAppUseUserLicense._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script lang="javascript">
        var params = {},
            queryString = location.hash.substring(1),
            regex = /([^&=]+)=([^&]*)/g,
            m;
        while (m = regex.exec(queryString)) {
            params[m[1]] = m[2];
        }
        if (params["access_token"]) {
            console.log("token:" + params["access_token"]);
            window.location.href = "Default.aspx?access_token=" + params["access_token"];
        }
    </script>
    <asp:Panel ID="Panel0" runat="server">
        <div class="jumbotron">
            <h1>Vault SDK Example</h1>
            <p class="lead">This is an example web app to use Vault SDK in a web app with user license.</p>
        </div>
    </asp:Panel>
    <div class="row">
        <div class="col-md">
            <asp:Panel ID="Panel1" runat="server">
                <h2>Login to Autodesk ID</h2>
                <p>
                    <asp:Button ID="btAid" runat="server" OnClick="btAid_Click" Text="Login AutodeskId" />
                    <asp:TextBox ID="tbToken" runat="server" Width="275px" Visible="false"></asp:TextBox>
                </p>
            </asp:Panel>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Panel ID="Panel2" runat="server">
                <h2>Login to Vault</h2>
                <p>
                    <asp:TextBox ID="tbServerName" runat="server" ToolTip="Server name">localhost</asp:TextBox>
                    <asp:TextBox ID="tbVaultName" runat="server" ToolTip="Vault name">Vault</asp:TextBox>
                    <asp:TextBox ID="tbUserName" runat="server" ToolTip="User name">Administrator</asp:TextBox>
                    <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" ToolTip="password"></asp:TextBox>
                    <asp:Button ID="btLogin" runat="server" OnClick="btLogin_Click" Text="Login" />
                    <asp:CheckBox ID="cbUseAutodeskId" runat="server" Text="Login to Vault use Autodesk ID" AutoPostBack="True" />
                </p>
            </asp:Panel>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
                <asp:Panel ID="Panel3" runat="server">
                    <div class="row">
                        <div class="col">
                            <h2>Operate in Vault</h2>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-11 col-sm-8">
                            <asp:Button ID="btListFolder" runat="server" Text="ListFolder" OnClick="btListFolder_Click" />
                        </div>
                        <div class="col-md-1 col-sm-4">
                            <asp:Button ID="btLogout" runat="server" OnClick="btLogout_Click" Text="Logout" />
                        </div>
                    </div>
                    <div class="row">
                        <table style="width:100%">
                            <tr>
                                <td style="width:30%">
                                    <div style="overflow:auto; border-style: solid; border-width:1px; height:600px;">
                                        <asp:TreeView ID="tvFolders" runat="server" OnSelectedNodeChanged="tvFolders_SelectedNodeChanged" Width="100%">
                                        </asp:TreeView>
                                    </div>
                                </td>
                                <td style="width:70%">
                                    <asp:ListBox ID="ListBox1" runat="server" Width="600px" Height="600px"></asp:ListBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <p>
                <br />
                <asp:Label ID="lbStatus" runat="server" Text="..."></asp:Label>
            </p>
        </div>
    </div>
</asp:Content>
