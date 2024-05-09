using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flashcards.Core;

namespace Flashcards.MVVM.Model
{
    public class Flashcard : ObservableObject
    {
        private string _front;
        private string _back;
        private byte[] _image;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("FlashcardSetId")]
        public int FlashcardSetId { get; set; }
        public virtual FlashcardSet FlashcardSet { get; set; }

        [Required(ErrorMessage = "Front of the flashcard is required.")]
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

        [Required(ErrorMessage = "Back of the flashcard is required.")]
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

        public int? PictureId { get; set; } 
        public virtual Picture Picture { get; set; }

        public Flashcard(string front, string back, int? pictureId = null)
        {
            Front = front;
            Back = back;
            PictureId = pictureId; 
        }


    }
}
