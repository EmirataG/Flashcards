using Flashcards.Core;
using Flashcards.MVVM.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using Flashcards.MVVM.Model.Context;
using System; // Add this line to use FlashcardsDbContext

namespace Flashcards.MVVM.ViewModel
{
    public class CreateSetViewModel : ObservableObject
    {
        public ObservableCollection<Flashcard> NewSet { get; set; }
        public string SetName { get; set; }
        public RelayCommand AddCardCommand { get; set; }
        public RelayCommand DeleteCardCommand { get; set; }
        public RelayCommand CreateSetCommand { get; set; }

        public RelayCommand UpdateFrontCommand { get; set; }
        public RelayCommand UpdateBackCommand { get; set; }
        public event Action SetCreated;


        private FlashcardsDbContext _context; // Add this line to declare the DbContext

        public CreateSetViewModel(FlashcardsDbContext flashcardsDbContext) // Modify the constructor to accept the DbContext
        {
            _context = flashcardsDbContext; // Initialize the DbContext

            SetName = "";

            NewSet = new ObservableCollection<Flashcard>()
            {
                new Flashcard("", ""),
                new Flashcard("", ""),
                new Flashcard("", "")
            };

            AddCardCommand = new RelayCommand(o =>
            {
                NewSet.Add(new Flashcard("", ""));
                foreach (Flashcard c in NewSet)
                {
                    Debug.WriteLine($"{c.Front} - {c.Back}");
                }
            });

            DeleteCardCommand = new RelayCommand(o =>
            {
                if (NewSet.Count > 3)
                {
                    if (o is Flashcard card)
                    {
                        NewSet.Remove(card);
                    }
                }
                else
                {
                    MessageBox.Show("The set must include at least 3 cards!", "Cmnon now", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            });

            CreateSetCommand = new RelayCommand(o =>
            {
                if (SetName.Equals(string.Empty))
                {
                    MessageBox.Show("Please enter the name of the set", "Cmnon now", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    var emptyCartds = NewSet.Where(c => c.Front.Equals(string.Empty) || c.Back.Equals(string.Empty));
                    if (emptyCartds.Any())
                    {
                        MessageBox.Show("Please make sure that all cards are ready!", "Cmnon now", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    else
                    {
                        User currentUser = _context.Users.Find(MainViewModel.Instance.CurrentUser.ID);
                        FlashcardSet newFlashcardSet = new FlashcardSet(SetName, currentUser);
                        foreach (Flashcard card in NewSet)
                        {
                            _context.Flashcards.Add(card);
                            newFlashcardSet.Flashcards.Add(card);
                        }
                        _context.FlashcardSets.Add(newFlashcardSet);
                        _context.SaveChanges();
                        NewSet = new ObservableCollection<Flashcard>()
                            {
                                new Flashcard("", ""),
                                new Flashcard("", ""),
                                new Flashcard("", "")
                            };
                        SetCreated?.Invoke();
                        //MainViewModel.Instance.CurrentView = new MySetsViewModel(flashcardsDbContext, this);
                        MainViewModel.Instance.MySetsViewCommand.Execute(_context);
                    }
                }
            });
        }
    }
}
