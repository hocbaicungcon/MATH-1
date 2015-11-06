using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATH.Gui.Calc {
    class LinearGrowth : SolveVariableForm {

        public LinearGrowth() {
            this.Text = "Linear Growth";
            addInputs(new string[]{
                "Initial Population",
                "Common Difference",
                "Interval",
                "Final Population"
            });
            addOutputs(new string[]{
                "Initial Population",
                "Common Difference",
                "Interval",
                "Final Population"
            });
        }

        internal override void doCalculations() {
            // Final population
            if (areFieldsPopulated(new string[] { "Initial Population", "Common Difference", "Interval" })) {
                double finalpopulation = getInput("Initial Population") + getInput("Common Difference") * getInput("Interval");
                setOutput("Final Population", finalpopulation);
            }
            // Interval
            if (areFieldsPopulated(new string[] { "Initial Population", "Common Difference", "Final Population" })) {
                double interval = (getInput("Final Population") - getInput("Initial Population")) / getInput("Common Difference");
                setOutput("Interval", interval);
            }
            // Common Difference
            if (areFieldsPopulated(new string[] { "Initial Population", "Interval", "Final Population" })) {
                double difference = getInput("Final Population") - getInput("Initial Population") * getInput("Interval");
                setOutput("Common Difference", difference);
            }
            // Initial population
            if (areFieldsPopulated(new string[] { "Common Difference", "Interval", "Final Population" })) {
                double population = getInput("Final Population") - getInput("Common Difference") * getInput("Interval");
                setOutput("Initial Population", population);
            }
        }
    }
}
