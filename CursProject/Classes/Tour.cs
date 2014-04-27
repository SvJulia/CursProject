using System.Linq;
using CursProject.Grids;

namespace CursProject.Classes
{
    public partial class Tour
    {
        public override string ToString()
        {
            return string.Format("{0} ({1})", NameForClients, Name);
        }

        public GridTour ToGrid()
        {
            string excursions = "";

            if (TourExcursions.Any())
            {
                excursions = TourExcursions.Aggregate(excursions, (current, te) => current + te.Excursion + "\r\n");
            }

            return new GridTour
            {
                Id = Id,
                Name = Name,
                NameForClients = NameForClients,
                City = City.Name,
                Country = City.Country.Name,
                Excursions = excursions
            };
        }
    }
}