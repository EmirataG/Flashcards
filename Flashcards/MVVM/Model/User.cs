using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using Flashcards.Core;
using Flashcards.Utils;

namespace Flashcards.MVVM.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public int? PictureId { get; set; }
        public virtual Picture Picture { get; set; }

        private string _password;
        [Required(ErrorMessage = "Password is required.")]
        public string Password
        {
            get { return _password; }
            set { _password = UserUtils.ComputeSha256Hash(value); }
        }

        public virtual ICollection<FlashcardSet> FlashcardSets { get; set; } = new ObservableCollection<FlashcardSet>();

        public User(string username, string email, string password, int? pictureId = null)
        {
            Username = username;
            Email = email;
            Password = password;
            PictureId = pictureId;
            FlashcardSets = new List<FlashcardSet>();
        }

    }
}
