using Flashcards.Core;
using Flashcards.MVVM.Model;
using Flashcards.MVVM.Model.Context;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Flashcards.MVVM.ViewModel
{
    public class UpdateSetViewModel : ObservableObject
    {
        public FlashcardSet CurrentSet { get; set; }
        public ObservableCollection<Flashcard> Flashcards { get; set; }
        public string SetName { get; set; }
        public RelayCommand AddCardCommand { get; set; }
        public RelayCommand DeleteCardCommand { get; set; }
        public RelayCommand UpdateSetCommand { get; set; }

        public RelayCommand UpdateFrontCommand { get; set; }
        public RelayCommand UpdateBackCommand { get; set; }
        private FlashcardsDbContext _context;

        public event Action SetUpdated;


        public UpdateSetViewModel(FlashcardSet currentSet, FlashcardsDbContext flashcardsDbContext)
        {
            _context = flashcardsDbContext;
            CurrentSet = currentSet;
            Flashcards = new ObservableCollection<Flashcard>(CurrentSet.Flashcards);
            SetName = CurrentSet.SetName;

            AddCardCommand = new RelayCommand(o =>
            {
                Flashcards.Add(new Flashcard("", ""));
            });

            DeleteCardCommand = new RelayCommand(o =>
            {
                if (Flashcards.Count > 3)
                {
                    if (o is Flashcard card)
                    {
                        Flashcards.Remove(card);
                    }
                }
                else
                {
                    MessageBox.Show("The set must include at least 3 cards!", "Cmnon now", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            });


            UpdateSetCommand = new RelayCommand(o =>
            {
                if (SetName.Equals(string.Empty))
                {
                    MessageBox.Show("Please enter the name of the set", "Cmnon now", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    var emptyCards = Flashcards.Where(c => c.Front.Equals(string.Empty) || c.Back.Equals(string.Empty));
                    if (emptyCards.Any())
                    {
                        MessageBox.Show("Please make sure that all cards are ready!", "Cmnon now", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    else
                    {
                        CurrentSet.SetName = SetName;
                        CurrentSet.Flashcards = Flashcards.ToList();
                        _context.FlashcardSets.Update(CurrentSet);

                        foreach (Flashcard card in Flashcards)
                        {
                            _context.Flashcards.Update(card);
                        }

                        _context.SaveChanges();
                        SetUpdated?.Invoke();

                        //MainViewModel.Instance.CurrentView = new MySetsViewModel(flashcardsDbContext, this);
                        MainViewModel.Instance.MySetsViewCommand.Execute(null);
                    }
                }
            });

        }
    }
    }
