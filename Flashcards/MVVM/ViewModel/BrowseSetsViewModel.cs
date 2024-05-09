using Flashcards.Core;
using Flashcards.MVVM.Model;
using Flashcards.MVVM.Model.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq; 

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

        private FlashcardsDbContext _context;

        public BrowseSetsViewModel(FlashcardsDbContext flashcardsDbContext, CreateSetViewModel createSetViewModel, MySetsViewModel mySetsViewModel)
        {
            _context = flashcardsDbContext;

            mySetsViewModel.SetDeleted += RefreshSets;


            _sets = new ObservableCollection<FlashcardSet>(_context.FlashcardSets.Include(set => set.Flashcards).Include(set => set.Creator).ToList());

            createSetViewModel.SetCreated += RefreshSets;


            SelectSetCommand = new RelayCommand(SelectSet);
        }





        private void RefreshSets()
        {
            _sets = new ObservableCollection<FlashcardSet>(_context.FlashcardSets
                .Include(set => set.Flashcards).Include(set => set.Creator).ToList());
            OnPropertyChanged(nameof(Sets));
        }

        private void SelectSet(object set)
        {
            if (set is FlashcardSet selectedSet)
            {
                MainViewModel.Instance.CurrentView = new TakeTestViewModel(selectedSet);
            }
        }


        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                FilterSets();
            }
        }

        private void FilterSets()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Sets = new ObservableCollection<FlashcardSet>(_context.FlashcardSets.Include(set => set.Flashcards).Include(set => set.Creator).ToList());
            }
            else
            {
                Sets = new ObservableCollection<FlashcardSet>(_context.FlashcardSets.Include(set => set.Flashcards).Include(set => set.Creator).Where(set => set.SetName.Contains(SearchText)).ToList());
            }
        }
    }
}
