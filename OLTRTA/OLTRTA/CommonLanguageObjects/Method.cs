using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLTRTA.CommonLanguageObjects {
    class Method {
        public string type;
        public Parameter[] parameters;
        public Block bl;

        public Method(string _type, Parameter[] _parameters, Block _bl) {
            type = _type;
            parameters = _parameters;
            bl = _bl;
        }
    }
}
