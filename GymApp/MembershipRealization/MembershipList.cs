using GymApp.MembershipTypes;
using Newtonsoft.Json;
using Spectre.Console;
using System.Collections.Generic;

namespace GymApp.MembershipRealization
{
    internal sealed class MembershipList
    {
        public static List<MembershipRealization> GetMembershipList()
        {
            List<MembershipRealization> collection = new List<MembershipRealization>()
            {
                new GymMembershipRealization("Gym membership:\n", 50, "$ - price. Includes gym membership 24/7, free water and towels."),
                new GymAndYogaMembershipRealization("Gym and yoga membership:\n", 130, "$ - price.  Includes gym membership 24/7, free water and towels. " +
            "\nPlus yoga classes twice a week with a coach."),
                new GymAndStretchingMembershipRealization("Gym and stretching membership:\n", 130, "$ - price. Includes gym membership 24/7, free water and towels." +
            "\nPlus stretching classes 3 times a week with a coach."),
                new GymAndPersonalTrainingsRealization("Gym and personal trainigs membership:\n", 350, "$ - price. Includes gym membership 24/7, free water and towels." +
            "\nPlus personal trainigs 3 times a week with a coach.")
            };

            var table = new Table();

            table.AddColumn("[Aqua]Membership List[/]");

            char i = '1';

            foreach (MembershipRealization item in collection)
            {
                table.AddRow($"{i}. {item}");
                table.AddEmptyRow();

                i++;
            }

            table.BorderColor(Color.Aqua);

            AnsiConsole.Write(table);

            return collection;
        }

        public string jsonData = JsonConvert.SerializeObject(GetMembershipList(), Formatting.Indented);
    }
}