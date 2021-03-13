﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerLibrary
{
    /// <summary>
    /// Недетерминированный конечный автомат
    /// </summary>
    public class FiniteAutomata
    {
        /// <summary>
        /// Переход из одного состояний в другое
        /// </summary>
        struct Change
        {
            /// <summary>
            /// Исходное состояние автомата
            /// </summary>
            public int from;
            /// <summary>
            /// Символ по которому осуществляется переход
            /// </summary>
            public char symbol;
            /// <summary>
            /// Состояние, в которое должен перейти автомат
            /// </summary>
            public int to;
        }

        /// <summary>
        /// Пустой переход из одного состояний в другое (осуществляется всегда)
        /// </summary>
        public struct EmptyChange
        {
            /// <summary>
            /// Исходное состояние автомата
            /// </summary>
            public int from;
            /// <summary>
            /// Состояния, в которые должен перейти автомат
            /// </summary>
            public List<int> to;
        }

        /// <summary>
        /// Список переходов автомата
        /// </summary>
        List<Change> changes;

        /// <summary>
        /// Список пустых(принудительных) переходов автомата
        /// </summary>
        public List<EmptyChange> emptyChanges;

        /// <summary>
        /// Начальное состояние автомата
        /// </summary>
        int startState;

        /// <summary>
        /// Конечные состояния автомата (при успешном распознавании автомат доходит до этих состояний)
        /// </summary>
        int[] finalStates;

        /// <summary>
        /// Текущие состояния автомата (их несколько при нескольких ветвях переходов
        /// </summary>
        List<int> states;

        /// <summary>
        /// Создается пустой автомат и устанавливается начальное состояние
        /// </summary>
        /// <param name="start">номер начального состояния</param>
        public FiniteAutomata(int start = 0)
        {
            startState = start;
            states = new List<int>();
            states.Add(start);
            changes = new List<Change>();
            emptyChanges = new List<EmptyChange>();
            finalStates = new int[] { };

        }

        /// <summary>
        /// Устанавливаются конечные состояния автомата
        /// </summary>
        /// <param name="states">конечные состояния</param>
        public void SetFinaleStates(int[] states)
        {
            finalStates = states;
        }

        /// <summary>
        /// Добавляется переход
        /// </summary>
        /// <param name="from">начальное состояние</param>
        /// <param name="symbol">символ по которому осуществляется переход</param>
        /// <param name="to">конечное состояние</param>
        public void Add(int from, char symbol, int to)
        {
            Change change = new Change();
            change.from = from;
            change.symbol = symbol;
            change.to = to;
            changes.Add(change);
        }

        /// <summary>
        /// Добавляются пустые(принудительные) переходы.
	/// Конечные состояния не дублируются
        /// </summary>
        /// <param name="from">начальное состояние</param>
        /// <param name="to">конечные состояния</param>
        public void Add(int from, params int[] to)
        {
            bool changeAdded = false;
            for (int i = 0; i < emptyChanges.Count; i++)
            {
                if (emptyChanges[i].from == from)
                {
                    changeAdded = true;
                    for (int j = 0; j < to.Length; j++)
                    {
                        if (!emptyChanges[i].to.Contains(to[j]))
                        {
                            emptyChanges[i].to.Add(to[j]);
                        }
                    }
                }
            }
            if (!changeAdded)
            {
                EmptyChange change = new EmptyChange();
                change.from = from;
                change.to = to.ToList();
                emptyChanges.Add(change);
            }
        }

        /// <summary>
        /// Добавляется пустой(принудительный) переход
	/// Конечное состояние добавляется в список, если есть такой переход, или создается новый переход
        /// </summary>
        /// <param name="from">начальное состояние</param>
        /// <param name="to">конечное состояние</param>
        public void Add(int from, int to)
        {
            bool changeAdded = false;
            for (int i = 0; i < emptyChanges.Count; i++)
            {
                if (emptyChanges[i].from == from)
                {
                    changeAdded = true;
                    if (!emptyChanges[i].to.Contains(to))
                    {
                        emptyChanges[i].to.Add(to);
                    }
                }
            }
            if (!changeAdded)
            {
                EmptyChange change = new EmptyChange();
                change.from = from;
                change.to = new List<int>() { to };
                emptyChanges.Add(change);
            }
        }

        /// <summary>
        /// Символ поступает в автомат. Автомат меняет состояние.
        /// </summary>
        /// <param name="symbol">текущий символ</param>
        public void NewSymbol(char symbol)
        {
            List<int> tempStates = new List<int>();
            for (int i = 0; i < states.Count; i++)
            {
                var tos = emptyChanges.FirstOrDefault(p => p.from == states[i]).to;
                for (int j = 0; j < tos?.Count; j++)
                {
                    if (j == 0)
                    {
                        states[i] = tos[j];
                    }
                    else
                    {
                        tempStates.Add(tos[j]);
                    }
                }
                foreach (var change in changes)
                    if (states[i] == change.from && symbol == change.symbol)
                        states[i] = change.to;
            }
            for (int i = 0; i < tempStates.Count; i++)
            {
                foreach (var change in changes)
                    if (tempStates[i] == change.from && symbol == change.symbol)
                        tempStates[i] = change.to;
            }
            states.AddRange(tempStates);
        }

        /// <summary>
        /// Проверка окончания распознавания
        /// </summary>
        /// <returns>true - если успешное распознавание, false - неуспешное</returns>
        public bool Check()
        {
            for (int i = 0; i < finalStates.Length; i++)
                foreach (var state in states)
                    if (state == finalStates[i])
                        return true;
            return false;
        }

        /// <summary>
        /// Сброс автомата в начальное состояние для нового распознавания
        /// </summary>
        public void Reset()
        {
            states.Clear();
            states.Add(startState);
        }
    }
}
