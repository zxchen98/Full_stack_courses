// See https://aka.ms/new-console-template for more information
using CSAssignment_4;

// MyStack<int> my = new MyStack<int>();
// my.Push(1);
// my.Push(3);
// Console.WriteLine($"the count is {my.Count()}");
// my.Push(7);
// Console.WriteLine($"the last item is {my.Pop()}");
// Console.WriteLine($"the count is {my.Count()}");

// MyList<int> newLs = new MyList<int>();
// newLs.Add(4);
// newLs.InsertAt(1,0);
// Console.WriteLine($"the item in index 0 is {newLs.Find(0)}");

Student a = new Student();
a.Id = 1;
Student b = new Student();
b.Id = 2;

GenericRepository gr = new GenericRepository();
gr.Add(a);
gr.Add(b);
Console.WriteLine(gr.GetById(1));