using System.Diagnostics.Metrics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace inlämningsuppgift
{

    internal class Program
    {
        
        
        static void Main(string[] args)
        {
            Console.Title = "Searcher";
            header();
            matchSearcher();
        }


        static void matchSearcher()
        {
            decimal total = 0;

            Console.WriteLine("Enter a string containing letters and numbers to search for matches: \n");
            string theString = Console.ReadLine();

            

            for (char number = '0'; number <= '9'; number++)
            {
                string pattern = $@"{number}([^a-zA-Z{number}]*){number}";
                MatchCollection matches = Regex.Matches(theString, pattern);

                if (matches.Count > 0)
                    foreach(Match match in matches)
                    {
                        string searchMatch = match.Value;
                        decimal numberMatch;

                        if (decimal.TryParse(searchMatch, out numberMatch))
                        {
                            total += numberMatch;
                        }

                        string beforeMatch = theString.Substring(0, match.Index);
                        string afterMatch = theString.Substring(match.Index + match.Length);

                        Console.WriteLine();
                        Console.Write(beforeMatch);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(match.Value);
                        Console.ResetColor();
                        Console.Write(afterMatch);

                    }
            }
            
            Console.WriteLine($"\n\nTotal of all the matches is: {total}");
            Console.ReadKey();
        }




        static void header()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("******************************************************************");
            Console.WriteLine(@"*███████╗███████╗ █████╗ ██████╗  ██████╗██╗  ██╗███████╗██████╗ *
*██╔════╝██╔════╝██╔══██╗██╔══██╗██╔════╝██║  ██║██╔════╝██╔══██╗*
*███████╗█████╗  ███████║██████╔╝██║     ███████║█████╗  ██████╔╝*
*╚════██║██╔══╝  ██╔══██║██╔══██╗██║     ██╔══██║██╔══╝  ██╔══██╗*
*███████║███████╗██║  ██║██║  ██║╚██████╗██║  ██║███████╗██║  ██║*
*╚══════╝╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝*
******************************************************************
");
            
            Console.ResetColor();
        }




        
    }
}