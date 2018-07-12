using Monster.OldWeb.Controllers;

namespace Monster.OldWeb.Models
{
    public class ControllerContext
    {
        public ControllerBase Controller { get; set; }
        public RequestContext RequestContext { get; set; }
    }
}