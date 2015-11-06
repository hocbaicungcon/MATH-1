using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATH.Gui.Calc {
    class InterestCompound : SolveVariableForm {

        public InterestCompound() {
            this.Text = "Compound Interest";
            addInputs(new string[]{
                "Principal",
                "Rate",
                "Years",
                "Period",
                "Final Amount"
            });
            addOutputs(new string[]{
                "Principal",
                "Rate",
                "Years",
                "Interest",
                "Final Amount"
            });
        }

        internal override void doCalculations() {
            // Final amount
            if (areFieldsPopulated(new string[] { "Principal", "Rate", "Years", "Period" })) {
                double finalAmount = getInput("Principal") * Math.Pow(1 + getInput("Rate") / getInput("Period"), getInput("Years") * getInput("Period"));
                double interest = finalAmount - getInput("Principal");
                setOutput("Final Amount", finalAmount);
                setOutput("Interest", interest);
            }
            // Period TODO
            // Rate
            if (areFieldsPopulated(new string[] { "Principal", "Years", "Period", "Final Amount" })) {
                double rate = (Math.Pow(getInput("Final Amount") / getInput("Principal"), 1 / (getInput("Years") * getInput("Period"))) - 1) * getInput("Period");
                double interest = getInput("Final Amount") - getInput("Principal");
                setOutput("Rate", rate);
                setOutput("Interest", interest);
            }
            // Years
            if (areFieldsPopulated(new string[] { "Principal", "Rate", "Period", "Final Amount" })) {
                double years = Math.Log10(getInput("Final Amount") / getInput("Principal")) / Math.Log10(1 + getInput("Rate") / getInput("Period")) / getInput("Period");
                setOutput("Years", years);
                setOutput("Interest", getInput("Final Amount") - getInput("Principal"));
            }
            // Principal
            if (areFieldsPopulated(new string[] { "Rate", "Years", "Period", "Final Amount" })) {
                double principal = getInput("Final Amount") / Math.Pow(1 + getInput("Rate") / getInput("Period"), getInput("Years") * getInput("Period"));
                double interest = getInput("Final Amount") - principal;
                setOutput("Principal", principal);
                setOutput("Interest", interest);
            }
        }

    }
}
