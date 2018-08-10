using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;

namespace ClasesDePalabras
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream pb = new FileStream(@"D:\AnalisisPalabrasAPF\InventarioNOK.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(pb, System.Text.Encoding.GetEncoding("iso-8859-1"));
            string palabras = sr.ReadToEnd();
            sr.Close();
            pb.Close();

            var myRegex = new Regex(@"[a-zA-ZáéíóúÁÉÍÓÚÑñüÜÇç]+");
            MatchCollection AllMatches = myRegex.Matches(palabras);
            List<int> matchList = new List<int>();

            if (AllMatches.Count > 0)
            {
                foreach (Match someMatch in AllMatches)
                {
                    int editDist = LevenshteinDistance.LevenshteinD(someMatch.Groups[0].Value, "vehículo");
                    if (editDist < 3)
                    {
                        Console.WriteLine(someMatch.Groups[0].Value + " " + editDist);
                    }
                }
            }

            Console.ReadKey();


            var trie = new SimplePrefixTrie(); // or new SimpleCompressedPrefixTrie();
            trie.AddWord("hello");
            trie.AddWord("iced");
            trie.AddWord("i");
            trie.AddWord("ice");
            trie.AddWord("icedt");
            trie.AddWord("icecone");
            trie.AddWord("dtgg");
            trie.AddWord("hicet");
            trie.AddWord("avogadroicedtggsinazucar");
            trie.AddWord("avogadroiicedtggsinazucar");
            trie.AddWord("avogadroiícedtggsinazucar");
            trie.AddWord("avogadroiecdtggsinazucar");
            trie.AddWord("avogadroiceedtggsinazucar");
            foreach (var w in trie.FindWordsMatchingPrefixesOf("icedtgg"))
                Console.WriteLine(w);

            Console.WriteLine("Fin");
            Console.ReadKey();
        }
    }
}
