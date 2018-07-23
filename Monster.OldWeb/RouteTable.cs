namespace Monster.OldWeb
{
    public class RouteTable
    {
        public static RouteDictionary Routes { get; }

        static RouteTable()
        {
            Routes = new RouteDictionary();
        }
    }
}
