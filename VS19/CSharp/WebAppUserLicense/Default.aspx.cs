using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VDF = Autodesk.DataManagement.Client.Framework;
using Autodesk.Connectivity.WebServices;

namespace WebAppUseUserLicense
{
    public partial class _Default : Page
    {
        private static readonly string FORGE_SERVER_URL = "https://developer.api.autodesk.com";
        private static readonly string FORGE_CLIENT_ID = "YourForgeAppClientIdHere"; //change to your Forge App client Id. visit https://forge.autodesk.com/ to learn how to create your app.
        private static readonly string CALLBACK_URL = "http://localhost/WebAppExample/Default.aspx"; //change to your Forge App callback Url. the url must be able to handle the callback input. e.g., in this example app the Default.aspx use javascript to read the token from the callback.
        private VDF.Vault.Currency.Connections.Connection m_conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["access_token"]))
            {
                string token = Request.QueryString["access_token"];
                Session["token"] = token;
                Response.Redirect("Default.aspx");
            }
            if (Session["token"] == null)
            {
                Panel0.Visible = true;
                Panel1.Visible = true;
                Panel2.Visible = false;
                Panel3.Visible = false;
            }
            else
            {
                Panel0.Visible = true;
                Panel1.Visible = false;
                tbToken.Text = Session["token"].ToString();
                if (Session["conn"] == null)
                {
                    Panel2.Visible = true;
                    Panel3.Visible = false;
                    tbUserName.Visible = !cbUseAutodeskId.Checked;
                    tbPassword.Visible = !cbUseAutodeskId.Checked;
                }
                else
                {
                    m_conn = (VDF.Vault.Currency.Connections.Connection)Session["conn"];
                    Panel0.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = true;
                }
            }

        }

        protected void btLogin_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "start login...";
            VDF.Vault.Results.LogInResult results;
            if (cbUseAutodeskId.Checked)
            {
                AutodeskAccount adAccount = AutodeskAccount.BuildAccountAsync(tbToken.Text).Result;
                results = VDF.Vault.Library.ConnectionManager.LogInWithUserLicense(
                tbServerName.Text, tbVaultName.Text, adAccount, VDF.Vault.Currency.Connections.AuthenticationFlags.AutodeskAuthentication, null);
            }
            else
            {
                results = VDF.Vault.Library.ConnectionManager.LogInWithUserLicense(
                tbServerName.Text, tbVaultName.Text, tbUserName.Text, tbPassword.Text, tbToken.Text, VDF.Vault.Currency.Connections.AuthenticationFlags.Standard, null);

            }
           m_conn = results.Connection;
            if (m_conn != null)
            {
                lbStatus.Text = "Login finished.";
                Session["conn"] = m_conn;
                Panel0.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = true;
            }
            else
            {
                lbStatus.Text = "Login failed with error: " + results.ErrorMessages.Values.ToList().Aggregate( (a,b) => a + "; " + b);
            }

        }
        private void ListFolderContent(long folderId)
        {

            ListBox1.Items.Clear();
            var folder = m_conn.FolderManager.GetFoldersByIds(new long[] { folderId }).First().Value;
            var folders = m_conn.FolderManager.GetChildFolders(folder, false, false).ToList();
            folders.ForEach(f =>
            {
                ListItem x;
                x = new ListItem(f.EntityName, f.Id.ToString());
                x.Attributes.Add("type", "folder");
                ListBox1.Items.Add(x);
            }
            );

            var propFolderPath = m_conn.PropertyManager.GetPropertyDefinitionBySystemName("FolderPath");
            var cond = new SrchCond();
            cond.PropDefId = propFolderPath.Id;
            cond.SrchOper = 3; //IsExactly
            cond.SrchTxt = folder.FullName;
            //var sort = new SrchSort();
            //sort.PropDefId = 27; //Name
            //sort.SortAsc = true;
            string bookmark = string.Empty;
            SrchStatus status = null;
            var results = m_conn.WebServiceManager.DocumentService.FindFilesBySearchConditions(new SrchCond[] { cond }, null, null, false, true, ref bookmark, out status);
            if (results != null)
            {
                var files = results.ToList();
                files.ForEach(f =>
                {
                    ListItem x;
                    x = new ListItem(f.Name, f.Id.ToString());
                    x.Attributes.Add("type", "file");
                    ListBox1.Items.Add(x);
                });
                if (status.TotalHits > files.Count)
                {
                    ListBox1.Items.Add("...");
                }
            }
        }

        protected void btListFolder_Click(object sender, EventArgs e)
        {
            PopFolderTree();
        }
        private void PopFolderTree()
        {

            tvFolders.Nodes.Clear();
            TreeNode tn = new TreeNode("Project Explorer($)", "1");
            tvFolders.Nodes.Add(tn);
            AddTreeNode(tn, 1);
        }


        private void AddTreeNode(TreeNode parent, long parentId)
        {
            var folder = m_conn.FolderManager.GetFoldersByIds(new long[] { parentId }).First().Value;
            var folders = m_conn.FolderManager.GetChildFolders(folder, false, false).ToList();
            parent.ChildNodes.Clear();
            folders.ForEach(f => {
                TreeNode tn = new TreeNode(f.EntityName, f.Id.ToString());
                parent.ChildNodes.Add(tn);
            }
            );
        }

        protected void btAid_Click(object sender, EventArgs e)
        {
            string autodeskIdLoinUrl = FORGE_SERVER_URL + "/authentication/v1/authorize?response_type=token&client_id=" + FORGE_CLIENT_ID + "&scope=data:read&redirect_uri=" + CALLBACK_URL;
            Response.Redirect(autodeskIdLoinUrl);
        }

        protected void tvFolders_SelectedNodeChanged(object sender, EventArgs e)
        {
            long folderId;
            long.TryParse(tvFolders.SelectedNode.Value, out folderId);
            AddTreeNode(tvFolders.SelectedNode, folderId);
            ListFolderContent(folderId);
            lbStatus.Text = "Done.";
        }

        protected void btLogout_Click(object sender, EventArgs e)
        {
            Session["token"] = null;
            Session["conn"] = null;
            Response.Redirect("Default.aspx");
        }

    }
}