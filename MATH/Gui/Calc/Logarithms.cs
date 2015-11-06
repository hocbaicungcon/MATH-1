using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATH.Gui.Calc {
    class Logarithms : SolveVariableForm {

        public Logarithms() {
            this.Text = "Logarithms";
            addInputs(new string[]{
                "Exponentless Side",
                "Base",
                "Exponent"
            });
            addOutputs(new string[]{
                "Exponentless Side",
                "Base",
                "Exponent"
            });
        }

        internal override void doCalculations() {
            // Exponent
            if (areFieldsPopulated(new string[] { "Exponentless Side", "Base" })) {
                double exponent = Math.Log10(getInput("Exponentless Side")) / Math.Log10(getInput("Base"));
                setOutput("Exponent", exponent);
            }
            // Base
            if (areFieldsPopulated(new string[] { "Exponentless Side", "Exponent" })) {
                double baseValue = Math.Pow(getInput("Exponentless Side"), 1D / getInput("Exponent"));
                setOutput("Base", baseValue);
            }
            // Exponentless Side
            if (areFieldsPopulated(new string[] { "Base", "Exponent" })) {
                double exponentlessSide = Math.Pow(getInput("Base"), getInput("Exponent"));
                setOutput("Exponentless Side", exponentlessSide);
            }
        }

    }
}
