using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LambdasAndDelegates
{

    public delegate int BizRulesDelegate(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            var data = new ProcessData();
            BizRulesDelegate addDel = (x, y) => x + y;
            BizRulesDelegate addMultiply = (x, y) => x*y;

            //data.Process(2,3, addDel);
            //DemostrationOfActionOfT(data);

            DemostrationOfFuncOfT(data);
        }

        private static void DemostrationOfFuncOfT(ProcessData data)
        {
            Func<int, int, int> funcAddDel = (x, y) => x + y;
            Func<int, int, int> funcMultiplyDel = (x, y) => x*y;

            data.ProcessFunc(2, 3, funcAddDel);
            data.ProcessFunc(2, 3, funcMultiplyDel);
        }

        private static void DemostrationOfActionOfT(ProcessData data)
        {
            Action<int, int> myAction = (x, y) => Console.WriteLine(x + y);
            Action<int, int> myMultiplyAction = (x, y) => Console.WriteLine(x*y);

            data.ProcessAction(2, 3, myAction);
            data.ProcessAction(2, 3, myMultiplyAction);
        }
    }
}
