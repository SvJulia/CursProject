using CursProject.Grids;

namespace CursProject.Classes
{
    public partial class Trip
    {       
        public override string ToString()
        {
            return string.Format("{0} - {1}руб.", Tour, TotalPrice);
        }
                   
        public GridTrip ToGrid()
        {
            return new GridTrip
            {
              Id = Id,
              Name = Tour.ToString(),
              Count =Amount,
              Nights = Nights,
              DateArival = DateArival.ToShortDateString(),
              DateDeparture = DateDeparture.ToShortDateString(),
              TotalPrice = TotalPrice + " руб."
            };
        }

        public int TotalPrice
        {
            get
            {
                return HotelPrice + MealPrice + TourPrice + TransportPrice;
            }
        }
    }
}
