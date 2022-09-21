using GymApp.MembershipTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.MembershipRealization
{
    internal sealed class GymAndStretchingMembershipRealization : MembershipRealization
    {
        public string Name { get; set; }
        public decimal Price { get; private set; }

        public string Description { get; private set; }

        public GymAndStretchingMembershipRealization()
        { 
        }

        public GymAndStretchingMembershipRealization(string name, decimal price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
        }

        public override string GetMembership()
        {
            string info = string.Empty;

            GymAndStretchingMembership membership = new(Price)

            {
                PurchaseDate = DateTime.Now
            };

            info = "The membership starts from " + membership.StartingOfMembership().ToString() + "\nand ends " + membership.EndingOfMembership().ToString();

            return info;
        }
        public override string ToString() => Name + Price + Description;

        public override void NotifyViaEmailAboutMembership()
        {
            GymAndStretchingMembershipRealization gymStretching = new("Gym and stretching membership: ", 130, "$ - price. " +
                        " Includes gym membership 24/7, free water and towels. " +
                        "\nPlus stretching classes 3 times a week with a coach. Attendance on Tuesdays, Fridays, Saturdays at 7 pm.");

            string info = GetMembership();

            string? usersEmail = "sasharubby336@gmail.com"; //Console.ReadLine();  //"sasharubby336@gmail.com"

            MailAddress from = new MailAddress("sasha.rudaya.99@mail.ru", "GymApp");

            MailAddress to = new MailAddress(usersEmail);

            MailMessage m = new MailMessage(from, to);

            m.Subject = "Purchasing of membership";

            m.Body = $"Hello, friend. Information about your membership: {gymStretching} {info}.";

            m.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);

            smtp.UseDefaultCredentials = false;

            smtp.Credentials = new NetworkCredential("sasha.rudaya.99@mail.ru", "euP3yzrqixtE6axGsTru");

            smtp.EnableSsl = true;

            try
            {
                smtp.Send(m);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();

            Console.WriteLine("Please, check your email to see more detailed info about your gym and stretching membership");
        }
    }
}
