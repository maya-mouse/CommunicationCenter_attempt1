using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public class Controller
        : User
    {
        public Controller(int UserID,int communicationcenterID, string Name, string Surname, string Email)
            : base(UserID, communicationcenterID, Name, Surname, Email, nameof(Controller))
        {
        }
    }
}
