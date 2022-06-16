import { TaxiService } from './taxi.service';
import { HttpClient } from '@angular/common/http';
import { TaxiRide } from '../taxi-ride';
import { of } from 'rxjs';

let taxiService: TaxiService

describe('TaxiService', () => {
  let httpClientSpy: jasmine.SpyObj<HttpClient>;
  let baseUrlSpy: any;
  let taxiRideSpy: jasmine.SpyObj<TaxiRide>;

  beforeEach(() => {
    httpClientSpy = jasmine.createSpyObj('HttpClient', ['post']);
    baseUrlSpy = jasmine.createSpyObj('Inject', ['get']);
    taxiService = new TaxiService(httpClientSpy, baseUrlSpy);
  });

  it('should be created', () => {
    expect(taxiService).toBeTruthy();
  });

  it('should return numeric result', (done: DoneFn) => {
    const expectedResult: number = 26.50;

    httpClientSpy.post.and.returnValue(of(expectedResult));

    taxiService.calculateFare(taxiRideSpy).subscribe({
      next: number => {
        expect(expectedResult)
          .withContext('expected taxi fare')
          .toEqual(expectedResult);
        done();
      },
      error: done.fail
    });

    expect(httpClientSpy.post.calls.count())
      .withContext('one call')
      .toBe(1);
  });
});
