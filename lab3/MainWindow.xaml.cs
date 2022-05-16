using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using linear_system;

namespace lab3
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      int n = Int32.Parse(MatrixSizeTextBox.Text);
      GenerateMatrix(n);
      GenerateFreeCoefficientsVector(n);
      FillMatrix();
      FillFreeCoefficientsVector();
    }

    private void GenerateMatrix(int size)
    {
      if(Matrix is null)
      {
        return;
      }
      Matrix.Children.Clear();
      for (int i = 0; i < size; i++)
      {
        var stackPanel = new StackPanel()
        {
          Orientation = Orientation.Horizontal
        };
        for (int j = 0; j < size; j++)
        {
          TextBox textBox = new()
          {
            Text = "0",
            Width = 50,
            Height = 30,
            TextAlignment = TextAlignment.Center,
            Name = $"Matrix_{i}_{j}",
            Margin = new Thickness(1),
          };
          stackPanel.Children.Add(textBox);
        }
        Matrix.Children.Add(stackPanel);
      }
    }
  
    private void GenerateFreeCoefficientsVector(int size)
    {
      if(FreeCoefficientsVector is null)
      {
        return;
      }
      FreeCoefficientsVector.Children.Clear();
      for (int i = 0; i < size; i++)
      {
          TextBox textBox = new()
          {
            Text = "0",
            Width = 50,
            Height = 30,
            TextAlignment = TextAlignment.Center,
            Name = $"Vector_{i}",
            Margin = new Thickness(1),
          };
        FreeCoefficientsVector.Children.Add(textBox);
      }
    }

    private void GenerateAndFillResultVector(double[] resultVector)
    {
      if(ResultVector is null)
      {
        return;
      }
      ResultVector.Children.Clear();
      for (int i = 0; i < resultVector.Length; i++)
      {
        TextBox textBox = new()
        {
          Text = $"{resultVector[i]:F2}",
          Width = 50,
          Height = 30,
          TextAlignment = TextAlignment.Center,
          IsReadOnly = true,
          Margin = new Thickness(1),
        };
        ResultVector.Children.Add(textBox);
      }
    }

    private void FillMatrix()
    {
      double[] source = { 3.8, 14.2, 6.3, -15.5, 8.3, -6.6, 5.8, 12.2, 6.4, -8.5, -4.3, 8.8, 17.1, -8.3, 14.4, -7.2};
      double[] iterationSource = { 16.6, -2.8, -2.3, 2.1, 2.5, -7.95, 1.15, -1.95, 1.9, 1.9, 10.1, 3.4, 8.8, -1.7, 8.6, -19.4 };

      int i = 0;
      foreach (StackPanel stackPanel in Matrix.Children)
      {
        foreach (TextBox textBox in stackPanel.Children)
        {
          textBox.Text = $"{iterationSource[i++]}";
        }
      }
    }

    private void FillFreeCoefficientsVector()
    {
      double[] vector = { 2.8, -4.7, 7.7, 13.5 };
      double[] iterationVector = { 18.2, 7.7, -12.4, 18.2 };
      int i = 0;
      foreach (TextBox textBox in FreeCoefficientsVector.Children)
      {
        textBox.Text = $"{iterationVector[i++]}";
      }
    }

    private void GaussButton_Click(object sender, RoutedEventArgs e)
    {
      var augMatrex = GetAugmentedMatrixFromTextBoxes();
      var res = LinearSystemSolver.GaussSolve(augMatrex);

      GenerateAndFillResultVector(res.ResultVector);
      DeterminantTextBox.Text = $"{res.Determinant:F2}";
      ConditionNumberTextBox.Text = $"{res.ConditionNumber:F2}";
      GaussResultsStackPanel.Visibility = Visibility.Visible;
    }


    private void IterationMethodButton_Click(object sender, RoutedEventArgs e)
    {
      var augMatrex = GetAugmentedMatrixFromTextBoxes();
      var res = LinearSystemSolver.IterationSolve(augMatrex);
      GenerateAndFillResultVector(res);
      GaussResultsStackPanel.Visibility = Visibility.Hidden;
    }

    private AugmentedMatrix GetAugmentedMatrixFromTextBoxes()
    {
      int n = Int32.Parse(MatrixSizeTextBox.Text);
      double[,] matrix = new double[n, n];
      int i = 0;
      foreach (StackPanel stackPanel in Matrix.Children)
      {
        int j = 0;
        foreach (TextBox textBox in stackPanel.Children)
        {
          matrix[i, j++] = double.Parse(textBox.Text);
        }
        i++;
      }
      double[] vector = new double[n];
      i = 0;
      foreach (TextBox textBox in FreeCoefficientsVector.Children)
      {
        vector[i++] = double.Parse(textBox.Text);
      }
      return AugmentedMatrix.Create(matrix, vector);
    }

    private void MatrixSizeTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
      int n = Int32.Parse(MatrixSizeTextBox.Text);
      if(n < 2 || n > 6)
      {
        n = 4;
        MatrixSizeTextBox.Text = $"{n}";
      }
      GenerateMatrix(n);
      GenerateFreeCoefficientsVector(n);
      if (ResultVector is not null)
      {
        ResultVector.Visibility = Visibility.Hidden;
      }
      if (GaussResultsStackPanel is not null)
      {
        GaussResultsStackPanel.Visibility = Visibility.Hidden;
      }
    }
  }
}
