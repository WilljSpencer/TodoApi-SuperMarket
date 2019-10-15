using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace TodoApi.Domain.Services.Communications
{
    public abstract class BaseResponse
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }
        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }

    
}
