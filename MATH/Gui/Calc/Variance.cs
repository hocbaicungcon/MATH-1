using MATH.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATH.Gui.Calc {
    class Variance : ListInputForm {
        public Variance() {
            this.Text = "Variance";
            addOutputs(new string[] {
                "Population",
                "Sample"
            });
        }

        internal override void doCalculations() {
            double[] list = this.getListInput();
            if (list.Length == 0)
                return;
            setOutput("Population", MMath.variance(list));
            setOutput("Sample", MMath.variance(list, true));
        }
    }
}
