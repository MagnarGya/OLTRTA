using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OLTRTA.CommonLanguageObjects;

namespace OLTRTA {
    class TestClass {
        void test() {
        Method method = new Method();
            method.type = "void";
            method.parameters = null;

            Block mainBlock = new Block();
            mainBlock.exs = new Expression[6];
            mainBlock.exs[0] = new Expression();
            mainBlock.exs[0].content = "readSensors()";
        }
    }
}
