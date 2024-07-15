namespace ResumeProject.Exceptions
{
    public class RestException : Exception
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        public RestException(int status, string message) 
        {
            Status = status;
            Message = message;
        }

        public RestException(int status, List<string> errors)
        {
            Status = status;
            Errors = errors;
        }

        public RestException(int status) => Status = status;
        public RestException(string message) => Message = message;
    }
}
