using System;
using System.Collections.Generic;
using System.ServiceModel;
using DirectoryFileCount.DBModels;

namespace DirectoryFileCount.ServiceInterface
{
    [ServiceContract]
    public interface IRequestContract
    {
        [OperationContract]
        bool UserExists(string login);
        [OperationContract]
        User GetUserByLogin(string login);
        [OperationContract]
        User GetUserByGuid(Guid guid);
        [OperationContract]
        List<User> GetAllUsers(Guid requestGuid);
        [OperationContract]
        void AddUser(User user);
        [OperationContract]
        void AddRequest(Request request);
        [OperationContract]
        void SaveRequest(Request request);
        [OperationContract]
        void DeleteRequest(Request selectedRequest);
    }
}
