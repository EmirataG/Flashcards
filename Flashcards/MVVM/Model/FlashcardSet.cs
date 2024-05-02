using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;

namespace Flashcards.MVVM.Model
{
    public class FlashcardSet
    {
        public string SetName { get; set; }
        public User Creator { get; set; }
        public ObservableCollection<Flashcard> Flashcards;
        public int NumCards { get; set; }

        public FlashcardSet(string setName, User creator, params Flashcard[] flashcards)
        {
            SetName = setName;
            Creator = creator;
            Flashcards = new ObservableCollection<Flashcard>(flashcards);
            NumCards = flashcards.Length;
        }
    }
}
