using CursProject.Grids;

namespace CursProject.Classes
{
    public partial class Excursion
    {
        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, Rating);
        }

        public GridExcursion ToGrid()
        {
            return new GridExcursion { Id = Id, Name = Name, Description = Description, Rating = string.Format("{0} из 10", Rating) };
        }
    }
}