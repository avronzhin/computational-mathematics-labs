namespace function_interpolation
{
  public class InterpolationPolynomials
  {
    public (double x, double y)[] nodes;

    public InterpolationPolynomials(double[] arguments, Func<double, double> f)
    {
      var nodesCount = arguments.Length;
      var nodes = new (double x, double y)[nodesCount];
      for(int i = 0; i < nodesCount; i++)
      {
        nodes[i].x = arguments[i];
        nodes[i].y = f(arguments[i]);
      }
      this.nodes = nodes;
    }

    public Polynomial ConstructPolynomial()
    {
      Polynomial pol = new();
      for (int i = 0; i < nodes.Length; i++)
      {
        double dividedDiffirence = GetDividedDifferences(0, i);
        List<double> rotes = GetGeneralizedDegreeRoots(i);
        Monomial mon = new(dividedDiffirence, rotes);
        pol.addMonomial(mon);
      }
      return pol;
    }
    
    private List<double> GetGeneralizedDegreeRoots(int i)
    {
      List<double> roots = new List<double>();
      for (int j = 0; j < i; j++)
      {
        var x = nodes[j].x;
        roots.Add(x);
      }
      return roots;
    } 

    private double GetDividedDifferences(int i, int n)
    {
      if (n == 0)
      {
        return nodes[i].y;
      }
      if (n == 1)
      {
        return ((nodes[i + 1].y) - (nodes[i].y)) / (nodes[i + 1].x - nodes[i].x);
      }
      return (GetDividedDifferences(i + 1, n - 1) - GetDividedDifferences(i, n - 1)) / (nodes[i + n].x - nodes[i].x);
    }
  }
}