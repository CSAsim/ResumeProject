namespace ResumeProject.DTOs.Auth
{
    public class ResetPasswordDTO
    {
        public string Token { get; set; }
        public string Old_Password { get; set; }
        public string New_Password { get; set; }
        public string Confirm_Password {  get; set; }
    }
}
