namespace Jadcup.Common.Response {
    public class Response<T> {
        public Response(){}
        public Response(T data) {
            Data = data;
        }
        public T Data { get; set; }
    }
}