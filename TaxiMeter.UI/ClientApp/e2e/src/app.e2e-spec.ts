import { browser, by, element, Key } from 'protractor';

describe('TaxiFare', () => {

  beforeEach(() => {
    browser.get('https://localhost:44342');
  });

  it('should display title', () => {
    expect(element(by.tagName('h1')).getText()).toEqual('Taxi Meter Calculator');
  });

  it('should return initial charge when button is clicked', function () {

    element(by.tagName('button')).click();

    expect(element(by.id('under6mph')).getAttribute('value')).toEqual('0');
    expect(element(by.id('over6mph')).getAttribute('value')).toEqual('0');
    expect(element(by.id('fare')).getText()).toContain('Your fare is: $');
  });

  it('should return charge of $9.75 for given scenario', function () {

    element(by.id('under6mph')).clear();
    element(by.id('under6mph')).sendKeys(2);
    expect(element(by.id('under6mph')).getAttribute('value')).toEqual('2');

    element(by.id('over6mph')).clear();
    element(by.id('over6mph')).sendKeys(5);
    expect(element(by.id('over6mph')).getAttribute('value')).toEqual('5');

    element(by.id('dateOfRide')).clear();
    element(by.id('dateOfRide')).sendKeys(10082010);
    expect(element(by.id('dateOfRide')).getAttribute('value')).toEqual('2010-10-08');


    element(by.id('startTimeOfRide')).clear();
    element(by.id('startTimeOfRide')).sendKeys('530PM');
    expect(element(by.id('startTimeOfRide')).getAttribute('value')).toEqual('17:30');

    element(by.tagName('button')).click();
    expect(element(by.id('fare')).getText()).toContain('Your fare is: $9.75');
  });

  it('should disable Submit button if miles under 6 mph is empty', function () {

    element(by.id('under6mph')).clear();

    expect(element(by.id('under6mph')).getAttribute('value')).toEqual('');
    expect(element(by.tagName('button')).isEnabled()).toBeFalsy();
  });

  it('should disable Submit button if minutes over 6 mph is empty', function () {

    element(by.id('over6mph')).clear();

    expect(element(by.id('over6mph')).getAttribute('value')).toEqual('');
    expect(element(by.tagName('button')).isEnabled()).toBeFalsy();
  });

  it('should disable Submit button if date of ride is empty', function () {

    element(by.id('dateOfRide')).click();
    element(by.id('dateOfRide')).sendKeys(Key.DELETE);

    expect(element(by.id('dateOfRide')).getAttribute('value')).toEqual('');
    expect(element(by.tagName('button')).isEnabled()).toBeFalsy();
  });

  it('should disable Submit button if start time of ride is empty', function () {

    element(by.id('startTimeOfRide')).click();
    element(by.id('startTimeOfRide')).sendKeys(Key.DELETE);

    expect(element(by.id('startTimeOfRide')).getAttribute('value')).toEqual('');
    expect(element(by.tagName('button')).isEnabled()).toBeFalsy();
  });

});
