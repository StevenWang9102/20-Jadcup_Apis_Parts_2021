namespace Jadcup.Common.Error {
    public class HttpExceptionResponse {
        public SystemMessage Message { get; set; }
        public string InnerMessage { get; set; }
        public int StatusCode { get; set; }
    }
}