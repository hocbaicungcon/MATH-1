using MATH.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATH.Gui.Calc {
    class StandardDeviation : ListInputForm {

        public StandardDeviation() {
            this.Text = "Standard Deviation";
            addOutputs(new string[] {
                "Population",
                "Sample"
            });
        }

        internal override void doCalculations() {
            // Check
            double[] list = this.getListInput();
            if (list.Length == 0)
                return;
            // Deviation
            
            setOutput("Population", MMath.standardDeviation(list));
            setOutput("Sample", MMath.standardDeviation(list, true));
        }

    }
}
