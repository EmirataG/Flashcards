namespace Flashcards.MVVM.Model
{
    public class Flashcard
    {
        public string Front { get; set; }
        public string Back { get; set; }

        public Flashcard(string front, string back)
        {
            Front = front;
            Back = back;
        }
    }
}
