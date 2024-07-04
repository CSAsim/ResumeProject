using ResumeProject.DTOs.Skills;

namespace ResumeProject.DTOs.User
{
    public class UserUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone_Number { get; set; }
        public string Profile_Description { get; set; }
        public string Nationality { get; set; }
        public string Birthplace { get; set; }
        public List<SkillsGetDTO> UserSkills { get; set; }
    }
}
