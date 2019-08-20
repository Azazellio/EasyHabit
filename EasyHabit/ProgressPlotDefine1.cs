using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Wpf;

namespace EasyHabit
{
    public class ProgressPlotDefine1
    {
        /*public static OxyPlot.PlotModel ZeroCrossing()
        {
            var plotmodel = new OxyPlot.PlotModel();
            plotmodel.PlotAreaBorderThickness = new OxyPlot.OxyThickness(0.0);
            plotmodel.PlotMargins = new OxyPlot.OxyThickness(10);
            var linearAxis = new OxyPlot.Axes.LinearAxis();
            linearAxis.Maximum = 40;
            linearAxis.Minimum = -40;
            linearAxis.PositionAtZeroCrossing = true;
            linearAxis.TickStyle = OxyPlot.Axes.TickStyle.Crossing;
            plotmodel.Axes.Add(linearAxis);
            var secondLinearAxis = new OxyPlot.Axes.LinearAxis();
            secondLinearAxis.Maximum = 40;
            secondLinearAxis.Minimum = -40;
            secondLinearAxis.PositionAtZeroCrossing = true;
            secondLinearAxis.TickStyle = OxyPlot.Axes.TickStyle.Crossing;
            secondLinearAxis.Position = OxyPlot.Axes.AxisPosition.Bottom;
            plotmodel.Axes.Add(secondLinearAxis);
            return plotmodel;
        }*/

        public static OxyPlot.PlotModel ZeroCrossing()
        {
            var plotmodel = new OxyPlot.PlotModel();
            plotmodel.Title = "Progress";
            var linearAxis1 = new OxyPlot.Axes.LinearAxis();
            linearAxis1.MajorGridlineStyle = OxyPlot.LineStyle.Solid;
            linearAxis1.MinorGridlineStyle = OxyPlot.LineStyle.Dot;
            plotmodel.Axes.Add(linearAxis1);
            var linearAxis2 = new OxyPlot.Axes.LinearAxis();
            linearAxis2.Position = OxyPlot.Axes.AxisPosition.Bottom;
            plotmodel.Axes.Add(linearAxis2);

        /*var startDate = DateTime.Now.AddDays(-10);
        var endDate = DateTime.Now;

        var minVal = Convert.ToDouble(startDate);
        var maxVal = Convert.ToDouble(endDate);



        var DateAxis = new DateTimeAxis {Position = OxyPlot.Axes.AxisPosition.Bottom, Minimum = minVal, Maximum = maxVal , StringFormat = "dd" };




        plotmodel.Axes.Add(DateAxis); 
            /*OxyPlot.Axes.Position = OxyPlot.AxisPosition.Bottom,
            Minimum = minValue,
            Maximum = maxValue,*/


        var series1 = new OxyPlot.Series.LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 5,
                MarkerStroke = OxyColors.White
            };
            series1.Points.Add(new DataPoint(0.3, 6.4));
            series1.Points.Add(new DataPoint(1.6, 2.7));
            series1.Points.Add(new DataPoint(2.0, 4.6));
            series1.Points.Add(new DataPoint(3.1, 2.3));
            series1.Points.Add(new DataPoint(4.5, 7.5));
            series1.Points.Add(new DataPoint(6.7, 6.1));
            series1.Points.Add(new DataPoint(8.4, 8.9));

            plotmodel.Series.Add(series1);

            return plotmodel;
        }

        /*public class LineChart
        {
            public PlotModel MyModel { get; set; }

            DateTime from_date, end_date;

            public LineChart()
            {
                var plotModel = new PlotModel
                {
                    Title = "Multiview"
                };

                var xAxis = new DateTimeAxis
                {
                    StringFormat = "MM/DD/yyyy"
                };

                var linearAxis = new LinearAxis();*/

                /*plotModel.Axes.Add(xAxis);
                plotModel.Axes.Add(linearAxis);

                var series1 = new LineSeries
                {
                    StrokeThickness = 3,
                    MarkerType = MarkerType.Cross,
                    MarkerStroke = OxyColors.Aqua,
                    MarkerSize = 4,
                    MarkerStrokeThickness = 1,
                    DataFieldX = "Date",
                    DataFieldY = "Value",
                    Smooth = true
                };

                series1.Points.Add(new DataPoint(1.2, 4.5));
                series1.Points.Add(new DataPoint(2.2, 5.8));
                series1.Points.Add(new DataPoint(4.4, 8.7));

                plotModel.Series.Add(series1);

                this.MyModel = plotModel;
            }
        }*/
    }
}
