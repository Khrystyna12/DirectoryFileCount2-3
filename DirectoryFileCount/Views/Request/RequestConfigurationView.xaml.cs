using DirectoryFileCount.ViewModels;

namespace DirectoryFileCount.Views.Request
{
    /// <summary>
    /// Interaction logic for DirectoryFileConfigurationView.xaml
    /// </summary>
    public partial class RequestConfigurationView
    {
        public RequestConfigurationView(Models.Request directoryfile)
        {
            InitializeComponent();
            var directoryfileModel = new RequestConfigurationViewModel(directoryfile);
            DataContext = directoryfileModel;
        }
    }
}
