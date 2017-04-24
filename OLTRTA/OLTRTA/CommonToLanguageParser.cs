using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OLTRTA.CommonLanguageObjects;

namespace OLTRTA {
    interface CommonToLanguageParser {
        string parseBlock(Block _bl);
        string parseElse(Else _else);
        string parseExpression(Expression _exp);
        string parseFor(For _for);
        string parseIf(If _if);
        string parseMethod(Method _method);
        string parseParameter(Parameter _parameter);
        string parseWhile(While _while);
    }
}
