namespace CursProject.Classes
{
    public partial class Hotel
    {
        public override string ToString()
        {
            return string.Format("{0} - {1}", Name, Type);
        }
    }
}
