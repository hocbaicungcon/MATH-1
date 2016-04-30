using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATH.Gui.Calc {
    class RoofFrameLeg : SolveVariableForm {
        public RoofFrameLeg() {
            this.Text = "Roof Frame Leg Size";
            addInputs(
                "Short Leg",
                "Frame",
                "Roof Degrees"
            );
            addOutputs("Long Leg");
        }

        internal override void doCalculations() {
            // Long leg
            if (areFieldsPopulated("Short Leg", "Frame", "Roof Degrees")) {
                double shortLeg = getInput("Short Leg");
                double frame = getInput("Frame");
                double degrees = getInput("Roof Degrees");
                if (degrees >= 1)
                    degrees /= 100;
                double longLeg = -degrees * frame - shortLeg;
                setOutput("Long Leg", Math.Abs(longLeg));
            }
        }
    }
}
