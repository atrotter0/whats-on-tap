namespace WhatsOnTap.ViewModels
{
    public class ProfileViewModel
    {
        public string Email { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }

        public ProfileViewModel() {}

        public ProfileViewModel(string email)
        {
            Email = email;
        }
    }
}