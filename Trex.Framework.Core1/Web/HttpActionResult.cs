namespace Trex.Framework.Core.Web
{
    public class HttpActionResult<T> : NoActionResult
    {
        public T Result { get; set; }
    }
}
