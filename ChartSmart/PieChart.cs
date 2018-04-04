using System.Drawing;

namespace ChartSmart
{
    internal class PieChart : Chart
    {
        public override void RenderBackground(string chartSize, Graphics graphics)
        {
            SolidBrush brush;
            if (chartSize != ChartSingleCompareOrig.ChartSizeBig)
            {
                brush = new SolidBrush(Color.Blue);
                graphics.FillEllipse(brush, 20, 30, 160, 160);
            }
            else
            {
                brush = new SolidBrush(Color.Blue);
                graphics.FillEllipse(brush, 20, 30, 320, 320);
            }

            brush.Dispose();
        }
    }
}