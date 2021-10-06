import {
  Directive,
  HostListener,
  HostBinding,
  ElementRef,
  ContentChild,
} from '@angular/core';

@Directive({
  selector: '[appDropdownMenu]',
})

/**
 * A Bootstrap-es lenyiló menük kinyitását és becsukását végzi.
 * Ezt a "dropdown-menu" class-al rendelkező elemre kell tenni.
 */
export class DropdownMenuDirective {
  @HostBinding('class.show') isOpen = false;
}

@Directive({
  selector: '[appDropdown]',
})

/**
 * A Bootstrap-es lenyiló menük kinyitását és becsukását végzi.
 * Ezt a "dropdown" class-al rendelkező elemre kell tenni.
 */
export class DropdownDirective {
  @ContentChild(DropdownMenuDirective)
  private dropdownMenu!: DropdownMenuDirective;

  @HostBinding('class.show') private isOpen = false;

  @HostListener('document: click', ['$event']) private toggelOpen(
    event: Event
  ) {
    this.isOpen = this.elRef.nativeElement.contains(event.target)
      ? !this.isOpen
      : false;
    this.dropdownMenu.isOpen = this.isOpen;
  }

  constructor(private elRef: ElementRef) {}
}
