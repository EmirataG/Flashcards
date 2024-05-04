using Flashcards.Core;
using Flashcards.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.MVVM.ViewModel.Registration
{
    public class SignUpViewModel : ObservableObject
    {
        public string EnteredEmail { get; set; }
        public string EnteredUsername { get; set; }
        public string EnteredPassword { get; set; }
        public string EnteredComnfirmPassword { get; set; }
        public RelayCommand SignUpCommand { get; set; }

        public SignUpViewModel()
        {
            SignUpCommand = new RelayCommand(o => {
                if (EnteredPassword.Equals(EnteredComnfirmPassword))
                {
                    User? user = DemoSets.TestUsers.Where(u => u.Name == EnteredUsername).FirstOrDefault();
                    if (user == null) 
                    {
                        int nextId = DemoSets.TestUsers.Max(u => u.ID) + 1;
                        User newUser = new User(nextId, EnteredUsername, EnteredPassword);
                        DemoSets.TestUsers.Add(newUser);
                        WindowViewModel.Instance.CurrentView = new MainViewModel(newUser);
                    }
                }
            });
        }
    }
}
