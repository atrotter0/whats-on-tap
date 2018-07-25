using System.ComponentModel.DataAnnotations;

namespace WhatsOnTap.ViewModels
{
    public class ProfileViewModel
    {
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        public ProfileViewModel() {}

        public ProfileViewModel(string email)
        {
            Email = email;
        }
    }
}