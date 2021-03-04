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
	/// </summary>
        /// <param name="pat">шаблон регулярного выражения</param>
        public Pattern (string pat)
        {
            avtomat = new FiniteAvtomata();
            for (int i =0; i < pat.Length; i++)
                avtomat.Add(i, pat[i], i + 1);
            avtomat.SetFinaleStates(new int[] { pat.Length });
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
