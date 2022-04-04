using function_interpolation;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Windows;

namespace lab4
{
  /// <summary>
  /// Логика взаимодействия для GraphicsWindow.xaml
  /// </summary>
  public partial class GraphicsWindow : Window
  {
    public PlotModel FunctionModel { get; set; } = new PlotModel();

    public PlotModel PolynomialModel { get; set; } = new PlotModel();

    public PlotModel BothGraphsModel { get; set; } = new PlotModel();

    public PlotModel ErrorPlotModel { get; set; } = new PlotModel();

    private class MeasurementError
    {
      private Func<double, double> f1;
      private Func<double, double> f2;

      public MeasurementError(Func<double, double> f1, Func<double, double> f2)
      {
        this.f1 = f1;
        this.f2 = f2;
      }

      public double f(double x)
      {
        return Math.Abs(f1(x) - f2(x));
      }
    }

    public GraphicsWindow(Func<double, double> f, Func<double, double> polF, double minX, double maxX)
    {
      InitializeComponent();
      DataContext = this;
      var polynomialSeries = new FunctionSeries(polF, minX, maxX, 0.001);
      var functionSeries = new FunctionSeries(f, minX, maxX, 0.001);
      FunctionModel.Series.Add(functionSeries);
      PolynomialModel.Series.Add(polynomialSeries);
      polynomialSeries = new FunctionSeries(polF, minX, maxX, 0.001);
      functionSeries = new FunctionSeries(f, minX, maxX, 0.001);
      BothGraphsModel.Series.Add(functionSeries);
      BothGraphsModel.Series.Add(polynomialSeries);
      MeasurementError measurementError = new(f, polF);
      var errorSeries = new FunctionSeries(measurementError.f, minX, maxX, 0.001);
      ErrorPlotModel.Series.Add(errorSeries);
    }
  }
}
