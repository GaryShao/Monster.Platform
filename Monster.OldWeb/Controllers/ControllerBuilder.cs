using System;

namespace Monster.OldWeb.Controllers
{
    public class ControllerBuilder
    {
        private Func<IControllerFactory> factoryThunk;
        public static ControllerBuilder Current { get; }

        static ControllerBuilder()
        {
            Current = new ControllerBuilder();
        }

        public IControllerFactory GetControllerFactory()
        {
            return factoryThunk();
        }

        public void SetControllerFactory(IControllerFactory controllerFactory)
        {
            factoryThunk = () => controllerFactory;
        }
    }
}