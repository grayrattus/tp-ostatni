//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

namespace WpdOstatni.Model
{
  /// <summary>
  /// Class User - a class representing user
  /// </summary>
  public class User
  {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Active { get; set; }
        public override string ToString()
        {
            return Name + " " + Age + " " + Active;
        }
    }
}
