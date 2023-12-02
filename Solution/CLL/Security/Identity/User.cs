using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public abstract class User
    {
        public User(int UserID,int communicationcenterID, string Name, string Surname, string Email, string userType)
        {
            this.communicationcenterID = communicationcenterID;
            this.UserID = UserID;
            this.Name = Name;
            this.Surname = Surname;
            this.Email = Email;
            this.UserType = userType;
        }
        public int UserID { get; }
        public int communicationcenterID { get; }
        public string Name { get; }
        public string Surname { get; }
        public string Email { get; }
        protected string UserType { get; }
    }
}
