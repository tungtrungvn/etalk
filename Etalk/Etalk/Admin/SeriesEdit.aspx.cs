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
                IsDisabled.Visible = true;
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
                chkIsDisabled.Checked = series.IsDisabled;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SeriesProcess process = new SeriesProcess();
            string err = string.Empty;
            bool result = false;
            if (id == 0)
                result = process.AddNewSeries(txtSeriesName.Text.Trim(), ref err);
            else
                result = process.EditSeries(id,txtSeriesName.Text.Trim(), chkIsDisabled.Checked,err);
            if(!string.IsNullOrEmpty(err)) lblMessage.Text = err;
            else if(!result) lblMessage.Text = "System fail.";
            else lblMessage.Text = "Update series successful.";
        }
    }
}