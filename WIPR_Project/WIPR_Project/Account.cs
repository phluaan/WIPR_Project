using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPR_Project
{
    public class Account
    {
        private int id;
        private string userAccount;
        private string password;
        private string userRole;
        private int idInforUser;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string UserAccount
        {
            get { return userAccount; }
            set { userAccount = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public int IdInforUser
        {
            get { return idInforUser; }
            set { idInforUser = value; }
        }
        public string UserRole
        {
            get { return userRole; }
            set { userRole = value; }
        }
        public Account(int id, string userAccount, string password, string userRole, int idInforUser)
        {
            this.id = id;
            this.userAccount = userAccount;
            this.password = password;
            this.userRole = userRole;
            this.idInforUser = idInforUser;
        }
        public Account()
        {

        }
    }
}
