using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChartSmart
{
    public partial class ChartSingleCompareOrig : Form
    {
        private const int ChartTypeBar = 406;
        public const string ChartSizeBig = "rpfll";
        private const string ChartSizeCompare = "splitdisplay";
        private string chartSize;
        private int chartType;

        public ChartSingleCompareOrig()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(380, 380);
        }

        public void ShowChart(int chartType, string chartSize, bool showDialog)
        {
            this.chartType = chartType;
            this.chartSize = chartSize;
            drawArea = new Bitmap(this.ClientRectangle.Width,
            this.ClientRectangle.Height,
            System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            InitializeDrawArea();
            DrawChart();
            if (showDialog)
            {
                this.ShowDialog();
            }
        }

        private void InitializeDrawArea()
        {
            Graphics graphics;
            graphics = Graphics.FromImage(drawArea);
            SolidBrush brush = new SolidBrush(Color.LightYellow);
            graphics.Clear(Color.LightYellow);
            brush.Dispose();
            graphics.Dispose();
        }

        private void ChartSingleCompareOrig_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(drawArea, 0, 0, drawArea.Width, drawArea.Height);
        }

        private void DrawChart()
        {
            var graphics = InitializeGraphics();
            var chart = ChartFactory();
            chart.RenderBackground(chartSize, graphics);

            ChartData chartData;

            if (chartType == ChartTypeBar)
            {
                chartData = GetBarChartData(chartSize);
            }
            else
            {
                chartData = GetPieChartData(chartSize);
            }

            DisplayData(graphics, chartData);
            InvalidateIfNeeded(graphics, chartData);
        }

        private Graphics InitializeGraphics()
        {
            Graphics graphics = Graphics.FromImage(drawArea);
            graphics.Clear(Color.LightYellow);
            return graphics;
        }

        private void InvalidateIfNeeded(Graphics graphics, ChartData chartData)
        {
            try
            {
                if (!(graphics.DpiX == 300) ||
                    graphics != null && (chartData.otherData.Length > 20 || chartData.otherData.Length < 5) &&
                    (chartData.data == null || !chartData.data.StartsWith("hold")))
                {
                    this.Invalidate();
                }
            }
            catch (ArgumentException ex)
            {
                this.Invalidate();
            }
        }

        private void DisplayData(Graphics graphics, ChartData chartData)
        {
            if (chartType == ChartTypeBar)
            {
                DisplayBarChart(graphics, chartData);
            }
            else
            {
                DisplayPieChart(graphics, chartData);
            }
        }

        private static void DisplayPieChart(Graphics graphics, ChartData chartData)
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

        private void DisplayBarChart(Graphics graphics, ChartData chartData)
        {
            Brush brush2 = new SolidBrush(Color.Black);

            if (chartSize == ChartSizeCompare)
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

        private static ChartData GetPieChartData(string s)
        {
            ChartData chartData;
            chartData = new ChartData();
            if (s == ChartSizeBig)
            {
                chartData.otherData = "Pie Data\nLarge";
            }
            else
            {
                chartData.someOtherDataObject = "Pie Data\nSmall";
            }

            return chartData;
        }

        private static ChartData GetBarChartData(string s)
        {
            ChartData chartData;
            chartData = new ChartData();
            if (s == ChartSizeBig)
                chartData.data = "Bar Data\nLarge";
            else
            {
                chartData.data = "Bar Data\nSmall";
            }

            return chartData;
        }

        private Chart ChartFactory()
        {
            Chart chart;
            if (chartType == ChartTypeBar)
            {
                chart = new BarChart();
            }
            else
            {
                chart = new PieChart();
            }

            return chart;
        }

        private Bitmap drawArea;
    }
}