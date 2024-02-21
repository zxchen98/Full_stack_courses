namespace CSAssignment_3;

public class WorkingWithMethod
{
    public int[] GenerateNumbers(int len)
    {
        int[] res = new int[len];
        for (int i = 0; i < len; i++)
        {
            res[i] = i;
        }

        return res;
    }

    public void Reverse(int[] arr)
    {
        int[] res = new int[arr.Length];
        int start = 0;
        int temp;
        for (int i = arr.Length - 1; i >= arr.Length/2; i--)
        {
            temp = arr[i];
            arr[i] = arr[start];
            arr[start] = temp;
            start++;
        }
        
    }

    public void PrintNumbers(int[] arr)
    {
        foreach (int i in arr)
        {
            Console.Write($"{i} ");
        }
    }

    public int Fibonacci(int num)
    {
        if (num == 1 || num == 2)
        {
            return 1;
        }
        else
        {
            return Fibonacci(num - 1) + Fibonacci(num - 2);
        }
    }
}

