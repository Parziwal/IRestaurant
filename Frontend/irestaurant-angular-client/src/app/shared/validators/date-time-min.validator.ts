import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

/**
 * Validátor, ami ellenőrzi, hogy a megadott idő a paraméterként beállított idő után van-e, ha
 * nem akkor ezt hibaként jelzi.
 * @param min A minimális megadható időpont.
 * @returns Valid-e a megadott időpont.
 */
export function dateTimeMin(min: Date): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
        if (control.value !== undefined && new Date(control.value) < min) {
            return { dateTimeMin: true };
        }
        return null;
    }
}