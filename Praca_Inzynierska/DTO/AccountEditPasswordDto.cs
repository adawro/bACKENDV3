using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska.DTO
{
    public class AccountEditPasswordDto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
