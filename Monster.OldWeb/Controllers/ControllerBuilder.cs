using System;
using System.Collections.Generic;

namespace Monster.OldWeb.Controllers
{
    public class ControllerBuilder
    {
        private Func<IControllerFactory> factoryThunk;
        public static ControllerBuilder Current { get; }
        public IEnumerable<string> DefaultNamespaces { get; set; }

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