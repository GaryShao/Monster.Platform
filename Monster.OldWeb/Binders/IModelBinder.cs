using Monster.OldWeb.Models;
using System;

namespace Monster.OldWeb.Binders
{
    public interface IModelBinder
    {
        object BindModel(ControllerContext controllerContext, string modelName, Type modelType);
    }
}
