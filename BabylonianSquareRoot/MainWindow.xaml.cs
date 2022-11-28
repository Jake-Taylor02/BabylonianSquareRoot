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
            if (e.Key == Key.Return && dudInput.Value.HasValue)
            {
                enterValue((double)dudInput.Value);
                dudInput.Value = null;
            }
        }

        const double MAX_ERROR = 0.001;
        const int MAX_ITERATIONS = 100;

        List<Result> results = new List<Result>();

        private void enterValue(double Y)
        {
            if (Y < 0)
            {
                // invalid
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
