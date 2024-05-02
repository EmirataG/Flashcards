using Flashcards.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public RegistrationViewModel()
        {
            LogInVM = new LogInViewModel();
            SignUpVM = new SignUpViewModel();
            LogInViewCommand = new RelayCommand(o => 
            {
                CurrentView = LogInVM;
            });
            SignUpViewCommand = new RelayCommand(o =>
            {
                CurrentView = SignUpVM; 
            });
        }
    }
}
