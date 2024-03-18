namespace TechnicalInstance.Common.Dtos
{
    public class ResponseDto<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } 
        public T Result { get; set; }
    }
}
