using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Etalk.Bussiness;
using Etalk.Data;

namespace Etalk.Web.Admin
{
    public partial class SeriesEdit : System.Web.UI.Page
    {
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string strId = Request.QueryString["id"];
            if (string.IsNullOrEmpty(strId))
                (Master as Admin).SetTitle("Add new series");
            else
            {
                (Master as Admin).SetTitle("Edit series");
                SeriesId.Visible = true;
                //int id = 0;
                int.TryParse(strId, out id);
                if(id > 0)LoadSeries(id);
            }
        }

        private void LoadSeries(int id)
        {
            SeriesProcess process = new SeriesProcess();
            Series series = process.GetSeriesById(id);
            if (series != null)
            {
                lblSeriesId.Text = series.Id.ToString();
                txtSeriesName.Text = series.Name;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}