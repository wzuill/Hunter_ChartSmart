using System.Drawing;

namespace ChartSmart
{
    internal abstract class Chart
    {
        public abstract void RenderBackground(string chartSize, Graphics graphics);
        public abstract ChartData GetData(string chartSize);
    }
}