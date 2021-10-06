import { Injectable } from '@angular/core';
import { MatPaginatorIntl } from '@angular/material/paginator';
import { Subject } from 'rxjs';
import '@angular/localize/init';

@Injectable()
/**
 * A angular material-os lapozó elem internalizálása.
 */
export class HuPaginatorIntl implements MatPaginatorIntl {
  changes = new Subject<void>();

  firstPageLabel = $localize`Első oldal`;
  itemsPerPageLabel = $localize`Oldalankénti tételek:`;
  lastPageLabel = $localize`Utolsó oldal`;

  nextPageLabel = 'Következő oldal';
  previousPageLabel = 'Előző oldal';

  getRangeLabel(page: number, pageSize: number, length: number): string {
    if (length === 0) {
      return $localize`oldal 1 / 1`;
    }
    const amountPages = Math.ceil(length / pageSize);
    return $localize`Oldal ${page + 1} / ${amountPages}`;
  }
}
