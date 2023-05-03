
using HEDGEHOGS_Test;

var hedgehogs = new Hedgehogs();

hedgehogs.Print();

hedgehogs.SetHedgehogsOfSpecificColor(Hedgehogs.Colors.Red);
hedgehogs.SetHedgehogsOfSpecificColor(Hedgehogs.Colors.Green);
hedgehogs.SetHedgehogsOfSpecificColor(Hedgehogs.Colors.Blue);

bool result;
int neededHedgehogColor;
do
{
    Console.WriteLine("Please, select color!\n0 - Red\n1 - Green\n2 - Blue \nEnter number:");

    result = int.TryParse(Console.ReadLine(), out neededHedgehogColor);

    if (neededHedgehogColor < 0 || neededHedgehogColor > 2)
    {
        Console.Clear();
        hedgehogs.Print();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You entered wrong number!");
        Console.ResetColor();
        result = false;
    }
}
while (!result);

var encountersCount = hedgehogs.GetMinNumbersOfMeetings(neededHedgehogColor);
if (encountersCount >= 0)
{
    Console.WriteLine($"\nThe minimum number of encounters: {encountersCount}.");
}
else Console.WriteLine("It is impossible to change all hedgehogs to a given color!");

Console.ReadKey();
