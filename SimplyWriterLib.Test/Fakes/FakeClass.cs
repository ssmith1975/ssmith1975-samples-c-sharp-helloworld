using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyWriterLib.Test.Fakes {
    public class FakeClass1:ISimplyWrite {
        public bool SimplyWriteSpy = false;
        public FakeClass1() {

        }

        public void SimplyWrite() {
            SimplyWriteSpy = true;
        }
    }
    public class FakeClass2  {
        public bool SimplyWriteSpy = false;

        public FakeClass2() {
           
        }

    }

    public class FakeClass3 : ISimplyWrite {
        public string ParameterSpy1 = String.Empty;
        public string ParameterSpy2 = String.Empty;

        public FakeClass3(string paramSpy1) {
            ParameterSpy1 = paramSpy1;
        }

        public FakeClass3(string paramSpy1, string paramSpy2) {
            ParameterSpy1 = paramSpy1;
            ParameterSpy2 = paramSpy2;
        }
        public void SimplyWrite() {
          
        }
    }



}
