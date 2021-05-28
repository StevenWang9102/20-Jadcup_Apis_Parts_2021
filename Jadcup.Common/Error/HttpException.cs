using System;
using System.Net;

namespace Jadcup.Common.Error {
    public class HttpException : Exception {
        public HttpException(
            int httpStatusCode,
            SystemMessage userMessage = null,
            string developerMessage = null
        ) : base(developerMessage ?? userMessage?.Message) {
            StatusCode = httpStatusCode;
            UserMessage = userMessage;
        }

        public HttpException(
            HttpStatusCode httpStatusCode,
            SystemMessage userMessage = null,
            string developerMessage = null
        ) : base(developerMessage ?? userMessage?.Message) {
            StatusCode = (int)httpStatusCode;
            UserMessage = userMessage;
        }

        public HttpException(
            int httpStatusCode,
            Exception inner,
            SystemMessage userMessage = null,
            string developerMessage = null
        ) : base(developerMessage ?? userMessage?.Message, inner) {
            StatusCode = httpStatusCode;
            UserMessage = userMessage;
        }

        public HttpException(
            HttpStatusCode httpStatusCode,
            Exception inner,
            SystemMessage userMessage = null,
            string developerMessage = null
        ) : base(developerMessage ?? userMessage?.Message, inner) {
            StatusCode = (int)httpStatusCode;
            UserMessage = userMessage;
        }

        public int StatusCode { get; }
        public SystemMessage UserMessage { get; }
    }
}