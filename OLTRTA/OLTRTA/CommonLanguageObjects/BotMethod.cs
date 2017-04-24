using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OLTRTA.CommonLanguageObjects {
    class BotMethod:Method {
        public string text;

        public BotMethod(string _robot, string _name) {
            name = _name;
            XDocument xml = XDocument.Load(@"..\..\" + _robot + "\\" + _robot + "Methods.xml");
            var t = xml.Element("methods");
            text = t.Element(_name).Value;

            string _parameters = t.Element(_name).FirstAttribute.Value;

            if (_parameters != "") {
                string[] _parameterstrings = _parameters.Split(new string[] { "," }, StringSplitOptions.None);
                parameters = new Parameter[_parameterstrings.Length];
                for (int i = 0; i < parameters.Length; i++) {
                    string[] _paramparts = _parameterstrings[i].Split(new string[] { " " }, StringSplitOptions.None);
                    parameters[i] = new Parameter(_paramparts[0], _paramparts[1]);
                }
            }

            type = "void";
            Expression[] exs = { new Expression(text)};
            bl = new Block(exs);
        }
    }
}
