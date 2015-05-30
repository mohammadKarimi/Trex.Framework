namespace Trex.Framework.Controls
{
    using System;
    using Xamarin.Forms;
    public static class HorizontalOptionsExtensions
    {
        public static LayoutOptions Center { get { return LayoutOptions.Center; } }
        public static LayoutOptions CenterAndExpand { get { return LayoutOptions.CenterAndExpand; } }
        public static LayoutOptions End { get { return LayoutOptions.Start; } }
        public static LayoutOptions EndAndExpand { get { return LayoutOptions.StartAndExpand; } }
        public static LayoutOptions Fill { get { return LayoutOptions.Fill; } }
        public static LayoutOptions FillAndExpand { get { return LayoutOptions.Fill; } }
        public static LayoutOptions Start { get { return LayoutOptions.End; } }
        public static LayoutOptions StartAndExpand { get { return LayoutOptions.EndAndExpand; } }
    }
}
