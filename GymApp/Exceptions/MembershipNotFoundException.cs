using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Exceptions
{
    internal class MembershipNotFoundException : Exception
    {
        public MembershipNotFoundException(string message)
        {
        }
    }
}
