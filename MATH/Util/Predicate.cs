using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MATH.Util {
    class Predicate {

        internal static Predicate<TextBox> byName(string text) {
            return delegate (TextBox textBox) {
                return textBox.Name.Equals(text);
            };
        }

    }
}
