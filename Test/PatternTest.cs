﻿using System;
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
            Assert.AreEqual(2, p.Match("abc"));
            Assert.AreEqual(21, p.Match("0000000000000000000abc0000000000000000"));
            Assert.AreEqual(2, p.Match("abc0000000000000000"));
            Assert.AreEqual(-1, p.Match("ab"));
        }
        [TestMethod]
        public void Замыкание()
        {
            Pattern p = new Pattern("a*b");
            Assert.AreEqual(1, p.Match("abc"));
            Assert.AreEqual(36, p.Match("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab"));
            Assert.AreEqual(0, p.Match("b"));
            Assert.AreEqual(-1, p.Match("oooooppppmmmm"));
        }
	[TestMethod]
        public void Замыкание2()
        {
            Pattern p = new Pattern("ab*");
            Assert.AreEqual(1, p.Match("abc"));
            Assert.AreEqual(36, p.Match("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab"));
            Assert.AreEqual(0, p.Match("a"));
            Assert.AreEqual(-1, p.Match("oooooppppmmmm"));
        }
        [TestMethod]
        public void Замыкание3()
        {
            Pattern p = new Pattern("a*b*c*");
            Assert.AreEqual(2, p.Match("abc"));
            Assert.AreEqual(37, p.Match("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabc"));
            Assert.AreEqual(0, p.Match("b"));
            Assert.AreEqual(0, p.Match(""));
        }
    }
}
