﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using OLTRTA.CommonLanguageObjects;

namespace OLTRTA {
    class TestClass {
        public static void test() {
            Expression[] exs = new Expression[6];
            exs[0] = new Expression("ReadSensors()");

            Expression[] bl1Exs = { new Expression("MoveBackward(500)")};
            Block block1 = new Block(bl1Exs);
            exs[1] = new If(new Expression("Touching()"), block1);

            Expression[] bl2Exs = { new Expression("MoveBackward(500)") };
            Block block2 = new Block(bl2Exs);
            exs[2] = new If(new Expression("SeeingBoth()"), block2);

            Expression[] bl3Exs = { new Expression("TurnRight(90)") };
            Block block3 = new Block(bl3Exs);
            exs[3] = new Else(new If(new Expression("SeeingLeft()"), block3));

            Expression[] bl4Exs = { new Expression("TurnLeft(90)") };
            Block block4 = new Block(bl4Exs);
            exs[4] = new Else(new If(new Expression("SeeingRight()"), block4));

            Expression[] bl5Exs = { new Expression("MoveForward(500)") };
            Block block5 = new Block(bl5Exs);
            exs[5] = new Else(block5);

            Method loop = new Method("void","loop",new Block(exs));
            

            CommonToLanguageParser cparser = new CommonToCParser();
            Console.Write(cparser.parseMethod(loop));
            
            

            CommonToLanguageParser pyparser = new CommonToPythonParser();
            Console.Write(pyparser.parseMethod(loop));

            XDocument xml = XDocument.Load(@"..\..\" + "ArduinoShieldBot" + "\\" + "ArduinoShieldBot" + ".xml");
            string script = xml.Element("robot").Element("setup").Value;
            XDocument config = XDocument.Load(@"..\..\" + "ArduinoShieldBot" + "\\" + "ShieldBot1(Standard)" + ".xml");
            var a = config.Element("assignments").Elements();
            foreach (XElement assign in a) {
                script = script.Replace(assign.Name.ToString(), assign.FirstAttribute.Value.ToString());
            }
            script += cparser.parseMethod(loop);
            BotMethods botmet = new BotMethods("ArduinoShieldBot", "ShieldBot1(Standard)");
            for (int i = 0; i < botmet.methods.Length; i++) {
                script += cparser.parseMethod(botmet.methods[i]);
            }
            Console.Write(script);
        }

        void hardcodedTestToGenerateFullArduinoScript(Method loop) {
            
        }
    }
}
