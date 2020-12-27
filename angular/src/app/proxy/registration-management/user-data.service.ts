import type { RegisterExtendedDto, UserPositionDto } from './dto/models';
import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { IdentityUserDto } from '../volo/abp/identity/models';

@Injectable({
  providedIn: 'root',
})
export class UserDataService {
  apiName = 'Default';

  registerByRegisterExtendedDto = (registerExtendedDto: RegisterExtendedDto) =>
    this.restService.request<any, IdentityUserDto>({
      method: 'POST',
      url: `/api/app/userData/register`,
      body: registerExtendedDto,
    },
    { apiName: this.apiName });

  setUserPositionByUserPositionDto = (userPositionDto: UserPositionDto) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/userData/setUserPosition`,
      body: userPositionDto,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
