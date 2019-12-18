using System;
using System.Collections.Generic;

namespace API.Infrastructure
{
    public class BusinessException : Exception
    { 
        private static readonly Dictionary<ErrorCodes, string> ErrorDescriptions;
        static BusinessException()
        {
            ErrorDescriptions = new Dictionary<ErrorCodes, string>()
            {
                // { ErrorCodes.KEY, "" }
            };
        }

        public ClientSideError Error { get; private set; }

        public BusinessException(ErrorCodes errorCode) : base(errorCode.ToString())
        {
            Error = new ClientSideError()
            {
                Code = errorCode,
                Message = FindMessage(errorCode)
            };
        }

        private string FindMessage(ErrorCodes errorCode)
        {
            return ErrorDescriptions.ContainsKey(errorCode) 
                ? ErrorDescriptions[errorCode] 
                : "No message set for this error code";
        }
    }
}