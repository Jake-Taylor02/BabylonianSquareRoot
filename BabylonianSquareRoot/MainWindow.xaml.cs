using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace BabylonianSquareRoot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (sender.Equals(txtInput) && e.Key == Key.Return)
            {
                txtInvalid.Visibility = Visibility.Hidden;
                
                Debug.WriteLine("text box");
                double a = 0;

                try
                {
                    a = Convert.ToDouble(txtInput.Text);
                } catch (FormatException)
                {
                    txtInvalid.Visibility = Visibility.Visible;
                    return;
                }

                enterValue(a);
                txtInput.Clear();

                return;
            }

            //if (e.Key != Key.Return) return;

            //txtInvalid.Visibility = Visibility.Hidden;

            //if (e.Key == Key.Return && dudInput.Value.HasValue)
            //{
                
                
            //    enterValue((double)dudInput.Value);
            //    dudInput.Value = 0;
            //    //txtInvalid.Visibility = Visibility.Hidden;
                
            //    //Debug.WriteLine("Visibility is: " + txtInvalid);
            //}
            //else
            //{
            //    txtInvalid.Visibility = Visibility.Visible;
            //    Debug.WriteLine("elseif ");
            //    //txtInvalid.Visibility = Visibility.Visible;
            //    dudInput.Value = null;
            //}
            
            //Debug.WriteLine("Visibility is: " + txtInvalid.Visibility);

        }

        const double MAX_ERROR = 0.001;
        const int MAX_ITERATIONS = 100;

        List<Result> results = new List<Result>();

        private void enterValue(double Y)
        {
            if (Y <= 0)
            {
                // invalid
                txtInvalid.Visibility = Visibility.Visible;
                return;
            }

            double prevGuess;
            double sqRoot = 10;

            int totalIterations = MAX_ITERATIONS;

            for (int i = 1; i <= MAX_ITERATIONS; i++) 
            {
                prevGuess = sqRoot;

                sqRoot = 0.5 * (prevGuess + Y / prevGuess);

                double AbsError = Math.Abs(Y - (sqRoot * sqRoot));

                if (AbsError <= MAX_ERROR)
                {
                    totalIterations = i;
                    break;
                }
            }

            //results.Add(new Result(value, sqRoot, totalIterations));
            Result a = new Result(Y, sqRoot, totalIterations);
            lvResults.Items.Add(a);
            lvResults.SelectedIndex = lvResults.Items.Count - 1;
            lvResults.ScrollIntoView(a);
            //txtInvalid.Visibility = Visibility.Hidden;

        }
    }

    public class Result
    {
        public double Y { get; set; }
        public double sqRoot { get; set; }
        public int iterations { get; set; }

        public Result(double y, double sqRoot, int iterations)
        {
            Y = y;
            this.sqRoot = sqRoot;
            this.iterations = iterations;
        }
    }
}
