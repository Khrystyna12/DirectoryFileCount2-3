using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DirectoryFileCount.DBModels;
using DirectoryFileCount.Managers;
using DirectoryFileCount.Models;
using DirectoryFileCount.Properties;
using DirectoryFileCount.Tools;

namespace DirectoryFileCount.ViewModels
{
    class MainViewViewModel : INotifyPropertyChanged
    {
        #region Fields
        private RequestUIModel _selectedRequest;
        private ObservableCollection<RequestUIModel> _requests;
        #region Commands
        private ICommand _addRequestCommand;
        private ICommand _deleteRequestCommand;
        #endregion
        #endregion

        #region Properties
        #region Commands

        public ICommand AddRequestCommand
        {
            get
            {
                return _addRequestCommand ?? (_addRequestCommand = new RelayCommand<object>(AddRequestExecute));
            }
        }

        public ICommand DeleteRequestCommand
        {
            get
            {
                return _deleteRequestCommand ?? (_deleteRequestCommand = new RelayCommand<KeyEventArgs>(DeleteRequestExecute));
            }
        }

        #endregion

        public ObservableCollection<RequestUIModel> Requests
        {
            get { return _requests; }
        }
        public RequestUIModel SelectedRequest
        {
            get { return _selectedRequest; }
            set
            {
                _selectedRequest = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructor
        public MainViewViewModel()
        {
            PropertyChanged += OnPropertyChanged;
            FillRequests();
        }
        #endregion
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "SelectedRequest")
                OnRequestChanged(_selectedRequest);
        }
        private void FillRequests()
        {
            _requests = new ObservableCollection<RequestUIModel>();
            foreach (var request in StationManager.CurrentUser.Requests)
            {
                _requests.Add(new RequestUIModel(request));
            }
            if (_requests.Count > 0)
            {
                _selectedRequest = Requests[0];
            }
        }

        private void DeleteRequestExecute(KeyEventArgs args)
        {
            if (args.Key != Key.Delete) return;

            if (SelectedRequest == null) return;

            StationManager.CurrentUser.Requests.RemoveAll(uwr => uwr.Guid == SelectedRequest.Guid);
            DBManager.DeleteRequest(SelectedRequest.Request);
            FillRequests();
            OnPropertyChanged(nameof(SelectedRequest));
            OnPropertyChanged(nameof(Requests));
        }

        private void AddRequestExecute(object o)
        {
            Request request = new Request("New Request", StationManager.CurrentUser);
            DBManager.AddRequest(request);
            var requestUIModel = new RequestUIModel(request);
            _requests.Add(requestUIModel);
            _selectedRequest = requestUIModel;
        }
        
        #region EventsAndHandlers
        #region Loader
        internal event RequestChangedHandler RequestChanged;
        internal delegate void RequestChangedHandler(RequestUIModel request);

        internal virtual void OnRequestChanged(RequestUIModel request)
        {
            RequestChanged?.Invoke(request);
        }
        #endregion
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }  
        #endregion
        #endregion


    }
}
