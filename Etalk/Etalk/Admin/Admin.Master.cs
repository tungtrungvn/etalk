using System;

namespace Etalk.Web.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void SetTitle(string pageTitle)
        {
            ltrPageTitle.Text = pageTitle + "  ::  Etalk" ;
            lblPageTitle.Text = pageTitle;
        }
    }
}