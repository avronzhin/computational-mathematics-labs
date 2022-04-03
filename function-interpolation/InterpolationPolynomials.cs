namespace function_interpolation
{
  public static class InterpolationPolynomials
  {
    public static double[] nodes;
    public static Func<double, double> f;


    public static string ConstructPolynomial(double[] nodes, Func<double, double> f)
    {
      InterpolationPolynomials.nodes = nodes;
      InterpolationPolynomials.f = f;
      string polynomial = "L(x) = ";

      polynomial += nodes[0] + "";
      for (int i = 1; i < nodes.Length; i++)
      {
        double differnce = Foo(0, i);
        polynomial += (differnce > 0) ? " + " : " - ";
        polynomial += $"{Math.Abs(differnce):F2}";
        for (int j = 0; j < i; j++)
        {
          var xj = nodes[j];

          polynomial += (xj == 0) ? "x" : $"(x - {nodes[j]})";
        }
      }
      return polynomial;
    }

    private static double Foo(int i, int n)
    {
      if (n == 0)
      {
        return 1;
      }
      if (n == 1)
      {
        return (f(nodes[i + 1]) - f(nodes[i])) / (nodes[i + 1] - nodes[i]);
      }
      return (Foo(i + 1, n - 1) - Foo(i, n - 1)) / (nodes[i + n] - nodes[i]);
    }
  }
}