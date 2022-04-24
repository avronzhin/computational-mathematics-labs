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
      double a = bottomLimition.X;
      double b = topLimition.X;
      int n = (int)Math.Ceiling((b - a) / h) + 1;
      var augMatrix = AugmentedMatrix.Create(new double[n, n], new double[n]);

      augMatrix.FillBottomLimition(bottomLimition, h);
      augMatrix.FillTopLimition(topLimition, h, n);
      augMatrix.FillRows(equation, h, n);

      var vector = LinearSystemSolver.GaussSolve(augMatrix).ResultVector;
      var x = a;
      return vector.ToList().ConvertAll<(double, double)>(it => (x += h, it));
    }

    private static void FillBottomLimition(this AugmentedMatrix augmentedMatrix, Limitation bottomLimition, double h)
    {
      var matrix = augmentedMatrix.Matrix;
      var vector = augmentedMatrix.FreeCoefficientsVector;
      matrix[0, 0] = bottomLimition.K0 * h - bottomLimition.K1;
      matrix[0, 1] = bottomLimition.K1;
      vector[0] = bottomLimition.A * h;
    }

    private static void FillTopLimition(this AugmentedMatrix augmentedMatrix, Limitation topLimition, double h, int n)
    {
      var matrix = augmentedMatrix.Matrix;
      var vector = augmentedMatrix.FreeCoefficientsVector;
      matrix[n - 1, n - 1] = topLimition.K0 * h + topLimition.K1;
      matrix[n - 1, n - 2] = -topLimition.K1;
      vector[n - 1] = topLimition.A * h;
    }

    private static void FillRows(this AugmentedMatrix augmentedMatrix, HomogeneousLinearEquation equation, double h, int n)
    {
      var matrix = augmentedMatrix.Matrix;
      var vector = augmentedMatrix.FreeCoefficientsVector;
      for (int i = 1; i < n - 1; i++)
      {
        matrix[i, i - 1] = 1;
        matrix[i, i] = equation.A2 * h * h - equation.A1 * h - 2;
        matrix[i, i + 1] = equation.A1 * h + 1;
      }
    }
  }
}
