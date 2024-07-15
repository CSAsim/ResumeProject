namespace ResumeProject.Response
{
    public class BaseResponse
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}
