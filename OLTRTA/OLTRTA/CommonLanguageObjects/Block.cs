using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLTRTA.CommonLanguageObjects {
    class Block : Expression{
        public Expression[] exs;

        public Block(Expression[] _exs) {
            exs = _exs;
        }
    }
}
