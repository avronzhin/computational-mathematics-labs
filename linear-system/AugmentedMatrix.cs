namespace linear_system
{
  public class AugmentedMatrix
  {
    public double[,] Matrix { get; }
    public double[] FreeCoefficientsVector { get; }

    private AugmentedMatrix(double[,] matrix, double[] vector)
    {
      this.Matrix = matrix;
      this.FreeCoefficientsVector = vector;
    }

    public static AugmentedMatrix Create(double[,] matrix, double[] freeCoefficientsVector)
    {
      if (matrix.GetLength(0) != freeCoefficientsVector.GetLength(0)
        || matrix.GetLength(0) != matrix.GetLength(1))
      {
        throw new MismatchedDimensionsException();
      }
      return new AugmentedMatrix(matrix, freeCoefficientsVector);
    }

    public void Print()
    {
      for (int i = 0; i < Matrix.GetLength(0); i++)
      {
        for (int j = 0; j < Matrix.GetLength(1); j++)
        {
          Console.Write($"{Matrix[i, j]:F2}");
          Console.Write(" ");
        }
        Console.WriteLine("\t| " + FreeCoefficientsVector[i]);
      }
      Console.WriteLine();
    }

    public int GetSize()
    {
      return Matrix.GetLength(0);
    }

    public AugmentedMatrix Copy()
    {
      int matrixSize = GetSize();
      var matrix = new double[matrixSize, matrixSize];
      var vector = new double[matrixSize];
      Array.Copy(Matrix, matrix, matrixSize * matrixSize);
      Array.Copy(FreeCoefficientsVector, vector, matrixSize);
      return new AugmentedMatrix(matrix, vector);
    }
  }  
}
