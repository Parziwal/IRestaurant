import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-confirmation-dialog',
  templateUrl: './confirmation-dialog.component.html',
  styleUrls: ['./confirmation-dialog.component.css']
})

export class ConfirmationDialogComponent {

  /** A megerősítő dilógus ablak szövege. */
  confirmMessage!: string;

  constructor(public dialogRef: MatDialogRef<ConfirmationDialogComponent>) {}
}
