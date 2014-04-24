namespace CursProject.Classes
{
    public partial class Tour
    {
        public override string ToString()
        {
            return string.Format("{0} ({1})", NameForClients, Name);
        }
    }
}
