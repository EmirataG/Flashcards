using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;
using Flashcards.Core;

namespace Flashcards.MVVM.Model
{
    public class FlashcardSet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User Creator { get; set; }

        [Required(ErrorMessage = "Set name is required.")]
        public string SetName { get; set; }

        public virtual ICollection<Flashcard> Flashcards { get; set; } = new ObservableCollection<Flashcard>();


        public FlashcardSet(string setName, User creator)
        {
            SetName = setName;
            Creator = creator;
            Flashcards = new ObservableCollection<Flashcard>();
        }

        public FlashcardSet()
        {
        }

        public void AddFlashcard(Flashcard flashcard)
        {
            flashcard.FlashcardSet = this;
            Flashcards.Add(flashcard);
        }
    }
}
