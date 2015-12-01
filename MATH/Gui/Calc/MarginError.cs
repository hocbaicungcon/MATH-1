using MATH.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATH.Gui.Calc {
    class MarginError : SolveVariableForm {
        public MarginError() {
            this.Text = "Margin of Error";
            this.addInputs(
                "Confidence",
                "Standard Deviation",
                "n",
                "Error Margin"
            );
            this.addOutputs(
                "Error Margin",
                "n"
            );
        }

        internal override void doCalculations() {
            if (areFieldsPopulated("Confidence", "Standard Deviation", "Error Margin"))
                setOutput("n", Math.Pow(MMath.probabilityToZ((1 - getInput("Confidence")) / 2) * getInput("Standard Deviation") / getInput("Error Margin"), 2));
            if (areFieldsPopulated("Confidence", "Standard Deviation", "n"))
                setOutput("Error Margin", MMath.errorMargin(getInput("Confidence"), getInput("Standard Deviation"), getInput("n")));
        }
    }
}
