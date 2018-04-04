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

        public override ChartData GetData(string s)
        {
            ChartData chartData;
            chartData = new ChartData();
            if (s == ChartSingleCompareOrig.ChartSizeBig)
                chartData.data = "Bar Data\nLarge";
            else
            {
                chartData.data = "Bar Data\nSmall";
            }

            return chartData;
        }
    }
}