﻿using Monster.OldWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Monster.OldWeb.Actions
{
    public abstract class ActionResult
    {
        public abstract void ExecuteResult(ControllerContext context);
    }
}