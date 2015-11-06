using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MATH.Gui {
    public partial class SolveVariableForm : Form {

        private List<TextBox> inputs = new List<TextBox>();
        private List<TextBox> outputs = new List<TextBox>();

        internal SolveVariableForm() {
            InitializeComponent();
            panel.AutoScroll = false;
            panel.HorizontalScroll.Enabled = false;
            panel.AutoScroll = true;
        }

        internal void addInputs(string[] inputs) {
            foreach (string input in inputs) {
                Label label = new Label();
                label.Text = input;
                label.Padding = new Padding(0, 5, 0, 0);
                new ToolTip().SetToolTip(label, input);
                TextBox textBox = new TextBox();
                textBox.Name = input;
                textBox.TextChanged += textChanged;
                this.panel.Controls.Add(label);
                this.panel.Controls.Add(textBox);
                this.inputs.Add(textBox);
            }
        }

        private void textChanged(object sender, EventArgs e) {
            clearOutputs();
            doCalculations();
        }

        private void clearOutputs() {
            foreach (TextBox output in outputs)
                output.Clear();
        }

        internal virtual void doCalculations() {
            throw new NotImplementedException();
        }

        internal bool areFieldsPopulated(string[] names) {
            foreach (string name in names) {
                double x;
                if (!Double.TryParse(inputs.Find(byName(name)).Text, out x))
                    return false;
            }
            return true;
        }

        internal void setOutput(string name, string value) {
            outputs.Find(byName(name)).Text = value;
        }

        internal void setOutput(string name, double value) {
            setOutput(name, value.ToString());
        }

        internal double getInput(string name) {
            return Double.Parse(inputs.Find(byName(name)).Text);
        }

        internal string getInputString(string name) {
            return inputs.Find(byName(name)).Text;
        }

        private Predicate<TextBox> byName(string text) {
            return delegate(TextBox textBox) {
                return textBox.Name.Equals(text);
            };
        }

        internal void addOutputs(string[] outputs) {
            foreach (string output in outputs) {
                Label label = new Label();
                label.Text = output;
                label.Padding = new Padding(0, 5, 0, 0);
                new ToolTip().SetToolTip(label, output);
                TextBox textBox = new TextBox();
                textBox.ReadOnly = true;
                textBox.BorderStyle = BorderStyle.None;
                textBox.Margin = new Padding(0, 6, 0, 0);
                textBox.Name = output;
                this.panel.Controls.Add(label);
                this.panel.Controls.Add(textBox);
                this.outputs.Add(textBox);
            }
        }

        internal FlowLayoutPanel getPanel() {
            return this.panel;
        }

        internal void addTextChangeEvent(Control control) {
            control.TextChanged += textChanged;
        }

        internal List<TextBox> getInputControls() {
            return inputs;
        }
    }
}
