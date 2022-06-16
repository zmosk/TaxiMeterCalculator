import { async, ComponentFixture, fakeAsync, TestBed, tick } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { By } from "@angular/platform-browser";
import { of, throwError } from 'rxjs';

import { TaxiComponent } from './taxi.component';
import { TaxiService } from './taxi.service';

describe('TaxiComponent', () => {
  let component: TaxiComponent;
  let fixture: ComponentFixture<TaxiComponent>;
  let taxiServiceSpy: jasmine.SpyObj<TaxiService> = jasmine.createSpyObj('TaxiService', ['calculateFare']);

  beforeEach(async(() => {    
    TestBed.configureTestingModule({
      declarations: [TaxiComponent],
      providers: [{ provide: TaxiService, useValue: taxiServiceSpy }],
      imports: [FormsModule]
    })
      .compileComponents();

    fixture = TestBed.createComponent(TaxiComponent);
    component = fixture.componentInstance;

    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should create TaxiRide with default values', () => {
    component.ngOnInit();

    expect(component.taxiRide).toBeDefined();

    expect(component.taxiRide.milesUnder6Mph).toBe(0);
    expect(component.taxiRide.minutesOver6Mph).toBe(0);
    expect(component.taxiRide.totalFare).toBe(0);
    expect(component.taxiRide.startDateOfRide).toMatch('^\\d{4}-\\d{2}-\\d{2}$')
    expect(component.taxiRide.startTimeOfRide).toMatch('^\\d{2}:\\d{2}$')
  });

  it('should display a title', async(() => {
    const titleText = fixture.nativeElement.querySelector('h1').textContent;
    expect(titleText).toEqual('Taxi Meter Calculator');
  }));

  it('should call TaxiService and get a numeric result when successful', async(() => {
    let expectedValue = 26.50;
    taxiServiceSpy.calculateFare.and.returnValue(of(expectedValue));
    component.calculateFare();
    expect(component.totalFare).toEqual(expectedValue);
    fixture.detectChanges();

    const fareLabel = fixture.debugElement.query(By.css('#fare'));
    expect(fareLabel.nativeElement.textContent.trim()).toBe('Your fare is: $26.50');
  }));

  it('should set TotalFare to 0 when TaxiService returns with error', fakeAsync(() => {
    let expectedValue = 0;
    taxiServiceSpy.calculateFare.and.returnValue(throwError({message: 'Some error!'}));
    component.calculateFare();
    tick();
    expect(component.totalFare).toBe(expectedValue);
  }));

});
