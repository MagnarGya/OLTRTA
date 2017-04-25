using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLTRTA.CommonLanguageObjects {
    class Script {
        public Expression[] header;
        public Method[] body;

        public Script() {
            header = null;
            body = null;
        }

        public Script(Expression[] _header, Method[] _body) {
            header = _header;
            body = _body;
        }
    }
}
