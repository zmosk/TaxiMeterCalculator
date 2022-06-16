import { FormControl } from '@angular/forms';
import { MileageValidatorDirective } from './mileage-validator.directive';

describe('MileageValidatorDirective', () => {
  it('should create an instance', () => {
    const directive = new MileageValidatorDirective();
    expect(directive).toBeTruthy();
  });

  it('should return null when no value is input', () => {
    const mileageDirective = new MileageValidatorDirective();
    expect(mileageDirective.validate(new FormControl())).toEqual(null);
  });

  it('should return null when input is numeric', () => {
    const mileageDirective = new MileageValidatorDirective();
    expect(mileageDirective.validate(new FormControl(5))).toEqual(null);
  });

  it('should return false when input has decimal', () => {
    const mileageDirective = new MileageValidatorDirective();
    expect(mileageDirective.validate(new FormControl(5.35))).toEqual({ 'mileageValid': false });
  });

});
