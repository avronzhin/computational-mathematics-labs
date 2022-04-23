using linear_system;

namespace ordinary_differential_equation
{
  public static class FiniteDifferenceMethod
  {
    public class HomogeneousLinearEquation
    {
      public double A1 { get; }
      public double A2 { get; }

      public HomogeneousLinearEquation(double a1, double a2)
      {
        this.A1 = a1;
        this.A2 = a2;
      }
    }

    public class Limitation
    { 
      public double X { get; }
      public double K0 { get; }
      public double K1 { get; }
      public double A { get; }

      public Limitation(double x, double k0, double k1, double a)
      {
        this.X = x;
        this.K0 = k0;
        this.K1 = k1; 
        this.A = a;
      }
    }

    public static IList<(double, double)> Execute(HomogeneousLinearEquation equation, 
      Limitation bottomLimition, Limitation topLimition, double h)
    {
      double a1 = equation.A1;
      double a2 = equation.A2;

      double a = bottomLimition.X;
      double k0 = bottomLimition.K0;
      double k1 = bottomLimition.K1;
      double A = bottomLimition.A;

      double b = topLimition.X;
      double m0 = topLimition.K0;
      double m1 = topLimition.K1;
      double B = topLimition.A;

      int n = (int)Math.Ceiling((b - a) / h) + 1;

      double[,] matrix = new double[n, n];
      for (int i = 0; i < n; i++)
      {
        for (int j = 0; j < n; j++)
        {
          matrix[i, j] = 0;
        }
      }
      double[] vector = new double[n];
      for (int i = 0; i < n; i++)
      {
        vector[i] = 0;
      }
      matrix[0, 0] = k0 * h - k1;
      matrix[0, 1] = k1;
      vector[0] = A * h;

      matrix[n - 1, n - 1] = m0 * h + m1;
      matrix[n - 1, n - 2] = -m1;
      vector[n - 1] = B * h;

      for (int i = 1; i < n - 1; i++)
      {
        matrix[i, i - 1] = 1;
        matrix[i, i] = a2 * h * h - a1 * h - 2;
        matrix[i, i + 1] = a1 * h + 1;
      }

      var result = new List<(double, double)>();

      var augMatrix = AugmentedMatrix.Create(matrix, vector);
      var x = a;
      foreach (var y in LinearSystemSolver.GaussSolve(augMatrix).ResultVector)
      {
        result.Add((x, y));
        x += h;
      }
      return result;
    }
  }
}
