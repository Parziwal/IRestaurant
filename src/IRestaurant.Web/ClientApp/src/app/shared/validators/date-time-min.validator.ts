import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function dateTimeMin(min: Date): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
        if (control.value !== undefined && new Date(control.value) < min) {
            return { dateTimeMin: true };
        }
        return null;
    }
}