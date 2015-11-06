using MATH.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATH.Gui.Calc {
    class NormalDistribution : ListInputForm {

        public NormalDistribution() {
            this.Text = "Normal Distribution";
            setListPlaceHolderText("List is optinal if using mean and deviation.");
            unfocusList(true);
            addInputs(new string[] {
                "Mean",
                "Deviation",
                "Below",
                "Above"
            });
            addOutputs(new string[] {
                "Z-Score Low",
                "Z-Score High",
                "Percent"
            });
        }

        internal override void doCalculations() {
            double[] list = this.getListInput();
            if (!areFieldsPopulated(new string[] { "Below" }) && !areFieldsPopulated(new string[] { "Above" }))
                return;
            double mean;
            double deviation;
            if (areFieldsPopulated(new string[] { "Mean", "Deviation" })) {
                mean = getInput("Mean");
                deviation = getInput("Deviation");
            } else if (list.Length > 0) {
                mean = MMath.mean(list);
                deviation = MMath.standardDeviation(list);
            } else {
                return;
            }
            double[] zScore = new double[2]; // low high
            zScore[0] = areFieldsPopulated(new string[] { "Above" }) ? (getInput("Above") - mean) / deviation : double.NaN;
            zScore[1] = areFieldsPopulated(new string[] { "Below" }) ? (getInput("Below") - mean) / deviation : double.NaN;
            // output
            setOutput("Z-Score Low", zScore[0]);
            setOutput("Z-Score High", zScore[1]);
            double percent = double.NaN;
            if (double.IsNaN(zScore[0])) {
                percent = MMath.phi(Math.Abs(zScore[1]));
            } else if (double.IsNaN(zScore[1])) {
                percent = MMath.phi(Math.Abs(zScore[0]));
            } else {
                percent = MMath.phi(zScore[1]) - MMath.phi(zScore[0]);
            }
            setOutput("Percent", percent);
        }

    }
}
