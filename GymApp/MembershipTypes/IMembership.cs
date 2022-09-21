using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.MembershipTypes
{
    public interface IMembership
    {
        public string NameOfMembership { get; }

        public string Description { get; set; }

        public DateTime PurchaseDate { get; set; }

        public decimal GetPrice();

        public DateTime StartingOfMembership();
        public DateTime EndingOfMembership();
    }
}
