using System;
using System.Linq;
using CursProject.Classes;
using CursProject.Helpers;

namespace CursProject.Form
{
    public partial class ShowGraphicsForm : System.Windows.Forms.Form
    {
        private static TourDbDataContext db = DataBase.Context;

        public ShowGraphicsForm(DateTime from, DateTime to)
        {
            InitializeComponent();

            from = from.Date.AddDays(1 - from.Day);
            to = to.Date.AddMonths(1).AddDays(-to.Day);

            for (var dateFrom = from; dateFrom <= to; dateFrom = dateFrom.AddMonths(1))
            {
                var dateTo = dateFrom.AddMonths(1).AddDays(-1);
                var trips = db.TripClients.Where(t => t.SaleDate >= dateFrom && t.SaleDate <= dateTo);
                int sum = trips.Any() ? trips.Sum(p => p.TotalPrice) : 0;
                chart.Series[0].Points.AddXY(StringHelper.GetMonth(dateFrom.Month), sum);
            }
        }
    }
}
