using DirectoryFileCount.Models;
using DirectoryFileCount.ViewModels;

namespace DirectoryFileCount.Views.Request
{
    /// <summary>
    /// Interaction logic for RequestConfigurationView.xaml
    /// </summary>
    public partial class RequestConfigurationView
    {
        public RequestConfigurationView(RequestUIModel request)
        {
            InitializeComponent();
            var requestModel = new RequestConfigurationViewModel(request);
            DataContext = requestModel;
        }
    }
}
