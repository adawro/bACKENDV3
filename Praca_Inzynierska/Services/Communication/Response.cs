using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska.Services.Communication
{
    public class Response
    {
        public bool Success { get; }
        public Dictionary<string, string[]> Message { get; }

        public Response(bool success, Dictionary<string, string[]> message)
        {
            Success = success;
            Message = message;
        }
    }
}
