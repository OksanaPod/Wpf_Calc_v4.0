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

namespace Wpf_Calc_v4._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double firstNum;
        public double secondNum;
        public string result;
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement el in ButtonGrid.Children)
            {
                Button buttn = (Button)el;
                buttn.Click += Button_Click;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string add = btn.Content.ToString();
            if (add == "+" || add == "-" || add == "/" || add == "*")
            {
                if (Result.Text.Contains("+") || Result.Text.Contains("-") || Result.Text.Contains("/") || Result.Text.Contains("*"))
                {
                    if (Result.Text.StartsWith("-"))
                    {
                        StartCalculate();
                        ChechNegative();
                        Result.Text += add;
                    }
                    else
                    {
                        Calculate1();
                        StartCalculate();
                        Result.Text += add;
                    }
                }
                else
                {
                    StartCalculate();
                    Result.Text += add;
                }
            }
            else if (add == "=")
            {
                Calculate1();
            }
            else if (add == "C")
            {
                Result.Text = null;
            }
            else if (add == "√x")
            {
                try
                {
                    if (Result.Text.Contains("+") || Result.Text.Contains("-") || Result.Text.Contains("/") || Result.Text.Contains("*"))
                    {
                        Calculate1();
                        Result.Text = Math.Sqrt(Convert.ToDouble(Result.Text)).ToString();
                    }
                    else
                    {
                        StartCalculate();
                        Result.Text = Math.Sqrt(firstNum).ToString();
                    }
                }
                catch
                { Result.Text = null; }
            }
            else if (add == "x²")
            {
                try
                {
                    if (Result.Text.Contains("+") || Result.Text.Contains("-") || Result.Text.Contains("/") || Result.Text.Contains("*"))
                    {
                        Calculate1();
                        Result.Text = Math.Pow(Convert.ToDouble(Result.Text), 2).ToString();
                    }
                    else
                    {
                        StartCalculate();
                        Result.Text = Math.Pow(firstNum, 2).ToString();
                    }
                }
                catch
                { Result.Text = null; }
            }
            else if (add == "⇐")
            {
                if (Result.Text.Length != 0)
                {
                    Result.Text = Result.Text.Remove(Result.Text.Length - 1);
                }
            }
            else if (add == "%")
            {
                if (Result.Text == string.Empty)
                {
                    Result.Text = null;
                }
                else
                {
                    ChechNegative();
                    if (Result.Text.Contains("+") || Result.Text.Contains("-") || Result.Text.Contains("/") || Result.Text.Contains("*"))
                    {
                        int count = (firstNum.ToString()).Length;
                        secondNum = firstNum / 100 * Convert.ToDouble((Result.Text.Remove(0, count + 1)));
                        Calculate2();
                    }
                    else
                    {
                        Result.Text = null;
                    }
                }
            }
            else
            {
                Result.Text += add;
            }
        }

        private void StartCalculate()
        {
            try
            {
                if (Result.Text == string.Empty)
                {
                    firstNum = 0;
                }
                else
                {
                    firstNum = Convert.ToDouble(Result.Text);
                }
            }
            catch (Exception)
            {
                Result.Text = null;
            }
        }

        private void Calculate1()
        {
            try
            {
                if (Result.Text.Contains("+"))
                {
                    string calculate = Result.Text.Remove(0, Result.Text.IndexOf("+") + 1);
                    secondNum = Convert.ToDouble(calculate);
                    Result.Text = (firstNum + secondNum).ToString();
                }
                else if (Result.Text.Contains("-"))
                {
                    ChechNegative();
                    string calculate = Result.Text.Remove(0, Result.Text.IndexOf("-") + 1);
                    secondNum = Convert.ToDouble(calculate);
                    Result.Text = (firstNum - secondNum).ToString();

                }
                else if (Result.Text.Contains("/"))
                {
                    string calculate = Result.Text.Remove(0, Result.Text.IndexOf("/") + 1);
                    secondNum = Convert.ToDouble(calculate);
                    Result.Text = (firstNum / secondNum).ToString();
                }
                else if (Result.Text.Contains("*"))
                {
                    string calculate = Result.Text.Remove(0, Result.Text.IndexOf("*") + 1);
                    secondNum = Convert.ToDouble(calculate);
                    Result.Text = (firstNum * secondNum).ToString();
                }
            }
            catch
            {
                Result.Text = null;
            }
        }

        private void Calculate2()
        {
            if (Result.Text.Contains("+"))
            {
                Result.Text = (firstNum + secondNum).ToString();
            }
            else if (Result.Text.Contains("-"))
            {
                Result.Text = (firstNum - secondNum).ToString();

            }
            else if (Result.Text.Contains("/"))
            {
                Result.Text = (firstNum / secondNum).ToString();
            }
            else if (Result.Text.Contains("*"))
            {
                Result.Text = (firstNum * secondNum).ToString();
            }
        }
        private void ChechNegative()
        {
            if (Result.Text.StartsWith("-"))
            {
                Result.Text = Result.Text.Remove(0, Result.Text.IndexOf("-") + 1);
            }
        }
    }
}
