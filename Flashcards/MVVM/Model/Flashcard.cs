using Flashcards.Core;

namespace Flashcards.MVVM.Model
{
    public class Flashcard : ObservableObject
    {
        private string _front;
        private string _back;

        public string Front
        {
            get { return _front; }
            set
            {
                if (_front != value)
                {
                    _front = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Back
        {
            get { return _back; }
            set
            {
                if (_back != value)
                {
                    _back = value;
                    OnPropertyChanged();
                }
            }
        }

        public Flashcard(string front, string back)
        {
            Front = front;
            Back = back;
        }
    }
}
