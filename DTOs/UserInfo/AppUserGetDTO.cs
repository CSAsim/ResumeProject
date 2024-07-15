namespace ResumeProject.DTOs.UserInfo
{
    public class AppUserGetDTO
    {
        public int Id { get; set; } 
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Confirm {  get; set; }
    }
}
