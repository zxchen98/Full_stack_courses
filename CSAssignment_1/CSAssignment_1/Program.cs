// See https://aka.ms/new-console-template for more information
using CSAssignment_1;
using System.Numerics;

// Playing with Console APP
HelperClasses play = new HelperClasses();
play.Qa();

//q1
play.TypeSize();

//q2
Console.WriteLine("Please input how many centuries you want to convert");
uint centuries = uint.Parse(Console.ReadLine());
play.ConvertCenturies(centuries, out uint years, out uint days, out uint hours,
    out ulong minutes, out ulong seconds, out ulong milliseconds, out ulong microseconds, out BigInteger nanoseconds);
Console.WriteLine($"{centuries} centuries equals to {years} years, {days} days, {hours} hours, {minutes} minutes," +
                  $"{seconds} seconds, {milliseconds} milliseconds, {microseconds} microseconds, {nanoseconds} nanoseconds");


// Practice Loops and Operators

//q1-fizzBuzz
PlayWithLoops playLoops = new PlayWithLoops();
playLoops.FissBuzz();

//The following code will end up in a infinite loop because byte type can not go over 255 and will
// go back to 0 and thus the loop will never ends
// int max = 500;
// for (byte i = 0; i < max; i++)
// {
//     Console.WriteLine(i);
// }


//q2 print-a-pyrmid
playLoops.PrintPyrmid(8);

//q3
Console.WriteLine(playLoops.GuessNumber());

//q4
DateTime birthday = new DateTime(1998, 5, 21);
playLoops.DaysOld(birthday);

//q5
playLoops.Greetings();

//q6
playLoops.CountWithSteps();
