
using Repository;
using System.Collections.Generic;

namespace WpdOstatni.Model
{
    public class IDataRepository : Repository.IDataRepository
    {
        List<User> Users = new List<User>()
        {
          new User() { Id = 1, Age = 21, Name = "Jan", Active = true },
          new User() { Id = 2, Age = 22, Name = "Stefan", Active = false }
        };
        

        public bool addUser(User user) 
        {
            Users.Add(user);
            return true;
        }

        public bool removeUser(User user)
        {
            Users.Remove(user);
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
