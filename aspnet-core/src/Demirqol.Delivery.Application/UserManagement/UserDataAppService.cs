using Demirqol.Delivery.RegistrationManagement.Dto;
using Demirqol.Delivery.Users;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Account;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace Demirqol.Delivery.RegistrationManagement
{
    public class UserDataAppService : DeliveryAppService
    {
        private readonly IdentityUserManager _identityUserManager;
        private readonly IIdentityRoleRepository _identityRoleRepository;
        private readonly IRepository<UserPosition> _userPositionRepository;
        private readonly IAccountAppService _accountAppService;

        public UserDataAppService(IdentityUserManager identityUserManager,
            IIdentityRoleRepository identityRoleRepository,
            IRepository<UserPosition> userPositionRepository,
            IAccountAppService accountAppService)
        {
            _identityUserManager = identityUserManager;
            _identityRoleRepository = identityRoleRepository;
            _userPositionRepository = userPositionRepository;
            _accountAppService = accountAppService;
        }

        public async Task<IdentityUserDto> Register(RegisterExtendedDto registerExtendedDto)
        {
            var result = await _accountAppService.RegisterAsync(registerExtendedDto);
            await CurrentUnitOfWork.SaveChangesAsync();
            var identityUser = await _identityUserManager.FindByIdAsync(result.Id.ToString());
            identityUser.SetPhoneNumber(registerExtendedDto.PhoneNumer, false);
            result.Name = identityUser.Name = registerExtendedDto.Name;
            result.Surname = identityUser.Surname = registerExtendedDto.Surname;
            result.PhoneNumber = registerExtendedDto.PhoneNumer;
            if (registerExtendedDto.RegistrationType == RegistrationType.Deliverer)
            {
                var roles = await _identityRoleRepository.GetListAsync();
                identityUser.AddRole(roles.FirstOrDefault(x => x.Name == "deliverer").Id);
                if (identityUser.IsInRole(roles.FirstOrDefault(x => x.Name == "customer").Id))
                {
                    identityUser.RemoveRole(roles.FirstOrDefault(x => x.Name == "customer").Id);
                }
            }
            return result;
        }

        [Authorize]
        public async Task SetUserPosition(UserPositionDto userPositionDto)
        {
            var userPosition = await AsyncExecuter.FirstOrDefaultAsync(_userPositionRepository.Where(x => x.Id == CurrentUser.Id));
            if (userPosition != null)
            {
                userPosition.Latitude = userPositionDto.Latitude;
                userPosition.Longitude = userPositionDto.Longitude;
            }
            else
            {
                await _userPositionRepository.InsertAsync(new UserPosition(CurrentUser.Id.GetValueOrDefault())
                {
                    Latitude = userPositionDto.Latitude,
                    Longitude = userPositionDto.Longitude
                });
            }
        }
    }
}
