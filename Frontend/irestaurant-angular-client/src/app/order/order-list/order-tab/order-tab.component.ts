import { Component, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { PagedList } from 'src/app/shared/models/pagedList.type';
import { OrderOverview } from '../../models/order-overview.type';

@Component({
  selector: 'app-order-tab',
  templateUrl: './order-tab.component.html',
  styleUrls: ['./order-tab.component.css']
})
export class OrderTabComponent {

  /** A rendelések áttekintő adatait tartalmazza. */
  @Input() orderOverviewPagedList: Observable<PagedList<OrderOverview>> = new Observable();

}
