namespace PostgreSql_API_4.Models
{
    public class ResponseModel
    {
        public ResponseType Type { get; set; }
        public object? Data { get; set; }
    }

    public enum ResponseType
    {
        Success,
        Failure
    }
}
