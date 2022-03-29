namespace linear_system
{
  public static class Matrices
  {
    public static double GetTriangularMatrixDeterminant(double[,] triangularMatrix)
    {
      var det = 1.0;
      for (int i = 0; i < triangularMatrix.GetLength(0); i++)
      {
        det *= triangularMatrix[i, i];
      }
      return det;
    }

    public static double GetConditionNumber(double[,] matrix)
    {
      var norm = GetNorm(matrix);
      var inverseMatrix = GetInverseMatrix(matrix);
      var inverseMatrixNorm = GetNorm(inverseMatrix);
      var conditionNumber = norm * inverseMatrixNorm;
      return conditionNumber;
    }

    public static double[,] GetInverseMatrix(double[,] matrix)
    {
      var copyMatrix = CopyMatrix(matrix);
      int N = matrix.GetLength(0);
      var identityMatrix = GetIdentityMatrix(N);

      // Прямой ход
      for (int k = 0; k < N - 1; k++)
      {
        for (int i = k + 1; i < N; i++)
        {
          double leadingElement = copyMatrix[k, k];
          if (leadingElement == 0)
          {
            ChangeLeadingRow(copyMatrix, identityMatrix, k);
            leadingElement = matrix[k, k];
          }
          double coef = (copyMatrix[i, k] / leadingElement);
          for (int j = 0; j < N; j++)
          {
            copyMatrix[i, j] -= copyMatrix[k, j] * coef;
            identityMatrix[i, j] -= identityMatrix[k, j] * coef;
          }
        }
      }

      // Обратный ход
      for (int k = N - 1; k > 0; k--)
      {
        for (int i = k - 1; i >= 0; i--)
        {
          double leadingElement = copyMatrix[k, k];
          double coef = (copyMatrix[i, k] / leadingElement);
          for (int j = 0; j < N; j++)
          {
            copyMatrix[i, j] -= copyMatrix[k, j] * coef;
            identityMatrix[i, j] -= identityMatrix[k, j] * coef;
          }
        }
      }

      //Приведение матрицы к единичной
      for (int i = 0; i < N; i++)
      {
        var coef = copyMatrix[i, i];
        for (int j = 0; j < N; j++)
        {
          copyMatrix[i, j] /= coef;
          identityMatrix[i, j] /= coef;
        }
      }

      return identityMatrix;
    }

    private static void ChangeLeadingRow(double[,] matrix, double[,] identityMatrix, int currentLeadingRow)
    {
      for (int i = currentLeadingRow + 1; i < matrix.GetLength(0); i++)
      {
        if (matrix[i, currentLeadingRow] != 0)
        {
          ChangeRows(matrix, identityMatrix, currentLeadingRow, i);
          return;
        }
      }
      throw new DegenerateSystemException();
    }

    private static void ChangeRows(double[,] matrix, double[,] identityMatrix, int firstRow, int secondRow)
    {
      double temp;
      for (int i = 0; i < matrix.GetLength(1); i++)
      {
        temp = matrix[firstRow, i];
        matrix[firstRow, i] = matrix[secondRow, i];
        matrix[secondRow, i] = temp;

        temp = identityMatrix[firstRow, i];
        identityMatrix[firstRow, i] = identityMatrix[secondRow, i];
        identityMatrix[secondRow, i] = temp;
      }
    }

    private static double[,] CopyMatrix(double[,] matrix)
    {
      var copyMatrix = new double[matrix.GetLength(0), matrix.GetLength(1)];
      Array.Copy(matrix, copyMatrix, matrix.Length);
      return copyMatrix;
    }

    private static double[,] GetIdentityMatrix(int size)
    {
      var identityMatrix = new double[size, size];
      for (int i = 0; i < size; i++)
      {
        for (int j = 0; j < size; j++)
        {
          identityMatrix[i, j] = (i == j) ? 1 : 0;
        }
      }
      return identityMatrix;
    }

    private static double GetNorm(double[,] matrix)
    {
      var norm = 0.0;
      for (int i = 0; i < matrix.GetLength(0); i++)
      {
        var sum = 0.0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
          sum += Math.Abs(matrix[i, j]);
        }
        if (sum > norm)
        {
          norm = sum;
        }
      }
      return norm;
    }

    public static void Print(double[,] matrix)
    {
      for(int i=0; i<matrix.GetLength(0); i++)
      {
        for(int j=0; j<matrix.GetLength(1); j++)
        {
          Console.Write($"{matrix[i, j]:F2} ");
        }
        Console.WriteLine();
      }
      Console.WriteLine();
    }
  }
}
