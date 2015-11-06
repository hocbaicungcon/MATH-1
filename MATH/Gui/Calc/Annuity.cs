using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATH.Gui.Calc {
    class Annuity : SolveVariableForm {

        public Annuity() {
            this.Text = "Annuity";
            addInputs(new string[]{
                "Deposit",
                "Rate",
                "Years",
                "Period",
                "Final Amount"
            });
            addOutputs(new string[]{
                "Deposit",
                "Years",
                "Final Amount"
            });
        }

        internal override void doCalculations() {
            // Final amount
            if (areFieldsPopulated(new string[] { "Deposit", "Rate", "Years", "Period" })) {
                double finalAmount = getInput("Deposit") * (Math.Pow(1 + getInput("Rate") / getInput("Period"), getInput("Years") * getInput("Period")) - 1) / (getInput("Rate") / getInput("Period"));
                setOutput("Final Amount", finalAmount);
            }
            // Years
            if (areFieldsPopulated(new string[] { "Deposit", "Rate", "Period", "Final Amount" })) {
                double years = Math.Log10(getInput("Final Amount") * (getInput("Rate") / getInput("Period")) / getInput("Deposit") + 1) / (Math.Log10(1 + getInput("Rate") / getInput("Period")) * getInput("Period"));
                setOutput("Years", years);
            }
            // Deposit
            if (areFieldsPopulated(new string[] { "Rate", "Years", "Period", "Final Amount" })) {
                double deposit = getInput("Final Amount") * (getInput("Rate") / getInput("Period")) / (Math.Pow(1 + (getInput("Rate") / getInput("Period")), getInput("Years") * getInput("Period")) - 1);
                setOutput("Deposit", deposit);
            }
        }

    }
}
