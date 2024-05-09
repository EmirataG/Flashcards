using Flashcards.Core;
using Flashcards.MVVM.Model;
using System.Diagnostics;
using System.Linq;
using Flashcards.Utils; // Add this line to use UserUtils
using Flashcards.MVVM.Model.Context;
using Microsoft.EntityFrameworkCore;
using System.Windows.Controls;
using System.Windows; // Add this line to use FlashcardsDbContext

namespace Flashcards.MVVM.ViewModel.Registration
{
    public class LogInViewModel : ObservableObject
    {
        public string EnteredUsernameOrEmail { get; set; } // Changed to EnteredUsernameOrEmail
        public RelayCommand LogInCommand { get; set; }

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



        private readonly FlashcardsDbContext _context;

        public LogInViewModel(FlashcardsDbContext context)
        {
            _context = context;

            _context.Users.FirstOrDefault(u => u.ID == 0);
            LogInCommand = new RelayCommand(o =>
            {
                string hashedPassword = UserUtils.ComputeSha256Hash(Password);
                User? user = _context.Users.Where(u => (u.Username == EnteredUsernameOrEmail || u.Email == EnteredUsernameOrEmail) && u.Password == hashedPassword).FirstOrDefault(); // Check against the hashed password in DbContext

                if (user != null)
                {
                    Debug.WriteLine(user.Username);
                    Debug.WriteLine(user.Password);
                    WindowViewModel.GetInstance(context).CurrentView = new MainViewModel(user, context);
                }
                else
                {
                    MessageBox.Show("Incorrect username or password", "Cmnon now", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            });
        }
    }
}
