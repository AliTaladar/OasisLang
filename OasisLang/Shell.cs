using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OasisLang
{
    internal class Shell
    {
        public Shell()
        {
            Oasis oasis = new Oasis();
            while (true)
            {
                Console.Write("Oasis > ");
                string text = Console.ReadLine();

                TokensHelper tokensHelper = oasis.Run("std:in", text);

                if (tokensHelper.error != null)
                {
                    Console.WriteLine(tokensHelper.error);
                }
                else
                {
                    Console.WriteLine("[" + string.Join(", ", tokensHelper.tokens) + "]");
                }
                Console.WriteLine();
            }
        }
    }
}
