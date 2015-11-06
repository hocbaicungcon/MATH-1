using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MATH.Gui {
    class ListInputForm : SolveVariableForm {
        private string listPlaceHolder;
        private TextBox listTextBox;
        private bool doInitialUnfocus;

        internal ListInputForm() {
            addTextBoxInput();
        }

        private void addTextBoxInput() {
            listTextBox = new TextBox();
            listTextBox.Width = 210;
            listTextBox.Name = "ListInputForm_ListInput";
            addTextChangeEvent(listTextBox);
            listTextBox.GotFocus += listFocused;
            listTextBox.LostFocus += listUnfocused;
            getPanel().Controls.Add(listTextBox);
            getInputControls().Add(listTextBox);
        }

        private void listUnfocused(object sender, EventArgs e) {
            if (listTextBox.Text.Equals(""))
                listTextBox.Text = listPlaceHolder;
        }

        private void listFocused(object sender, EventArgs e) {
            if (listTextBox.Text.Equals(listPlaceHolder))
                listTextBox.Text = "";
            if (doInitialUnfocus)
                unfocusList();
        }

        internal double[] getListInput() {
            string[] stringArray = getInputString("ListInputForm_ListInput").Split(',');
            List<double> doubleList = new List<double>();
            foreach (string s in stringArray) {
                double parsed;
                if (Double.TryParse(s, out parsed))
                    doubleList.Add(parsed);
                else
                    return new double[] {};
            }
            return doubleList.ToArray();
        }

        private void cleanData(TextBox textBox) {
            textBox.Text = textBox.Text.Replace("\n", ",").Replace(" ", ",").Replace(",,", ",").TrimEnd(',');
        }

        internal void setListPlaceHolderText(string text) {
            this.listPlaceHolder = text;
        }

        internal void unfocusList(bool initial) {
            doInitialUnfocus = initial;
            this.SelectNextControl(listTextBox, true, true, true, false);
        }

        private void unfocusList() {
            unfocusList(false);
        }

    }
}
