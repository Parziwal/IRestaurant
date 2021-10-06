import { UserAddressWithId } from 'src/app/shared/models/user-address-with-id.type';

export interface DeliveryDetials {
  preferredDeliveryDate: Date;
  address: UserAddressWithId;
}
