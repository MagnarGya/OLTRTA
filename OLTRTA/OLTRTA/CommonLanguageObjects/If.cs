using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLTRTA.CommonLanguageObjects {
    class If : Expression{
        public Expression ex;
        public Block bl;

        public If(Expression _ex, Block _bl) {
            ex = _ex;
            bl = _bl;
        }
    }
}
