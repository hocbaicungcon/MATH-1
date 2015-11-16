using MATH.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATH.Gui.Calc {
    class GeometricDistribution : SolveVariableForm {
        public GeometricDistribution() {
            this.Text = "Geometric Distribution";
            addInputs(
                "p (success probability)",
                "x (success index)"
            );
            addOutputs("Geometric");
        }

        internal override void doCalculations() {
            if (!areFieldsPopulated("p (success probability)"))
                return;
            double probability = 0;
            if (areFieldsPopulated(">", "<")) {
                for (double i = getInput(">") + 1; i < getInput("<"); i++)
                    probability += MMath.geometricDist(getInput("p (success probability)"), i);
            } else if (isFieldPopulated(">")) {
                for (double i = getInput(">") + 1; i < 100; i++)
                    probability += MMath.geometricDist(getInput("p (success probability)"), i);
            } else if (isFieldPopulated("<")) {
                for (double i = 0; i < getInput("<"); i++)
                    probability += MMath.geometricDist(getInput("p (success probability)"), i);
            } else if (isFieldPopulated("x (success index)")) {
                probability = MMath.geometricDist(getInput("p (success probability)"), getInput("x (success index)"));
            }
            setOutput("Geometric", probability);
        }
    }
}
