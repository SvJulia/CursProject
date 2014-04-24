namespace CursProject.Classes
{
    public partial class Meal
    {
        public override string ToString()
        {
            return string.Format("{0} - {1}", Name, Type);
        }
    }
}
