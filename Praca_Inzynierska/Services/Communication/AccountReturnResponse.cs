using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Praca_Inzynierska.DTO.ReturnDto;

namespace Praca_Inzynierska.Services.Communication
{
    public class AccountReturnResponse : Response
    {
        public AccountReturn User { get; }

        private AccountReturnResponse(bool success, Dictionary<string, string[]> message, AccountReturn user)
            : base(success, message)
        {
            User = user;
        }

        public AccountReturnResponse(AccountReturn user)
            : this(true, new Dictionary<string, string[]>(), user)
        {
        }

        public AccountReturnResponse(Dictionary<string, string[]> message)
            : this(false, message, null)
        {
        }
    }
   
}
