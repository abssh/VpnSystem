
using System.ComponentModel;
using System.Drawing.Drawing2D;


namespace WinForm.CustomControls
{
    public partial class RoundedButton : Button
    {
        public RoundedButton()
        {
            InitializeComponent();
        }

        //[Category("Extra Fields")]
        //float BorderSize { get; set; } = 5;
        //[Category("Extra Fields")]
        //Color BorderColor { get; set; } = Color.Navy;


        GraphicsPath GetCircle(RectangleF rect)
        {
            int size = Math.Min(Width, Height);
            GraphicsPath graphics = new GraphicsPath();
            graphics.AddArc(rect.X, rect.Y, size, size, 0F, 360F);
            return graphics;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            RectangleF Rect = new RectangleF(0, 0, Width, Height);
            using (GraphicsPath graphics = GetCircle(Rect))
            {
                Region = new Region(graphics);
                using (Pen pen = new Pen(Color.Navy, 5))
                {
                    pen.Alignment = PenAlignment.Inset;
                    pevent.Graphics.DrawPath(pen, graphics);
                }
            }

            
        }
    }
}
