using System;
using System.Collections.Generic;
using DirectoryFileCount.DBAdapter;
using DirectoryFileCount.DBModels;
using DirectoryFileCount.ServiceInterface;

namespace DirectoryFileCount.RequestService
{

    class RequestService : IRequestContract
    {
        public bool UserExists(string login)
        {
            return EntityWrapper.UserExists(login);
        }

        public User GetUserByLogin(string login)
        {
            return EntityWrapper.GetUserByLogin(login);
        }

        public User GetUserByGuid(Guid guid)
        {
            return EntityWrapper.GetUserByGuid(guid);
        }

        public void AddUser(User user)
        {
            EntityWrapper.AddUser(user);
        }

        public void AddRequest(Request request)
        {
            EntityWrapper.AddRequest(request);
        }

        public List<User> GetAllUsers(Guid requestGuid)
        {
            return EntityWrapper.GetAllUsers(requestGuid);
        }

        public void DeleteRequest(Request selectedRequest)
        {
            EntityWrapper.DeleteRequest(selectedRequest);
        }


        public void SaveRequest(Request request)
        {
            EntityWrapper.SaveRequest(request);
        }
    }
}
