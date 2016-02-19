using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;

namespace MockReturnValueTest
{
    
    public class Class1
    {
        [Test]
        public void TestLogger()
        {
            Debug.WriteLine("text");
            ILogger logger = MockRepository.GenerateMock<ILogger>();
            logger.Stub(x => x.LogDebug("ccc"))
                .IgnoreArguments()
                //.WhenCalled((vv)=>this.Helper(vv.Arguments[0].ToString()));
                .WhenCalled((vv) => Debug.WriteLine(vv.Arguments[0].ToString()))
                ;
            var service = new Service(logger);
            //logger.AssertWasCalled(x=>x.LogDebug(""),arg=>arg.IgnoreArguments());
        }

        void Helper(string text)
        {
            Debug.WriteLine(text);
        }
    }


    public class Service
    {
        public Service(ILogger logger)
        {
            logger.LogDebug("log den error");
        }
        
    }

    public interface ILogger
    {
        void LogDebug(string xxx);
    }

}
