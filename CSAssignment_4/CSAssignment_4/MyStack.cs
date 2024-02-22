namespace CSAssignment_4;

public class MyStack<T>
{
    private List<T> stack { get; set; }

    public MyStack()
    {
        stack = new List<T>();
    }

    public int Count()
    {
        return this.stack.Count;
    }

    public void Push(T obj)
    {
        this.stack.Add(obj);
    }

    public T? Pop()
    {
        if (this.stack.Count == 0)
        {
            Console.WriteLine("this stack is empty");
            return default(T?);
        }
        else
        {
            T a = this.stack[stack.Count - 1];
            this.stack.RemoveAt(stack.Count-1);
            return a;
        }
    }
}