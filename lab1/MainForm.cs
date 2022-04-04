using System;
using System.Windows.Forms;

namespace lab2
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
    }

    private void ButtonStart_Click(object sender, EventArgs e)
    {
      labelResult.Text = "";
      try
      {
        double a = Double.Parse(textBoxA.Text);
        double b = Double.Parse(textBoxB.Text);
        double eps = Double.Parse(textBoxE.Text);
        if (F(a) * F(b) > 0)
        {
          labelResult.Text = "В данном промежутке не удается найти один корень";
          return;
        }
        double result = GetResult(a, b, eps);
        labelResult.Text = $"х = {result.ToString()}";
      }
      catch
      {
        labelResult.Text = "Некорректные значение границ";
      }
    }

    private double GetResult(double a, double b, double eps)
    {
      if (radioButtonDichotomy.Checked)
      {
        return Dichotomy(a, b, eps);
      }
      if (radioButtonChord.Checked)
      {
        return MethodChord(a, b, eps);
      }
      if (radioButtonNewton.Checked)
      {
        return MethodNewton(a, b, eps);
      }
      if (radioButtonModifiedNewton.Checked)
      {
        return ModifiedMethodNewton(a, b, eps);
      }
      if (radioButtonCombined.Checked)
      {
        return CombinedMethod(a, b, eps);
      }
      return MethodIterations(a, b, eps);
    }


    private double Dichotomy(double leftLimit, double rigthLimit, double eps)
    {
      double left = leftLimit;
      double rigth = rigthLimit;
      double middle;

      do
      {
        middle = GetMiddleX(left, rigth);
        _ = (F(middle) * F(left) > 0) ? left = middle : rigth = middle;

      } while (!isRoot(middle, eps));
      return middle;
    }

    private double GetMiddleX(double leftLimit, double rigthLimit)
    {
      return (leftLimit + rigthLimit) / 2;
    }

    private double MethodChord(double leftLimit, double rigthLimit, double eps)
    {
      double cutPoint = GetInitialApproximation(leftLimit, rigthLimit);
      double x = (cutPoint == leftLimit) ? rigthLimit : leftLimit;
      do
      {
        x = GetNextXInMethodChord(x, cutPoint);
      } while (!isRoot(x, eps));
      return x;
    }

    private double GetNextXInMethodChord(double currentX, double сutPoint)
    {
      return currentX - F(currentX) * (сutPoint - currentX) / (F(сutPoint) - F(currentX));
    }

    private double MethodNewton(double leftLimit, double rigthLimit, double eps)
    {
      double x = GetInitialApproximation(leftLimit, rigthLimit);
      do
      {
        x = GetNextXInMethodNewton(x);
      } while (!isRoot(x, eps));
      return x;
    }

    private double GetNextXInMethodNewton(double currentX)
    {
      return currentX - F(currentX) / DerF(currentX);
    }

    private double ModifiedMethodNewton(double leftLimit, double rigthLimit, double eps)
    {
      double x = GetInitialApproximation(leftLimit, rigthLimit);
      double derStartX = DerF(x);
      do
      {
        x = GetNextXInModifiedMethodNewton(x, derStartX);
      } while (!isRoot(x, eps));
      return x;
    }

    private double GetNextXInModifiedMethodNewton(double currentX, double derStartX)
    {
      return currentX - F(currentX) / derStartX;
    }

    private double CombinedMethod(double leftLimit, double rigthLimit, double eps)
    {
      double x = GetInitialApproximation(leftLimit, rigthLimit);
      double y = (x == leftLimit) ? rigthLimit : leftLimit;
      double value;
      do
      {
        x = GetNextXInMethodNewton(x);
        y = GetNextYInCombinedMethod(x, y);
        value = (x + y) / 2;
      } while (!isRoot(value, eps));
      return value;
    }

    private double GetNextYInCombinedMethod(double nextX, double currentY)
    {
      return currentY - F(currentY) * (nextX - currentY) / (F(nextX) - F(currentY));
    }

    private double MethodIterations(double leftlimit, double rigthLimit, double eps)
    {
      double x = (leftlimit + rigthLimit) / 2;
      do
      {
        x = IterationMethodF(x);
      } while (!isRoot(x, eps));
      return x;
    }

    private double F(double x)
    {
      return Math.Pow(x, 5) + x - 0.2;
    }

    private double DerF(double x)
    {
      return 5 * Math.Pow(x, 4) + 1;
    }

    private double SecondDerF(double x)
    {
      return 20 * Math.Pow(x, 3);
    }

    private double IterationMethodF(double x)
    {
      return x - F(x) / 2;
    }

    private double GetInitialApproximation(double leftLimit, double rigthLimit)
    {
      double cutPoint;
      if (F(leftLimit) * SecondDerF(leftLimit) > 0)
      {
        cutPoint = leftLimit;
      }
      else
      {
        cutPoint = rigthLimit;
      }
      return cutPoint;
    }

    private bool isRoot(double x, double eps)
    {
      return Math.Abs(F(x)) < eps;
    }

  }
}
