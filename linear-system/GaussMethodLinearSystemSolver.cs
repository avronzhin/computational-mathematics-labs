namespace linear_system
{
  internal static class GaussMethodLinearSystemSolver
  {
    public class SolveResult
    {
      public double[,] TriangularMatrix { get; }
      public double[] ResultVector { get; }

      internal SolveResult(double[,] matrix, double[] vector)
      {
        TriangularMatrix = matrix;
        ResultVector = vector;
      }
    }

    internal static SolveResult Solve(AugmentedMatrix augmentedMatrix)
    {
      var copyAugmentedMatrix = augmentedMatrix.Copy();
      ReduceToTriangularMatrix(copyAugmentedMatrix);
      var resultVector = GetResultVector(copyAugmentedMatrix);
      return new SolveResult(copyAugmentedMatrix.Matrix, resultVector);
    }

    private static void ReduceToTriangularMatrix(AugmentedMatrix augmentedMatrix)
    {
      int matrixSize = augmentedMatrix.GetSize();
      var matrix = augmentedMatrix.Matrix;
      var vector = augmentedMatrix.FreeCoefficientsVector;
      for (int k = 0; k < matrixSize - 1; k++)
      {
        double leadingElement = matrix[k, k];
        if (leadingElement == 0)
        {
          ChangeLeadingRow(augmentedMatrix, k);
          leadingElement = matrix[k, k];
        }
        for (int i = k + 1; i < matrixSize; i++)
        {
          double coef = (matrix[i, k] / leadingElement);
          for (int j = 0; j < matrixSize; j++)
          {
            matrix[i, j] -= matrix[k, j] * coef;
          }
          vector[i] -= vector[k] * coef;
        }
      }
    }

    private static void ChangeLeadingRow(AugmentedMatrix augmentedMatrix, int currentLeadingRow)
    {
      double[,] matrix = augmentedMatrix.Matrix;
      for (int i = currentLeadingRow + 1; i < matrix.GetLength(0); i++)
      {
        if (matrix[i, currentLeadingRow] != 0)
        {
          ChangeRows(augmentedMatrix, currentLeadingRow, i);
          return;
        }
      }
      throw new DegenerateSystemException();
    }

    private static void ChangeRows(AugmentedMatrix augmentedMatrix, int firstRow, int secondRow)
    {
      double[,] matrix = augmentedMatrix.Matrix;
      double[] vector = augmentedMatrix.FreeCoefficientsVector;
      double temp;
      for (int i = 0; i < matrix.GetLength(1); i++)
      {
        temp = matrix[firstRow, i];
        matrix[firstRow, i] = matrix[secondRow, i];
        matrix[secondRow, i] = temp;
      }
      temp = vector[firstRow];
      vector[firstRow] = vector[secondRow];
      vector[secondRow] = temp;
    }

    private static double[] GetResultVector(AugmentedMatrix augmentedMatrix)
    {
      int matrixSize = augmentedMatrix.GetSize();
      var matrix = augmentedMatrix.Matrix;
      var vector = augmentedMatrix.FreeCoefficientsVector;
      var resultVector = new double[matrixSize];

      for (int i = matrixSize - 1; i >= 0; i--)
      {
        double sum = 0;
        for (int j = i + 1; j < matrixSize; j++)
        {
          sum += matrix[i, j] * resultVector[j];
        }
        resultVector[i] = (vector[i] - sum) / matrix[i, i];
      }
      return resultVector;
    }
  }
}
