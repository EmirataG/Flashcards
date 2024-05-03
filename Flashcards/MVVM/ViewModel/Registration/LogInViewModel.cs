using Flashcards.Core;
using Flashcards.MVVM.Model;
using System.Diagnostics;
using System.Linq;

namespace Flashcards.MVVM.ViewModel.Registration
{
    public class LogInViewModel : ObservableObject
    {
        public string EnteredUsername { get; set; }
        public string EnteredPassword { get; set; }
        public RelayCommand LogInCommand { get; set; }
        public LogInViewModel() 
        {
            LogInCommand = new RelayCommand(o =>
            {
                User? user = DemoSets.TestUsers.Where(u => u.Name == EnteredUsername && u.Password == EnteredPassword).FirstOrDefault();
                
                if (user != null)
                {
                    Debug.WriteLine(user.Name);
                    Debug.WriteLine(user.Password);
                    WindowViewModel.Instance.CurrentView = new MainViewModel(user);
                }
                else
                {
                    Debug.Write("Incorrect username or password");
                }
            });
        }
    }
}
