using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerLibrary
{
    /// <summary>
    ///   Лексический анализатор
    /// </summary>
    public class Lexer
    {
	/// <summary>
	///   текущая строка для лексического разбора
	/// </summary>
        string lexString;
	/// <summary>
	///   шаблоны лексем
	/// </summary>	
        List<Pattern> patterns;
	/// <summary>
	///  лексемы
	/// </summary>
        List<int> lexs;
	/// <summary>
	///  разделители
	/// </summary>
        string separators;

	/// <summary>
	///   Создает лексический анализатор
	/// </summary>
        /// <param name="s">строка для разбора</param>
        /// <param name="sep">строка разделителей между лексемами</param>
        public Lexer(string s, string sep = " \t\n")
        {
            lexString = s;
            patterns = new List<Pattern>();
            lexs = new List<int>();
	    separators = sep;
        }

	/// <summary>
	///   Устанавливает строку для разбора
	/// </summary>
        /// <param name="s">строка для разбора</param>
        public void SetString(string s)
        {
            lexString = s;
        }

	/// <summary>
	///   Добавляет лексему
	/// </summary>
        /// <param name="lex">лексема</param>
        /// <param name="pat">шаблон для лексемы (регулярное выражение)</param>
        public void Add(int lex, string pat)
        {
            patterns.Add(new Pattern(pat));
            lexs.Add(lex);
        }

	/// <summary>
	///   Разбирает текущую лексему из строки и удаляет ее
	/// </summary>
        /// <returns>номер распознанной лексемы, -1 если неуспешное распознавание</returns>
        public int GetToken()
        {
	    int j;
	    int k;
	    for (j = 0; j < lexString.Length; j++)
	    {
		for (k = 0; k < separators.Length; k++)
		    if (lexString[j] == separators[k]) break;
		if (k == separators.Length) break;
	    }
	    lexString = lexString.Substring(j);
            for (int i = 0; i < patterns.Count; i++)
            {
                Pattern pattern = patterns[i];
                int result = pattern.Match(lexString);

                if (result != -1)
                {
                    lexString = lexString.Substring(result + 1);
                    return lexs[i];
                }
            }
            return -1;
        }
    }
}
