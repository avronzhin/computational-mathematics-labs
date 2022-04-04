using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace function_interpolation
{
  public class Polynomial
  {

    public Polynomial()
    {
      Monomials = new();
    }

    public List<Monomial> Monomials { get; set; }
     
    public void addMonomial(Monomial monomial)
    {
      Monomials.Add(monomial);
    }

    public double f(double x)
    {
      double result = 0;
      foreach (Monomial monomial in Monomials)
      {
        result += monomial.f(x);
      }
      return result;
    }

    public override string? ToString()
    {
      string result = string.Empty;
      foreach (Monomial monomial in Monomials)
      {
        result += monomial.ToString();
      }
      if (result.Length > 4)
      {
        result = removeExtraPlus(result);
      }
      return result;
    }

    public string removeExtraPlus(string str)
    {
      if (str[1] == '+')
      {
        str = str.Substring(3);
      }
      return str;
    }
  }
}
