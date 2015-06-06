namespace Trex.Framework.Core.Web
{
    using System;
    using System.Collections.Generic;
    public class NoActionResult
    {
        public NoActionResult()
        {
            this.IsSuccess = false;
        }
        public bool IsSuccess { get; set; }
        public string BussinessMessage { get; set; }
    }
}
