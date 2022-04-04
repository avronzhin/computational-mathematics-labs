namespace function_interpolation
{
  public class Monomial
  {
    public Monomial(double coef, List<double> roots)
    {
      this.coef = coef;
      this.roots = roots;
    }

    public double coef { get; set; }
    public List<double> roots { get; set; }

    public double f(double x)
    {
      var result = this.coef;
      foreach (double root in roots)
      {
        result *= (x - root);
      }
      return result;
    }

    public override string? ToString()
    {
      var result = string.Empty;
      var absCoef = Math.Abs(coef);
      if (absCoef < 0.001)
      {
        return string.Empty;
      }
      result += (coef > 0) ? " + " : " - ";
      result += $"{absCoef:F2}";
      foreach (var root in roots)
      {

        result += (root == 0) ? "x" : $"(x - {root})";
      }
      return result;
    }
  }
}
