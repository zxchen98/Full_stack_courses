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
}