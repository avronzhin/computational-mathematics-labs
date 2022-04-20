using ordinary_differential_equation;
using System;
using System.Collections.Generic;
using System.Windows;

namespace lab5
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
      InitializeComponent();
    }

    private void buttonStart_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        double h = double.Parse(textBoxH.Text);
        double x0 = double.Parse(textBoxX0.Text);
        double xEnd = double.Parse(textBoxXEnd.Text);
        double y0 = Math.Atan(2 - Math.E);
        double f(double x, double y) => 3 * Math.Exp(x) * Math.Tan(y) * Math.Pow(Math.Cos(x), 2) / (Math.Exp(x) - 2);

        double testF(double x, double y) => -y / x * Math.Log(y);
        IList<(double, double)> pointsWithFullStep = RungeKuttaMethod.Execute(testF, 1, Math.E, 2.6, h);
        IList<(double, double)> pointsWithDoubledStep = RungeKuttaMethod.Execute(testF, 1, Math.E, 2.6, h * 2);
        IList<(double, double)> pointsWithHalfStep = RungeKuttaMethod.Execute(testF, 1, Math.E, 2.6, h / 2);

        var window = new GraphicsWindow();
        window.fillModels(pointsWithFullStep, pointsWithDoubledStep, pointsWithHalfStep);
        window.Show();
      }
      catch { };
    }

    private void buttonSecondTaskStart_Click(object sender, RoutedEventArgs e)
    {
      double h = 0.4;
      double a = 0;
      double b = 5;
      double x0 = 1;
      double y0 = 0;
      double f(double t, double x, double y) => t * t + y * y;
      double g(double t, double x, double y) => t * x * y;
      IList<(double, double, double)> pointsWithFullStep = RungeKuttaMethod.Execute(a, b, h, f, x0, g, y0);
      IList<(double, double, double)> pointsWithDoubledStep = RungeKuttaMethod.Execute(a, b, h * 2, f, x0, g, y0);
      IList<(double, double, double)> pointsWithHalfStep = RungeKuttaMethod.Execute(a, b, h / 2, f, x0, g, y0);

      var window = new GraphicsWindow();
      window.fillModels(pointsWithFullStep, pointsWithDoubledStep, pointsWithHalfStep);
      window.Show();
    }
  }
}
