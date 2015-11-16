using MATH.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATH.Gui.Calc {
    class BinomialDistribution : SolveVariableForm {

        public BinomialDistribution() {
            this.Text = "Bionomial Distribution";
            addInputs(new string[] {
                "n (number of trials)",
                "p (success probability)",
                "q (failure probability)",
                "x (success count)",
                ">",
                "<"
            });
            addOutputs(new string[] {
                "P(x)",
                "Mean",
                "Variance",
                "Standard Deviation"
            });
        }

        internal override void doCalculations() {
            if ((!areFieldsPopulated(new string[] { "n (number of trials)" })) || !(areFieldsPopulated(new string[] { "p (success probability)" }) || areFieldsPopulated(new string[] { "q (failure probability)" })))
                return;
            double n = getInput("n (number of trials)");
            double p = areFieldsPopulated(new string[] { "p (success probability)" }) ? getInput("p (success probability)") : 1 - getInput("q (failure probability)");
            double q = areFieldsPopulated(new string[] { "q (failure probability)" }) ? getInput("q (failure probability)") : 1 - p;
            setOutput("Mean", MMath.biNomExMean(n, p));
            setOutput("Variance", MMath.biNomExVariance(n, p, q));
            setOutput("Standard Deviation", MMath.biNomExStdDev(n, p, q));
            if (!(isFieldPopulated("x (success count)") || isFieldPopulated("<") || isFieldPopulated(">")))
                return;
            double probability = 0;
            if (areFieldsPopulated(">", "<")) {
                for (double i = getInput(">") + 1; i < getInput("<"); i++)
                    probability += MMath.biNomExProbOfOccurances(n, p, q, i);
            } else if (isFieldPopulated(">")) {
                for (double i = getInput(">") + 1; i < n; i++)
                    probability += MMath.biNomExProbOfOccurances(n, p, q, i);
            } else if (isFieldPopulated("<")) {
                for (double i = 0; i < getInput("<"); i++)
                    probability += MMath.biNomExProbOfOccurances(n, p, q, i);
            } else if (isFieldPopulated("x (success count)")) {
                probability = MMath.biNomExProbOfOccurances(n, p, q, getInput("x (success count)"));
            }
            setOutput("P(x)", probability);
        }

    }
}
