using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;

namespace Flashcards.MVVM.Model
{
    internal class DemoSets
    {
        public static ObservableCollection<User> TestUsers = new ObservableCollection<User>()
        {
            new User(1, "Emir"),
            new User(2, "Ervin"),
            new User(3, "Aksin")
        };
        public static ObservableCollection<FlashcardSet> TestSets { get; set; } = new ObservableCollection<FlashcardSet>()
        {
            new FlashcardSet("Buildings", TestUsers[0],
                new Flashcard("Kirche", "Chirch"), new Flashcard("Krankenhaus", "Hospital"), new Flashcard("Hotel", "Hotel")),
            new FlashcardSet("Things", TestUsers[1],
                new Flashcard("Kirche", "Chirch"), new Flashcard("Krankenhaus", "Hospital"), new Flashcard("Hotel", "Hotel")),
            new FlashcardSet("Others", TestUsers[2],
                new Flashcard("Kirche", "Chirch"), new Flashcard("Krankenhaus", "Hospital"), new Flashcard("Hotel", "Hotel")),
            new FlashcardSet("Buildings", TestUsers[0],
                new Flashcard("Kirche", "Chirch"), new Flashcard("Krankenhaus", "Hospital"), new Flashcard("Hotel", "Hotel")),
            new FlashcardSet("Things", TestUsers[1],
                new Flashcard("Kirche", "Chirch"), new Flashcard("Krankenhaus", "Hospital"), new Flashcard("Hotel", "Hotel")),
            new FlashcardSet("Others", TestUsers[2],
                new Flashcard("Kirche", "Chirch"), new Flashcard("Krankenhaus", "Hospital"), new Flashcard("Hotel", "Hotel")),
            new FlashcardSet("Buildings", TestUsers[0],
                new Flashcard("Kirche", "Chirch"), new Flashcard("Krankenhaus", "Hospital"), new Flashcard("Hotel", "Hotel")),
            new FlashcardSet("Things", TestUsers[1],
                new Flashcard("Kirche", "Chirch"), new Flashcard("Krankenhaus", "Hospital"), new Flashcard("Hotel", "Hotel")),
            new FlashcardSet("Others", TestUsers[2],
                new Flashcard("Kirche", "Chirch"), new Flashcard("Krankenhaus", "Hospital"), new Flashcard("Hotel", "Hotel")),
            new FlashcardSet("Buildings", TestUsers[0],
                new Flashcard("Kirche", "Chirch"), new Flashcard("Krankenhaus", "Hospital"), new Flashcard("Hotel", "Hotel")),
            new FlashcardSet("Things", TestUsers[1],
                new Flashcard("Kirche", "Chirch"), new Flashcard("Krankenhaus", "Hospital"), new Flashcard("Hotel", "Hotel")),
            new FlashcardSet("Others", TestUsers[2],
                new Flashcard("Kirche", "Chirch"), new Flashcard("Krankenhaus", "Hospital"), new Flashcard("Hotel", "Hotel"))
        };
    }
}
