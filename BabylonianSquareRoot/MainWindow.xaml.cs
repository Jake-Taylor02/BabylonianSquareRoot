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
    /// 
    /// Square root by the Babylonian method 
    /// 
    /// Jake Taylor
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     When the Return key is pressed and the input is valid, the square root
        ///     is calculated and diplayed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (sender.Equals(txtInput) && e.Key == Key.Return)
            {
                txtInvalid.Visibility = Visibility.Hidden;
                
                double Y = 0;

                try // try to parse into double, if exception occurs,
                {   // input must be invalid
                    Y = Convert.ToDouble(txtInput.Text);
                } catch (FormatException)
                {// Input is invalid, Reject
                    txtInvalid.Visibility = Visibility.Visible;
                    txtInput.Clear();
                    return;
                }

                var sqR = BabylonSquareRoot.getSquareRoot(Y);
                if (sqR == null)
                {
                    // Input is invalid, Reject
                    txtInvalid.Visibility = Visibility.Visible;
                }
                else
                {
                    if (sqR.isCorrect)
                    {
                        lvResults.Items.Add(sqR);
                    } else
                    {
                        lvResults.Items.Add(new { sqR.Y, sqR.sqRoot, iterations = sqR.iterations.ToString() + " (Incorrect)" });
                    }

                    // Highlight the most recent entry and make sure its in view
                    lvResults.SelectedIndex = lvResults.Items.Count - 1;
                    lvResults.ScrollIntoView(lvResults.SelectedItem);
                }

                txtInput.Clear();
            }
        }

    }

}
