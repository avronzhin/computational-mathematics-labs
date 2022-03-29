namespace linear_system
{
  public static class LinearSystemSolver
  {
    public class Result
    {
      public double[] ResultVector { get; }
      public double Determinant { get; }
      public double ConditionNumber { get; }

      public Result(double[] resultVector, double det, double conditionNumber)
      {
        this.ResultVector = resultVector;
        this.Determinant = det;
        this.ConditionNumber = conditionNumber;
      }
    }

    public static Result GaussSolve(AugmentedMatrix augmentedMatrix)
    {
      var matrix = augmentedMatrix.Matrix;
      var conditionNumber = Matrices.GetConditionNumber(matrix);

      var solveResult = GaussMethodLinearSystemSolver.Solve(augmentedMatrix);
      var resultVector = solveResult.ResultVector;
      var triangularMatrix = solveResult.TriangularMatrix;

      var det = Matrices.GetTriangularMatrixDeterminant(triangularMatrix);
      return new Result(resultVector, det, conditionNumber);
    }

    public static double[] IterationSolve(AugmentedMatrix augmentedMatrix)
    {
      double eps = 0.001;
      return IterationMethodLinearSystemSolver.Solve(augmentedMatrix, eps);
    }
  }
}