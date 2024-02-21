namespace CSAssignment_3;
// Interfaces begins here
public interface IPersonService
{
    int CalculateAge();
    decimal CalculateSalary();
}

public interface IStudentService : IPersonService
{
    double CalculateGPA();
}

public interface IInstructorService : IPersonService
{
    decimal CalculateBonus();
}

// Classes begins here
// The person base class
public abstract class Person{
    public string name { get; set; }
    public string email { get; set; }
    public int age { get; set; }
    public decimal salary { get; set; }
    protected string[] address { get; set; }
    public abstract void IntroduceMyself();

    public virtual void SalayCalc()
    {
    }
}
// The course class
public class Course
{
    public string name { get; set; }
    public Instructor instructor { get; set; }
    private List<Student> students;

    public Course(string name)
    {
        this.name = name;
        this.students = new List<Student>();
    }

    public void EnrollStudent(Student sd)
    {
        this.students.Add(sd);
        sd.courses.Add(this);
        Console.WriteLine($"{this.name} now enrolled {sd.name}");
    }

    public void ShowStudents()
    {
        Console.WriteLine($"{this.name}: ");
        foreach (Student sd in this.students)
        {
            Console.WriteLine($"{sd.name} ");
        }
    }
}
// The department class
public class Department
{
    public string name { get; set; }
    public Instructor head { get; private set; }
    public decimal budge { get; set; }

    public Department(string name)
    {
        this.name = name;
        this.budge = 5000m;
    }

    public void AssignDepartmentLead(Instructor ins)
    {
        this.head = ins;
        Console.WriteLine($"The head of this {this.name} department is {this.head}!");
    }
}
// The student class derived from Person and implement IStudentService
public class Student : Person, IStudentService
{
    private double gpa;
    public List<Course> courses { get; set; }
    public Dictionary<Course, string> grades;
    
    public Student(string name, string email,int age)
    {
        this.name = name;
        this.email = email;
        this.age = age;
        this.gpa = 4.0;
        this.courses = new List<Course>();
        this.grades = new Dictionary<Course, string>();
    }

    public override void IntroduceMyself()
    {
        Console.WriteLine($"Hi, my name is {this.name} I am {this.age} years' old student");
    }

    public int CalculateAge()
    {
        return this.age;
    }

    public decimal CalculateSalary()
    {
        return 0m;
    }
    
    public double CalculateGPA()
    {
        Dictionary<string, double> gpaTable = new Dictionary<string, double>()
        {
            {"A",4.0},
            {"B",3.0},
            {"C",2.0},
            {"F",0}
        };
        foreach (Course c in grades.Keys)
        {
            this.gpa = (this.gpa + gpaTable[grades[c]]) / 2;
        }
        Console.WriteLine($"Your calculated gpa is {this.gpa}");
        return this.gpa;
    }

    public void TakeExam(Course course,string grade)
    {
        if (this.courses.Contains(course))
        {
            this.grades[course] = grade;
        }
        else
        {
            Console.WriteLine("You have not taken that class");
        }
    }
    public void TakeClass(Course course)
    {
        this.courses.Add(course);
        course.EnrollStudent(this);
    }
}

// The Instructor class derived from Person class and implement IInstructorService interface
public class Instructor : Person, IInstructorService
{
    public int yearsJoined { set; get; }
    public Department dpt { get; set; }
        
    public Instructor(string name, string email, int age)
    {
        this.name = name;
        this.email = email;
        this.age = age;
        this.salary = 5000m;
        this.yearsJoined = 0;
    }

    public override void IntroduceMyself()
    {
        Console.WriteLine($"Hi, I am an instructor called {this.name}");
    }

    public decimal CalculateBonus()
    {
        decimal bonus = this.salary * (decimal)Math.Pow(1.25,this.yearsJoined);
        Console.WriteLine($"Your bonus is {bonus}");
        return bonus;
    }

    public int CalculateAge()
    {
        return this.age;
    }

    public decimal CalculateSalary()
    {
        return this.salary;
    }
}