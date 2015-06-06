namespace Trex.Framework.Core.Helper
{
    using System;
    public class EventArgs<T> : EventArgs
    {
        /// <summary>
        /// ایجاد یک نمونه از تایپ <see cref="EventArgs"/> 
        /// </summary>
        /// <param name="value">مقدار آرگومنت</param>
        public EventArgs(T value)
        {
            this.Value = value;
        }

        /// <summary>
        /// دریافت مقدار آرگومنت
        /// </summary>
        public T Value { get; private set; }
    }
}
