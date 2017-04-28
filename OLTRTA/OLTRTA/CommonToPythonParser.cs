using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OLTRTA.CommonLanguageObjects;

namespace OLTRTA {
    class CommonToPythonParser : CommonToLanguageParser {
        public string parseBlock(Block _bl) {
            string returnstring = "";
            foreach (Expression ex in _bl.exs) {
                returnstring += parseExpression(ex);
                if (ex.GetType() == typeof(Expression)) {
                    returnstring += "\n";
                }
            }

            string[] lines = returnstring.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length - 1; i++) {
                lines[i] = "    " + lines[i] + "\n";
            }
            returnstring = "";
            returnstring += "\n";
            foreach (string str in lines) {
                returnstring += str;
            }

            return returnstring;
        }

        public string parseElse(Else _else) {
            string returnstring = "";

            if (_else.ex.GetType() == typeof(If)) {
                returnstring += "el";
                returnstring += parseExpression(_else.ex);
            } else {
                returnstring += "else: ";
                returnstring += parseExpression(_else.ex);
            }
            return returnstring;
        }

        public string parseExpression(Expression _exp) {
            switch (_exp.GetType().ToString()) {
                case "OLTRTA.CommonLanguageObjects.If": return parseIf(_exp as If);
                case "OLTRTA.CommonLanguageObjects.Else": return parseElse(_exp as Else);
                case "OLTRTA.CommonLanguageObjects.Block": return parseBlock(_exp as Block);
                case "OLTRTA.CommonLanguageObjects.While": return parseWhile(_exp as While);
                case "OLTRTA.CommonLanguageObjects.For": return parseFor(_exp as For);
                case "OLTRTA.CommonLanguageObjects.Declaration": return _exp.content + "\n";
                default: return _exp.content;
            }
        }

        public string parseFor(For _for) {
            string returnstring = "";

            returnstring += "for (" + parseExpression(_for.init) + ";" + parseExpression(_for.check) + ";" + parseExpression(_for.action) + ": ";
            returnstring += parseBlock(_for.bl);

            return returnstring;
        }

        public string parseIf(If _if) {
            string returnstring = "";

            returnstring += "if " + parseExpression(_if.ex) + ":";
            returnstring += parseBlock(_if.bl);

            return returnstring;
        }

        public string parseMethod(Method _method) {
            string returnstring = "";

            returnstring += "def " + _method.name + "(";
            if (_method.parameters != null) {
                foreach (Parameter param in _method.parameters) {
                    returnstring += parseParameter(param);
                    if (param != _method.parameters.Last()) {
                        returnstring += ",";
                    }
                }
            }
            returnstring += "):";
            returnstring += parseBlock(_method.bl);

            return returnstring;
        }

        public string parseParameter(Parameter _parameter) {
            string returnstring = "";

            returnstring += _parameter.type + " " + _parameter.content;

            return returnstring;
        }

        public string parseWhile(While _while) {
            string returnstring = "";

            returnstring += "while (" + parseExpression(_while.ex) + "): ";
            returnstring += parseBlock(_while.bl);

            return returnstring;
        }
    }
}
