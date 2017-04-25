using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OLTRTA.CommonLanguageObjects {
    class BotMethods {
        public Method[] methods;

        public BotMethods(string _robot) {
            XDocument xml = XDocument.Load(@"..\..\" + _robot + "\\" + _robot + "Methods.xml");
            var t = xml.Element("methods").Elements();
            List<Method> methodlist = new List<Method>();
            foreach(XElement el in t) {

                Parameter[] parameters = null;
                string _text = el.Value;
                string name = el.Name.ToString();
                string _parameters = el.FirstAttribute.Value;
                if(_parameters != "") {
                    string[] _parameterstrings = _parameters.Split(new string[] { "," }, StringSplitOptions.None);
                    parameters = new Parameter[_parameterstrings.Length];
                    for(int i = 0; i < parameters.Length; i++) {
                        string[] _paramparts = _parameterstrings[i].Split(new string[] { " " }, StringSplitOptions.None);
                        parameters[i] = new Parameter(_paramparts[0], _paramparts[1]);
                    }
                }
                string type = el.LastAttribute.Value;
                Expression[] exs = { new Expression(_text) };
                Block bl = new Block(exs);
                methodlist.Add(new Method(type, name, parameters, bl));
            }
            methods = methodlist.ToArray();
        }
    }
}
