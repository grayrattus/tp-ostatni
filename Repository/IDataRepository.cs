using System.Collections.Generic;

namespace Repository
{
    public interface IDataRepository
    {
        bool addUser(User addUser);
        bool removeUser(User addUser);
        bool updateUser(User updateUser);
        List<User> getUsers();
    }
}
