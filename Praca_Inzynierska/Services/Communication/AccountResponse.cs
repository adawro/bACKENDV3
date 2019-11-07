using System.Collections.Generic;
using Praca_Inzynierska.DTO;

namespace Praca_Inzynierska.Services.Communication
{
    public class AccountResponse : Response
    {
        public JwtTokenDto Token { get; }

        private AccountResponse(bool success, Dictionary<string, string[]> message, JwtTokenDto token)
            : base(success, message)
        {
            Token = token;
        }

        public AccountResponse(JwtTokenDto token)
            : this(true, new Dictionary<string, string[]>(), token)
        {
        }

        public AccountResponse(Dictionary<string, string[]> message)
            : this(false, message, null)
        {
        }
    }
}
