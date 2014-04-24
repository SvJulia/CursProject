using System.Collections.Generic;
using System.Linq;
using CursProject.Properties;

namespace CursProject.Classes
{
    public partial class Client
    {
        public override string ToString()
        {
            return string.Format("{0}", Fio);
        }  

        public int TotaPurchases
        {
            get
            {
                var db = new TourDbDataContext(Settings.Default.ConnectionString);
                var tcs =db.TripClients.Where(p => p.ClientId == Id);

                if (!tcs.Any()) return 0;

                return tcs.Sum(p => p.TotalPrice);
            }
        }

        public int Discount
        {
            get
            {
                var db = new TourDbDataContext(Settings.Default.ConnectionString);

                var tp = TotaPurchases;
                var ds = db.Discounts.Where(p => p.Range < tp);

                if (!ds.Any()) return 0;
                return ds.Max(p => p.Value);
            }
        }
    }
}
