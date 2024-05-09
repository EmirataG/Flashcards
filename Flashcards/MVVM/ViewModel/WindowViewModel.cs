using Flashcards.Core;
using Flashcards.MVVM.Model.Context;
using Flashcards.MVVM.ViewModel.Registration;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.MVVM.ViewModel
{
    public class WindowViewModel : ObservableObject
    {
        private FlashcardsDbContext _context;

        private static WindowViewModel _instance;
        public static WindowViewModel GetInstance(FlashcardsDbContext context)
        {
            _instance ??= new WindowViewModel(context);
            return _instance;
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

        public WindowViewModel(FlashcardsDbContext flashcardsDbContext)
        {
            _context = flashcardsDbContext;
            _instance = this;
            CurrentView = new RegistrationViewModel(flashcardsDbContext);
        }

    }
}
