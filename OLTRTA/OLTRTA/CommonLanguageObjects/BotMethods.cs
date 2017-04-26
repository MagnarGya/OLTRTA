using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OLTRTA.CommonLanguageObjects {
    class BotMethods {
        public Method[] methods;

        public BotMethods(string _robot, string _name) {
            XDocument xml = XDocument.Load(@"..\..\" + _robot + "\\" + _robot + ".xml");
            var m = xml.Element("robot").Element("methods").Elements();
            List<Method> methodlist = new List<Method>();
            foreach(XElement el in m) {

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
            xml = XDocument.Load(@"..\..\" + _robot + "\\" + _robot + ".xml");
            XDocument config = XDocument.Load(@"..\..\" + _robot + "\\" + _name + ".xml");
            m = xml.Element("robot").Element("metamethods").Elements();
            foreach(XElement el in m) {
                Parameter[] parameters = null;
                string _text = el.Value;
                var a = config.Element("assignments").Elements();
                foreach(XElement assign in a) {
                    _text = _text.Replace(assign.Name.ToString(), assign.FirstAttribute.Value.ToString());
                }
                string name = el.Name.ToString();
                string _parameters = el.FirstAttribute.Value;
                if (_parameters != "") {
                    string[] _parameterstrings = _parameters.Split(new string[] { "," }, StringSplitOptions.None);
                    parameters = new Parameter[_parameterstrings.Length];
                    for (int i = 0; i < parameters.Length; i++) {
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
