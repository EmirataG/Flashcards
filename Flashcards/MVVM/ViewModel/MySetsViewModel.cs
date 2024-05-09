using Flashcards.Core;
using Flashcards.MVVM.Model.Context;
using Flashcards.MVVM.Model;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System;

namespace Flashcards.MVVM.ViewModel
{
    public class MySetsViewModel : ObservableObject
    {
        public User CurrentUser { get; set; }
        public event Action SetDeleted;

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
        public RelayCommand EditSetCommand { get; set; }
        public RelayCommand DeleteSetCommand { get; set; }
        public RelayCommand SelectSetCommand { get; set; }

        private FlashcardsDbContext _context;

        public MySetsViewModel(FlashcardsDbContext flashcardsDbContext, CreateSetViewModel createSetViewModel)
        {
            createSetViewModel.SetCreated += RefreshSets;


            _context = flashcardsDbContext;

            CurrentUser = _context.Users.Find(MainViewModel.Instance.CurrentUser.ID);

            //var allSets = _context.FlashcardSets.Local.ToObservableCollection();

            _mySets = new ObservableCollection<FlashcardSet>(_context.FlashcardSets
              .Include(set => set.Flashcards)
              .Where(set => set.Creator.ID == CurrentUser.ID));

            SelectSetCommand = new RelayCommand(SelectSet);
            EditSetCommand = new RelayCommand(EditSet);
            DeleteSetCommand = new RelayCommand(DeleteSet);
        }

        public MySetsViewModel(FlashcardsDbContext flashcardsDbContext, UpdateSetViewModel updateSetViewModel)
        {
            updateSetViewModel.SetUpdated += RefreshSets;


            _context = flashcardsDbContext;

            CurrentUser = _context.Users.Find(MainViewModel.Instance.CurrentUser.ID);


            _mySets = new ObservableCollection<FlashcardSet>(_context.FlashcardSets
              .Include(set => set.Flashcards)
              .Where(set => set.Creator.ID == CurrentUser.ID));

            SelectSetCommand = new RelayCommand(SelectSet);
        }







        private void SelectSet(object set)
        {
            if (set is FlashcardSet selectedSet)
            {
                MainViewModel.Instance.CurrentView = new TakeTestViewModel(selectedSet);
            }
        }

        private void RefreshSets()
        {
            CurrentUser = _context.Users.Find(MainViewModel.Instance.CurrentUser.ID);
            _mySets = new ObservableCollection<FlashcardSet>(_context.FlashcardSets
                .Include(set => set.Flashcards)
                .Where(set => set.Creator.ID == CurrentUser.ID));
            OnPropertyChanged(nameof(MySets));
        }


    

        private void EditSet(object set)
        {
            if (set is FlashcardSet selectedSet)
            {
                MainViewModel.Instance.CurrentView = new UpdateSetViewModel(selectedSet, _context);
            }
        }

        private void DeleteSet(object set)
        {
            if (set is FlashcardSet selectedSet)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this flashcard set?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {

                    foreach (var flashcard in selectedSet.Flashcards.ToList())
                    {
                        _context.Flashcards.Remove(flashcard);
                    }

                    _context.FlashcardSets.Remove(selectedSet);

                    _context.SaveChanges();
                    SetDeleted?.Invoke();

                    RefreshSets();
                }
            }
        }

    }
}
