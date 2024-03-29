﻿using CompilerLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiniteAutomataTest
{
    /// <summary>
    /// Сводное описание для LexerTest
    /// </summary>
    [TestClass]
    public class LexerTest
    {
        Lexer lexer;
        public LexerTest()
        {
            lexer = new Lexer(" \t ab \t  cd");
            lexer.Add(" \t\n");
            lexer.Add(3, "ab");
            lexer.Add(4, "cd");
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Дополнительные атрибуты тестирования
        //
        // При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        // ClassInitialize используется для выполнения кода до запуска первого теста в классе
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // TestInitialize используется для выполнения кода перед запуском каждого теста 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // TestCleanup используется для выполнения кода после завершения каждого теста
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetToken_Pattern_ab_3Returned()
        {
            Assert.AreEqual(3, lexer.GetToken());
            Assert.AreEqual(4, lexer.GetToken());
        }
    }
}
