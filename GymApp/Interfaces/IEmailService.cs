using GymApp.MembershipRealization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Interfaces
{
    internal interface IEmailService
    {
        public void NotifyViaEmailAboutMembership();
    }
}
