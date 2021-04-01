using System;

namespace CompilerLibrary
{
    /// <summary>
    ///   Класс для хранения множества символов регулярных
    ///   выражений [123] [0-9] [a-z]
    /// </summary>
    class Range
    {
	/// <summary>
	///   Массив Char
	/// </summary>
        private char[] ln; 

        public Range() { }

	/// <summary>
	///   Добавляет один символ
	/// </summary>
        public void Add(char c) 
        {
            if (ln == null) //проверка на пустой массив
            {
                Array.Resize(ref ln, 1); //создаем
            }
            else
            {
                Array.Resize(ref ln, ln.Length + 1); //создаем
            }

            ln[ln.Length - 1] = c; //заносим
        }

	/// <summary>
	///   Добавляет диапазон символов, включая граничные
	/// </summary>
        public void Add(char begin, char end) 
        {
            if (char.IsNumber(begin) && char.IsNumber(end)) //если это число
            {
                lnNull(begin, end); //проверка на пустой массив
            }

            if (char.IsUpper(begin) && char.IsUpper(end)) //если это буква в верхнем регистре
            {
                lnNull(begin, end); //проверка на пустой массив
            }

            if (char.IsLower(begin) && char.IsLower(end)) //если это буква в нижнем регистре
            {
                lnNull(begin, end); //проверка на пустой массив
            }
        }

        void lnNull(char begin, char end) //Проверка на пустой массив
        {
            if (ln == null)
            {
                resNull(begin, end); //если массив пустой
            }
            else
            {
                res(begin, end); //если заполненный
            }
        }

        void resNull(char begin, char end) //Если массив пустой
        {
            Array.Resize(ref ln, 1); //создаем
            ln[ln.Length - 1] = begin; //заполняем

            for (int i = (int)begin + 1; i <= (int)end; i++) //продолжаем заполнять
            {
                Array.Resize(ref ln, ln.Length + 1); //увеличиваем размер
                ln[ln.Length - 1] = (char)i; //заполняем 
            }
        }

        void res(char begin, char end) //Если заполненный
        {
            for (int i = (int)begin; i <= (int)end; i++) //продолжаем заполнять
            {
                Array.Resize(ref ln, ln.Length + 1); //увеличиваем размер
                ln[ln.Length - 1] = (char)i; //заполняем 
            }
        }

	/// <summary>
	///   Возвращаем массив
	/// </summary>
        public char[] Get() 
        {
            return ln;
        }
    }
}
