using Etalk.Data;

namespace Etalk.Bussiness
{
    public class DataBase
    {
        protected EtalkConnection Data;
        public DataBase()
        {
            Data = new EtalkConnection();
        }
    }
}
