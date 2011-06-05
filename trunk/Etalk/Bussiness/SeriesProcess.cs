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

        public bool AddNewSeries(string seriesName)
        { 
            Series series = new Series();
            series.Name = seriesName;
            Data.Series.AddObject(series);
            return Data.SaveChanges() > 0 ? true : false;
        }
    }
}
