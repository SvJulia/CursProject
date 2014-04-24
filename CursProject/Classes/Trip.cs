namespace CursProject.Classes
{
    public partial class Trip
    {       
        public override string ToString()
        {
            return string.Format("{0} - {1}руб.", Tour, TotalPrice);
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
