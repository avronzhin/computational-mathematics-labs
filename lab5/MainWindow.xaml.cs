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
        double y0 = double.Parse(textBoxY0.Text);

        static double f(double x, double y) => - y * Math.Log(y) / x;
        
        IList<(double, double)> pointsWithFullStep = RungeKuttaMethod.Execute(f, x0, y0, xEnd, h);
        IList<(double, double)> pointsWithDoubledStep = RungeKuttaMethod.Execute(f, x0, y0, xEnd, h * 2);
        IList<(double, double)> pointsWithHalfStep = RungeKuttaMethod.Execute(f, x0, y0, xEnd, h / 2);

        var window = new GraphicsWindow();
        window.fillModels(pointsWithFullStep, pointsWithDoubledStep, pointsWithHalfStep);
        window.Show();
      }
      catch { };
    }

    private void buttonSecondTaskStart_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        double h = double.Parse(textBoxH_task2.Text);
        double t0 = double.Parse(textBoxT0.Text);
        double tEnd = double.Parse(textBoxTEnd.Text);
        double x0 = double.Parse(textBoxX0_task2.Text);
        double y0 = double.Parse(textBoxY0_task2.Text);

        //double f(double t, double x, double y) => Math.Pow(t, 2) + Math.Pow(y, 2);
        //double g(double t, double x, double y) => t * x * y;

        double f(double t, double x, double y) => Math.Atan(t * t + y * y);
        double g(double t, double x, double y) => Math.Sin(t + x);

        IList<(double, double, double)> pointsWithFullStep = RungeKuttaMethod.Execute(t0, tEnd, h, f, x0, g, y0);
        IList<(double, double, double)> pointsWithDoubledStep = RungeKuttaMethod.Execute(t0, tEnd, h * 2, f, x0, g, y0);
        IList<(double, double, double)> pointsWithHalfStep = RungeKuttaMethod.Execute(t0, tEnd, h / 2, f, x0, g, y0);

        var window = new GraphicsWindow();
        window.fillModels(pointsWithFullStep, pointsWithDoubledStep, pointsWithHalfStep);
        window.Show();
      }
      catch { };

    }

    private void buttonThirdTaskStart_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        double h = double.Parse(textBoxH_task3.Text);
        double a1 = double.Parse(textBoxA1.Text);
        double a2 = double.Parse(textBoxA2.Text);
        FiniteDifferenceMethod.HomogeneousLinearEquation equation = new(a1, a2);

        double k0 = double.Parse(textBoxK0.Text);
        double k1 = double.Parse(textBoxK1.Text);
        double A = double.Parse(textBoxA.Text);
        double a = double.Parse(textBoxX0_task3.Text);
        FiniteDifferenceMethod.Limitation bottomLimitation = new(a, k0, k1, A);

        double m0 = double.Parse(textBoxM0.Text);
        double m1 = double.Parse(textBoxM1.Text);
        double B = double.Parse(textBoxB.Text);
        double b = double.Parse(textBoxXEnd_task3.Text);
        FiniteDifferenceMethod.Limitation topLimitation = new(b, m0, m1, B);

        IList<(double, double)> pointsWithFullStep = FiniteDifferenceMethod.Execute(equation, bottomLimitation, topLimitation, h);
        IList<(double, double)> pointsWithDoubledStep = FiniteDifferenceMethod.Execute(equation, bottomLimitation, topLimitation, h * 2);
        IList<(double, double)> pointsWithHalfStep = FiniteDifferenceMethod.Execute(equation, bottomLimitation, topLimitation, h / 2);

        var window = new GraphicsWindow();
        window.fillModels(pointsWithFullStep, pointsWithDoubledStep, pointsWithHalfStep);
        window.Show();
      } catch { };
      
    }
  }
}
