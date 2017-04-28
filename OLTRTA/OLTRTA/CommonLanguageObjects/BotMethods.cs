using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OLTRTA.CommonLanguageObjects {
    class BotMethods {
        public string name;
        public string robot;
        public Declaration[] global_variables;
        public Method setup;
        public Method[] methods;
        public Method[] metamethods;
        public string extension;

        public BotMethods(string _robot, string _name) {
            name = _name;
            robot = _robot;
            global_variables = getGlobalVariables(_robot, _name);
            setup = getSetup(_robot, _name);
            methods = getMethods(_robot, _name);
            metamethods = getMetamethods(_robot, _name);
            extension = getExtension(_robot, _name);
            
        }
        Declaration[] getGlobalVariables(string _robot, string _name) {
            XDocument xml = XDocument.Load(@"..\..\" + _robot + "\\" + _robot + ".xml");
            XDocument config = XDocument.Load(@"..\..\" + _robot + "\\" + _name + ".xml");
            var v = xml.Element("robot").Element("setup").Element("globalvariables").Elements();
            List<Declaration> expressions = new List<Declaration>();
            foreach(XElement el in v) {
                string name = el.FirstAttribute.Value;
                string type = el.LastAttribute.Value;
                var a = config.Element("assignments").Elements();
                foreach(XElement assign in a) {
                    name = name.Replace(assign.Name.ToString(), assign.FirstAttribute.Value.ToString());
                    type = type.Replace(assign.Name.ToString(), assign.FirstAttribute.Value.ToString());
                }
                expressions.Add(new Declaration(type + " " + name));
            }
            return expressions.ToArray();
        }

        Method getSetup(string _robot, string _name) {
            XDocument xml = XDocument.Load(@"..\..\" + _robot + "\\" + _robot + ".xml");
            XDocument config = XDocument.Load(@"..\..\" + _robot + "\\" + _name + ".xml");
            var m = xml.Element("robot").Element("setup").Element("method").Element("setup");
            var a = config.Element("assignments").Elements();
            Parameter[] parameters = null;
            string _text = m.Value;
            string name = m.Name.ToString();
            foreach (XElement assign in a) {
                _text = _text.Replace(assign.Name.ToString(), assign.FirstAttribute.Value.ToString());
            }
            string _parameters = m.FirstAttribute.Value;
            if (_parameters != "") {
                string[] _parameterstrings = _parameters.Split(new string[] { "," }, StringSplitOptions.None);
                parameters = new Parameter[_parameterstrings.Length];
                for (int i = 0; i < parameters.Length; i++) {
                    string[] _paramparts = _parameterstrings[i].Split(new string[] { " " }, StringSplitOptions.None);
                    parameters[i] = new Parameter(_paramparts[0], _paramparts[1]);
                }
           }
           string type = m.LastAttribute.Value;
           Expression[] exs = { new Expression(_text) };
           Block bl = new Block(exs);
           return (new Method(type, name, bl));
        }

        Method[] getMethods(string _robot, string _name) {
            XDocument xml = XDocument.Load(@"..\..\" + _robot + "\\" + _robot + ".xml");
            XDocument config = XDocument.Load(@"..\..\" + _robot + "\\" + _name + ".xml");
            var m = xml.Element("robot").Element("methods").Elements();
            List<Method> methodlist = new List<Method>();
            foreach (XElement el in m) {
                var a = config.Element("assignments").Elements();
                Parameter[] parameters = null;
                string _text = el.Value;
                string name = el.Name.ToString();
                foreach (XElement assign in a) {
                    _text = _text.Replace(assign.Name.ToString(), assign.FirstAttribute.Value.ToString());
                }
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
            return methodlist.ToArray();
        }
        Method[] getMetamethods(string _robot, string _name) {
            XDocument xml = XDocument.Load(@"..\..\" + _robot + "\\" + _robot + ".xml");
            XDocument config = XDocument.Load(@"..\..\" + _robot + "\\" + _name + ".xml");
            List<Method> methodlist = new List<Method>();
            var m = xml.Element("robot").Element("metamethods").Elements();
            foreach (XElement el in m) {
                Parameter[] parameters = null;
                string _text = el.Value;
                var a = config.Element("assignments").Elements();
                foreach (XElement assign in a) {
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

            return methodlist.ToArray();
        }
        string getExtension(string _robot, string _name) {
            XDocument xml = XDocument.Load(@"..\..\" + _robot + "\\" + _robot + ".xml");
            var x = xml.Element("robot").Element("setup").Element("extension").Value;
            return x as string;
        }
    }
}
