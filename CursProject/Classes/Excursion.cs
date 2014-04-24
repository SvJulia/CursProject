namespace CursProject.Classes
{
    public partial class Excursion
    {
        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, Rating);
        }
    }
}
