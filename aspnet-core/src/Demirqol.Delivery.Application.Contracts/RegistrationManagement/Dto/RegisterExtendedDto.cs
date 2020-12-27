using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Account;

namespace Demirqol.Delivery.RegistrationManagement.Dto
{
    public class RegisterExtendedDto: RegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumer { get; set; }
        public RegistrationType RegistrationType { get; set; }
    }
}
