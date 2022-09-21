using GymApp.MembershipRealization;
using Spectre.Console;
using GymApp.Exceptions;
using GymApp.Logger;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("---------- Hey, welcome to our gym app! ----------");
        Console.WriteLine("--------------------------------------------------\n");

        #region Call the membership list

        Console.WriteLine("Take a look at our list of memberships:\n");

        MembershipList.GetMembershipList();

        Logger.WriteLog(Logger.Level.Info, MethodBase.GetCurrentMethod(), "Structured info about memberships");

        //MembershipList list = new();

        //Console.WriteLine(list.jsonData);

        //string path = @"membershipList.json";
        //File.WriteAllText(path, list.jsonData);

        #endregion

        Console.WriteLine();

        Console.WriteLine("Let's decide on exact type of membership!");

        #region Choosing the membership

        var table = new Table();

        table.AddColumn("[Aqua]What kind of membership do you wanna purchase?[/]");

        Console.WriteLine();

        table.AddRow("Tap =>  1  to create Gym membership");
        table.AddEmptyRow();

        table.AddRow("Tap =>  2  to create Gym + Yoga membership");
        table.AddEmptyRow();

        table.AddRow("Tap =>  3  to create Gym + Stretching membership");
        table.AddEmptyRow();

        table.AddRow("Tap =>  4  to create Gym + Personal trainigs\n");

        table.BorderColor(Color.Aqua);

        AnsiConsole.Write(table);

        #endregion

        #region Info about choosen membership

        Console.WriteLine();
        Console.Write("Your choice is: ");

        string? outputMembership = Console.ReadLine();
        Console.WriteLine();

        try
        {
            MembershipRealization realization = GetTypeOfMembership(outputMembership);

            Console.WriteLine("Membership created:\n");
            Console.WriteLine(realization);

            realization.NotifyViaEmailAboutMembership();
        }
        catch (MembershipNotFoundException ex)
        {
            Console.WriteLine($"Incorrect output: {outputMembership}");

            Console.WriteLine("Error. Please, try again!");

            Logger.WriteLog(Logger.Level.Error, MethodBase.GetCurrentMethod(), "There is no such type of membership. Please, try again!");
        }

        #endregion

    }

    private static MembershipRealization? GetTypeOfMembership(string outputMembership) =>

        outputMembership switch
        {
            var i when i.Equals("1") => new GymMembershipRealization("Gym - ", 50, "$. Gym membership 24/7."),
            var i when i.Equals("2") => new GymAndYogaMembershipRealization("Gym and yoga - ", 130, "$. Gym 24/7 and yoga twice a week"),
            var i when i.Equals("3") => new GymAndStretchingMembershipRealization("Gym and stretching - ", 130, "$. Gym 24/7 and stretching 3 times a week"),
            var i when i.Equals("4") => new GymAndPersonalTrainingsRealization("Gym and personal trainings - ", 350, "$. Gym 24/7 and personal trainings 3 times a week"),
            _ => throw new MembershipNotFoundException("Incorrect output")
        };
}