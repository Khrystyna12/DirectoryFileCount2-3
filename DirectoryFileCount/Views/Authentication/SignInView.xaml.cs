using DirectoryFileCount.ViewModels.Authentication;

namespace DirectoryFileCount.Views.Authentication
{
    internal partial class SignInView
    {
        #region Constructor
        internal SignInView()
        {
            InitializeComponent();
            var signInViewModel = new SignInViewModel();
            DataContext = signInViewModel;
        }
        #endregion
    }
}
