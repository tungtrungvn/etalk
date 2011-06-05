using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etalk.Data;

namespace Etalk.Bussiness
{
    public class SeriesProcess : DataBase
    {
        public Series GetSeriesById(int seriesId)
        {
            return Data.Series.SingleOrDefault(s=>s.Id == seriesId);
        }

        public List<Series> GetSeriesList()
        {
            return Data.Series.ToList();
        }

        public bool AddNewSeries(string seriesName, ref string err)
        {
            var list = Data.Series.Where(s=>s.Name.Equals(seriesName, StringComparison.OrdinalIgnoreCase)).ToList();
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

        public bool EditSeries(int seriesId, string seriesName,string err)
        {
            var list = Data.Series.Where(s => s.Name.Equals(seriesName, StringComparison.OrdinalIgnoreCase) && s.Id != seriesId).ToList();
            if (list != null && list.Count > 0)
            {
                err = "The other series with this name is existing.";
                return false;
            }
            Series series = Data.Series.SingleOrDefault(s=>s.Id == seriesId);
            if (series != null)
            {
                series.Name = seriesName;
                return Data.SaveChanges() > 0 ? true : false;
            }
            return false;
        }

        public bool IsSeriesEmpty(int seriesId)
        { 
            Series series = Data.Series.SingleOrDefault(s=>s.Id == seriesId);
            if (series != null)
            {
                if (series.MediaItems != null && series.MediaItems.Count > 0) return true;
                else return false;

            }
            return true;
        }

        public bool DeleteSeries(int seriesId)
        {
            Series series = Data.Series.SingleOrDefault(s=>s.Id == seriesId);
            if (series != null)
            {
                Data.Series.DeleteObject(series);
            }
            return Data.SaveChanges() > 0 ? true : false;
        }
    }
}
