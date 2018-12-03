using System.Windows;
using System.Windows.Controls;
using DirectoryFileCount.ViewModels;
using DirectoryFileCount.Views.Request;

namespace DirectoryFileCount.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView
    {
        private MainViewModel _mainWindowViewModel;
        private RequestConfigurationView _currentRequestConfigurationView;

        public MainView()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Visibility = Visibility.Visible;
            _mainWindowViewModel = new MainViewModel();
            _mainWindowViewModel.DirectoryFileChanged += OnDirectoryFileChanged;
            DataContext = _mainWindowViewModel;
        }

        private void OnDirectoryFileChanged(Models.Request directoryfile)
        {
            if (_currentRequestConfigurationView == null)
            {
                _currentRequestConfigurationView = new RequestConfigurationView(directoryfile);
                MainGrid.Children.Add(_currentRequestConfigurationView);
                Grid.SetRow(_currentRequestConfigurationView, 0);
                Grid.SetRowSpan(_currentRequestConfigurationView, 2);
                Grid.SetColumn(_currentRequestConfigurationView, 1);
            }
            else
                _currentRequestConfigurationView.DataContext = new RequestConfigurationViewModel(directoryfile);

        }

    }
}
