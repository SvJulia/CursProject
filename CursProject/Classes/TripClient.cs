using CursProject.Grids;

namespace CursProject.Classes
{
    public partial class TripClient
    {
        public GridTripClient ToGrid()
        {
            return new GridTripClient
            {
                Id = Id,
                Fio = Fio,
                Name = Trip.Tour.ToString(),
                TotalPrice = TotalPrice + " руб.",
                LeftPrice = LeftPrice + " руб.",
                SaleDate = SaleDate.ToShortDateString(),
                IsPaid = IsPaid
            };
        }
    }
}