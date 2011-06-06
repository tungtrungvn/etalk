using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etalk.Data;

namespace Etalk.Bussiness
{
    public class TopicProcess : DataBase
    {
        public Topic GetTopicById(int topicId)
        {
            return Data.Topics.SingleOrDefault(t => t.Id == topicId);
        }

        public List<Topic> GetTopicList()
        {
            return Data.Topics.ToList();
        }

        public bool AddNewTopic(string seriesName, ref string err)
        {
            var list = Data.Series.Where(s => s.Name.Equals(seriesName, StringComparison.OrdinalIgnoreCase)).ToList();
            if (list != null && list.Count > 0)
            {
                err = "The other series with this name is existing.";
                return false;
            }
            Series series = new Series();
            series.Name = seriesName;
            Data.Series.AddObject(series);
            return Data.SaveChanges() > 0 ? true : false;
        }
    }
}
