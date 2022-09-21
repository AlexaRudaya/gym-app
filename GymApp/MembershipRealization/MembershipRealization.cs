using GymApp.Interfaces;
using GymApp.MembershipTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.MembershipRealization
{
    internal abstract class MembershipRealization : IEmailService
    {
        public abstract string GetMembership();

        public abstract void NotifyViaEmailAboutMembership();

    }
}
