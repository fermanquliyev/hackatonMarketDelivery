import type { RegisterDto } from '../../volo/abp/account/models';
import type { RegistrationType } from './registration-type.enum';

export interface RegisterExtendedDto extends RegisterDto {
  name: string;
  surname: string;
  phoneNumer: string;
  registrationType: RegistrationType;
}

export interface UserPositionDto {
  latitude: number;
  longitude: number;
}
