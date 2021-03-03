using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp2;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            FiniteAvtomat finiteAvtomat = new FiniteAvtomat();
            //finiteAvtomat.Add(0, 'a', 1);
            //finiteAvtomat.Add(1, 'b', 2);
            //finiteAvtomat.Add(0, 'c', 3);
            //finiteAvtomat.Add(3, 'd', 4);

            finiteAvtomat.Add(0, 1);
            finiteAvtomat.Add(1, 'a', 1);
            finiteAvtomat.Add(1, 'b', 2);
            finiteAvtomat.Add(0, 2);
            finiteAvtomat.Add(2, 'd', 2);
            finiteAvtomat.Add(2, 'e', 3);

            finiteAvtomat.SetFinaleStates(new int[] { 2, 3 });
            Assert.AreEqual(true, Run(finiteAvtomat, "ab"));
            Assert.AreEqual(true, Run(finiteAvtomat, "aaaaaaaaaaaaaaaaaab"));
            Assert.AreEqual(true, Run(finiteAvtomat, "b"));
            Assert.AreEqual(false, Run(finiteAvtomat, "a"));
            Assert.AreEqual(true, Run(finiteAvtomat, "de"));
            Assert.AreEqual(true, Run(finiteAvtomat, "dddde"));
            Assert.AreEqual(true, Run(finiteAvtomat, "e"));
            Assert.AreEqual(false, Run(finiteAvtomat, "c"));
        }

        public bool Run(FiniteAvtomat finit, string s)
        {
            finit.Reset();
            foreach (char c in s)
                finit.NewSymbol(c);
            return finit.Check();
        }
    }
}
