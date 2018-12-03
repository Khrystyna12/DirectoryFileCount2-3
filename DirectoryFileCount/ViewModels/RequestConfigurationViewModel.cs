using System.ComponentModel;
using System.Windows.Forms;
using DirectoryFileCount.Managers;
using System.Runtime.CompilerServices;
using DirectoryFileCount.Models;
using DirectoryFileCount.Properties;

namespace DirectoryFileCount.ViewModels
{
    internal class RequestConfigurationViewModel : INotifyPropertyChanged
    {
        #region Fields
        private readonly Request _currentDirectoryFile;
        #endregion
        
        #region Properties

        public string Title
        {
            get { return _currentDirectoryFile.Title; }
            set
            {
                _currentDirectoryFile.Title = value;
                OnPropertyChanged();
            }
        }
        public string Path
        {
            get { return _currentDirectoryFile.Path; }
            set { }
        }
        public string Result
        {
            get { return _currentDirectoryFile.Result; }
        }
        #endregion

        

        #region Constructor
        public RequestConfigurationViewModel(Request directoryfile)
        {
            _currentDirectoryFile = directoryfile;
        }
        #endregion
        #region EventsAndHandlers
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        internal virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            DBManager.UpdateUser(StationManager.CurrentUser);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #endregion


    }
}
