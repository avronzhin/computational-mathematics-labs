using function_interpolation;

double[] nodes = { 0, 0.1, 0.2, 0.5, 0.6, 0.8, 1 };
double b = 0.15;
Func<double, double> f = x => Math.Exp(-b*x)*Math.Sin(Math.PI*(x+Math.Pow(x,2)));
Console.WriteLine(InterpolationPolynomials.ConstructPolynomial(nodes, f));  