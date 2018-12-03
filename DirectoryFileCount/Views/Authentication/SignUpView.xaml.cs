using DirectoryFileCount.ViewModels.Authentication;

namespace DirectoryFileCount.Views.Authentication
{  
    internal partial class SignUpView
    {
        #region Constructor
        internal SignUpView()
        {
            InitializeComponent();
            var signUpViewModel = new SignUpViewModel();
            DataContext = signUpViewModel;
        }
        #endregion
    }
}
