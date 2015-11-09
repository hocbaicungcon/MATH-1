using MATH.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATH.Gui.Calc {
    class ProbabilityDistribution : ListInputForm {

        public ProbabilityDistribution() {
            this.Text = "Probability Distribution";
            this.addListInput("P(x)");
            this.setListPlaceHolderText("x");
            this.setListPlaceHolderText("P(x)", "P(x)");
            this.addOutputs(new string[] {
                "Mean",
                "Variance",
                "Standard Deviation"
            });
        }

        internal override void doCalculations() {
            double[] xList = getListInput();
            double[] pxList = getListInput("P(x)");
            if (xList.Length == 0 || pxList.Length == 0 || xList.Length != pxList.Length)
                return;
            setOutput("Mean", MMath.probDistMean(xList, pxList));
            setOutput("Variance", MMath.probDistVariance(xList, pxList));
            setOutput("Standard Deviation", MMath.probDistStdDev(xList, pxList));
        }

    }
}
