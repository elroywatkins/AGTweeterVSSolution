using System.Collections.Generic;

namespace AG.Common
{
    public class User : IPerson
    {
        public string Name { get; set; }
        public IList<Follower> Followers { get; set; }
    }
}