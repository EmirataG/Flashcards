using System.Collections.ObjectModel;

namespace Flashcards.MVVM.Model
{
    internal class DemoSets
    {
        public static ObservableCollection<User> TestUsers = new ObservableCollection<User>()
        {
            new User(1, "Emir", "12345678"),
            new User(2, "Ervin", "12345678"),
            new User(3, "Aksin", "12345678")
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
