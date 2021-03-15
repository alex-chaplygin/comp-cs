using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompilerLibrary;

namespace Testing
{
    [TestClass]
    public class PatternTest
    {
        [TestMethod]
        public void Простой()
        {
            Pattern p = new Pattern("abc");
            Assert.AreEqual(true, p.Match("abc"));
            Assert.AreEqual(true, p.Match("0000000000000000000abc0000000000000000"));
            Assert.AreEqual(true, p.Match("abc0000000000000000"));
            Assert.AreEqual(false, p.Match("ab"));
        }
        [TestMethod]
        public void Замыкание()
        {
            Pattern p = new Pattern("a*b");
            Assert.AreEqual(true, p.Match("abc"));
            Assert.AreEqual(true, p.Match("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab"));
            Assert.AreEqual(true, p.Match("b"));
            Assert.AreEqual(false, p.Match("oooooppppmmmm"));
        }
    }
}
