using Flashcards.Core;
using Flashcards.MVVM.Model;
using Flashcards.MVVM.View;
using Flashcards.MVVM.ViewModel.Registration;
using System.Windows.Controls;
using Flashcards.MVVM.Model.Context;

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
        public RelayCommand ProfileViewCommand { get; set; }
        public RelayCommand LogOutCommand { get; set; }


        public MySetsViewModel MySetsVM { get; set; }
        public BrowseSetsViewModel BrowseSetsVM { get; set; }
        public CreateSetViewModel CreateSetVM { get; set; }
        public ProfileViewModel ProfileVM { get; set; }

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

        private bool _isOnMySetsView;
        public bool IsOnMySetsView
        {
            get { return _isOnMySetsView; }
            set
            {
                _isOnMySetsView = value;
                OnPropertyChanged();
            }
        }
        private bool _isOnBrowseSetsView;
        public bool IsOnBrowseSetsView
        {
            get { return _isOnBrowseSetsView; }
            set
            {
                _isOnBrowseSetsView = value;
                OnPropertyChanged();
            }
        }
        private bool _isOnCreateSetView;
        public bool IsOnCreateSetView
        {
            get { return _isOnCreateSetView; }
            set
            {
                _isOnCreateSetView = value;
                OnPropertyChanged();
            }
        }
        private bool _isOnProfileView;
        public bool IsOnProfileView
        {
            get { return _isOnProfileView; }
            set
            {
                _isOnProfileView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(User currentUser, FlashcardsDbContext context)
        {
            CurrentUser = currentUser;
            _instance = this;
            CreateSetVM = new CreateSetViewModel(context);
            MySetsVM = new MySetsViewModel(context, CreateSetVM);
            BrowseSetsVM = new BrowseSetsViewModel(context, CreateSetVM, MySetsVM);
            ProfileVM = new ProfileViewModel(context);

            CurrentView = MySetsVM;

            IsOnMySetsView = true;
            IsOnBrowseSetsView = false;
            IsOnCreateSetView = false;
            IsOnProfileView = false;

            MySetsViewCommand = new RelayCommand(o =>
            {
                CurrentView = MySetsVM;

                IsOnMySetsView = true;
                IsOnBrowseSetsView = false;
                IsOnCreateSetView = false;
                IsOnProfileView = false;
            });

            CreateSetViewCommand = new RelayCommand(o =>
            {
                CurrentView = CreateSetVM;

                IsOnMySetsView = false;
                IsOnBrowseSetsView = false;
                IsOnCreateSetView = true;
                IsOnProfileView = false;
            });

            BrowseSetsViewCommand = new RelayCommand(o =>
            {
                CurrentView = BrowseSetsVM;

                IsOnMySetsView = false;
                IsOnBrowseSetsView = true;
                IsOnCreateSetView = false;
                IsOnProfileView = false;
            });

            ProfileViewCommand = new RelayCommand(o =>
            {
                CurrentView = ProfileVM;

                IsOnMySetsView = false;
                IsOnBrowseSetsView = false;
                IsOnCreateSetView = false;
                IsOnProfileView = true;
            });

            LogOutCommand = new RelayCommand(o =>
            {
                WindowViewModel.GetInstance(context).CurrentView = new RegistrationViewModel(context);
            });
        }
    }

}
