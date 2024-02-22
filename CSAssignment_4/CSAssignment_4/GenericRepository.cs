namespace CSAssignment_4;

public interface IRepository<T> where T:class
{
    void Add(T item);
    void Remove(T item);
    void Save();
    IEnumerable<T> GetAll();
    T GetById(int id);
}

public class Student
{
    public int Id { get; set; }
    public string studentName { get; set; }
    public double gpa { get; set; }

    public void introduce()
    {
        Console.WriteLine($"Hi, my name is {studentName} and my GPA is {gpa}.");
    }
}

public class GenericRepository : IRepository<Student>
{
    public List<Student> objs = new List<Student>();

    public void Add(Student std)
    {
        objs.Add(std);
    }

    public void Remove(Student std)
    {
        objs.Remove(std);
    }

    public void Save()
    {
        Console.WriteLine("your data has been saved");
    }

    public IEnumerable<Student> GetAll()
    {
        return objs;
    }

    public Student GetById(int id)
    {
        foreach (Student i in objs)
        {
            if (i.Id == id)
            {
                return i;
            }
        }

        return null;
    }
    
}