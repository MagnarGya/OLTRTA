using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OLTRTA.CommonLanguageObjects;

namespace OLTRTA {
    class CommonToCParser : CommonToLanguageParser {
        public string parseBlock(Block _bl) {
            string returnstring = "";

            returnstring += "{";
            foreach (Expression ex in _bl.exs) {
                returnstring += parseExpression(ex);
                if (ex.GetType() == typeof(Expression)) {
                    returnstring += ";";
                }
            }
            returnstring += "}";

            return returnstring;
        }

        public string parseElse(Else _else) {
            string returnstring = "";

            returnstring += "else";
            returnstring += parseExpression(_else.ex);

            return returnstring;
        }

        public string parseExpression(Expression _exp) {
                switch (_exp.GetType().ToString()) {
                case "OLTRTA.CommonLanguageObjects.If": return parseIf(_exp as If);
                case "OLTRTA.CommonLanguageObjects.Else": return parseElse(_exp as Else);
                case "OLTRTA.CommonLanguageObjects.Block": return parseBlock(_exp as Block);
                case "OLTRTA.CommonLanguageObjects.While": return parseWhile(_exp as While);
                case "OLTRTA.CommonLanguageObjects.For": return parseFor(_exp as For);
                default: return _exp.content;
            }
        }

        public string parseFor(For _for) {
            string returnstring = "";

            returnstring += "for (" + parseExpression(_for.init) + ";" + parseExpression(_for.check) + ";" + parseExpression(_for.action);
            returnstring += parseBlock(_for.bl);

            return returnstring;
        }

        public string parseIf(If _if) {
            string returnstring = "";

            returnstring += "if (" + parseExpression(_if.ex) + ")";
            returnstring += parseBlock(_if.bl);

            return returnstring;
        }

        public string parseMethod(Method _method) {
            string returnstring = "";

            returnstring += _method.type + " " + _method.name + "(";
            foreach (Parameter param in _method.parameters) {
                returnstring += parseParameter(param);
            }
            returnstring += ")";
            returnstring += parseBlock(_method.bl);

            return returnstring;
        }

        public string parseParameter(Parameter _parameter) {
            string returnstring = "";



            return returnstring;
        }

        public string parseWhile(While _while) {
            throw new NotImplementedException();
        }
    }
}
