using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLTRTA.CommonLanguageObjects {
    class For : Expression {
        public Expression init;
        public Expression check;
        public Expression action;
        public Block bl;
    }
}
