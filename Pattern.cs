using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerLibrary
{
    /// <summary>
    /// Класс распознавания по шаблонам регулярных выражений
    /// </summary>
    public class Pattern
    {
	/// <summary>
	/// Конечный автомат для распознавания
	/// </summary>
        FiniteAutomata avtomat;
	
	/// <summary>
	/// По регулярному выражению создается конечный автомат
	/// "abc" 0 ---a----> 1 ---b----> 2 ---c--->3
	/// "a*b" 0 ----->1----b--->2    1--a->1
	/// </summary>
        /// <param name="pat">шаблон регулярного выражения</param>
        public Pattern (string pat)
        {
            avtomat = new FiniteAutomata();
            int i = 0;
            int state = 0;
            while (i < pat.Length)
            {
                if (i + 1 < pat.Length && pat[i + 1] == '*')
                {
                    avtomat.Add(state, state + 1);
                    avtomat.Add(state + 1, pat[i], state + 1);
                    i += 2;
                }
                else
                {
                    avtomat.Add(state, pat[i], state + 1);
                    i++;
                }
                state++;
            }         
            avtomat.SetFinaleStates(new int[] { state });
        }
	
	/// <summary>
	/// Сопоставление строки с шаблоном регулярного выражения
	/// </summary>
        /// <param name="s">строка для распознавания</param>
        /// <returns>true - строка соответствует шаблону, false - не соответствует</returns>
        public bool Match(string s)
        {
            avtomat.Reset();
            foreach (var c in s)
                avtomat.NewSymbol(c);
            return avtomat.Check();
        }
    }
}
