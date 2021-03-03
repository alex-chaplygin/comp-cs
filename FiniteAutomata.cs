using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compile
{
    public class FiniteAutomata
    {
        List<Change> changes;
        List<EmptyChange> emptyChanges;
        int startState;
        int[] finalStates;
        List<int> states;

        public FiniteAutomata(int start = 0)
        {
            startState = start;
            states = new List<int>();
            states.Add(start);
            changes = new List<Change>();
            emptyChanges = new List<EmptyChange>();
            finalStates = new int[] { };

        }
        public void SetFinaleStates(int[] states)
        {
            finalStates = states;
        }
        public void Add(int from, char symbol, int to)
        {
            Change change = new Change();
            change.from = from;
            change.symbol = symbol;
            change.to = to;
            changes.Add(change);
        }
        public void Add(int from, int to)
        {
            EmptyChange change = new EmptyChange();
            change.from = from;
            change.to = to;
            emptyChanges.Add(change);
        }
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
        public bool Check()
        {
            for (int i = 0; i < finalStates.Length; i++)
                foreach (var state in states)
                if (state == finalStates[i])
                     return true;
           return false;
        }
        public void Reset()
        {
            states.Clear();
            states.Add(startState);
        }
        struct Change
        {
            public int from;
            public char symbol;
            public int to;
        }

        struct EmptyChange
        {
            public int from;
            public int to;
        }
    }
}
