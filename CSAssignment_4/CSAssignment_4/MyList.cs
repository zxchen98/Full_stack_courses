namespace CSAssignment_4;

public class MyList<T>
{
    private List<T> list { set; get; }

    public MyList()
    {
        list = new List<T>();
    }

    public void Add(T item)
    {
        list.Add(item);
    }

    public T Remove(int index)
    {
        T a = list[index];
        list.RemoveAt(index);
        return a;
    }

    public bool Contains(T item)
    {
        foreach (T i in list)
        {
            if (item.Equals(i))
            {
                return true;
            }
        }

        return false;
    }

    public void Clear()
    {
        this.list.Clear();
    }

    public void InsertAt(T item, int index)
    {
        list.Insert(index,item);
    }

    public void DeleteAt(int index)
    {
        list.RemoveAt(index);
    }

    public T Find(int index)
    {
        return list[index];
    }
}