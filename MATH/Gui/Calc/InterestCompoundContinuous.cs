using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATH.Gui.Calc {
    class InterestCompoundContinuous : SolveVariableForm {

        public InterestCompoundContinuous() {
            this.Text = "Continuous Compound Interest";
            addInputs(new string[]{
                "Principal",
                "Rate",
                "Years",
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
            if (areFieldsPopulated(new string[] { "Principal", "Rate", "Years" })) {
                double finalAmount = getInput("Principal") * Math.Exp(getInput("Rate") * getInput("Years"));
                setOutput("Final Amount", finalAmount);
                setOutput("Interest", finalAmount - getInput("Principal"));
            }
            // Years
            if (areFieldsPopulated(new string[] { "Principal", "Rate", "Final Amount" })) {
                double years = Math.Log10(getInput("Final Amount") / getInput("Principal")) / (Math.Log10(Math.Exp(1)) * getInput("Rate"));
                setOutput("Years", years);
            }
            // Rate
            if (areFieldsPopulated(new string[] { "Principal", "Years", "Final Amount" })) {
                double rate = Math.Log10(getInput("Final Amount") / getInput("Principal")) / Math.Log10(Math.Exp(1)) * getInput("Years");
                setOutput("Rate", rate);
            }
            // Principal
            if (areFieldsPopulated(new string[] { "Rate", "Years", "Final Amount" })) {
                double principal = getInput("Final Amount") / Math.Exp(getInput("Rate") * getInput("Years"));
                setOutput("Principal", principal);
            }
        }

    }
}
