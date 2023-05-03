namespace HEDGEHOGS_Test;

public class Hedgehogs
{
    public int[] ColorsCount { get; private set; } = new int[3];

    public enum Colors
    {
        Red,
        Green,
        Blue
    }

    public void SetHedgehogsOfSpecificColor(Colors color)
    {
        bool result;
        int numberOfHedgehogs;
        do
        {
            Console.WriteLine($"Please, enter numberof {color} hedgehogs: ");
            
            result = int.TryParse(Console.ReadLine(), out numberOfHedgehogs);
        }
        while (!result);

        if (numberOfHedgehogs >= 0)
        {
            ColorsCount[(int)color] = numberOfHedgehogs;
            Console.Clear();
            Print();
        }
    }

    public int GetMinNumbersOfMeetings(int neededHedgehogColor)
    {
        if (!IsHedgehogsCountCorrect(ColorsCount[(int)Colors.Red],
                                    ColorsCount[(int)Colors.Green],
                                    ColorsCount[(int)Colors.Blue]))
        {
            return -1;
        }

        int secondHedgehogColorCount = 0, thirdHedgehogColorCount = 0;

        for (int i = 0; i < ColorsCount.Length; i++)
        {
            if (i == neededHedgehogColor) continue;

            if (secondHedgehogColorCount == 0)
            {
                secondHedgehogColorCount = ColorsCount[i];
            }
            else
            {
                thirdHedgehogColorCount = ColorsCount[i];
            }
        }

        if (Math.Abs(secondHedgehogColorCount - thirdHedgehogColorCount) % 3 == 0)
        {
            if (secondHedgehogColorCount >= thirdHedgehogColorCount)
            {
                return secondHedgehogColorCount;
            }
            else
            {
                return thirdHedgehogColorCount;
            }
        }

        return -1;
    }

    private bool IsHedgehogsCountCorrect(int redHedgehogs, int greenHedgehogs, int blueHedgehogs)
    {
        if (((redHedgehogs == 0) & (greenHedgehogs == 0))
            || ((greenHedgehogs == 0) & (blueHedgehogs == 0))
            || ((blueHedgehogs == 0) & (redHedgehogs == 0)))
        {
            return false;
        }

        return true;
    }

    public void Print()
    {
        Console.Write("Number of");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(" Red ");
        Console.ResetColor();
        Console.WriteLine($"hedgehogs: {ColorsCount[(int)Colors.Red]}");

        Console.Write("Number of");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(" Green ");
        Console.ResetColor();
        Console.WriteLine($"hedgehogs: {ColorsCount[(int)Colors.Green]}");

        Console.Write("Number of");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(" Blue ");
        Console.ResetColor();
        Console.WriteLine($"hedgehogs: {ColorsCount[(int)Colors.Blue]}");
    }
}
