using System.Text;

namespace CSAssignment_2;

public class PracticeArrays
{
    public void CopyArr(int[] ori, ref int[] tocopy)
    {
        for (int i = 0; i < ori.Length; i++)
        {
            tocopy[i] = ori[i];
        }
    }

    public void ShopList()
    {
        List<String> lst = new List<string>();
        while (true)
        {
            Console.WriteLine("Enter command (+ item, - item, or -- to clear):");
            string input = Console.ReadLine();
            if (input == "--")
            {
                Console.WriteLine("clearing the list");
                lst = new List<string>();
                continue;
            }
            if (input.StartsWith("+"))
            {
                lst.Add(input.Substring(2));
            }
            else if (input.StartsWith("-"))
            {
                lst.Remove(input.Substring(2));
            }

            Console.WriteLine("Your shop list has been updated");
            foreach (string i in lst)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("");
        }
    }

    public bool Prime(int num)
    {
        if (num == 2)
        {
            return true;
        }

        if (num % 2 == 0)
        {
            return false;
        }
        int limit = (int)Math.Ceiling(Math.Sqrt(num));
        for (int i = 3; i <= limit; ++i)
        {
            if (num % i == 0)
            {
                return false;
            }
        }
        return true;
    }
    public void FindPrime(int start, int end)
    {
        List<int> sofar = new List<int>();
        for (int i = start; i <= end; i++)
        {
            if (Prime(i))
            {
                sofar.Add(i);
            }
        }

        foreach (int i in sofar)
        {
            Console.Write($"{i},");
        }
    }

    public void RotateSum(int[] arr, int k)
    {
        int[] res = new int[arr.Length];
        int cycles = k / arr.Length;
        int remains = k % arr.Length;
        int total = arr.Sum();
        for (int i = 0; i < arr.Length; i++)
        {
            res[i] += total*cycles;
            for (int j = 0; j < remains; j++)
            {
                int pos = (i + arr.Length - j - 1) % arr.Length;
                res[i] += arr[pos];
            }
        }

        foreach (int i in res)
        {
            Console.Write($"{i},");
        }
    }

    public void longestSeq(int[] arr)
    {
        int longestLen = 0;
        int longestStart = 0;
        int longestEnd = 1;
        int start = 0;
        int end = 1;
        int cur = 1;

        while (end < arr.Length)
        {
            if (arr[end] != arr[start])
            {
                start = end;
                end += 1;
                cur = 1;
            }
            else
            {
                if (cur>longestLen)
                {
                    longestLen = cur;
                    longestStart = start;
                    longestEnd = end;
                }

                cur += 1;
                end += 1;
            }
        }

        for (int i = longestStart; i <= longestEnd; i++)
        {
            int idx = arr[i];
            Console.Write($"{idx} ");
        }
    }

    public void MostFreq(int[] arr)
    {
        Dictionary<int, int> freq = new Dictionary<int, int>();
        for (int i = 0; i < arr.Length; i++)
        {
            if (freq.ContainsKey(arr[i]))
            {
                freq[arr[i]]++;
            }
            else
            {
                freq[arr[i]] = 1;
            }
        }

        int maxFreq = freq.Values.Max();

        foreach (int i in freq.Keys)
        {
            if (freq[i] == maxFreq)
            {
                Console.Write($"{i} ");
            }
        }
    }
}

public class PracticeString
{
    public void Reverse()
    {
        Console.WriteLine("Input your string");
        string str = Console.ReadLine();
        char[] arr = str.ToCharArray();
        Array.Reverse(arr);
        string reversed = new string(arr);

        for (int i = 0; i<arr.Length; i++)
        {
            Console.Write($"{arr[i]} ");
        }
    }

    public void ReverseSentence(string str)
    {
        StringBuilder strb = new StringBuilder(str);
        char[] delimeters = new char[]{',','.',':',';','=','(',')','&','[',']','"','\\','/','?','!'};
        List<List<object>> indexs = new List<List<object>>();
        string[] tokens = str.Split(' ');
        
        for (int i = 0; i < tokens.Length; i++)
        {
            bool startWord = false;
            for (int j = 0; j < tokens[i].Length; j++)
            {
                if (delimeters.Contains(tokens[i][j]))
                {
                    indexs.Add(new List<object>() { i, startWord, tokens[i][j] });
                    continue;
                }

                startWord = true;
            }
            for (int j = 0; j < delimeters.Length; j++)
            {
                tokens[i]=tokens[i].Replace(delimeters[j].ToString(), "");
            }
        }
        Array.Reverse(tokens);
        for (int i = 0; i < indexs.Count; i++)
        {
            int widx = (int)indexs[i][0];
            bool cidx = (bool)indexs[i][1];
            char deli = (char)indexs[i][2];
            
            if (cidx)
            {
                tokens[widx] = tokens[widx] + deli;
            }
            else
            {
                tokens[widx] = deli + tokens[widx];
            }
        }

        Console.WriteLine(String.Join(" ", tokens));

    }

    public bool isPalindrom(string str)
    {
        int i = 0;
        int j = str.Length-1;
        while (j > i)
        {
            if (!str[i].Equals(str[j]))
            {
                return false;
            }

            i += 1;
            j -= 1;
        }
        return true;
    }

    public void extractPalindrom(string str)
    {
        List<string> res = new List<string>();
        string[] tokens = str.Split(' ', ',');
        char[] delimeters = new char[]{',','.',':',';','=','(',')','&','[',']','"','\\','/','?','!'};

        for (int i = 0; i < tokens.Length; i++)
        {
            for (int j = 0; j < delimeters.Length; j++)
            {
                tokens[i]=tokens[i].Replace(delimeters[j].ToString(), "");
            }

            if (isPalindrom(tokens[i]))
            {
                res.Add(tokens[i]);
            }
        }

        String[] newres = res.ToArray();
        Array.Sort(newres);
        foreach (string i in newres)
        {
            Console.Write($"{i}, ");
        }
    }

    public void ParseURL(string str)
    {
        int http = str.IndexOf("://");
        string serverStr = "";
        if (http != -1)
        {
            serverStr = str.Substring(http+3);
            Console.WriteLine($"[Protocol] =  {str.Substring(0, http)}");
        }
        else
        {
            serverStr = str;
            Console.WriteLine($"[Protocol] =  ''");
        }
        
        int server = serverStr.IndexOf("/");
        if (server != -1)
        {
            Console.WriteLine($"[Server] = {serverStr.Substring(0, server)}");

            Console.WriteLine($"[Resource] = {serverStr.Substring(server + 1)}");
        }
        else
        {
            Console.WriteLine($"[Server] = {serverStr}");

            Console.WriteLine($"[Resource] = ''");
        }

    }
}