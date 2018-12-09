using DirectoryFileCount.DBModels;
using DirectoryFileCount.Tools;
using DirectoryFileCount.ServiceInterface;

namespace DirectoryFileCount.Managers
{
    public class DBManager
    {
        public static bool UserExists(string login)
        {
            return RequestServiceWrapper.UserExists(login);
        }

        public static User GetUserByLogin(string login)
        {
            return RequestServiceWrapper.GetUserByLogin(login);
        }

        public static void AddUser(User user)
        {
            RequestServiceWrapper.AddUser(user);
        }

        internal static User CheckCachedUser(User userCandidate)
        {
            var userInStorage = RequestServiceWrapper.GetUserByGuid(userCandidate.Guid);
            if (userInStorage != null && userInStorage.CheckPassword(userCandidate))
                return userInStorage;
            return null;
        }
        
        public static void DeleteRequest(Request selectedRequest)
        {
            RequestServiceWrapper.DeleteRequest(selectedRequest);
        }

        public static void AddRequest(Request request)
        {
            RequestServiceWrapper.AddRequest(request);
        }
    }
}

