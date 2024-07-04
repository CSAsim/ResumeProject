namespace ResumeProject.DTOs.EmploymentHistory
{
    public class EmploymentHistoryUpdateDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly? Start_Date { get; set; }
        public DateOnly? End_Date { get; set; }
        public int User_Id { get; set; }
    }
}
