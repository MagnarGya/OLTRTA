using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLTRTA.CommonLanguageObjects {
    class Method {
        public string type;
        public string name;
        public Parameter[] parameters;
        public Block bl;

        public Method(string _type, string _name, Parameter[] _parameters, Block _bl) {
            type = _type;
            name = _name;
            parameters = _parameters;
            bl = _bl;
        }

        public Method(string _type, string _name, Block _bl) {
            type = _type;
            name = _name;
            parameters = null;
            bl = _bl;
        }

        public Method() {

        }
    }
}
