using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OLTRTA.CommonLanguageObjects;

namespace OLTRTA {
    class TestClass {
        public static void test() {
            Expression[] exs = new Expression[6];
            exs[0] = new Expression("readSensors()");

            Expression[] bl1Exs = { new Expression("moveBackward(500)")};
            Block block1 = new Block(bl1Exs);
            exs[1] = new If(new Expression("touching"), block1);

            Expression[] bl2Exs = { new Expression("moveBackward(500)") };
            Block block2 = new Block(bl2Exs);
            exs[2] = new If(new Expression("seeing"), block2);

            Expression[] bl3Exs = { new Expression("turnRight(90)") };
            Block block3 = new Block(bl3Exs);
            exs[3] = new Else(new If(new Expression("seeingLeft"), block3));

            Expression[] bl4Exs = { new Expression("turnLeft(90)") };
            Block block4 = new Block(bl4Exs);
            exs[4] = new Else(new If(new Expression("seeingRight"), block4));

            Expression[] bl5Exs = { new Expression("moveForward(500)") };
            Block block5 = new Block(bl5Exs);
            exs[5] = new Else(block5);

            Method loop = new Method("void","loop",new Block(exs));
            BotMethod botmet = new BotMethod("ArduinoShieldBot", "MoveForward");

            CommonToLanguageParser cparser = new CommonToCParser();
            Console.Write(cparser.parseMethod(loop));
            Console.Write(cparser.parseMethod(botmet));
        }
    }
}
