using OLTRTA.CommonLanguageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLTRTA {
    class CodeOutputWriter {
        CommonToLanguageParser parser;
        BotMethods botmethods;
        Method loop;

        public CodeOutputWriter(CommonToLanguageParser _parser, BotMethods _botmethods, Method _loop) {
            parser = _parser;
            botmethods = _botmethods;
            loop = _loop;
        }

        public void writeToFile() {
            string script = "";
            for (int i = 0; i < botmethods.global_variables.Length; i++) {
                script += parser.parseExpression(botmethods.global_variables[i]);
            }
            script += parser.parseMethod(botmethods.setup);
            script += parser.parseMethod(loop);
            for (int i = 0; i < botmethods.methods.Length; i++) {
                script += parser.parseMethod(botmethods.methods[i]);
            }
            for (int i = 0; i < botmethods.metamethods.Length; i++) {
                script += parser.parseMethod(botmethods.metamethods[i]);
            }
            System.IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\Robocode\\" + botmethods.name + "\\" + botmethods.name + botmethods.extension, script);
        }
    }
}
