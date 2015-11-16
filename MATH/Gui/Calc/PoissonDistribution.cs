using MATH.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATH.Gui.Calc {
    class PoissonDistribution : SolveVariableForm {

        public PoissonDistribution() {
            this.Text = "Poisson Distribution";
            addInputs(
                "Mean",
                "x",
                ">",
                "<"
            );
            addOutputs("Poisson");
        }

        internal override void doCalculations() {
            if (!areFieldsPopulated("Mean"))
                return;
            double probability = 0;
            if (areFieldsPopulated(">", "<")) {
                for (double i = getInput(">") + 1; i < getInput("<"); i++)
                    probability += MMath.poisson(getInput("Mean"), i);
            } else if (isFieldPopulated(">")) {
                for (double i = getInput(">") + 1; i < 100; i++)
                    probability += MMath.poisson(getInput("Mean"), i);
            } else if (isFieldPopulated("<")) {
                for (double i = 0; i < getInput("<"); i++)
                    probability += MMath.poisson(getInput("Mean"), i);
            } else if (isFieldPopulated("x")) {
                probability = MMath.poisson(getInput("Mean"), getInput("x"));
            }
            setOutput("Poisson", probability);
        }

    }
}
