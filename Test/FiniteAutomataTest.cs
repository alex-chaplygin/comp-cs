using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp2;

namespace CompilerLibrary
{
    [TestClass]
    public class FiniteAutomataTest
    {
	[TestMethod]
        public void Линейный()
        {
            FiniteAutomata finiteAutomat = new FiniteAutomata();
            finiteAutomat.Add(0, 'a', 1);
            finiteAutomat.Add(1, 'b', 2);
            finiteAutomat.Add(2, 'c', 3);
            finiteAutomat.Add(3, 'd', 4);

            finiteAutomat.SetFinaleStates(new int[] { 4 });
            Assert.AreEqual(true, Run(finiteAutomat, "abcd"));
	}
	
        [TestMethod]
        public void Разветвление()
        {
            FiniteAvtomat finiteAvtomat = new FiniteAvtomat();

            finiteAvtomat.Add(0, 1);
            finiteAvtomat.Add(1, 'a', 1);
            finiteAvtomat.Add(1, 'b', 2);
            finiteAvtomat.Add(0, 3);
            finiteAvtomat.Add(3, 'd', 4);
            finiteAvtomat.Add(4, 'e', 5);

            finiteAvtomat.SetFinaleStates(new int[] { 2, 5 });
            Assert.AreEqual(true, Run(finiteAvtomat, "ab"));
            Assert.AreEqual(true, Run(finiteAvtomat, "aaaaaaaaaaaaaaaaaab"));
            Assert.AreEqual(true, Run(finiteAvtomat, "b"));
            Assert.AreEqual(false, Run(finiteAvtomat, "a"));
            Assert.AreEqual(true, Run(finiteAvtomat, "de"));
            Assert.AreEqual(true, Run(finiteAvtomat, "dddde"));
            Assert.AreEqual(true, Run(finiteAvtomat, "e"));
            Assert.AreEqual(false, Run(finiteAvtomat, "c"));
        }

	[TestMethod]
        public void СложноеВетвление1()
        {
            FiniteAutomata finiteAutomat = new FiniteAutomata();
            finiteAutomat.Add(0, 1, 7);
            finiteAutomat.Add(1, 'a', 2);
            finiteAutomat.Add(2, 3, 5);
            finiteAutomat.Add(3, 'b', 4);
            finiteAutomat.Add(5, 'c', 6);
            finiteAutomat.Add(7, 'd', 8);
            finiteAutomat.Add(8, 'e', 9);

            finiteAutomat.SetFinaleStates(new int[] { 4, 6, 9 });
            Assert.AreEqual(true, Run(finiteAutomat, "ab"));
            Assert.AreEqual(true, Run(finiteAutomat, "ac"));
            Assert.AreEqual(true, Run(finiteAutomat, "de"));
            Assert.AreEqual(false, Run(finiteAutomat, "af"));
            Assert.AreEqual(false, Run(finiteAutomat, "cf"));
            Assert.AreEqual(false, Run(finiteAutomat, "df"));
        }

        [TestMethod]
        public void СложноеВетвление2()
        {
            FiniteAutomata finiteAutomat = new FiniteAutomata();
            finiteAutomat.Add(0, 1, 11);
            finiteAutomat.Add(1, 'a', 2);
            finiteAutomat.Add(2, 3, 9);
            finiteAutomat.Add(3, 'b', 4);
            finiteAutomat.Add(4, 5, 7);
            finiteAutomat.Add(5, 'c', 6);
            finiteAutomat.Add(7, 'd', 8);
            finiteAutomat.Add(9, 'e', 10);
            finiteAutomat.Add(11, 'f', 12);
            finiteAutomat.Add(12, 13, 15, 18);
            finiteAutomat.Add(13, 'g', 14);
            finiteAutomat.Add(15, 'h', 16);
            finiteAutomat.Add(16, 'i', 17);
            finiteAutomat.Add(18, 'j', 19);


            finiteAutomat.SetFinaleStates(new int[] { 6, 8, 10, 14, 17, 19 });
            Assert.AreEqual(true, Run(finiteAutomat, "abc"));
            Assert.AreEqual(true, Run(finiteAutomat, "abd"));
            Assert.AreEqual(true, Run(finiteAutomat, "ae"));
            Assert.AreEqual(true, Run(finiteAutomat, "fg"));
            Assert.AreEqual(true, Run(finiteAutomat, "fhi"));
            Assert.AreEqual(true, Run(finiteAutomat, "fj"));


            Assert.AreEqual(false, Run(finiteAutomat, "ad"));
            Assert.AreEqual(false, Run(finiteAutomat, "ff"));
            Assert.AreEqual(false, Run(finiteAutomat, "fe"));

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
