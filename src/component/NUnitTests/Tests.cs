using System;
using System.IO;
using NUnit.Framework;
using OKafkaEco;

using ScriptEngine.HostedScript;
using ScriptEngine.Machine;
using ScriptEngine.Environment;


namespace NUnitTests
{
    [TestFixture]
    public class MainTestClass
    {

        private EngineHelpWrapper host;

        [OneTimeSetUp]
        public void Initialize()
        {
            host = new EngineHelpWrapper();
            host.StartEngine();
        }
        
        //External Tests
        
        
        [Test]
        public void TestsKafkaLib()
        {
            host.RunTestScript("NUnitTests.Tests.kafka.os");
        }
      
    }
}