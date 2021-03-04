using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compile
{
    class Pattern
    {
        FiniteAvtomata avtomat;
        public Pattern (string pat)
        {
            avtomat = new FiniteAvtomata();
            for (int i =0; i<pat.Length;i++)
                avtomat.Add(i, pat[i], i + 1);
            avtomat.SetFinaleStates(new int[] { pat.Length });
        }
	
        public bool Match(string s)
        {
            avtomat.Reset();
            foreach (var c in s)
                avtomat.NewSymbol(c);
            return avtomat.Check();
        }
    }
}
