using System;
using System.Collections.ObjectModel;

namespace Flashcards.MVVM.Model
{
    public class DemoSets
    {
        public static ObservableCollection<User> TestUsers = new ObservableCollection<User>()
        {
            new User( "Emir", "emir@gmail.com","12345678"),
            new User( "Ervin", "ervin@gmail.com", "12345678"),
            new User( "Aksin", "aksin@gmail.com", "12345678")
        };


        public static ObservableCollection<FlashcardSet> TestSets()
        {
            Flashcard flashcard1 = new Flashcard("Kirche", "Chirch");
            Flashcard flashcard2 = new Flashcard("Krankenhaus", "Hospital");
            Flashcard flashcard3 = new Flashcard("Hotel", "Hotel");
            Flashcard flashcard4 = new Flashcard("Schule", "School");
            Flashcard flashcard5 = new Flashcard("Buch", "Book");

            FlashcardSet flashcardSet1 = new FlashcardSet("Buildings", TestUsers[0]);
            FlashcardSet flashcardSet2 = new FlashcardSet("Buildings", TestUsers[1]);
            FlashcardSet flashcardSet3 = new FlashcardSet("Buildings", TestUsers[2]);
            FlashcardSet flashcardSet4 = new FlashcardSet("Buildings", TestUsers[0]);

            flashcardSet1.AddFlashcard(flashcard1);
            flashcardSet1.AddFlashcard(flashcard2);
            flashcardSet2.AddFlashcard(flashcard3);
            flashcardSet2.AddFlashcard(flashcard4);
            flashcardSet3.AddFlashcard(flashcard5);
            flashcardSet4.AddFlashcard(flashcard1);
            return new ObservableCollection<FlashcardSet>() { flashcardSet1, flashcardSet2, flashcardSet3, flashcardSet4 };
        }
    }
}
