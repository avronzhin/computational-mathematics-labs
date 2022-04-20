namespace ordinary_differential_equation
{
  public static class RungeKuttaMethod
  {
    public static IList<(double, double)> Execute(Func<double, double, double> f, double x0,
      double y0, double xEnd, double h)
    {
      var result = new List<(double, double)>();
      double y = y0;
      double x = x0;
      while (x < xEnd + h / 2)
      {
        var point = (x, y);
        result.Add(point);

        double k1 = h * f(x, y);
        double k2 = h * f(x + h / 2, y + k1 / 2);
        double k3 = h * f(x + h / 2, y + k2 / 2);
        double k4 = h * f(x + h, y + k3);

        x += h;
        y += (k1 + 2 * k2 + 2 * k3 + k4) / 6;
      }
      return result;
    }

    public static IList<(double, double, double)> Execute
      (
      double a, double b, double h,
      Func<double, double, double, double> f, double x0,
      Func<double, double, double, double> g, double y0
      )
    {
      var result = new List<(double, double, double)>();
      double t = a;
      double x = x0;
      double y = y0;
      while (t < b + h / 2)
      {
        var point = (t, x, y);
        result.Add(point);

        double k1 = h * f(t, x, y);
        double m1 = h * g(t, x, y);
        double k2 = h * f(t + h / 2, x + k1 / 2, y + m1 / 2);
        double m2 = h * g(t + h / 2, x + k1 / 2, y + m1 / 2);
        double k3 = h * f(t + h / 2, x + k2 / 2, y + m2 / 2);
        double m3 = h * g(t + h / 2, x + k2 / 2, y + m2 / 2);
        double k4 = h * f(t + h, x + k3, y + m3);
        double m4 = h * g(t + h, x + k3, y + m3);

        t += h;
        x += (k1 + 2 * k2 + 2 * k3 + k4) / 6;
        y += (m1 + 2 * m2 + 2 * m3 + m4) / 6;
      }
      return result;
    }
  }
}
