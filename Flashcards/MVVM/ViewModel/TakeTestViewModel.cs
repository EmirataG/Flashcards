using Flashcards.Core;
using Flashcards.MVVM.Model;
using System.Windows.Input;

namespace Flashcards.MVVM.ViewModel
{
    public class TakeTestViewModel : ObservableObject
    {
        public FlashcardSet Set { get; set; }
        public ICommand PreviousCardCommand { get; set; }
        public ICommand FlipCardCommand { get; set; }
        public ICommand NextCardCommand { get; set; }
        private int _currentCardIndex;
        private bool _isFront;
        public string CurrentCardStatus
        {
            get
            {
                return $"Card {_currentCardIndex + 1}/{Set.Flashcards.Count}";
            }
        }

        public TakeTestViewModel(FlashcardSet set)
        {
            Set = set;
            _currentCardIndex = 0;
            _isFront = true;

            PreviousCardCommand = new RelayCommand(_ => PreviousCard(), _ => CanGoToPrevious());
            FlipCardCommand = new RelayCommand(_ => FlipCard());
            NextCardCommand = new RelayCommand(_ => NextCard(), _ => CanGoToNext());
        }

        private void PreviousCard()
        {
            _currentCardIndex--;
            _isFront = true;
            OnPropertyChanged("CurrentCard");
            OnPropertyChanged("CurrentCardStatus");
        }

        private bool CanGoToPrevious()
        {
            return _currentCardIndex > 0;
        }

        private void FlipCard()
        {
            _isFront = !_isFront;
            OnPropertyChanged("CurrentCard");
        }

        private void NextCard()
        {
            _currentCardIndex++;
            _isFront = true;
            OnPropertyChanged("CurrentCard");
            OnPropertyChanged("CurrentCardStatus");
        }

        private bool CanGoToNext()
        {
            return _currentCardIndex < Set.Flashcards.Count - 1;
        }

        public Flashcard CurrentCard
        {
            get
            {
                return _isFront ? Set.Flashcards[_currentCardIndex] : new Flashcard(Set.Flashcards[_currentCardIndex].Back, Set.Flashcards[_currentCardIndex].Front);
            }
        }
    }
}
