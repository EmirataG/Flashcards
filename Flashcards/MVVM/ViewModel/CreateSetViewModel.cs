using Flashcards.Core;
using Flashcards.MVVM.Model;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;

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
        public CreateSetViewModel()
        {
            SetName = "Set Name";

            NewSet = new ObservableCollection<Flashcard>()
            { 
                new Flashcard("Front", "Back"),
                new Flashcard("Front", "Back"),
                new Flashcard("Front kok", "Back")
            };

            AddCardCommand = new RelayCommand(o => {
                NewSet.Add(new Flashcard("Front", "Back"));
                foreach(Flashcard c in NewSet)
                {
                    Debug.WriteLine($"{c.Front} - {c.Back}");
                }
            });

            DeleteCardCommand = new RelayCommand(o => {
                if(NewSet.Count > 3) 
                {
                    if (o is Flashcard card)
                    {
                        NewSet.Remove(card);
                    }
                }
                else
                {
                    MessageBox.Show("The set must include at least 3 cards!");
                }
            });


            CreateSetCommand = new RelayCommand(o =>
            {
                DemoSets.TestSets.Add(new FlashcardSet(SetName, MainViewModel.Instance.CurrentUser, NewSet.ToArray()));
            });
        }
    }
}
