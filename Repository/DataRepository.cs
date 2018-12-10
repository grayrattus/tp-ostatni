
using System;
using System.Collections.Generic;

namespace Repository
{
    public class DataRepository : IDataRepository
    {
        List<User> Users = new List<User>()
        {
          new User() { Id = Guid.NewGuid(), Age = 21, Name = "Jan", Active = true },
          new User() { Id = Guid.NewGuid(), Age = 22, Name = "Stefan", Active = false }
        };
        

        public bool addUser(User user) 
        {
            user.Id = Guid.NewGuid();
            Users.Add(user);
            return true;
        }

        public bool removeUser(User user)
        {
            Users.RemoveAll(u => (u.Id == user.Id));
            return true;
        }

        public bool updateUser(User updateUser)
        {
            User u = Users.Find( user => (user.Id == updateUser.Id));
            u.Name = updateUser.Name;
            u.Age = updateUser.Age;
            u.Active = updateUser.Active;
            return true;
        }

        public List<User> getUsers()
        {
            return Users;
        }
    }
}
