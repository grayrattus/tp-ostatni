using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpdOstatni.Model;

namespace Repository
{
    interface IDataRepository
    {
        bool addUser(User addUser);
        bool removeUser(User addUser);
        bool updateUser(User updateUser);
        List<User> getUsers();
    }
}
