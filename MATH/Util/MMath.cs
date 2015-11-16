using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATH.Util {
    public class MMath {

        /// <summary>
        /// Calculates the mean of a list
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        internal static double mean(double[] list) {
            double mean = 0;
            foreach (double d in list)
                mean += d;
            mean /= list.Length;
            return mean;
        }

        /// <summary>
        /// Calculate geometric ditribution
        /// </summary>
        /// <param name="successRate">Probability of success (p)</param>
        /// <param name="successIndex">Number where first success occurs (x)</param>
        /// <returns></returns>
        internal static double geometricDist(double successRate, double successIndex) {
            return successRate * Math.Pow(1 - successRate, successIndex - 1);
        }

        /// <summary>
        /// Calulates the standard deviation of a list
        /// </summary>
        /// <param name="list"></param>
        /// <param name="isSample">Determines if the sample formula should be used</param>
        /// <returns></returns>
        internal static double standardDeviation(double[] list, bool isSample) {
            double mean = MMath.mean(list);
            double sumOfSquares = 0;
            foreach (double d in list)
                sumOfSquares += Math.Pow(d - mean, 2);
            double deviation = Math.Sqrt(sumOfSquares / (list.Length - (isSample ? 1 : 0)));
            return deviation;
        }

        /// <summary>
        /// Calcualtes the standard deviation of a binomial (experiment) distribution
        /// </summary>
        /// <param name="n">Number of trials</param>
        /// <param name="p">Probability of success</param>
        /// <param name="q">Probability of failure</param>
        /// <returns></returns>
        internal static double biNomExStdDev(double n, double p, double q) {
            return Math.Sqrt(MMath.biNomExVariance(n, p, q));
        }

        /// <summary>
        /// Calcualtes the probability of success (x) of a binomial (experiment) distribution
        /// </summary>
        /// <param name="n">Number of trials</param>
        /// <param name="p">Probability of success</param>
        /// <param name="q">Probability of failure</param>
        /// <param name="x">Count of success</param>
        /// <returns></returns>
        internal static double biNomExProbOfOccurances(double n, double p, double q, double x) {
            return MMath.fact(n) / (MMath.fact(n - x) * MMath.fact(x)) * Math.Pow(p, x) * Math.Pow(q, n - x);
        }

        /// <summary>
        /// Solves a factorial
        /// </summary>
        /// <param name="x"></param>
        private static double fact(double x) {
            if (x <= 1)
                return 1;
            return x * fact(x - 1);
        }

        /// <summary>
        /// Calculates poisson distribution
        /// </summary>
        /// <param name="mean"></param>
        /// <param name="x">occurances</param>
        /// <returns></returns>
        internal static double poisson(double mean, double x) {
            return Math.Pow(mean, x) * Math.Pow(Math.E, -mean) / MMath.fact(x);
        }

        /// <summary>
        /// Calcualtes the variance of a binomial (experiment) distribution
        /// </summary>
        /// <param name="n">Number of trials</param>
        /// <param name="p">Probability of success</param>
        /// <param name="q">Probability of failure</param>
        /// <returns></returns>
        internal static double biNomExVariance(double n, double p, double q) {
            return n * p * q;
        }

        /// <summary>
        /// Calcualtes the mean of a binomial (experiment) distribution
        /// </summary>
        /// <param name="n">Number of trials</param>
        /// <param name="p">Probability of success</param>
        /// <returns></returns>
        internal static double biNomExMean(double n, double p) {
            return n * p;
        }

        /// <summary>
        /// Calculates the variance of a list
        /// </summary>
        /// <param name="list"></param>
        /// <param name="isSample">Determines of the list data is a sample</param>
        /// <returns></returns>
        internal static double variance(double[] list, bool isSample) {
            return Math.Pow(standardDeviation(list, isSample), 2);
        }

        /// <summary>
        /// Calculates the mean of a probability distribution
        /// </summary>
        /// <param name="xList"></param>
        /// <param name="pxList"></param>
        /// <returns></returns>
        internal static double probDistMean(double[] xList, double[] pxList) {
            double sum = 0;
            for (int i = 0; i < xList.Length; i++)
                sum += xList[i] * pxList[i];
            return sum;
        }

        /// <summary>
        /// Calculates the standard deviation of a probability distribution
        /// </summary>
        /// <param name="xList"></param>
        /// <param name="pxList"></param>
        /// <returns></returns>
        internal static double probDistStdDev(double[] xList, double[] pxList) {
            return Math.Sqrt(probDistVariance(xList, pxList));
        }

        /// <summary>
        /// Calculates the variance of a probability distribution
        /// </summary>
        /// <param name="xList"></param>
        /// <param name="pxList"></param>
        /// <returns></returns>
        internal static double probDistVariance(double[] xList, double[] pxList) {
            double sum = 0;
            double mean = probDistMean(xList, pxList);
            for (int i = 0; i < xList.Length; i++)
                sum += Math.Pow(xList[i] - mean, 2) * pxList[i];
            return sum;
        }

        internal static double variance(double[] list) {
            return variance(list, false);
        }

        internal static double standardDeviation(double[] list) {
            return standardDeviation(list, false);
        }

        /// <summary>
        /// Calculates percentile based on z-score
        /// </summary>
        /// <param name="x">z-score</param>
        /// <returns></returns>
        /// <remarks>
        /// http://www.johndcook.com/blog/csharp_phi/
        /// </remarks>
        internal static double phi(double x) {
            // constants
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;

            // Save the sign of x
            int sign = 1;
            if (x < 0)
                sign = -1;
            x = Math.Abs(x) / Math.Sqrt(2.0);

            // A&S formula 7.1.26
            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);

            return 0.5 * (1.0 + sign * y);
        }
    }
}
