using Flashcards.Core;
using Flashcards.MVVM.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Flashcards.MVVM.ViewModel
{
    public class MySetsViewModel : ObservableObject
    {
        private ObservableCollection<FlashcardSet> _mySets;
        public ObservableCollection<FlashcardSet> MySets
        {
            get { return _mySets; }
            set
            {
                _mySets = value;
                OnPropertyChanged(nameof(MySets));
            }
        }
        public MySetsViewModel()
        {
            _mySets = new ObservableCollection<FlashcardSet>(DemoSets.TestSets.Where(set => set.Creator.ID == 1));
        }
    }
}