namespace Trex.Framework.Controls.Droid
{
    using Android.App;
    using Android.Content;
    using Android.Graphics;
    using Android.Util;
    using Android.Views;

    public class TxSeparatorDroidView : View
    {
        private TxSeparatorOrientation _orientation;
        private float _dm;
        public TxSeparatorDroidView(Context context)
            : base(context)
        {
            Initialize();
        }

        public TxSeparatorDroidView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            Initialize();
        }

        public TxSeparatorDroidView(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
            Initialize();
        }
        public double Thickness { set; get; }
        public double SpacingBefore { set; get; }
        public double SpacingAfter { set; get; }
        public Color StrokeColor { set; get; }
        public StrokeType StrokeType { set; get; }
        public TxSeparatorOrientation Orientation
        {
            set
            {
                _orientation = value;
                Invalidate();
            }
            get
            {
                return _orientation;
            }
        }
        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            var r = new Rect(0, 0, canvas.Width, canvas.Height);
            var dAdjustedThicnkess = (float)Thickness * _dm;

            var paint = new Paint { Color = StrokeColor, StrokeWidth = dAdjustedThicnkess, AntiAlias = true };
            paint.SetStyle(Paint.Style.Stroke);
            switch (StrokeType)
            {
                case StrokeType.Dashed:
                    paint.SetPathEffect(new DashPathEffect(new[] { 6 * _dm, 2 * _dm }, 0));
                    break;
                case StrokeType.Dotted:
                    paint.SetPathEffect(new DashPathEffect(new[] { dAdjustedThicnkess, dAdjustedThicnkess }, 0));
                    break;
                default:

                    break;
            }

            var desiredTotalSpacing = (SpacingAfter + SpacingBefore) * _dm;
            float leftForSpacing = 0;
            float actualSpacingBefore = 0;
            float actualSpacingAfter = 0;

            if (Orientation == TxSeparatorOrientation.Horizontal)
            {
                leftForSpacing = r.Height() - dAdjustedThicnkess;
            }
            else
            {
                leftForSpacing = r.Width() - dAdjustedThicnkess;
            }
            if (desiredTotalSpacing > 0)
            {
                var spacingCompressionRatio = (float)(leftForSpacing / desiredTotalSpacing);
                actualSpacingBefore = (float)SpacingBefore * _dm * spacingCompressionRatio;
                actualSpacingAfter = (float)SpacingAfter * _dm * spacingCompressionRatio;
            }
            else
            {
                actualSpacingBefore = 0;
                actualSpacingAfter = 0;
            }
            var thicknessOffset = (dAdjustedThicnkess) / 2.0f;

            var p = new Path();
            if (Orientation == TxSeparatorOrientation.Horizontal)
            {
                p.MoveTo(0, actualSpacingBefore + thicknessOffset);
                p.LineTo(r.Width(), actualSpacingBefore + thicknessOffset);
            }
            else
            {
                p.MoveTo(actualSpacingBefore + thicknessOffset, 0);
                p.LineTo(actualSpacingBefore + thicknessOffset, r.Height());
            }
            canvas.DrawPath(p, paint);
        }
        private void Initialize()
        {
            _dm = Application.Context.Resources.DisplayMetrics.Density;
        }
    }
}