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
    public partial class TopicList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as Admin).SetTitle("List of topics");
            if (!IsPostBack)
            {
                LoadListOfSeries();
            }
        }

        void LoadListOfSeries()
        {
            TopicProcess process = new TopicProcess();
            List<Topic> list = process.GetTopicList();
            grvTopics.DataSource = list;
            grvTopics.DataBind();
        }

        protected void grvTopics_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = 0;
            Control btnDelete = grvTopics.Rows[e.RowIndex].FindControl("btnDelete");
            int.TryParse((btnDelete as LinkButton).CommandArgument, out id);
            if (id > 0)
            {
                TopicProcess process = new TopicProcess();
                bool isEmpty = process.IsTopicEmpty(id);
                if (!isEmpty)
                {
                    string script = "alert('This topic is not empty. So you can not delete it.');";
                    ClientScript.RegisterStartupScript(this.GetType(), "deleteTopic", script, true);
                }
                else
                {
                    bool result = process.DeleteTopic(id);
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