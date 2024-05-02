namespace Flashcards.MVVM.Model
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public User(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
