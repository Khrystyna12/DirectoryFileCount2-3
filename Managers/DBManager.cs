﻿using DirectoryFileCount.DBAdapter;
using DirectoryFileCount.DBModels;
using DirectoryFileCount.Tools;

namespace DirectoryFileCount.Managers
{
    public class DBManager
    {
        public static bool UserExists(string login)
        {
            return EntityWrapper.UserExists(login);
        }

        public static User GetUserByLogin(string login)
        {
            return EntityWrapper.GetUserByLogin(login);
        }

        public static void AddUser(User user)
        {
            EntityWrapper.AddUser(user);
        }

        internal static User CheckCachedUser(User userCandidate)
        {
            var userInStorage = EntityWrapper.GetUserByGuid(userCandidate.Guid);
            if (userInStorage != null && userInStorage.CheckPassword(userCandidate))
                return userInStorage;
            return null;
        }
        
        public static void DeleteRequest(Request selectedRequest)
        {
            EntityWrapper.DeleteRequest(selectedRequest);
        }

        public static void AddRequest(Request request)
        {
            EntityWrapper.AddRequest(request);
        }
    }
}

