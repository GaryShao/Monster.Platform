namespace Monster.Platform.Infrastructure
{
    public class MvcConfiguration
    {
        public MvcConfiguration()
        {
            Route = new RouteCollection();
        }

        public RouteCollection Route { get; }
    }
}
