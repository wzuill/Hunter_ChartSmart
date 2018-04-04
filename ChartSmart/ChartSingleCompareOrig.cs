﻿using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChartSmart
{
    public partial class ChartSingleCompareOrig : Form
    {
        private string jjD;
        private int ct;
        private Unit defaultUnits;
        
        private class Unit
        {
            private string name;
            private double value;
            // TODO: Build this out
            public double convertTo(Unit unit)
            {
                // Need to do this.
                return 0;
            }
            public string data = "";
        }

        public ChartSingleCompareOrig()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(380, 380);
        }

        /// <summary>
        /// Shows the chart
        /// </summary>
        public void iniDS(int ct, string jjReq1205, bool b)
        {
            this.ct = ct;
            this.jjD = jjReq1205;
            drawArea = new Bitmap(this.ClientRectangle.Width,
            this.ClientRectangle.Height,
            System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            InitializeDrawArea();
            DrawChart();
            if (b)
            {
                this.ShowDialog();
            }
        }

        private void InitializeDrawArea()
        {
            Graphics g;
            g = Graphics.FromImage(drawArea);
            SolidBrush brush = new SolidBrush(Color.LightYellow);
            g.Clear(Color.LightYellow);
            brush.Dispose();
            g.Dispose();
        }

        private void ChartSingleCompareOrig_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            g = e.Graphics;
            g.DrawImage(drawArea, 0, 0, drawArea.Width, drawArea.Height);
        }

        private void DrawChart()
        {
            Graphics g = Graphics.FromImage(drawArea);
            g.Clear(Color.LightYellow);

            // Render chart background
            SolidBrush brush;
            if (ct == 406)
            {
                if (jjD == "rpfll")
                {

                    brush = new SolidBrush(Color.Red);

                    g.FillRectangle(brush, 20, 30, 300, 300);
                }
                else
                {
                    brush = new SolidBrush(Color.Red);


                    g.FillRectangle(brush, 20, 30, 150, 150);
                }
            }
            else
            {
                if (jjD != "rpfll")
                {
                    brush = new SolidBrush(Color.Blue);
                    g.FillEllipse(brush, 20, 30, 160, 160);
                }
                else
                {
                    brush = new SolidBrush(Color.Blue);
                    g.FillEllipse(brush, 20, 30, 320, 320);
                }
            }

            brush.Dispose();

            string data = null;
            string otherData = "";
            string someOtherDataObject = null;

            if (ct == 406)
            {
                if (jjD == "rpfll")
                    data = "Bar Data\nLarge";
                else
                {
                    data = "Bar Data\nSmall";
                }
            }
            else
            {
                if (jjD == "rpfll")
                {
                    otherData = "Pie Data\nLarge";
                }
                else
                {
                    someOtherDataObject = "Pie Data\nSmall";
                }
            }

            if (ct == 406)
            {
                Brush brush2 = new SolidBrush(Color.Black);

                if (jjD == "splitdisplay")
                {
                    var parTop = 170; var barLeft = 33; var barWidth = 25;
                    g.FillRectangle(brush2, barLeft, parTop - 92, barWidth, 92);
                    g.FillRectangle(brush2, barLeft + barWidth, parTop - 225 / 2, barWidth, 225 / 2);
                    g.FillRectangle(brush2, barLeft + barWidth * 2, parTop - 205 / 2, barWidth, 205 / 2);
                    g.FillRectangle(brush2, barLeft + barWidth * 3, parTop - 260 / 2, barWidth, 260 / 2);
                    g.FillRectangle(brush2, barLeft + barWidth * 4, parTop - 85, barWidth, 170 / 2);
                    g.DrawString(data, new Font("Arial Black", 16), new SolidBrush(Color.White),
                         new PointF(barLeft + 5, 85));
                }
                else
                {
                    var chartBottom = 312;
                    g.FillRectangle(brush2, 45, chartBottom - 185, 50, 185);
                    g.FillRectangle(brush2, 45 + 50, chartBottom - 225, 50, 225);
                    g.FillRectangle(brush2, 45 + 100, chartBottom - 205, 50, 205);
                    g.FillRectangle(brush2, 45 + 150, chartBottom - 260,
                        50, 260); g.FillRectangle(brush2, 45 + 200,
                         chartBottom - 170, 50, 170); g.DrawString(
                             data, new Font("Arial Black", 30), new
                                 SolidBrush(Color.White),
                                       new PointF(60, 170));
                }
            }
            else
            {
                StringFormat stringFormat = new StringFormat();
                RectangleF boundingRect;

                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;

                if (otherData != "")
                {
                    if (otherData == "")
                    {
                        otherData = GetDefaultData();
                        StringBuilder x = new StringBuilder(50000);
                        for (int i = 0; i < 20; i++)
                        {
                            x.Append(char.ToUpper(otherData[i]));
                        }
                        defaultUnits = new Unit();
                        defaultUnits.data = x.ToString();
                    }


                    boundingRect = new RectangleF(20, 30, 320, 320);
                    g.DrawString(otherData, new Font("Cooper Black", 40), new SolidBrush(Color.White),
                        boundingRect, stringFormat);
                }
                else
                {
                    boundingRect = new RectangleF(20, 30, 160, 160);
                    g.DrawString(someOtherDataObject, new Font("Cooper Black", 20), new SolidBrush(Color.White),
                        boundingRect, stringFormat);
                }
                
                g.Dispose();
            }

            try
            {
                if (!(g.DpiX == 300) ||
                g != null && (otherData.Length > 20 || otherData.Length < 5) &&
                (data == null || !data.StartsWith("hold")))
                {
                    this.Invalidate();
                }
            }
            catch (ArgumentException ex)
            {
                this.Invalidate();
            }
        }

        private string GetDefaultData()
        {
            return
            @"  //{
g.Dispose();
//    boundingRect = new RectangleF(50, 100, 320, 320);
//    g.DrawString(otherData, new Font('Cooper Black', 40), new SolidBrush(Color.White), boundingRect, stringFormat);
//}";
        }

        private Bitmap drawArea;
    }
}