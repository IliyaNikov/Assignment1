using System;
using System.Collections.Generic;
using System.Linq;
using Assignment1.Data;
using Models;

namespace FileData
{
    public class UserServiceImpl : IUserService
    {
        private static IList<User> users;

        public UserServiceImpl()
        {
            users = new[]
            {
                new User
                {
                    password = "123456",
                    SecurityLevel = "1",
                    username = "Ilia"
                },
                new User
                {
                    password = "123456",
                    SecurityLevel = "1",
                    username = "Troels"
                }
            }.ToList();

        }



        public static User ValidateUser(string username, string password)
        {
            User first = users.FirstOrDefault(user => user.username.Equals(username));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return first;
        }

        User IUserService.ValidateUser(string username, string password)
        {
            return ValidateUser(username, password);
        }
    }
    
}