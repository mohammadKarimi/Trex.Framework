using Trex.Framework.Controls;
using Trex.Framework.Controls.WinPhone;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(TxSeparator), typeof(TxSeparatorRenderer))]

namespace Trex.Framework.Controls.WinPhone
{
    using System.Windows.Media;
    using System.Windows.Shapes;
    using Xamarin.Forms.Platform.WinPhone;
    public class TxSeparatorRenderer : ViewRenderer<TxSeparator, Path>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TxSeparator> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                return;
            }

            if (Control == null)
            {
                Background = Xamarin.Forms.Color.Transparent.ToBrush();
                SetNativeControl(new Path());
            }

            SetProperties(Control);
        }
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            SetProperties(Control);
        }
        private void SetProperties(Path line)
        {
            var myLineSegment = new LineSegment()
            {
                Point = new System.Windows.Point(Element.Width, 0)
            };

            var myPathSegmentCollection = new PathSegmentCollection { myLineSegment };

            var myPathFigureCollection = new PathFigureCollection
				                             {
					                             new PathFigure
						                             {
							                             StartPoint = new System.Windows.Point(0, 0),
							                             Segments = myPathSegmentCollection
						                             }
				                             };

            line.Stroke = Element.Color.ToBrush();
            line.StrokeDashArray = new System.Windows.Media.DoubleCollection();

            if (Element.StrokeType != StrokeType.Solid)
            {
                if (Element.StrokeType == StrokeType.Dashed)
                {
                    line.StrokeDashArray.Add(10);
                }
                line.StrokeDashArray.Add(2);
            }

            line.Data = new PathGeometry { Figures = myPathFigureCollection };

            line.StrokeThickness = Element.Thickness;
        }
    }
}
