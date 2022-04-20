using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Windows;

namespace lab5
{
  /// <summary>
  /// Логика взаимодействия для GraphicsWindow.xaml
  /// </summary>
  public partial class GraphicsWindow : Window
  {

    public PlotModel FullStepModel { get; set; } = new PlotModel();
    public PlotModel DoubledStepModel { get; set; } = new PlotModel();
    public PlotModel HalfStepModel { get; set; } = new PlotModel();


    public GraphicsWindow()
    {
      InitializeComponent();
      DataContext = this;
    }

    public void fillModels(
      IList<(double x, double y)> pointsWithFullStep,
      IList<(double x, double y)> pointsWithDoubledStep,
      IList<(double x, double y)> pointsWithHalfStep)
    {
      fillModel(FullStepModel, pointsWithFullStep);
      fillModel(DoubledStepModel, pointsWithDoubledStep);
      fillModel(HalfStepModel, pointsWithHalfStep);
    }

    private void fillModel(PlotModel model, IList<(double x, double y)> points)
    {
      IList<DataPoint> list = new List<DataPoint>();
      foreach ((double x, double y) in points)
      {
        DataPoint dataPoint = new DataPoint(x, y);
        list.Add(dataPoint);
      }
      var series = new LineSeries();
      series.ItemsSource = list;
      model.Series.Add(series);
    }

    private void fillModel(PlotModel model, IList<(double t, double x, double y)> points)
    {
      IList<DataPoint> firstList = new List<DataPoint>();
      IList<DataPoint> secondList = new List<DataPoint>();

      foreach ((double t, double x, double y) in points)
      {
        DataPoint dataPoint = new DataPoint(t, x);
        firstList.Add(dataPoint);
        dataPoint = new DataPoint(t, y);
        secondList.Add(dataPoint);
      }
      var series = new LineSeries();
      series.ItemsSource = firstList;
      series.Title = "x";
      model.Series.Add(series);
      series = new LineSeries();
      series.Title = "y";
      series.ItemsSource = secondList;
      model.Series.Add(series);
    }

    public void fillModels(
      IList<(double t, double x, double y)> pointsWithFullStep,
      IList<(double t, double x, double y)> pointsWithDoubledStep,
      IList<(double t, double x, double y)> pointsWithHalfStep)
    {
      fillModel(FullStepModel, pointsWithFullStep);
      fillModel(DoubledStepModel, pointsWithDoubledStep);
      fillModel(HalfStepModel, pointsWithHalfStep);
    }
  }
}
