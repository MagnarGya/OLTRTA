using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLTRTA.CommonLanguageObjects {
    class Declaration: Expression{

        public Declaration(string _content) {
            content = _content;
        }
    }
}
