using Flashcards.Core;
using Flashcards.MVVM.Model;
using System.Collections.ObjectModel;


namespace Flashcards.MVVM.ViewModel
{
    public class BrowseSetsViewModel : ObservableObject
    {
        private ObservableCollection<FlashcardSet> _sets;
        public ObservableCollection<FlashcardSet> Sets
        {
            get { return _sets; }
            set
            {
                _sets = value;
                OnPropertyChanged(nameof(Sets));
            }
        }

        public RelayCommand SelectSetCommand { get; set; }

        public BrowseSetsViewModel()
        {
            _sets = DemoSets.TestSets;
            SelectSetCommand = new RelayCommand(SelectSet);
        }

        private void SelectSet(object set)
        {
            if (set is FlashcardSet selectedSet)
            {
                MainViewModel.Instance.CurrentView = new TakeTestViewModel(selectedSet);
            }
        }
    }
}
