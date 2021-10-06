import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { faTimes } from '@fortawesome/free-solid-svg-icons';
import { OrderSearch } from '../../models/order-search.type';
import { OrderSortBy } from '../../models/order-sort-by.type';
import { OrderService } from '../../order.service';

@Component({
  selector: 'app-order-search-bar',
  templateUrl: './order-search-bar.component.html',
  styleUrls: ['./order-search-bar.component.css']
})
export class OrderSearchBarComponent implements OnInit {

  /** Törlési ikon. */
  faTimes = faTimes;

  /** A keresési feltétel. */
  @Input() search: OrderSearch = <OrderSearch>{};

  /** A rendelési lista frissítésére vonatkozó esemény. */
  @Output() refreshOrderList = new EventEmitter<void>();

  /** A lehetséges rendezési szempontokat tartalmazó lista. */
  orderSortByOptions = Object.keys(OrderSortBy)
    .map(s => ({
      value: s,
      text: this.orderService.getOrderSortByInString(s as OrderSortBy)
    }));

  /** Azon rendelési dátumokat tartalmazza, amik az alsó határát jelentik a kilistázott rendeléseknek. */
  orderDateOptions: {value: string, text: string}[] = [];

  constructor(private orderService: OrderService) { }

  ngOnInit() {
    this.initOrderMinDateOptions();
    this.refreshOrderList.emit();
  }

  private initOrderMinDateOptions() {
    this.orderDateOptions = [
      { value: new Date(new Date().setMonth(new Date().getMonth() - 1)).toISOString(), text: "Előző 30 napban" },
      { value: new Date(new Date().setMonth(new Date().getMonth() - 3)).toISOString(), text: "Előző 3 hónapban" }
    ];

    for (let i = new Date().getFullYear(); i > 2010; i--) {
      this.orderDateOptions.push(
        { value: new Date(new Date().setFullYear(i, 0, 1)).toISOString() + "#" +  new Date(new Date().setFullYear(i + 1, 0, 1)).toISOString(), text: i.toString()}
      );
    }

    this.search.orderMinDate = this.orderDateOptions[0].value;
  }
                                
 /**
  * A kereső mező törlése és a rendelések listájának frissítése.
  */
  clearBrowser() {
    this.search.restaurantName = "";
    this.search.guestName = "";
    this.refreshOrderList.emit();
  }

  /**
   * A kiválasztott rendelési dátum tartomány megváltozásakor beállítja a keresési
   * feltétel megfelelő értékeit és kiad egy a rendelési lista frissítésére vonatkozó eseményt.
   * @param dateRange A kiválasztott rendelési dátum tartomány.
   */
  orderDateRangeChanged(dateRange: string) {
    this.search.orderMinDate = dateRange.split("#")[0];
    let maxDate = dateRange.split("#")[1];
    if (maxDate === undefined) {
      delete this.search.orderMaxDate;
    } else {
      this.search.orderMaxDate = maxDate;
    }

    this.refreshOrderList.emit();
  }
}
