using Flashcards.Core;
using Flashcards.MVVM.Model;
using Flashcards.MVVM.View;
using Flashcards.MVVM.ViewModel.Registration;
using System.Windows.Controls;

namespace Flashcards.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private static MainViewModel _instance;
        public static MainViewModel Instance
        {
            get
            {
                return _instance;
            }
        }
        public User CurrentUser { get; set; }
        public RelayCommand MySetsViewCommand { get; set; }
        public RelayCommand CreateSetViewCommand { get; set; }
        public RelayCommand BrowseSetsViewCommand { get; set; }
        public RelayCommand LogOutCommand { get; set; }


        public MySetsViewModel MySetsVM { get; set; }
        public BrowseSetsViewModel BrowseSetsVM { get; set; }

        public CreateSetViewModel CreateSetVM { get; set; }

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

        public MainViewModel(User currentUser)
        {
            CurrentUser = currentUser;
            _instance = this;
            MySetsVM = new MySetsViewModel();
            CreateSetVM = new CreateSetViewModel();
            BrowseSetsVM = new BrowseSetsViewModel();

            CurrentView = MySetsVM;

            MySetsViewCommand = new RelayCommand(o =>
            {
                CurrentView = MySetsVM;
            });

            CreateSetViewCommand = new RelayCommand(o =>
            {
                CurrentView = CreateSetVM;
            });

            BrowseSetsViewCommand = new RelayCommand(o =>
            {
                CurrentView = BrowseSetsVM;
            });

            LogOutCommand = new RelayCommand(o =>
            {
                WindowViewModel.Instance.CurrentView = new RegistrationViewModel();
            });
        }
    }
}