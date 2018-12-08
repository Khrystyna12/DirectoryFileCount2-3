using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DirectoryFileCount.DBModels;
using DirectoryFileCount.Properties;

namespace DirectoryFileCount.Models
{
    public class RequestUIModel:INotifyPropertyChanged
    {
        #region Fields
        private Request _request;
        #endregion

        #region Properties
        internal Request Request
        {
            get { return _request; }
            private set
            {
                _request = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get { return _request.Title; }
            set
            {
                _request.Title = value;
                OnPropertyChanged();
            }
        }
        public string Path
        {
            get { return _request.Path; }
        }
        public string Result
        {
            get { return _request.Result; }
        }

        public Guid Guid
        {
            get { return _request.Guid; }
        }

        #endregion

        public RequestUIModel(Request request)
        {
            _request = request;
        }

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
