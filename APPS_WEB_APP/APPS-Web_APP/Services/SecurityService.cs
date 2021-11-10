using APPS_Web_APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APPS_Web_APP.Services
{
    //Creating new UsersDAO object for checking login
  
    public class SecurityService
    {
        UsersDAO usersDAO = new UsersDAO();
        public SecurityService()
        {

        }

        public bool IsValid(User user)
        {
            return usersDAO.FindUserByNameAndPassword(user);
        }

        public void AddUser(User user)
        {
            usersDAO.AddUser(user);
        }

        public bool checkManager(User user)
        {
           return usersDAO.checkManager(user);
        }



    }
}
