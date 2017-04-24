using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLTRTA.CommonLanguageObjects {
    class Else : Expression{
        public Expression ex;

        public Else(Expression _ex) {
            ex = _ex;
        }
    }
}
