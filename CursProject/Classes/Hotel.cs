using System;
using System.Linq.Expressions;
using CursProject.Grids;
using CursProject.Helpers;
using CursProject.Types;

namespace CursProject.Classes
{
    public partial class Hotel
    {
        public override string ToString()
        {
            return string.Format("{0} - {1}", Name, Type);
        }

        public GridHotel ToGrid()
        {
            return new GridHotel
            {
                Id = Id,
                Name = Name,
                Type = EnumHelper.Huminize(EnumHelper.FromString<HotelType>(Type))
            };
        }
    }
}
