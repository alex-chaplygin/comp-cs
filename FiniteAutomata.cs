using System;
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
        struct EmptyChange
        {
	    /// <summary>
	    /// Исходное состояние автомата
	    /// </summary>
            public int from;
	    /// <summary>
	    /// Состояние, в которое должен перейти автомат
	    /// </summary>
            public int to;
        }
	
	/// <summary>
	/// Список переходов автомата
	/// </summary>
        List<Change> changes;
	
	/// <summary>
	/// Список пустых(принудительных) переходов автомата
	/// </summary>
        List<EmptyChange> emptyChanges;
	
	/// <summary>
	/// Начальное состояние автомата
	/// </summary>
        int startState;

	/// <summary>
	/// Конечные состояния автомата (при успешном распознавании автомат доходит до этих состояний)
	/// </summary>
        int[] finalStates;
	
	/// <summary>
	/// Текущие состояния автомата (их несколько при нескольких ветвях переходов0
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
	/// Добавляется пустой(принудительный) переход
	/// </summary>
        /// <param name="from">начальное состояние</param>
        /// <param name="to">конечное состояние</param>
        public void Add(int from, int to)
        {
            EmptyChange change = new EmptyChange();
            change.from = from;
            change.to = to;
            emptyChanges.Add(change);
        }

	/// <summary>
	/// Символ поступает в автомат. Автомат меняет состояние.
	/// </summary>
        /// <param name="symbol">текущий символ</param>
        public void NewSymbol(char symbol)
        {
                for (int i = 0; i < states.Count; i++)
                {
                   foreach (var change in emptyChanges)
		       if (states[i] == change.from)
			   states[i] = change.to;
                   foreach (var change in changes)
		       if (states[i] == change.from && symbol == change.symbol)
			   states[i] = change.to;
		}
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
