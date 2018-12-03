using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DirectoryFileCount.Managers;
using DirectoryFileCount.Models;
using DirectoryFileCount.Properties;
using DirectoryFileCount.Tools;

namespace DirectoryFileCount.ViewModels
{

    class MainViewModel : INotifyPropertyChanged
    {
        public static int title = 1;
        #region Fields
        private Request _selectedDirectoryFile;
        private ObservableCollection<Request> _directoryfiles;
        #region Commands
        private ICommand _addDirectoryFileCommand;
        private ICommand _deleteDirectoryFileCommand;
        private ICommand _signInCommand;
        #endregion
        #endregion

        #region Properties
        #region Commands

        public ICommand AddDirectoryFileCommand
        {
            get
            {
                return _addDirectoryFileCommand ?? (_addDirectoryFileCommand = new RelayCommand<object>(AddDirectoryFileExecute));
            }
        }

        public ICommand DeleteDirectoryFileCommand
        {
            get
            {
                return _deleteDirectoryFileCommand ?? (_deleteDirectoryFileCommand = new RelayCommand<KeyEventArgs>(DeleteDirectoryFileExecute));
            }
        }
        public ICommand SignInCommand
        {
            get
            {
                return _signInCommand ?? (_signInCommand = new RelayCommand<object>(SignInExecute));
            }
        }

        private void SignInExecute(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.SignIn);
        }
        #endregion

        public ObservableCollection<Request> DirectoryFiles
        {
            get { return _directoryfiles; }
            set
            {
                _directoryfiles = value;
                OnPropertyChanged(nameof(DirectoryFiles));
            }
        }
        public Request SelectedDirectoryFile
        {
            get { return _selectedDirectoryFile; }
            set
            {
                _selectedDirectoryFile = value;
                OnPropertyChanged(nameof(SelectedDirectoryFile));
            }
        }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            FillDirectoryFiles();
            PropertyChanged += OnPropertyChanged;
        }
        #endregion
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "SelectedDirectoryFile")
                OnDirectoryFileChanged(_selectedDirectoryFile);
        }
        private void FillDirectoryFiles()
        {
            _directoryfiles = new ObservableCollection<Request>();
            foreach (var directoryfile in StationManager.CurrentUser.DirectoryFiles)
            {
                _directoryfiles.Add(directoryfile);
            }
            if (_directoryfiles.Count > 0)
            {
                SelectedDirectoryFile = DirectoryFiles[0];
            }
        }

        private void DeleteDirectoryFileExecute(KeyEventArgs args)
        {
            if (args.Key != Key.Delete) return;

            if (SelectedDirectoryFile == null) return;

            StationManager.CurrentUser.DirectoryFiles.RemoveAll(uwr => uwr.Guid == SelectedDirectoryFile.Guid);
            DBManager.UpdateUser(StationManager.CurrentUser);
            FillDirectoryFiles();
        }

        private void AddDirectoryFileExecute(object o)
        {
            Request directoryfile = new Request((title++).ToString(), StationManager.CurrentUser);
            _directoryfiles.Add(directoryfile);
            _selectedDirectoryFile = directoryfile;
        }

        #region EventsAndHandlers
        #region Loader
        internal event DirectoryFileChangedHandler DirectoryFileChanged;
        internal delegate void DirectoryFileChangedHandler(Request directoryfile);

        internal virtual void OnDirectoryFileChanged(Request directoryfile)
        {
            DirectoryFileChanged?.Invoke(directoryfile);
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
