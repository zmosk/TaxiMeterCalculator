import { Directive } from '@angular/core';
import { AbstractControl, Validator, NG_VALIDATORS, ValidationErrors } from '@angular/forms';

@Directive({
  selector: '[appMileageValidator]',
  providers: [{
    provide: NG_VALIDATORS,
    useExisting: MileageValidatorDirective,
    multi: true
  }]
})
export class MileageValidatorDirective implements Validator {

  validate(control: AbstractControl): { [key: string]: boolean } | null {
    let mileage = control.value;
    if (mileage === null || mileage === undefined)
      return null;

    let decimalPortions = mileage.toString().split('.');
    if(decimalPortions.length < 2)
      return null;

    if (decimalPortions[1].length > 1 || decimalPortions[1] % 2 !== 0) {
      return { 'mileageValid': false };
    }
      return null;
    
  }

}
