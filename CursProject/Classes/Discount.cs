using CursProject.Grids;

namespace CursProject.Classes
{
    public partial class Discount
    {
        public override string ToString()
        {
            return string.Format("{0}", Name);
        }

        public GridDiscount ToGrid()
        {
            return new GridDiscount
            {
                Id = Id,
                Range = "от " + Range + " руб.",
                Value = Value + "%"
            };
        }
    }
}
