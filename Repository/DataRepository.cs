﻿
using System.Collections.Generic;

namespace WpdOstatni.Model
{
  public class DataRepository
  {
    public IEnumerable<User> User
    {
      get
      {
        List<User> Users = new List<User>()
        {
          new User() { Age = 21, Name = "Jan", Active = true },
          new User() { Age = 22, Name = "Stefan", Active = false }
        };
        return Users;
      }
    }
  }
}