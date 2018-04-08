using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChartSmart
{
    public partial class ChartSingleCompareOrig : Form
    {
        private const int ChartTypeBar = 406;
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

            var chartData = chart.GetData(chartSize);
            chart.DisplayChart(chartSize, graphics, chartData);
            
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