using System.Drawing;

namespace ChartSmart
{
    internal class PieChart : Chart
    {
        public override void RenderBackground(string s, Graphics graphics)
        {
            SolidBrush brush;
            if (s != ChartSizes.ChartSizeBig)
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

        public override ChartData GetData(string s)
        {
            ChartData chartData;
            chartData = new ChartData();
            if (s == ChartSizes.ChartSizeBig)
            {
                chartData.otherData = "Pie Data\nLarge";
            }
            else
            {
                chartData.someOtherDataObject = "Pie Data\nSmall";
            }

            return chartData;
        }

        public override void DisplayChart(string chartSize1, Graphics graphics, ChartData chartData)
        {
            StringFormat stringFormat = new StringFormat();
            RectangleF boundingRect;

            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            if (chartData.otherData != "")
            {
                boundingRect = new RectangleF(20, 30, 320, 320);
                graphics.DrawString(chartData.otherData, new Font("Cooper Black", 40), new SolidBrush(Color.White),
                    boundingRect, stringFormat);
            }
            else
            {
                boundingRect = new RectangleF(20, 30, 160, 160);
                graphics.DrawString(chartData.someOtherDataObject, new Font("Cooper Black", 20),
                    new SolidBrush(Color.White),
                    boundingRect, stringFormat);
            }

            graphics.Dispose();
        }
    }
}