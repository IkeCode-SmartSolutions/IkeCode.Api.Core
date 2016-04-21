using System;

namespace IkeCode.Api.Core
{
    public class IkeCodeApiResponse<TResult> : IIkeCodeApiResponse<TResult>
    {
        public TResult Content { get; private set; }
        public string Status { get; private set; }
        public string Message { get; private set; }
        public string InnerExceptionMessage { get; private set; }

        private IkeCodeApiResponse(string status)
        {
            Status = status;
        }

        public IkeCodeApiResponse(string status, Exception ex)
            : this(status)
        {
            Message = ex.Message;
            InnerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : null;
        }
        
        public IkeCodeApiResponse(IkeCodeResponseStatus status, Exception ex)
            : this(status.ToString(), ex)
        {
        }

        public IkeCodeApiResponse(string status, TResult content)
            : this(status)
        {
            Content = content;
        }

        public IkeCodeApiResponse(IkeCodeResponseStatus status, TResult content)
            : this(status.ToString(), content)
        {
        }
    }
}
