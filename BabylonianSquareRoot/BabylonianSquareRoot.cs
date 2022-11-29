using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabylonianSquareRoot
{
    public class BabylonianSquareRoot
    {
        public double Y { get; }
        public double sqRoot { get; private set; }
        public int iterations { get; private set; }

        //The Square root is correct if it is within the MAX_ERROR
        public bool isCorrect { get; private set; }

        public const double MAX_ERROR = 0.001;
        public const int MAX_ITERATIONS = 100;

        
        private BabylonianSquareRoot(double Y)
        {
            this.Y = Y;
            isCorrect = false;
            calculate();
        }

        /// <summary>
        ///     Using Y, attempt to calculate the square root
        /// </summary>
        private void calculate()
        {
            double prevGuess;
            sqRoot = 10;

            iterations = MAX_ITERATIONS;

            for (int i = 1; i <= MAX_ITERATIONS; i++)
            {
                prevGuess = sqRoot;

                sqRoot = 0.5 * (prevGuess + Y / prevGuess);

                double AbsError = Math.Abs(Y - (sqRoot * sqRoot));

                if (AbsError <= MAX_ERROR)
                {
                    iterations = i;
                    isCorrect = true;
                    break;
                }
            }
        }

        /// <summary>
        ///     Validate Y before calling the constructor
        ///     A null return indicates an invalid parameter
        /// </summary>
        /// <param name="Y"></param>
        /// <returns>
        ///     BabylonianSquareRoot containing the approximate square root.
        /// </returns>
        public static BabylonianSquareRoot? getSquareRoot(double Y)
        {
            if (Y <= 0) return null;

            return new BabylonianSquareRoot(Y);
        }
    }
}
