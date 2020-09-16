using System;
using System.Collections.Generic;

class Solution
{
    private class Trie
    {
        private Dictionary<char, Trie> Chars { get; }
        private int Children { get; set; }

        public Trie()
        {
            Children = 0;
            Chars = new Dictionary<char, Trie>();
        }

        public void Insert(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return;
            }

            Children++;

            if (!Chars.ContainsKey(word[0]))
            {
                Chars.Add(word[0], new Trie());
            }

            Chars[word[0]].Insert(word.Substring(1));
        }

        public int GetCount(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return 0;
            }

            Chars.TryGetValue(word[0], out var trie);
            
            if (trie == null)
            {
                return 0;
            }

            if (word.Length == 1)
            {
                if (Chars.Count == 1)
                {
                    return Children;
                }

                return trie.Children;
            }

            return trie.GetCount(word.Substring(1));
        }
    }

    static int[] Contacts(string[][] queries)
    {
        var trie = new Trie();
        var result = new List<int>();
        
        foreach (var query in queries)
        {
            switch (query[0])
            {
                case "add":
                    trie.Insert(query[1]);
                    break;
                case "find":
                    var count = trie.GetCount(query[1]);
                    result.Add(count);
                    break;
            }
        }

        return result.ToArray();
    }

    static void Main(string[] args)
    {
        int queriesRows = Convert.ToInt32(Console.ReadLine());

        string[][] queries = new string[queriesRows][];

        for (int queriesRowItr = 0; queriesRowItr < queriesRows; queriesRowItr++)
        {
            queries[queriesRowItr] = Console.ReadLine().Split(' ');
        }

        int[] result = Contacts(queries);

        Console.WriteLine(string.Join("\n", result));

        Console.ReadKey();
    }
}
