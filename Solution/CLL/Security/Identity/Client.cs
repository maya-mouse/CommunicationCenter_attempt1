using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public class Client
       : User
    {
        public Client(int UserID, int communicationcenterID, string Name, string Surname, string Email) 
            : base(UserID, communicationcenterID ,Name, Surname, Email, nameof(Client))
        {
        }
    }
}
