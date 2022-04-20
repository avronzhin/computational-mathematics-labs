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

    public PlotModel FunctionModel { get; set; } = new PlotModel();

    public GraphicsWindow(List<(double x, double y)> points)
    {
      InitializeComponent();

      DataContext = this;
      IList<DataPoint> list = new List<DataPoint>();
      foreach ((double x, double y) in points)
      {
        DataPoint dataPoint = new DataPoint(x, y);
        list.Add(dataPoint);
      }
      var serise = new LineSeries();
      serise.ItemsSource = list;
      FunctionModel.Series.Add(serise);
    }
  }
}
