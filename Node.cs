using System;
using System.Collections.Generic;

namespace CompilerLibrary
{
    /// <summary>
    /// Используется для создания дерева.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Информация, которую хранит узел.
        /// </summary>
        public readonly object o;
        /// <summary>
        /// Внутренние узлы.
        /// </summary>
        private readonly List<Node> nodes;

        /// <summary>
        /// Количество внутренних узлов.
        /// </summary>
        public int Count => nodes.Count;

        /// <summary>
        /// Создает новый узел.
        /// </summary>
        /// <param name="o">Информация, которую будет хранить узел.</param>
        public Node(object o)
        {
            this.o = o ?? throw new ArgumentNullException(paramName: nameof(o));
            nodes = new List<Node>();
        }

        /// <summary>
        /// Добавляет внутренний узел.
        /// </summary>
        /// <param name="node">Внутренний узел.</param>
        public void Add(Node node)
        {
            if (node is null)
            {
                throw new ArgumentNullException(paramName: nameof(node));
            }

            nodes.Add(item: node);
        }

        /// <summary>
        /// Возвращает внутрений узел по индексу.
        /// </summary>
        /// <param name="index">Индекс внутреннего узла.</param>
        /// <returns>Внутрений узел.</returns>
        public Node GetNode(int index)
        {
            return nodes[index];
        }
    }
}
