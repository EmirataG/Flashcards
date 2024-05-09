using Flashcards.Core;
using Flashcards.MVVM.Model;
using Flashcards.MVVM.Model.Context;
using Flashcards.MVVM.ViewModel.Registration;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media;

namespace Flashcards.MVVM.ViewModel
{
    public class ProfileViewModel : ObservableObject
    {
        public User CurrentUser { get; set; }

        // USERNAME BUTTON STUFF
        private readonly FlashcardsDbContext _context;





        private bool _isReadOnlyUsername;
        public bool IsReadOnlyUsername
        {
            get { return _isReadOnlyUsername; }
            set
            {
                _isReadOnlyUsername = value;
                OnPropertyChanged(nameof(IsReadOnlyUsername));
            }
        }

        private string _usernameButtonContent;
        public string UsernameButtonContent
        {
            get { return _usernameButtonContent; }
            set
            {
                _usernameButtonContent = value;
                OnPropertyChanged(nameof(UsernameButtonContent));
            }
        }

        private Brush _usernameButtonColor;
        public Brush UsernameButtonColor
        {
            get { return _usernameButtonColor; }
            set
            {
                _usernameButtonColor = value;
                OnPropertyChanged(nameof(UsernameButtonColor));
            }
        }

        // EMAIL BUTTON STUFF

        private bool _isReadOnlyEmail;
        public bool IsReadOnlyEmail
        {
            get { return _isReadOnlyEmail; }
            set
            {
                _isReadOnlyEmail = value;
                OnPropertyChanged(nameof(IsReadOnlyEmail));
            }
        }

        private string _emailButtonContent;
        public string EmailButtonContent
        {
            get { return _emailButtonContent; }
            set
            {
                _emailButtonContent = value;
                OnPropertyChanged(nameof(EmailButtonContent));
            }
        }

        private Brush _emailButtonColor;
        public Brush EmailButtonColor
        {
            get { return _emailButtonColor; }
            set
            {
                _emailButtonColor = value;
                OnPropertyChanged(nameof(EmailButtonColor));
            }
        }


        public RelayCommand EditUsernameCommand { get; set; }
        public RelayCommand EditEamilCommand { get; set; }
        public RelayCommand LogOutCommand { get; set; }
        public RelayCommand UploadImageCommand { get; set; }

        public ProfileViewModel(FlashcardsDbContext flashcardsDbContext)
        {
            this._context = flashcardsDbContext;
            CurrentUser = _context.Users.Find(MainViewModel.Instance.CurrentUser.ID);

            EditUsernameCommand = new RelayCommand(EditUsername);
            EditEamilCommand = new RelayCommand(EditEmail);
            UploadImageCommand = new RelayCommand(UploadImage);

            IsReadOnlyUsername = true;
            UsernameButtonContent = "Edit";
            UsernameButtonColor = Brushes.PeachPuff;

            IsReadOnlyEmail = true;
            EmailButtonContent = "Edit";
            EmailButtonColor = Brushes.PeachPuff;

            LogOutCommand = new RelayCommand(o =>
            {
                WindowViewModel.GetInstance(_context).CurrentView = new RegistrationViewModel(_context);
            });
        }

        private void EditUsername(object o)
        {
            IsReadOnlyUsername = !IsReadOnlyUsername;
            UsernameButtonContent = IsReadOnlyUsername ? "Edit" : "Done?";
            UsernameButtonColor = IsReadOnlyUsername ? Brushes.PeachPuff : Brushes.LightSeaGreen;

            _context.Users.Update(CurrentUser);
            _context.SaveChanges();
        }

        private void EditEmail(object o)
        {
            IsReadOnlyEmail = !IsReadOnlyEmail;
            EmailButtonContent = IsReadOnlyEmail ? "Edit" : "Done?";
            EmailButtonColor = IsReadOnlyEmail ? Brushes.PeachPuff : Brushes.LightSeaGreen;

            _context.Users.Update(CurrentUser);
            _context.SaveChanges();
        }

        private void UploadImage(object o)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var stream = File.OpenRead(openFileDialog.FileName))
                {
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    CurrentUser.Picture = new Picture { Image = buffer };
                    _context.Users.Update(CurrentUser);
                    _context.SaveChanges();
                }
                MainViewModel.Instance.CurrentView = new ProfileViewModel(_context);
            }
        }
    }
}