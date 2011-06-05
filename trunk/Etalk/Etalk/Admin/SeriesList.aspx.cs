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
    public partial class SeriesList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as Admin).SetTitle("List of series");
            if (!IsPostBack)
            {
                LoadListOfSeries();
            }
        }

        void LoadListOfSeries()
        {
            SeriesProcess process = new SeriesProcess();
            List<Series> list = process.GetSeriesList();
            grvSeries.DataSource = list;
            grvSeries.DataBind();
        }

        protected void grvSeries_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = 0;
            int.TryParse((sender as LinkButton).CommandArgument, out id);
            if (id > 0)
            {
                SeriesProcess process = new SeriesProcess();
                bool isEmpty = process.IsSeriesEmpty(id);
                if (!isEmpty)
                {
                    string script = "alert('This series is not empty.\r\nSo you can not delete it.');";
                    ClientScript.RegisterStartupScript(this.GetType(),"deleteSeries",script,true);
                }
                else
                {
                    bool result = process.DeleteSeries(id);
                    if (result)
                    {
                        lblMessage.Text = "Delete series successful.";
                        LoadListOfSeries();
                    }
                    else lblMessage.Text = "System fail.";
                }
            }
        }
    }
}