using Flashcards.Core;
using Flashcards.MVVM.Model;
using System;
using System.Linq;
using Flashcards.MVVM.Model.Context;
using System.Windows.Controls;

namespace Flashcards.MVVM.ViewModel.Registration
{
    public class SignUpViewModel : ObservableObject
    {
        public string EnteredEmail { get; set; }
        public string EnteredUsername { get; set; }
        public string EnteredPassword { get; set; }
        public string EnteredComnfirmPassword { get; set; }
        public RelayCommand SignUpCommand { get; set; }
        private string _confirmPassword;
        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }
        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }


        private FlashcardsDbContext _context;

        public SignUpViewModel(FlashcardsDbContext flashcardsDbContext)
        {
            _context = flashcardsDbContext;

            SignUpCommand = new RelayCommand(o =>
            {

                if (Password.Equals(ConfirmPassword))
                {
                    User? user = _context.Users.Where(u => u.Username == EnteredUsername).FirstOrDefault();
                    if (user == null)
                    {
                        User newUser = new User(EnteredUsername, EnteredEmail, Password);
                        _context.Users.Add(newUser);
                        _context.SaveChanges();
                        WindowViewModel.GetInstance(_context).CurrentView = new MainViewModel(newUser, _context);
                    }
                }
            });

            }
        }
    }
