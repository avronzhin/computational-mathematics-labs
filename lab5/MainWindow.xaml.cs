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
        List<(double, double)> list = new();
        list.Add((1, 3));
        list.Add((2, 4));
        list.Add((3, 7));

        var window = new GraphicsWindow(list);
        window.Show();
      } catch { };
    }
  }
}
