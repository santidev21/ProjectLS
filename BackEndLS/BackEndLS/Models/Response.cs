namespace BackEndLS.Models
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Value { get; set; }


        public Response()
        {
        }
        public Response(bool success, string message, T value)
        {
            this.Success = success;
            this.Message = message;
            this.Value = value;
        }
    }
}
