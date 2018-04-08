using System.Drawing;

namespace ChartSmart
{
    internal class BarChart : Chart
    {
        public override void RenderBackground(string chartSize, Graphics graphics)
        {
            SolidBrush brush;
            if (chartSize == ChartSizes.ChartSizeBig)
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
            if (s == ChartSizes.ChartSizeBig)
                chartData.data = "Bar Data\nLarge";
            else
            {
                chartData.data = "Bar Data\nSmall";
            }

            return chartData;
        }

        public override void DisplayChart(string s, Graphics graphics, ChartData chartData)
        {
            Brush brush2 = new SolidBrush(Color.Black);

            if (s == ChartSizes.ChartSizeCompare)
            {
                var parTop = 170;
                var barLeft = 33;
                var barWidth = 25;
                graphics.FillRectangle(brush2, barLeft, parTop - 92, barWidth, 92);
                graphics.FillRectangle(brush2, barLeft + barWidth, parTop - 225 / 2, barWidth, 225 / 2);
                graphics.FillRectangle(brush2, barLeft + barWidth * 2, parTop - 205 / 2, barWidth, 205 / 2);
                graphics.FillRectangle(brush2, barLeft + barWidth * 3, parTop - 260 / 2, barWidth, 260 / 2);
                graphics.FillRectangle(brush2, barLeft + barWidth * 4, parTop - 85, barWidth, 170 / 2);
                graphics.DrawString(chartData.data, new Font("Arial Black", 16), new SolidBrush(Color.White),
                    new PointF(barLeft + 5, 85));
            }
            else
            {
                var chartBottom = 312;
                graphics.FillRectangle(brush2, 45, chartBottom - 185, 50, 185);
                graphics.FillRectangle(brush2, 45 + 50, chartBottom - 225, 50, 225);
                graphics.FillRectangle(brush2, 45 + 100, chartBottom - 205, 50, 205);
                graphics.FillRectangle(brush2, 45 + 150, chartBottom - 260,
                    50, 260);
                graphics.FillRectangle(brush2, 45 + 200,
                    chartBottom - 170, 50, 170);
                graphics.DrawString(
                    chartData.data, new Font("Arial Black", 30), new
                        SolidBrush(Color.White),
                    new PointF(60, 170));
            }
        }
    }
}