using MATH.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATH.Gui.Calc {
    class CentralTendency : ListInputForm {

        public CentralTendency() {
            this.Text = "Measures of Central Tendency";
            addOutputs(new string[] {
                "List (Low-High)",
                "List (High-Low)",
                "High",
                "Low",
                "Mean",
                "Median",
                "Mode",
                "1st Quartile",
                "2nd Quartile",
                "3rd Quartile"
            });
        }

        internal override void doCalculations() {
            // List checks
            double[] list = getListInput();
            if (list.Length == 0)
                return;
            // List Low-High
            string lowHigh = "";
            foreach (double d in list.OrderBy(c => c))
                lowHigh += d + ",";
            setOutput("List (Low-High)", lowHigh.TrimEnd(','));
            // List High-Low
            string highLow = "";
            foreach (double d in list.OrderByDescending(c => c))
                highLow += d + ",";
            setOutput("List (High-Low)", highLow.TrimEnd(','));
            // High
            setOutput("High", list.OrderByDescending(c => c).First());
            // Low
            setOutput("Low", list.OrderBy(c => c).First());
            // Mean
            setOutput("Mean", MMath.mean(list));
            // Median
            double median = calculateMedian(list.OrderBy(c => c).ToArray());
            setOutput("Median", median);
            // Mode
            IEnumerable<IGrouping<double, double>> freq = list.OrderBy(c => c).GroupBy(c => c);
            int highCount = 0;
            foreach (IGrouping<double, double> entry in freq) {
                if (entry.Count() > highCount)
                    highCount = entry.Count();
            }
            List<double> mode = new List<double>();
            foreach (IGrouping<double, double> entry in freq) {
                if (entry.Count() == highCount)
                    mode.Add(entry.Key);
            }
            string modeString = "";
            foreach (double d in mode)
                modeString += d + ",";
            setOutput("Mode", modeString.TrimEnd(','));
            // Amount check
            if (list.Length == 1)
                return;
            // 1st Quartile
            double[] listFirstHalf = list.OrderBy(c => c).ToList().GetRange(0, list.Length % 2  == 0 ? list.Length / 2 : (list.Length - 1) / 2).ToArray();
            setOutput("1st Quartile", calculateMedian(listFirstHalf));
            // 2nd Quartile
            setOutput("2nd Quartile", median);
            // 3rd Quartile
            double[] listSecondHalf = list.OrderBy(c => c).ToList().GetRange(list.Length % 2 == 0 ? listFirstHalf.Length : listFirstHalf.Length + 1, listFirstHalf.Length).ToArray();
            setOutput("3rd Quartile", calculateMedian(listSecondHalf));
        }

        private double calculateMedian(double[] list) {
            double median;
            if (list.Length % 2 == 0) {
                int index = list.Length / 2;
                median = (list.OrderBy(c => c).ToArray()[index - 1] + list.OrderBy(c => c).ToArray()[index]) / 2;
            } else {
                median = list[(list.Length - 1) / 2];
            }
            return median;
        }
        
    }
}
