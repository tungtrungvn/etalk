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

        public bool AddNewTopic(string topicTitle, ref string err)
        {
            var list = Data.Topics.Where(t => t.Title.Equals(topicTitle, StringComparison.OrdinalIgnoreCase)).ToList();
            if (list != null && list.Count > 0)
            {
                err = "The other topic with this name is existing.";
                return false;
            }
            Topic topic = new Topic();
            topic.Title = topicTitle;
            Data.Topics.AddObject(topic);
            return Data.SaveChanges() > 0 ? true : false;
        }

        public bool EditTopic(int topicId, string TopicTitle, bool isDisabled, string err)
        {
            var list = Data.Topics.Where(t => t.Title.Equals(TopicTitle, StringComparison.OrdinalIgnoreCase) && t.Id != topicId).ToList();
            if (list != null && list.Count > 0)
            {
                err = "The other topic with this name is existing.";
                return false;
            }
            Topic topic = Data.Topics.SingleOrDefault(t => t.Id == topicId);
            if (topic != null)
            {
                topic.Title = TopicTitle;
                topic.IsDisabled = isDisabled;
                return Data.SaveChanges() > 0 ? true : false;
            }
            return false;
        }

        public bool IsTopicEmpty(int topicId)
        {
            Topic topic = Data.Topics.SingleOrDefault(t => t.Id == topicId);
            if (topic != null)
            {
                if (topic.MediaItems != null && topic.MediaItems.Count > 0) return false;
                else return true;
            }
            return true;
        }

        public bool DeleteTopic(int topicId)
        {
            Topic topic = Data.Topics.SingleOrDefault(t => t.Id == topicId);
            if (topic != null)
            {
                Data.Topics.DeleteObject(topic);
            }
            return Data.SaveChanges() > 0 ? true : false;
        }
    }
}
