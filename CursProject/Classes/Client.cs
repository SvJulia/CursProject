using System.Linq;
using CursProject.Grids;
using CursProject.Properties;

namespace CursProject.Classes
{
    public partial class Client
    {
        public int TotaPurchases
        {
            get
            {
                var db = new TourDbDataContext(Settings.Default.ConnectionString);
                IQueryable<TripClient> tcs = db.TripClients.Where(p => p.ClientId == Id);

                if (!tcs.Any())
                {
                    return 0;
                }

                return tcs.Sum(p => p.TotalPrice);
            }
        }

        public int Discount
        {
            get
            {
                var db = new TourDbDataContext(Settings.Default.ConnectionString);

                int tp = TotaPurchases;
                IQueryable<Discount> ds = db.Discounts.Where(p => p.Range < tp);

                if (!ds.Any())
                {
                    return 0;
                }
                return ds.Max(p => p.Value);
            }
        }

        public override string ToString()
        {
            return string.Format("{0}", Fio);
        }

        public GridClient ToGrid()
        {
            return new GridClient { Id = Id, Fio = Fio, Discount = Discount + "%", TotaPurchases = TotaPurchases + " руб." };
        }
    }
}