﻿using function_interpolation;
using System;
using System.Windows;
using System.Windows.Controls;

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
      int n = Int32.Parse(textBoxN.Text);
      GenerateNodes(n);
    }

    private void GenerateNodes(int size)
    {
      if(stackPanelNodes == null)
      {
        return;
      }
      stackPanelNodes.Children.Clear();
      stackPanelNodes.Children.Add(GetTextBlocksPanel(size));
      stackPanelNodes.Children.Add(GetTextBoxesPanel(size));
    }

    private StackPanel GetTextBlocksPanel(int size)
    {
      var stackPanel = new StackPanel()
      {
        Orientation = Orientation.Horizontal,
        HorizontalAlignment = HorizontalAlignment.Center
      };
      for (int i = 0; i <= size; i++)
      {
        TextBlock textBlock = new()
        {
          Text = $"x{i}",
          Width = 50,
          Height = 30,
          TextAlignment = TextAlignment.Center,
          Margin = new Thickness(1),
        };
        stackPanel.Children.Add(textBlock);
      }
      return stackPanel;
    }

    private StackPanel GetTextBoxesPanel(int size)
    {
      var stackPanel = new StackPanel()
      {
        Orientation = Orientation.Horizontal,
        HorizontalAlignment = HorizontalAlignment.Center
      };
      for (int i = 0; i <= size; i++)
      {
        TextBox textBox = new()
        {
          Text = "0",
          Width = 50,
          Height = 30,
          TextAlignment = TextAlignment.Center,
          Margin = new Thickness(1),
        };
        stackPanel.Children.Add(textBox);
      }
      return stackPanel;
    }

    private void buttonStart_Click(object sender, RoutedEventArgs e)
    {

      int n = Int32.Parse(textBoxN.Text);
      var nodes = new double[n+1];
      int i = 0;
      foreach (TextBox textBox in ((StackPanel) stackPanelNodes.Children[1]).Children)
      {
        nodes[i++] = double.Parse(textBox.Text);
      }
      double b = 0.15;
      double f(double x) => Math.Exp(-b * x) * Math.Sin(Math.PI * (x + Math.Pow(x, 2)));
      textBlockResult.Text = InterpolationPolynomials.ConstructPolynomial(nodes, f);
    }

    private void textBoxN_TextChanged(object sender, TextChangedEventArgs e)
    {
      try
      {
        int n = Int32.Parse(textBoxN.Text);
        if (n < 2 || n > 6)
        {
          n = 4;
          textBoxN.Text = $"{n}";
        }
        GenerateNodes(n);
        if (textBlockResult is not null)
        {
          textBlockResult.Text = "";
        }
      } catch { 
      }
      
    }
  }
}
