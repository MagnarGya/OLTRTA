using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLTRTA.CommonLanguageObjects {
    class For : Expression {
        Expression init;
        Expression check;
        Expression action;
        Block bl;
    }
}
