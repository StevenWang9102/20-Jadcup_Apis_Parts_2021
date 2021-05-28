using Jadcup.Common.Error;

namespace Jadcup.Common.Model
{
    public class TaskResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public string ErrorCode { get; set; }
        public SystemMessage ErrorMessage { get; set; }
    }
}