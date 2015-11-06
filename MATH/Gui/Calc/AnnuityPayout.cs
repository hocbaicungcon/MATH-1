using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATH.Gui.Calc {
    class AnnuityPayout : SolveVariableForm {

        public AnnuityPayout() {
            this.Text = "Annuity Payout";
            addInputs(new string[]{
                "Principal",
                "Deposit",
                "Rate",
                "Years",
                "Period"
            });
            addOutputs(new string[]{
                "Principal",
                "Deposit"
            });
        }

        internal override void doCalculations() {
            // Principal
            if (areFieldsPopulated(new string[] { "Deposit", "Rate", "Years", "Period" })) {
                double principal = getInput("Deposit") * (1 - Math.Pow(1 + getInput("Rate") / getInput("Period"), -getInput("Years") * getInput("Period"))) / (getInput("Rate") / getInput("Period"));
                setOutput("Principal", principal);
            }
            // Deposit
            if (areFieldsPopulated(new string[] { "Principal", "Rate", "Years", "Period" })) {
                double deposit = getInput("Principal") * (getInput("Rate") / getInput("Period")) / (1 - Math.Pow(1 + getInput("Rate") / getInput("Years"), -getInput("Years") * getInput("Period")));
                setOutput("Deposit", deposit);
            }
        }

    }
}
