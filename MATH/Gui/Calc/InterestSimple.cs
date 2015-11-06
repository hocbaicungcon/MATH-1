using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATH.Gui.Calc {
    class InterestSimple : SolveVariableForm {

        public InterestSimple() {
            this.Text = "Simple Interest";
            addInputs(new string[]{
                "Principal",
                "Rate",
                "Interest",
                "Time",
                "Final Amount"
            });
            addOutputs(new string[]{
                "Principal",
                "Rate",
                "Interest",
                "Time",
                "Final Amount"
            });
        }

        internal override void doCalculations() {
            // Final amount
            if (areFieldsPopulated(new string[] { "Principal", "Rate", "Time" })) {
                double finalAmount = getInput("Principal") * (1 + getInput("Rate") * getInput("Time"));
                setOutput("Final Amount", finalAmount);
            }
            // Time
            if (areFieldsPopulated(new string[] { "Principal", "Rate", "Interest" })) {
                double time = getInput("Interest") / (getInput("Principal") * getInput("Rate"));
                setOutput("Time", time);
            }
            // Interest
            if (areFieldsPopulated(new string[] { "Principal", "Rate", "Time" })) {
                double interest = getInput("Principal") * getInput("Rate") * getInput("Time");
                setOutput("Interest", interest);
            }
            // Rate
            if (areFieldsPopulated(new string[] { "Principal", "Interest", "Time" })) {
                double rate = getInput("Interest") / (getInput("Principal") * getInput("Time"));
                setOutput("Rate", rate);
            }
            // Principal
            if (areFieldsPopulated(new string[] { "Rate", "Interest", "Time" })) {
                double principal = getInput("Interest") / (getInput("Rate") * getInput("Time"));
                setOutput("Principal", principal);
            }
        }

    }
}
