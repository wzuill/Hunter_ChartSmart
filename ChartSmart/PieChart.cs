using System.Drawing;

namespace ChartSmart
{
    internal class PieChart
    {
        public PieChart()
        {
        }

        public static void RenderPieChartBackground(string s, Graphics graphics)
        {
            SolidBrush brush;
            if (s != ChartSingleCompareOrig.ChartSizeBig)
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