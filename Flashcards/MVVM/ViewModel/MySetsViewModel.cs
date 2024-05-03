using Flashcards.Core;
using Flashcards.MVVM.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace Flashcards.MVVM.ViewModel
{
    public class MySetsViewModel : ObservableObject
    {
        public User CurrentUser { get; set; }
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
            CurrentUser = MainViewModel.Instance.CurrentUser;
            _mySets = new ObservableCollection<FlashcardSet>(DemoSets.TestSets.Where(set => set.Creator.ID == CurrentUser.ID));
        }
    }
}