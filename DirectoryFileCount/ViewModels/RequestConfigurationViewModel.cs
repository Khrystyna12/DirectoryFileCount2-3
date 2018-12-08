using System.ComponentModel;
using System.Runtime.CompilerServices;
using DirectoryFileCount.Managers;
using DirectoryFileCount.Models;
using DirectoryFileCount.Properties;

namespace DirectoryFileCount.ViewModels
{
    internal class RequestConfigurationViewModel : INotifyPropertyChanged
    {
        #region Fields
        private readonly RequestUIModel _currentRequest;
        #endregion

        #region Properties
        
        public string Title
        {
            get { return _currentRequest.Title; }
            set
            {
                _currentRequest.Title = value;
                OnPropertyChanged();
            }
        }
        public string Path
        {
            get { return _currentRequest.Path; }
            set { }
        }
        public string Result
        {
            get { return _currentRequest.Result; }
        }
        #endregion



        #region Constructor
        public RequestConfigurationViewModel(RequestUIModel request)
        {
            _currentRequest = request;
        }
        #endregion
        #region EventsAndHandlers
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        internal virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #endregion


    }
}
