using AG.Common;
using System.Collections.Generic;
using System.Linq;
using AG.TweeterDAL;

namespace AG.TweeterBLL
{
    public class UserRepository : IUserRepository
    {
        private IList<User> AllUsers;
        private ILogger Logger;
        public UserRepository(IDataSource userDataSource,ILogger logger)
        {                        
            Logger = logger;
            AllUsers = MapUserDataSourceToUsers(userDataSource);
        }

        public UserRepository(IList<User> userDataSource, ILogger logger)
        {
            Logger = logger;
            AllUsers = userDataSource;
        }

        //Main method to interpret dictionary into list of users
        private IList<User> MapUserDataSourceToUsers(IDataSource userDataSource)
        {
            var userDictionary = userDataSource.GetData();
            var resultUserList = new List<User>();
            string delimiter = AG.TweeterService.ServiceSettings.FileDelimiterFollows; 
            int lineNumber = 0;
            var itemString = "";
            foreach (KeyValuePair<int, string> userItem in userDictionary)
            {
                lineNumber = userItem.Key;
                itemString = userItem.Value;
                // find delimiter postion
                var chrIdx = itemString.IndexOf(delimiter);
                if (chrIdx == -1)
                {
                    Logger.LogError("Delimeter for users not found in file");
                    continue;
                }
                //extract user name
                string userName = itemString.Substring(0, chrIdx - 1).Trim();
                if (string.IsNullOrEmpty(userName))
                {
                    Logger.LogError("No username in file");
                    continue;
                }

                //if user already exists only add his followers
                var existingUser = resultUserList.FirstOrDefault(x => x.Name.Trim() == userName);

                //extract the followers from the rest of the string                
                var strLength = itemString.Length - chrIdx - delimiter.Length - 1;
                string followeesStringList = itemString.Substring(chrIdx + delimiter.Length + 1, strLength);
                var followees = GetFolloweesFromList(followeesStringList);

                //add or update users                
                if (existingUser == null)
                {
                    var user = new User()
                    {
                        Name = userName,
                        Followees = followees
                    };
                    resultUserList.Add(user);
                }
                else
                {
                    existingUser.Followees = UpdateFollowees(existingUser.Followees, followees);
                }
            }

            // add followees as users
            var uniqueFollowers = GetUniqueFolloweesNotExistingUsers(resultUserList);
            resultUserList.AddRange(uniqueFollowers);
            return resultUserList;

        }

        private static IList<Follower> GetFolloweesFromList(string followeesStringList)
        {
            var resultList = new List<Follower>();
            foreach (var follower in followeesStringList.Split(", ").ToList())
            {
                resultList.Add(new Follower() { Name = follower.Trim() });
            }
            return resultList;
        }

        private static IList<Follower> UpdateFollowees(IList<Follower> existingFollowees, IList<Follower> followeesToAdd)
        {
            foreach (var follower in followeesToAdd)
            {
                if (!existingFollowees.Any(x => x.Name == follower.Name))
                {
                    existingFollowees.Add(new Follower() { Name = follower.Name });
                }
            }
            return existingFollowees;
        }

        //Get all the followers who do not appear in the user list
        private static IList<User> GetUniqueFolloweesNotExistingUsers(List<User> userList)
        {
            //extract all followees
            var allFollowees = new List<User>();
            foreach (var user in userList)
            {
                foreach (var follower in user.Followees)
                {
                    allFollowees.Add(new User() { Name = follower.Name });
                }
            }
            
            var followersToAdd = allFollowees.Where(x => !userList.Any(y => y.Name == x.Name))
            .GroupBy(x => x.Name).Select(g => g.FirstOrDefault()).ToList();
            return followersToAdd;
        }

        //retrieval methods
        public IList<User> GetAllUsers()
        {
            return AllUsers;
        }

        public User GetUserByName(string userName)
        {
            return AllUsers.FirstOrDefault(u => u.Name == userName);
        }

        public IList<User> GetUsersByName(string userName)
        {
            return AllUsers.Where(u => u.Name == userName).ToList(); ;
        }

    }
}