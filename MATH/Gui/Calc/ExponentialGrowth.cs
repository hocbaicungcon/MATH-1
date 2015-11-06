using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATH.Gui.Calc {
    class ExponentialGrowth : SolveVariableForm {

        public ExponentialGrowth() {
            this.Text = "Exponential Growth";
            addInputs(new string[]{
                "Initial Amount",
                "Rate",
                "Interval",
                "Final Amount"
            });
            addOutputs(new string[]{
                "Initial Amount",
                "Rate",
                "Interval",
                "Final Amount"
            });
        }

        internal override void doCalculations() {
            // Final amount
            if (areFieldsPopulated(new string[] { "Initial Amount", "Rate", "Interval" })) {
                double finalAmount = getInput("Initial Amount") * Math.Pow(1 + getInput("Rate"), getInput("Interval"));
                setOutput("Final Amount", finalAmount);
            }
            // Interval
            if (areFieldsPopulated(new string[] { "Initial Amount", "Rate", "Final Amount" })) {
                double interval = Math.Log10(getInput("Final Amount") / getInput("Initial Amount")) / Math.Log10(1 + getInput("Rate"));
                setOutput("Interval", interval);
            }
            // Rate
            if (areFieldsPopulated(new string[] { "Initial Amount", "Interval", "Final Amount" })) {
                double rate = Math.Pow(getInput("Final Amount") / getInput("Initial Amount"), 1 / getInput("Interval")) - 1;
                setOutput("Rate", rate);
            }
            // Initial Amount
            if (areFieldsPopulated(new string[] { "Rate", "Interval", "Final Amount" })) {
                double initialAmount = getInput("Final Amount") / Math.Pow(1 + getInput("Rate"), getInput("Interval"));
                setOutput("Initial Amount", initialAmount);
            }
        }

    }
}
