using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OLTRTA.CommonLanguageObjects {
    class BotMethod:Expression {
        public string name;
        public Object text;

        public BotMethod(string _robot, string _name) {
            name = _name;
            XDocument xml = XDocument.Load(@"..\..\" + _robot + "\\"+_robot +"Methods.xml");
            var t = xml.Element("methods");
            text = t.Element(_name).Value;
        }
    }
}
