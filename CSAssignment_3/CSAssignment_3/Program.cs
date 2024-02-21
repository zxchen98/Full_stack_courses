// //Working with methods
using CSAssignment_3;
//
//Working with methods
//Please find the detailed implementation in WorkingWithMethod.cs
//Here only shows methods call
WorkingWithMethod wm = new WorkingWithMethod();
int[] numbers = wm.GenerateNumbers(10);
wm.Reverse(numbers);
wm.PrintNumbers(numbers);

//Fibonacci sequence
for (int i = 1; i <= 10; i++)
{
    Console.Write($"{wm.Fibonacci(i)} ");
}

//Designing and Building Classes using OOP
//Please find detailed Class implementation in Person.cs
//Below are some examples that use those classes
Student a = new Student("zxc", "zxc@gmail.com", 15);
Course math = new Course("math");
Course english = new Course("English");
Course history = new Course("history");
a.TakeClass(math);
math.ShowStudents();

a.TakeClass(english);
english.ShowStudents();

a.TakeExam(math,"B");
a.CalculateGPA();
a.TakeExam(english,"A");
a.CalculateGPA();

Instructor lee = new Instructor("lee", "lee@gmail.com", 38);
lee.IntroduceMyself();
math.instructor = lee;
lee.CalculateBonus();
Department cse = new Department("cse");
cse.AssignDepartmentLead(lee);

//Color Class questions
Color ac = new Color(23,65,255);
Color bc = new Color(34,53,254,245);
ac.grayScale();
ac.green = 255;
ac.grayScale();

Ball ball = new Ball();
ball.color = ac;
ball.thrown();
ball.thrown();
ball.Pop();
ball.thrown();