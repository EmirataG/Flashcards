using Flashcards.Core;
using Flashcards.MVVM.ViewModel.Registration;

namespace Flashcards.MVVM.ViewModel
{
    class WindowViewModel : ObservableObject
    {
        private static WindowViewModel _instance;
        public static WindowViewModel Instance
        {
            get
            {
                _instance ??= new WindowViewModel();
                return _instance;
            }
        }
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

        public WindowViewModel()
        {
            _instance = this;
            CurrentView = new RegistrationViewModel();
        }

    }
}
