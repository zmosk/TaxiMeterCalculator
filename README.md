# TaxiMeterCalculator

This solution is a Visual Studio solution and therefore should be opened in Visual Studio.
It contains 4 projects:
1) TaxiMeter.Common - contains the models that represent a TaxiRide
2) TaxiMeter.Services - contains a CalculatorService and Rules
3) TaxiMeter.Services.Test - contains c# unit tests for the service and rules
4) TaxiMeter.UI - this is an asp.ne core ASP.NET and Angular project
   - ClientApp folder which contains all the Angular code. Protractor e2e tests are in the e2e folder
   - Controllers folder that contains the TaxiFareController api
  
Ensure that TaxiMeter.UI is set as the startup project.
<br />Once set as startup, the solution can be run by clicking the IIS Express green run button on top.
The page will open at `https://localhost:44342`.

To run the Angular unit tests, open a command prompt at the TaxiMeter.UI folder and run `ng test`.
<br />To run the protractor e2e tests, run `ng e2e` at the same location.
