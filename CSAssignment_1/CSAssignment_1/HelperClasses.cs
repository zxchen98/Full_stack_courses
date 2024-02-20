
using System.Numerics;

namespace CSAssignment_1;

public class HelperClasses
{
    public void Qa()
    {
        Console.WriteLine("Tell me your name?");
        string name = Console.ReadLine();
        Console.WriteLine("Tell me your age?");
        string age = Console.ReadLine();
        Console.WriteLine($"Your user name is {name}{age}");
    }

    public void TypeSize()
    {
        Console.WriteLine($"sbyte's size, minvalue, maxvalue are: {sizeof(sbyte)} {sbyte.MinValue} {sbyte.MaxValue}");
        Console.WriteLine($"byte's size, minvalue, maxvalue are: {sizeof(byte)} {byte.MinValue} {byte.MaxValue}");
        Console.WriteLine($"short's size, minvalue, maxvalue are: {sizeof(short)} {short.MinValue} {short.MaxValue}");
        Console.WriteLine($"ushort's size, minvalue, maxvalue are: {sizeof(ushort)} {ushort.MinValue} {ushort.MaxValue}");
        Console.WriteLine($"int's size, minvalue, maxvalue are: {sizeof(int)} {int.MinValue} {int.MaxValue}");
        Console.WriteLine($"uint's size, minvalue, maxvalue are: {sizeof(uint)} {uint.MinValue} {uint.MaxValue}");
        Console.WriteLine($"long's size, minvalue, maxvalue are: {sizeof(long)} {long.MinValue} {long.MaxValue}");
        Console.WriteLine($"ulong's size, minvalue, maxvalue are: {sizeof(ulong)} {ulong.MinValue} {ulong.MaxValue}");
        Console.WriteLine($"float's size, minvalue, maxvalue are: {sizeof(float)} {float.MinValue} {float.MaxValue}");
        Console.WriteLine($"double's size, minvalue, maxvalue are: {sizeof(double)} {double.MinValue} {double.MaxValue}");
        Console.WriteLine($"decimal's size, minvalue, maxvalue are: {sizeof(decimal)} {decimal.MinValue} {decimal.MaxValue}");
    }

     public void ConvertCenturies(uint centuries, out uint years, out uint days, out uint hours, 
         out ulong minutes, out ulong seconds, out ulong milliseconds, out ulong microseconds, out BigInteger nanoseconds)
     {
         years = centuries * 100;
         days = years * 365;
         hours = days * 24;
         minutes = hours * 60;
         seconds = minutes * 60;
         milliseconds = seconds * 1000;
         microseconds = milliseconds * 1000;
         nanoseconds = microseconds * 1000;
     }
}

public class PlayWithLoops
{
    public void FissBuzz()
    {
        for (int i = 1; i < 100; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("FissBuzz");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(i);
            }
        }
    }

    public enum guess
    {
        low,
        high,
        correct,
        outofbound
    }

    public guess GuessNumber()
    {
        int correctNumber = new Random().Next(3) + 1;
        Console.WriteLine("Please guess a number from 1 to 3");
        int guessedNumber = int.Parse(Console.ReadLine());
        while (guessedNumber != correctNumber)
        {
            if (guessedNumber < 1 || guessedNumber > 3)
            {
                Console.WriteLine(guess.outofbound);
            }

            else if (guessedNumber < correctNumber)
            {
                Console.WriteLine(guess.low);
            }
            else
            {
                Console.WriteLine(guess.high);
            }

            Console.WriteLine("Guess again");
            guessedNumber = int.Parse(Console.ReadLine());
        }

        return guess.correct;
    }

    public void PrintPyrmid(int lvl)
    {
        int numSpaces = lvl-1;
        int numStars = 1;
        for (int i = 0; i < lvl; i++)
        {
            for (int j = numSpaces; j >= 0; j--)
            {
                Console.Write(" ");
            }

            for (int k = 0; k < numStars; k++)
            {
                Console.Write("*");
            }

            numSpaces -= 1;
            numStars += 2;
            Console.WriteLine();
        }

    }
    
    public void DaysOld(DateTime birthday)
    {
        DateTime now = DateTime.Today;
        int daysOld = (now - birthday).Days;
        Console.WriteLine($"You are now {daysOld} days' old");
        int daysToNextAnniversary = 10000 - (daysOld % 10000);
        Console.WriteLine($"Your next 10000 day anniversary is {now.AddDays(daysToNextAnniversary)}");
    }

    public void Greetings()
    {
        int current = DateTime.Now.Hour;

        if (current >= 6 && current < 12)
        {
            Console.WriteLine("Good Morning");
        }
        else if (current >= 12 && current < 16)
        {
            Console.WriteLine("Good Afternoon");
        }
        else if (current >= 16 && current < 21)
        {
            Console.WriteLine("Good Evening");
        }
        else
        {
            Console.WriteLine("Good Night");
        }
    }

    public void CountWithSteps()
    {
        for (int i = 1; i < 5; i++)
        {   
            Console.Write("0");
            for (int j = i; j < 25; j += i)
            {
                Console.Write($",{j}");
            }
            Console.Write("\n");
        }
    }
}
