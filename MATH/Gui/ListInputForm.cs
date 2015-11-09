using MATH.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MATH.Gui {
    class ListInputForm : SolveVariableForm {
        private List<TextBox> lists = new List<TextBox>();
        private bool doInitialUnfocus;
        private readonly string TEXTBOX_PREFIX = "ListInputForm_";
        private readonly string DEFAULT_TEXTBOX_NAME = "ListInput";

        internal ListInputForm() {
            addTextBoxInput();
        }

        private void addTextBoxInput() {
            addTextBoxInput(DEFAULT_TEXTBOX_NAME);
        }

        private void addTextBoxInput(string name) {
            TextBox listTextBox = new TextBox();
            listTextBox.Width = 210;
            listTextBox.Name = TEXTBOX_PREFIX + name;
            listTextBox.Tag = "";
            addTextChangeEvent(listTextBox);
            listTextBox.GotFocus += listFocused;
            listTextBox.LostFocus += listUnfocused;
            getPanel().Controls.Add(listTextBox);
            getInputControls().Add(listTextBox);
            lists.Add(listTextBox);
        }

        internal void addListInput(string name) {
            addTextBoxInput(name);
        }

        private void listUnfocused(object sender, EventArgs e) {
            if ((sender as TextBox).Text.Equals(""))
                (sender as TextBox).Text = (sender as TextBox).Tag.ToString();
        }

        private void listFocused(object sender, EventArgs e) {
            if ((sender as TextBox).Text.Equals((sender as TextBox).Tag.ToString()))
                (sender as TextBox).Text = "";
            if (doInitialUnfocus)
                unfocusList();
        }

        internal double[] getListInput(string name) {
            string[] stringArray = getInputString(TEXTBOX_PREFIX + name).Split(',');
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

        internal double[] getListInput() {
            return getListInput(DEFAULT_TEXTBOX_NAME);
        }

        private void cleanData(TextBox textBox) {
            textBox.Text = textBox.Text.Replace("\n", ",").Replace(" ", ",").Replace(",,", ",").TrimEnd(',');
        }

        internal void setListPlaceHolderText(string text) {
            this.lists.First().Tag = text;
        }

        internal void setListPlaceHolderText(string name, string text) {
            TextBox textBox = this.lists.Find(Predicate.byName(TEXTBOX_PREFIX + name));
            textBox.Tag = text;
            if (textBox.Text == "")
                textBox.Text = textBox.Tag.ToString();
        }

        internal void unfocusList(bool initial) {
            doInitialUnfocus = initial;
            this.SelectNextControl(this.lists.First(), true, true, true, false);
        }

        private void unfocusList() {
            unfocusList(false);
        }

    }
}
