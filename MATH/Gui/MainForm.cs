using MATH.Gui.Calc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MATH {
    public partial class MainForm : Form {

        private List<Type> forms = new List<Type>();

        public MainForm() {
            InitializeComponent();
            addForms();
            populateList();
        }

        private void populateList() {
            List<string> tempList = new List<string>();
            foreach (Type formType in forms) {
                using (Form form = getFormFromType(formType)) {
                    tempList.Add(form.Text);
                }
            }
            tempList.Sort();
            list.Items.AddRange(tempList.ToArray());
        }

        private Form getFormFromType(Type type) {
            return (Form)Activator.CreateInstance(type);
        }

        private void addForms() {
            forms.Add(typeof(LinearGrowth));
            forms.Add(typeof(ExponentialGrowth));
            forms.Add(typeof(Logarithms));
            forms.Add(typeof(InterestSimple));
            forms.Add(typeof(InterestCompound));
            forms.Add(typeof(InterestCompoundContinuous));
            forms.Add(typeof(Annuity));
            forms.Add(typeof(AnnuityPayout));
            forms.Add(typeof(Loan));
            forms.Add(typeof(CentralTendency));
            forms.Add(typeof(StandardDeviation));
            forms.Add(typeof(NormalDistribution));
        }

        private void enterItem(object sender, EventArgs e) {
            ListBox listBox = (ListBox)sender;
            if (listBox.SelectedIndex < 0)
                return;
            getFormFromType(forms.Find(byName((string)listBox.SelectedItem))).Show();
        }

        private Predicate<Type> byName(string name) {
            return delegate(Type form) {
                return getFormFromType(form).Text.Equals(name);
            };
        }

        private void checkEnterKey(object sender, KeyPressEventArgs e) {
            if (e.KeyChar.Equals((char)Keys.Enter))
                enterItem(sender, e);
        }

    }
}
