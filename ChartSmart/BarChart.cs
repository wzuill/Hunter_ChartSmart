using System.Drawing;

namespace ChartSmart
{
    internal class BarChart : Chart
    {
        public override void RenderBackground(string chartSize, Graphics graphics)
        {
            SolidBrush brush;
            if (chartSize == ChartSingleCompareOrig.ChartSizeBig)
            {
                brush = new SolidBrush(Color.Red);

                graphics.FillRectangle(brush, 20, 30, 300, 300);
            }
            else
            {
                brush = new SolidBrush(Color.Red);


                graphics.FillRectangle(brush, 20, 30, 150, 150);
            }

            brush.Dispose();
        }
    }
}