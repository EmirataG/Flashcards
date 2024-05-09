using Flashcards.Core;
using Flashcards.MVVM.Model.Context;

namespace Flashcards.MVVM.ViewModel.Registration
{
    public class RegistrationViewModel : ObservableObject
    {


        public RelayCommand LogInViewCommand { get; set; }
        public RelayCommand SignUpViewCommand { get; set; }
        public LogInViewModel LogInVM { get; set; }
        public SignUpViewModel SignUpVM { get; set; }
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public RegistrationViewModel(FlashcardsDbContext context)
        {
            LogInVM = new LogInViewModel(context);
            SignUpVM = new SignUpViewModel(context);

            _currentView = LogInVM;

            LogInViewCommand = new RelayCommand(o =>
            {
                CurrentView = LogInVM;
            });
            SignUpViewCommand = new RelayCommand(o =>
            {
                CurrentView = SignUpVM;
            });
        }

        public RegistrationViewModel()
        {
        }
    }
}
