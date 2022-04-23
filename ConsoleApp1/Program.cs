using linear_system;


double a1 = 0;
double a2 = 1;
double h = 0.1;
double a = -Math.PI / 2;
double b = 3 * Math.PI / 2;
double k0 = 1;
double k1 = 0;
double A = 3;
double m0 = 0;
double m1 = 1;
double B = 0;
int n = (int) Math.Ceiling((b - a) / h) + 1;
Console.WriteLine(n);
double[,] matrix = new double[n, n];
for(int i = 0; i < n; i++)
{
  for(int j = 0; j < n; j++)
  {
    matrix[i, j] = 0;
  }
}
double[] vector = new double[n];
for(int i = 0; i < n; i++)
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

for (int i = 0; i < n; i++)
{
  for (int j = 0; j < n; j++)
  {
    Console.Write(matrix[i, j] + " ");
  }
  Console.Write(" | " + vector[i] );
  Console.WriteLine();
}

var augMatrix = AugmentedMatrix.Create(matrix, vector);
var result = LinearSystemSolver.GaussSolve(augMatrix);

foreach(var i in result.ResultVector)
{
  Console.WriteLine(i);
}