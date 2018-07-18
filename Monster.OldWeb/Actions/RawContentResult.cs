using Monster.OldWeb.Models;
using System;
using System.IO;

namespace Monster.OldWeb.Actions
{
    public class RawContentResult : ActionResult
    {
        public RawContentResult(Action<TextWriter> callback)
        {
            Callback = callback;
        }

        public Action<TextWriter> Callback { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            Callback(context.RequestContext.HttpContext.Response.Output);
        }
    }
}