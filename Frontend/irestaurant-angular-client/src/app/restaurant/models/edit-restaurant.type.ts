import { UserAddress } from 'src/app/shared/models/user-address.type';

export interface EditRestaurant {
  name: string;
  shortDescription: string;
  detailedDescription: string;
  address: UserAddress;
}
