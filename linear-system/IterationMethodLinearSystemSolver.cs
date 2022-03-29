namespace linear_system
{
  internal static class IterationMethodLinearSystemSolver
  {
    internal static double[] Solve(AugmentedMatrix augmentedMatrix, double eps)
    {
      var size = augmentedMatrix.GetSize();
      var xVector = GetInitialApproximationVector(size);
      var prevXVector = new double[size];
      do
      {
        Array.Copy(xVector, prevXVector, size);
        xVector = GetNextXVector(prevXVector, augmentedMatrix);
      } while (GetAbsSum(xVector, prevXVector) > eps);
      return xVector;
    }

    private static double[] GetInitialApproximationVector(int size)
    {
      var vector = new double[size];
      for (int i = 0; i < size; i++)
      {
        vector[i] = 0;
      }
      return vector;
    }

    private static double GetAbsSum(double[] xVector, double[] prevXVector)
    {
      var absSum = 0.0;
      for (int i = 0; i < xVector.Length; i++)
      {
        absSum += Math.Abs(xVector[i] - prevXVector[i]);
      }
      return absSum;
    }

    private static double[] GetNextXVector(double[] xVector, AugmentedMatrix augmentedMatrix)
    {
      var matrix = augmentedMatrix.Matrix;
      var freeCoefficientsVector = augmentedMatrix.FreeCoefficientsVector;
      var size = freeCoefficientsVector.Length;
      var nextXVector = new double[size];
      for (int i = 0; i < size; i++)
      {
        double sum = 0;
        for (int j = 0; j < size; j++)
        {
          if (i != j)
          {
            sum += matrix[i, j] * xVector[j];
          }
        }
        nextXVector[i] = (freeCoefficientsVector[i] - sum) / matrix[i, i];
      }
      return nextXVector;
    }
  }
}
