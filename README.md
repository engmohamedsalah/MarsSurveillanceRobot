# MarsSurveillanceRobot

Mars Surveillance Robot repository.

This repository has all the developed code to complete assingment for Olympic Channel development department as part of the Backend Developer.



## Technologies
- .netcore 3.1

    #### Why .netCore?
    It has great benefits to create API and at the same time the output is exe so that it can work as a console application
    so from one out, I used it based on the args :
    - if the args are empty app will run the rest API
    - otherwise, it will run as a console app and it will use the arg[0] as input file and arg[1] as output file
    other benefits :
    - has built-in dependency injection
    - has the ability to add custom middleware for exception handling
    
- MSTest 
    for adding unit tests

## How to run 

#### Running obs_test.bat script
this will register the exe file to environment variables so that you can open any terminal and run :

command:

    - obs_test for run api postman or similar can be use to test the API
    - obs_test <inputfile> <outputfile> for run the app as exe

## Assumption
- the cell contains an infinity number of the same material 
-if the battery is not sufficient for the next move the robot will stop and the result will be returned
-if the robot tried the seven strategies after facing an obstacle and not being able to move the robot will stop and the current status will be returned

## Some design decissions

Given that the main methond will be managed if it will go in direction of console app or API service, 

```
http://localhost:5001/robot
```

## Solution
has two projects
----------------
Project | purpose 
--- | --- |
API|lightweight API layer
Application| contains the business logic 



## design pattern

- Factory
- Template Method








