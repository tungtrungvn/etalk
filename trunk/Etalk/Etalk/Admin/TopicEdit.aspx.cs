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
    public partial class TopicEdit : System.Web.UI.Page
    {
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string strId = Request.QueryString["id"];
            int.TryParse(strId, out id);
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(strId))
                    (Master as Admin).SetTitle("Add new topic");
                else
                {
                    (Master as Admin).SetTitle("Edit topic");
                    SeriesId.Visible = true;
                    IsDisabled.Visible = true;
                    if (id > 0) LoadTopic(id);
                }
            }
        }

        private void LoadTopic(int id)
        {
            TopicProcess process = new TopicProcess();
            Topic topic = process.GetTopicById(id);
            if (topic != null)
            {
                lblTopicId.Text = topic.Id.ToString();
                txtTopicTitle.Text = topic.Title;
                chkIsDisabled.Checked = topic.IsDisabled;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TopicProcess process = new TopicProcess();
            string err = string.Empty;
            bool result = false;
            if (id == 0)
                result = process.AddNewTopic(txtTopicTitle.Text.Trim(), ref err);
            else
                result = process.EditTopic(id, txtTopicTitle.Text.Trim(), chkIsDisabled.Checked, err);
            if (!string.IsNullOrEmpty(err)) lblMessage.Text = err;
            else if (!result) lblMessage.Text = "System fail.";
            else lblMessage.Text = "Update topic successful.";
        }
    }
}