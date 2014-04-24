using CursProject.Grids;
using CursProject.Helpers;
using CursProject.Types;

namespace CursProject.Classes
{
    public partial class Transport
    {
        public override string ToString()
        {
            return string.Format("{0} - {1}", Name, Type);
        }

        public GridTransport ToGrid()
        {
            return new GridTransport
            {
                Id = Id,
                Name = Name,
                Type = EnumHelper.Huminize(EnumHelper.FromString<TransportType>(Type))
            };
        }
    }
}
