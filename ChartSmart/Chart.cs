using System.Drawing;

namespace ChartSmart
{
    internal abstract class Chart
    {
        public abstract void RenderBackground(string chartSize, Graphics graphics);
        public abstract ChartData GetData(string chartSize);
        public abstract void DisplayChart(string chartSize, Graphics graphics, ChartData chartData);
    }
}