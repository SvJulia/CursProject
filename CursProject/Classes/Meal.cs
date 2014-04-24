using CursProject.Grids;
using CursProject.Helpers;
using CursProject.Types;

namespace CursProject.Classes
{
    public partial class Meal
    {
        public override string ToString()
        {
            return string.Format("{0} - {1}", Name, Type);
        }

        public GridMeal ToGrid()
        {
            return new GridMeal
            {
                Id = Id,
                Name = Name,
                Type = EnumHelper.Huminize(EnumHelper.FromString<MealType>(Type))
            };
        }
    }
}
