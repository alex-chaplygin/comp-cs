using CompilerLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FiniteAutomataTest
{
    /// <summary>
    /// Сводное описание для NodeTest
    /// </summary>
    [TestClass]
    public class NodeTest
    {
        /// <summary>
        /// Логика конструктора.
        /// </summary>
        public NodeTest() { }

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

        /// <summary>
        /// Тестирование создания дерева.
        /// </summary>
        [TestMethod]
        public void Add_CreateTree_8Returned()
        {
            // arrange
            Node node = new Node(o: 0);

            // act
            Node node1 = new Node(o: 1);
            node1.Add(new Node(o: 5));
            node1.Add(new Node(o: 6));
            node1.Add(new Node(o: 7));
            node1.Add(new Node(o: 8));

            node.Add(node: node1);
            node.Add(node: new Node(o: 2));
            node.Add(node: new Node(o: 3));
            node.Add(node: new Node(o: 4));

            // assert
            Assert.AreEqual(expected: 8, actual: node.GetNode(index: 0).GetNode(index: 3).o);
        }

        /// <summary>
        /// Тестирование возвращения количества node.
        /// </summary>
        [TestMethod]
        public void Count_CreateTree_4Returned()
        {
            // arrange
            Node node = new Node(o: 0);

            // act
            Node node1 = new Node(o: 1);
            node1.Add(new Node(o: 5));
            node1.Add(new Node(o: 6));
            node1.Add(new Node(o: 7));
            node1.Add(new Node(o: 8));

            node.Add(node: node1);
            node.Add(node: new Node(o: 2));
            node.Add(node: new Node(o: 3));
            node.Add(node: new Node(o: 4));

            // assert
            Assert.AreEqual(expected: 4, actual: node.GetNode(index: 0).Count);
        }
    }
}
