using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.MembershipTypes
{
    internal sealed class GymAndStretchingMembership : IMembership
    {
        private readonly string _name;

        private readonly decimal _price;

        public string Description { get; set; }

        public DateTime PurchaseDate { get; set; }

        public GymAndStretchingMembership(decimal price)
        {
            _name = "Gym + Stretching membership";
            _price = price;
        }

        public string NameOfMembership => _name;

        public decimal GetPrice() => _price;

        public DateTime StartingOfMembership()
        {
            Console.Write($"Your membership starts from {PurchaseDate}");
            return PurchaseDate;
        }
        public DateTime EndingOfMembership()
        {
            int durationOfMembership = 30;

            var duration = PurchaseDate.AddDays(durationOfMembership);
            Console.WriteLine($"\tand ends {duration}");
            return duration;
        }
    }
}
