namespace Trex.Framework.Controls.iOS
{
	using System;
	using UIKit;
	public class UITxSeparator : UIView
	{
        public UITxSeparator(CoreGraphics.CGRect bounds)
            : base(bounds)
        {
            Initialize();
        }
        public UITxSeparator(IntPtr handle)
            : base(handle)
        {
            Initialize();
        }
        public UITxSeparator()
        {
            Initialize();
        }

		private double _thickness;
		public double Thickness
		{
			set
			{
				_thickness = value;
				SetNeedsDisplayInRect(Bounds);
			}
			get
			{
				return _thickness;
			}
		}
		private double _spacingBefore;
		public double SpacingBefore
		{
			set
			{
				_spacingBefore = value;
				SetNeedsDisplayInRect(Bounds);
			}
			get
			{
				return _spacingBefore;
			}
		}
		private double _spacingAfter;
		public double SpacingAfter
		{
			set
			{
				_spacingAfter = value;
				SetNeedsDisplayInRect(Bounds);
			}
			get
			{
				return _spacingAfter;
			}
		}
		private UIColor _strokeColor;
		public UIColor StrokeColor
		{
			set
			{
				_strokeColor = value;
				SetNeedsDisplayInRect(Bounds);
			}
			get
			{
				return _strokeColor;
			}
		}
		private StrokeType _strokeType;
		public StrokeType StrokeType
		{
			set
			{
				_strokeType = value;
				SetNeedsDisplayInRect(Bounds);
			}
			get
			{
				return _strokeType;
			}
		}
		private TxSeparatorOrientation _orientation;
		public TxSeparatorOrientation Orientation
		{
			set
			{
				_orientation = value;
				SetNeedsDisplayInRect(Bounds);
			}
			get
			{
				return _orientation;
			}
		}
		void Initialize()
		{
			BackgroundColor = UIColor.Clear;
			Opaque = false;
		}
		public override void Draw(CoreGraphics.CGRect rect)
		{
			base.Draw(rect);
			var height = Bounds.Size.Height;
			//var percentage = (this.Limit - Math.Abs(this.CurrentValue)) / this.Limit;
			var context = UIGraphics.GetCurrentContext();

			context.ClearRect(rect);
			//context.SetFillColor(UIColor.Clear.CGColor);
			//context.FillRect(rect);
			context.SetStrokeColor(StrokeColor.CGColor);
			switch (StrokeType)
			{
				case StrokeType.Dashed:
					context.SetLineDash(0, new nfloat[] { 6, 2 });
					break;
				case StrokeType.Dotted:
					context.SetLineDash(0, new nfloat[] { (nfloat)Thickness, (nfloat)Thickness });
					break;
				default:

					break;
			}

			context.SetLineWidth((float)Thickness);
			var desiredTotalSpacing = SpacingAfter + SpacingBefore;

			float leftForSpacing = 0;
			float actualSpacingBefore = 0;
			float actualSpacingAfter = 0;

			if (Orientation == TxSeparatorOrientation.Horizontal)
			{
				leftForSpacing = (float)Bounds.Size.Height - (float)Thickness;
			}
			else
			{
				leftForSpacing = (float)Bounds.Size.Width - (float)Thickness;
			}
			if (desiredTotalSpacing > 0)
			{
				float spacingCompressionRatio = (float)(leftForSpacing / desiredTotalSpacing);
				actualSpacingBefore = (float)SpacingBefore * spacingCompressionRatio;
				actualSpacingAfter = (float)SpacingAfter * spacingCompressionRatio;
			}
			else
			{
				actualSpacingBefore = 0;
				actualSpacingAfter = 0;
			}
			float thicknessOffset = (float)Thickness / 2.0f;

			if (Orientation == TxSeparatorOrientation.Horizontal)
			{
				var half = Bounds.Size.Height / 2.0f;
				context.MoveTo(0, actualSpacingBefore + thicknessOffset);
				context.AddLineToPoint(rect.Width, actualSpacingBefore + thicknessOffset);
			}
			else
			{
				var half = Bounds.Size.Width / 2.0f;
				context.MoveTo(actualSpacingBefore + thicknessOffset, 0);
				context.AddLineToPoint(actualSpacingBefore + thicknessOffset, rect.Height);
			}
			context.StrokePath();
		}
	}
}

