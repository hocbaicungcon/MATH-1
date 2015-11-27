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
            this.addInputs(
                "Mean",
                "Standard Deviation",
                "Z-Score"
            );
            this.addOutputs(new string[] {
                "Mean",
                "Variance",
                "Standard Deviation",
                "Z-Score",
                "P(x)"
            });
            this.setListPlaceHolderText("x");
            this.setListPlaceHolderText("P(x)", "P(x)");
        }

        internal override void doCalculations() {
            double[] xList = getListInput();
            double[] pxList = getListInput("P(x)");
            if (xList.Length == 0 || pxList.Length == 0 || xList.Length != pxList.Length)
                if (!areFieldsPopulated("Mean", "Standard Deviation"))
                    return;
            double mean = isFieldPopulated("Mean") ? getInput("Mean") : MMath.probDistMean(xList, pxList);
            double standardDeviation = isFieldPopulated("Standard Deviation") ? getInput("Standard Deviation") : MMath.probDistStdDev(xList, pxList);
            setOutput("Mean", mean);
            setOutput("Variance", MMath.probDistVariance(xList, pxList));
            setOutput("Standard Deviation", standardDeviation);
            if(pxList.Length == 1)
                setOutput("Z-Score", (pxList.First() - mean) / standardDeviation);
            if (isFieldPopulated("Z-Score"))
                setOutput("P(x)", mean + getInput("Z-Score") * standardDeviation);
        }

    }
}
