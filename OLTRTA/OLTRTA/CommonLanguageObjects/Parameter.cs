using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLTRTA.CommonLanguageObjects {
    class Parameter {
        public string type;
        public string content;

        public Parameter(string _type, string _content) {
            type = _type;
            content = _content;
        }
    }
}
